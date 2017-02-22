using System.Collections.Generic;

namespace ProcessRouting.Messaging
{
    public class MessageRoutingMap
    {
        private readonly Dictionary<MessageType, MessageChannel> _map;

        private static readonly MessageRoutingMap Instance = new MessageRoutingMap();

        public MessageRoutingMap()
        {
            _map = new Dictionary<MessageType, MessageChannel>
            {
                { MessageType.NetPayBacsRealised, MessageChannel.XProcessManager },
                { MessageType.HmrcBacsRealised, MessageChannel.XProcessManager },
                { MessageType.FpsRealised, MessageChannel.XProcessManager },
                { MessageType.EpsRealised, MessageChannel.XProcessManager },
                { MessageType.LedgerRealised, MessageChannel.XProcessManager },
                { MessageType.NetPayApprovalProcessCompleted, MessageChannel.XProcessManager },
                { MessageType.HmrcApprovalProcessCompleted, MessageChannel.XProcessManager },
                { MessageType.FpsApprovalProcessCompleted, MessageChannel.XProcessManager },
                { MessageType.StartPayrun, MessageChannel.XProcessManager },
                { MessageType.HmrcDeadlineImminentAlert, MessageChannel.XProcessManager },
                { MessageType.NetPayDeadlineImminentAlert, MessageChannel.XProcessManager },
                { MessageType.FpsDeadlineImminentAlert, MessageChannel.XProcessManager },

                { MessageType.RealiseNetPayBacs, MessageChannel.XNetPayBacsService },
                { MessageType.StartNetPayApprovalProcess, MessageChannel.XNetPayBacsService },
                { MessageType.SendNetPayBacs, MessageChannel.XNetPayBacsService },

                { MessageType.RealiseHmrcBacs, MessageChannel.XHmrcBacsService },
                { MessageType.StartHmrcApprovalProcess, MessageChannel.XHmrcBacsService },
                { MessageType.SendHmrcBacs, MessageChannel.XHmrcBacsService },

                { MessageType.RealiseFps, MessageChannel.XFpsService },
                { MessageType.StartFpsApprovalProcess, MessageChannel.XFpsService },
                { MessageType.SendFps, MessageChannel.XFpsService },

                { MessageType.RealiseEps, MessageChannel.XEpsService },
                { MessageType.SendEps, MessageChannel.XEpsService },

                { MessageType.RealiseLedger, MessageChannel.XLedgerService },
                { MessageType.SendLedger, MessageChannel.XLedgerService },

                { MessageType.SetNetPayDeadlineImminentTimer, MessageChannel.XTimerService},
                { MessageType.SetHmrcDeadlineImminentTimer, MessageChannel.XTimerService},
                { MessageType.SetFpsDeadlineImminentTimer, MessageChannel.XTimerService},

                { MessageType.HmrcDeadlineNotification, MessageChannel.XNotificationsService },
                { MessageType.NetPayDeadlineNotification, MessageChannel.XNotificationsService },
                { MessageType.FpsDeadlineNotification, MessageChannel.XNotificationsService },
                { MessageType.NetPayBacsApprovalNeeded, MessageChannel.XNotificationsService },
                { MessageType.HmrcBacsApprovalNeeded, MessageChannel.XNotificationsService },
                { MessageType.FpsSubmissionApprovalNeeded, MessageChannel.XNotificationsService }
            };
        }

        public static MessageChannel GetChannelForMessageType(MessageType messageType)
        {
            return Instance._map[messageType];
        }
    }
}