using System.Collections.Generic;
using System.Linq;
using ProcessRouting.ProcessManagment.StepRepositories;

namespace ProcessRouting.ProcessManagment
{
    public class ProcessDependencyGraph
    {
        private readonly IEnumerable<ProcessStep> _processSteps;

        private readonly IList<ProcessStep> _completionCondition;

        public ProcessDependencyGraph()
        {
            ProcessStep realiseAllDocuments = new RealiseAllDocumentsStepRepository().GetStep();
            DocumentApprovalStepsDto approvalSteps = new DocumentApprovalStepsRepository().GetSteps(realiseAllDocuments);
            NotificationStepsDto notificationSteps = new ProcessNotificationStepsRepository().GetSteps(approvalSteps.NetPay, approvalSteps.Hmrc, approvalSteps.Fps);
            ProcessStep sendAllDocuments = new SendAllDocumentsStepRepository().GetStep(approvalSteps.NetPay, approvalSteps.Hmrc, approvalSteps.Fps);

            _processSteps = new List<ProcessStep>
            {
                realiseAllDocuments,
                approvalSteps.NetPay,
                approvalSteps.Hmrc,
                approvalSteps.Fps,
                notificationSteps.NetPayDeadlineTimer,
                notificationSteps.HmrcDealineTimer,
                notificationSteps.FpsDeadlineTimer,
                notificationSteps.NotifyNetPayDeadline,
                notificationSteps.NotifyHmrcDeadline,
                notificationSteps.NotifyFpsDeadline,
                sendAllDocuments
            };

            _completionCondition = new List<ProcessStep> { sendAllDocuments };
        }

        public ProcessStep GetNextProcessStep(ProcessState processState)
        {
            ProcessStep nextProcessStep = _processSteps.FirstOrDefault(x => x.DependenciesAreSatisfied(processState));

            return nextProcessStep;
        }

        public bool IsComplete(ProcessState processState)
        {
            return _completionCondition.All(x => processState.CompletedProcessStep.Contains(x));
        }
    }
}