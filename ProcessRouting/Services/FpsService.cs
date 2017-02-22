using System;
using System.Threading;
using ProcessRouting.Messaging;

namespace ProcessRouting.Services
{
    public class FpsService : ServiceBase
    {
        public FpsService() : base(MessageChannel.XFpsService)
        {
        }

        protected override void ReceiveMessage(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.RealiseFps:
                    MessageSender.Send(MessageType.FpsRealised);
                    return;

                case MessageType.StartFpsApprovalProcess:
                    Console.WriteLine("Approval Started");
                    MessageSender.Send(MessageType.FpsSubmissionApprovalNeeded);
                    Console.ReadLine();
                    Console.WriteLine("Approved");
                    MessageSender.Send(MessageType.FpsApprovalProcessCompleted);
                    return;

                default:
                    return;
            }
        }
    }
}