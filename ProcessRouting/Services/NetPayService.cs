using System;
using ProcessRouting.Messaging;

namespace ProcessRouting.Services
{
    public class NetPayService : ServiceBase
    {
        public NetPayService() : base(MessageChannel.XNetPayBacsService)
        {
        }

        protected override void ReceiveMessage(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.RealiseNetPayBacs:
                    MessageSender.Send(MessageType.NetPayBacsRealised);
                    return;

                case MessageType.StartNetPayApprovalProcess:
                    Console.WriteLine("Approval Started");
                    MessageSender.Send(MessageType.NetPayBacsApprovalNeeded);
                    Console.ReadLine();
                    Console.WriteLine("Approved");
                    MessageSender.Send(MessageType.NetPayApprovalProcessCompleted);
                    return;

                default:
                    return;
            }
        }
    }
}