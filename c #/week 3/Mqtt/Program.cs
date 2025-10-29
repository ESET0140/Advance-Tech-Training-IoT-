using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Text;
using System.Threading.Tasks;



namespace Mqtt
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            var factory = new MqttFactory();
            var client = factory.CreateManagedMqttClient();

            var client_option = new MqttClientOptionsBuilder()
            .WithTcpServer("Localhost", 1883)
            .Build();

            var managed_options = new ManagedMqttClientOptionsBuilder()
            .WithClientOptions(client_option)
            .Build();

            await client.StartAsync(managed_options);



            var message = new MqttApplicationMessageBuilder()
            .WithPayload("30 Degrees")
            .WithTopic("test/temperature")

            .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
            .WithRetainFlag(true)
            .Build();

            await client.EnqueueAsync(message);
            //await Task.Delay(1000);
        }
    }
}
