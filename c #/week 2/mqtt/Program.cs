using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Text;
using System.Threading.Tasks;

namespace mqtt
{
    internal class Program
    {
        static async Task Main(string[] args)
        {s
            var factory = new MqttFactory();
            var client = factory.CreateManagedMqttClient();

            var client_option = new MqttClientOptionsBuilder()
            .WithClientId("Myhome")
            .WithTcpServer("Localhost", 1883)
            .Build();

            var managed_options = new ManagedMqttClientOptionsBuilder()
            .WithClientOptions(client_option)
            .Build();

            await client.StartAsync(managed_options);

            while (true)
            {
                string payload = GenerateRandomTemperature();

                var message = new MqttApplicationMessageBuilder()
                    .WithPayload(payload)
                    .WithTopic("test/temperature")
                    .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce)
                    .WithRetainFlag(true)
                    .Build();

                await client.EnqueueAsync(message);
                await Task.Delay(3000);
            }
        }


        static string GenerateRandomTemperature()
        {
            Random random = new Random();
            double temperature = random.NextDouble() * 10 + 30; // Random value between 30.0 and 40.0
            return $"{temperature:F1} Degree";
        }

    }
}
