using System;
using System.Threading;
using System.Threading.Tasks;
using ProcessRouting.Messaging;

namespace ProcessRouting.Services
{
    public class TimerService : ServiceBase
    {
        public TimerService() : base(MessageChannel.XTimerService)
        {
        }

        protected override void ReceiveMessage(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.SetNetPayDeadlineImminentTimer:
                    SendMessageInABit(MessageType.NetPayDeadlineImminentAlert).Start();
                    return;

                case MessageType.SetHmrcDeadlineImminentTimer:
                    SendMessageInABit(MessageType.HmrcDeadlineImminentAlert).Start();
                    return;

                case MessageType.SetFpsDeadlineImminentTimer:
                    SendMessageInABit(MessageType.FpsDeadlineImminentAlert).Start();
                    return;

                default:
                    return;
            }
        }

        private Task SendMessageInABit(MessageType messageType)
        {
            return new Task(() =>
            {
                Thread.Sleep(5000);
                MessageSender.Send(messageType);
            });
        }
    }
}