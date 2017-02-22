using System;
using System.Threading;
using ProcessRouting.Messaging;

namespace ProcessRouting.Services
{
    public class HmrcService : ServiceBase
    {
        public HmrcService() : base(MessageChannel.XHmrcBacsService)
        {
        }

        protected override void ReceiveMessage(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.RealiseHmrcBacs:
                    MessageSender.Send(MessageType.HmrcBacsRealised);
                    return;

                case MessageType.StartHmrcApprovalProcess:
                    Console.WriteLine("Approval Started");
                    MessageSender.Send(MessageType.HmrcBacsApprovalNeeded);
                    Console.ReadLine();
                    Console.WriteLine("Approved");
                    MessageSender.Send(MessageType.HmrcApprovalProcessCompleted);
                    return;

                default:
                    return;
            }
        }
    }
}