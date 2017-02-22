using System;
using System.Linq;
using System.Text;
using System.Threading;
using ProcessRouting.Messaging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProcessRouting.ProcessManagment
{
    public class ProcessManager
    {
        private readonly ProcessDependencyGraph _processDependencyGraph;

        private readonly ProcessState _processState;

        private readonly ConnectionFactory _factory;

        private readonly EventingBasicConsumer _consumer;

        private readonly IConnection _connection;

        private readonly IModel _channel;

        public ProcessManager(ProcessDependencyGraph processDependencyGraph)
        {
            _processDependencyGraph = processDependencyGraph;
            _processState = new ProcessState();
            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(MessageChannel.XProcessManager.ToString(), false, false, false, null);

            _consumer = new EventingBasicConsumer(_channel);

            _consumer.Received += (model, ea) =>
            {
                var body = Encoding.UTF8.GetString(ea.Body);

                MessageType messageType;
                Enum.TryParse(body, out messageType);

                ReceiveMessage(messageType);
            };
        }

        public void StartMessageConsumer()
        {
            _channel.BasicConsume(MessageChannel.XProcessManager.ToString(), true, _consumer);
        }

        private void ReceiveMessage(MessageType messageType)
        {
            Console.WriteLine("\t-> [x]    " + messageType);

            _processState.ReceiveMessage(messageType);

            CompleteProcessSteps();

            StartAvailableProcessSteps();

            CompleteProcessSteps();

            if (_processDependencyGraph.IsComplete(_processState))
            {
                Console.WriteLine("==== Process Completed ====");
            }

            Thread.Sleep(100);
        }

        private void CompleteProcessSteps()
        {
            foreach (ProcessStep startedProcessStep in _processState.StartedProcessSteps.ToArray())
            {
                if (startedProcessStep.IsComplete(_processState))
                {
                    _processState.CompleteStep(startedProcessStep);
                    Console.WriteLine("Completed: " + startedProcessStep.Name);
                }
            }
        }

        private void StartAvailableProcessSteps()
        {
            while (true)
            {
                ProcessStep processStep = _processDependencyGraph.GetNextProcessStep(_processState);

                if (processStep == null)
                {
                    break;
                }

                Console.WriteLine("Started: " + processStep.Name);
                processStep.Start();
                _processState.ProcessStarted(processStep);
            }
        }
    }
}