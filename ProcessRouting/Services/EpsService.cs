using ProcessRouting.Messaging;

namespace ProcessRouting.Services
{
    public class EpsService : ServiceBase
    {
        public EpsService() : base(MessageChannel.XEpsService)
        {
        }

        protected override void ReceiveMessage(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.RealiseEps:
                    MessageSender.Send(MessageType.EpsRealised);
                    return;

                default:
                    return;
            }
        }
    }
}