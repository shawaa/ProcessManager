using System;
using System.Text;
using RabbitMQ.Client;
using System.Threading;

namespace ProcessRouting.Messaging
{
    public class MessageSender
    {
        private readonly ConnectionFactory _factory;

        private static readonly MessageSender Instance = new MessageSender();

        public MessageSender()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
        }

        public static void Send(MessageType messageType)
        {
            Thread.Sleep(300);
            Console.WriteLine("\t   [x] -> " + messageType);

            MessageChannel messageChannel = MessageRoutingMap.GetChannelForMessageType(messageType);

            using (var connection = Instance._factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(messageChannel.ToString(), false, false, false, null);

                string message = messageType.ToString();

                byte[] body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(
                    "",
                    messageChannel.ToString(),
                    null,
                    body);
            }
        }
    }
}