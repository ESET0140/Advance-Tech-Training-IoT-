using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt_returns
{
    internal class Program
    {
        private static IManagedMqttClient mqttClient;
        private static int messageCount = 0;
        private static bool isRunning = true;

        static async Task Main(string[] args)
        {
            var factory = new MQTTnet.MqttFactory();
            mqttClient = factory.CreateManagedMqttClient();

            // Create client options with authentication and will message configuration
            var clientOptions = new MqttClientOptionsBuilder()
                .WithClientId("Myhome_" + Guid.NewGuid().ToString()[..8]) // Unique client ID
                .WithTcpServer("localhost", 1883)
                .WithCleanSession(false)
                // ADDED: Authentication with username and password
                .WithCredentials("user1", "12345") // Username and password
                                                   // Configure will message - this will be published by broker if client disconnects unexpectedly
                .WithWillTopic("test/status")
                .WithWillPayload("Client disconnected unexpectedly")
                .WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .WithWillRetain(true)
                .Build();

            var managedOptions = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(clientOptions)
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(5)) // Auto-reconnect after 5 seconds
                .Build();

            // ==================== SUBSCRIBER FUNCTIONALITY ====================
            mqttClient.ApplicationMessageReceivedAsync += async e =>
            {
                Console.WriteLine($"[RECEIVED] {e.ApplicationMessage.Topic} -> {e.ApplicationMessage.ConvertPayloadToString()}");
            };

            // ==================== PUBLISHER FUNCTIONALITY ====================
            mqttClient.ConnectedAsync += async e =>
            {
                Console.WriteLine("[CONNECTED] Connected to MQTT broker with authentication");

                try
                {
                    // Subscribe to topics
                    await mqttClient.SubscribeAsync(new[]
                    {
                    new MqttTopicFilterBuilder()
                        .WithTopic("test/temperature")
                        .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce)
                        .Build(),
                    new MqttTopicFilterBuilder()
                        .WithTopic("test/status")
                        .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                        .Build()
                });

                    Console.WriteLine("[SUBSCRIBED] Subscribed to topics: test/temperature, test/status");

                    // Publish initial connected status
                    await PublishStatusMessage("Client connected and running with authentication");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Connection event error: {ex.Message}");
                }
            };

            mqttClient.DisconnectedAsync += async e =>
            {
                Console.WriteLine($"[DISCONNECTED] Disconnected from MQTT broker. Reason: {e.Reason}");
                if (e.Exception != null)
                {
                    Console.WriteLine($"[DISCONNECTED] Exception: {e.Exception.Message}");
                }
            };

            mqttClient.ConnectingFailedAsync += async e =>
            {
                Console.WriteLine($"[CONNECTION_FAILED] Failed to connect: {e.Exception.Message}");
                // Check if it's an authentication error
                if (e.Exception.Message.Contains("authentication", StringComparison.OrdinalIgnoreCase) ||
                    e.Exception.Message.Contains("not authorised", StringComparison.OrdinalIgnoreCase) ||
                    e.Exception.Message.Contains("username", StringComparison.OrdinalIgnoreCase) ||
                    e.Exception.Message.Contains("password", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("[AUTH_ERROR] Authentication failed. Check username/password and broker configuration.");
                }
            };

            try
            {
                Console.WriteLine("[STARTING] Starting MQTT client with authentication...");
                await mqttClient.StartAsync(managedOptions);
                Console.WriteLine("[STARTED] MQTT client started successfully with authentication");

                // Start publishing temperature data in background
                _ = Task.Run(async () => await PublishTemperatureData());

                // Keep the application running
                Console.WriteLine("[INFO] Press 'q' to exit...");
                while (isRunning)
                {
                    var key = Console.ReadKey(intercept: true);
                    if (key.KeyChar == 'q' || key.KeyChar == 'Q')
                    {
                        isRunning = false;
                    }
                }

                Console.WriteLine("[STOPPING] Stopping MQTT client...");
                await mqttClient.StopAsync();
                Console.WriteLine("[STOPPED] MQTT client stopped gracefully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to start MQTT client: {ex.Message}");
                // Check for authentication errors
                if (ex.Message.Contains("authentication", StringComparison.OrdinalIgnoreCase) ||
                    ex.Message.Contains("not authorised", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("[AUTH_ERROR] Authentication failed. Please verify:");
                    Console.WriteLine("[AUTH_ERROR] 1. Username: user1");
                    Console.WriteLine("[AUTH_ERROR] 2. Password: 12345");
                    Console.WriteLine("[AUTH_ERROR] 3. Mosquitto password file configuration");
                }
            }
        }

        // Method to continuously publish temperature data
        static async Task PublishTemperatureData()
        {
            while (isRunning)
            {
                try
                {
                    if (mqttClient.IsConnected)
                    {
                        messageCount++;
                        string payload = GenerateRandomTemperature();

                        var message = new MqttApplicationMessageBuilder()
                            .WithPayload(payload)
                            .WithTopic("test/temperature")
                            .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce)
                            .WithRetainFlag(false) // Changed to false to avoid retained message buildup
                            .Build();

                        await mqttClient.EnqueueAsync(message);
                        Console.WriteLine($"[PUBLISHED] Message #{messageCount} to test/temperature: {payload}");
                    }
                    else
                    {
                        Console.WriteLine("[WARNING] Client not connected, waiting for reconnection...");
                        // Wait longer when disconnected to avoid spamming
                        await Task.Delay(5000);
                        continue; // Skip the normal delay
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Failed to publish message: {ex.Message}");
                }

                await Task.Delay(3000);
            }
            Console.WriteLine("[INFO] Temperature publishing stopped");
        }

        // Method to publish status messages
        static async Task PublishStatusMessage(string status)
        {
            try
            {
                if (mqttClient.IsConnected)
                {
                    var statusMessage = new MqttApplicationMessageBuilder()
                        .WithTopic("test/status")
                        .WithPayload(status)
                        .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                        .WithRetainFlag(true)
                        .Build();

                    await mqttClient.EnqueueAsync(statusMessage);
                    Console.WriteLine($"[STATUS] Status published: {status}");
                }
                else
                {
                    Console.WriteLine($"[WARNING] Cannot publish status - client disconnected: {status}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to publish status: {ex.Message}");
            }
        }

        static string GenerateRandomTemperature()
        {
            Random random = new Random();
            double temperature = random.NextDouble() * 10 + 30; // Random value between 30.0 and 40.0
            return $"{temperature:F1}°C";
        }
    }
}