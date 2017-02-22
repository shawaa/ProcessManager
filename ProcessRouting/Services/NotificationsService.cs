using System;
using ProcessRouting.Messaging;

namespace ProcessRouting.Services
{
    public class NotificationsService : ServiceBase
    {
        public NotificationsService() : base(MessageChannel.XNotificationsService)
        {
        }

        protected override void ReceiveMessage(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.NetPayDeadlineNotification:
                    Console.WriteLine("Net Pay Bacs Deadline Is Imminent");
                    return;

                case MessageType.HmrcDeadlineNotification:
                    Console.WriteLine("HMRC Bacs Deadline Is Imminent");
                    return;

                case MessageType.FpsDeadlineNotification:
                    Console.WriteLine("Fps Submission Deadline Is Imminent");
                    return;

                case MessageType.NetPayBacsApprovalNeeded:
                    Console.WriteLine("Approval Needed for Net Pay Bacs Submission");
                    return;

                case MessageType.HmrcBacsApprovalNeeded:
                    Console.WriteLine("Approval Needed for Hmrc Bacs Submission");
                    return;

                case MessageType.FpsSubmissionApprovalNeeded:
                    Console.WriteLine("Approval Needed for FPS Submission");
                    return;

                default:
                    return;
            }
        }
    }
}