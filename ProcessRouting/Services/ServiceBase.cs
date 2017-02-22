using System;
using System.Text;
using System.Threading;
using ProcessRouting.Messaging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProcessRouting.Services
{
    public abstract class ServiceBase
    {
        private readonly ConnectionFactory _factory;

        private readonly EventingBasicConsumer _consumer;

        private readonly IConnection _connection;

        private readonly IModel _channel;

        protected ServiceBase(MessageChannel messageChannel)
        {
            Console.WriteLine(messageChannel);

            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(messageChannel.ToString(), false, false, false, null);

            _consumer = new EventingBasicConsumer(_channel);

            _consumer.Received += (model, ea) =>
            {
                Thread.Sleep(500);

                var body = Encoding.UTF8.GetString(ea.Body);

                MessageType messageType;
                Enum.TryParse(body, out messageType);

                Console.WriteLine("\t-> [x]    " + messageType);

                ReceiveMessage(messageType);
            };

            _channel.BasicConsume(messageChannel.ToString(), true, _consumer);
        }

        protected abstract void ReceiveMessage(MessageType messageType);
    }
}