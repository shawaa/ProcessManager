using ProcessRouting.Messaging;

namespace ProcessRouting.Services
{
    public class LedgerService : ServiceBase
    {
        public LedgerService() : base(MessageChannel.XLedgerService)
        {
        }

        protected override void ReceiveMessage(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.RealiseLedger:
                    MessageSender.Send(MessageType.LedgerRealised);
                    return;
                default:
                    return;
            }
        }
    }
}