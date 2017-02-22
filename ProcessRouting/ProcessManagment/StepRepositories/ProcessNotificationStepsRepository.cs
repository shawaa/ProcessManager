using System.Collections.Generic;
using ProcessRouting.Messaging;

namespace ProcessRouting.ProcessManagment.StepRepositories
{
    public class ProcessNotificationStepsRepository
    {
        public NotificationStepsDto GetSteps(
            ProcessStep netPayApprovalProcess, 
            ProcessStep hmrcApprovalProcess,
            ProcessStep fpsApprovalProcess)
        {
            ProcessStep hmrcDeadlineTimer = new ProcessStep(
                "Set Hmrc Deadline Timer",
                new List<MessageType> { MessageType.SetHmrcDeadlineImminentTimer },
                new List<MessageType> { MessageType.HmrcDeadlineImminentAlert },
                new ProcessStepDependencies());

            ProcessStep netPayDeadlineTimer = new ProcessStep(
                "Set Net Pay Deadline Timer",
                new List<MessageType> { MessageType.SetNetPayDeadlineImminentTimer },
                new List<MessageType> { MessageType.NetPayDeadlineImminentAlert },
                new ProcessStepDependencies());

            ProcessStep fpsDeadlineTimer = new ProcessStep(
                "Set Fps Deadline Timer",
                new List<MessageType> { MessageType.SetFpsDeadlineImminentTimer },
                new List<MessageType> { MessageType.FpsDeadlineImminentAlert },
                new ProcessStepDependencies());

            ProcessStep notifyNetPayDeadline = new ProcessStep(
                "Notify Hmrc Deadline",
                new List<MessageType> { MessageType.NetPayDeadlineNotification },
                new List<MessageType>(),
                new ProcessStepDependencies
                {
                    RequiredSteps = new List<ProcessStep> { netPayDeadlineTimer },
                    ObseleteIfAnyCompletedSteps = new List<ProcessStep> { netPayApprovalProcess }
                });

            ProcessStep notifyFpsDeadline = new ProcessStep(
                "Notify Hmrc Deadline",
                new List<MessageType> { MessageType.FpsDeadlineNotification },
                new List<MessageType>(),
                new ProcessStepDependencies
                {
                    RequiredSteps = new List<ProcessStep> { fpsDeadlineTimer },
                    ObseleteIfAnyCompletedSteps = new List<ProcessStep> { fpsApprovalProcess }
                });

            ProcessStep notifyHmrcDeadline = new ProcessStep(
                "Notify Hmrc Deadline",
                new List<MessageType> { MessageType.HmrcDeadlineNotification },
                new List<MessageType>(),
                new ProcessStepDependencies
                {
                    RequiredSteps = new List<ProcessStep> { hmrcDeadlineTimer },
                    ObseleteIfAnyCompletedSteps = new List<ProcessStep> { hmrcApprovalProcess }
                });

            return new NotificationStepsDto
            {
                NetPayDeadlineTimer = netPayDeadlineTimer,
                HmrcDealineTimer = hmrcDeadlineTimer,
                FpsDeadlineTimer = fpsDeadlineTimer,
                NotifyNetPayDeadline = notifyNetPayDeadline,
                NotifyHmrcDeadline = notifyHmrcDeadline,
                NotifyFpsDeadline = notifyFpsDeadline
            };
        }
    }
}