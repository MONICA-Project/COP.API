using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MQTTnet;

namespace COP.API.MQTT
{
    public class SendMQTTMessage
    {
        public bool sendMqttMessage(string topic, string payload)
        {
            bool retVal = false;
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();
            var options = new MQTTnet.Client.MqttClientOptionsBuilder()
                    .WithClientId(System.Guid.NewGuid().ToString())
                    .WithCommunicationTimeout(TimeSpan.FromSeconds(50))
                    //.WithCredentials("sm_user", "hemligt")
                    .WithTcpServer("192.168.229.101")
                    .Build();

            mqttClient.ConnectAsync(options).Wait();
            var message = new MQTTnet.MqttApplicationMessageBuilder()
        .WithTopic(topic)
        .WithPayload(payload)
        .WithAtLeastOnceQoS()
        .Build();
            List<MQTTnet.MqttApplicationMessage> mess = new List<MQTTnet.MqttApplicationMessage>();
            mess.Add(message);
            mqttClient.PublishAsync(mess);
            mqttClient.DisconnectAsync();
            return retVal;

        }
    }
}
