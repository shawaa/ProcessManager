using System;
using ProcessRouting.Messaging;
using ProcessRouting.ProcessManagment;

namespace ProcessRouting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Any key to start");
            Console.ReadLine();

            ProcessDependencyGraph processDependencyGraph = new ProcessDependencyGraph();
            ProcessManager processManager = new ProcessManager(processDependencyGraph);
            processManager.StartMessageConsumer();

            MessageSender.Send(MessageType.StartPayrun);

            Console.Read();
        }
    }
}
