using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt_returns
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new MqttFactory();
            var mqttClient = factory.CreateManagedMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1883)
                .WithCleanSession(false)
                .Build();

            var managedOptions = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(options)
                .Build();

            mqttClient.ApplicationMessageReceivedAsync += async e =>
            {
                Console.WriteLine($"Received: {e.ApplicationMessage.Topic} -> {e.ApplicationMessage.ConvertPayloadToString()}");
            };

            await mqttClient.StartAsync(managedOptions);

            await mqttClient.SubscribeAsync(new[]
            {
           new MqttTopicFilterBuilder()
           .WithTopic("test/temperature")
           .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce)
           .Build(),

        });
            while (true) ;



        }
    }
}
