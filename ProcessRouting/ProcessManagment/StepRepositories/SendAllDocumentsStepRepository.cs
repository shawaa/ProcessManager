using System.Collections.Generic;
using ProcessRouting.Messaging;

namespace ProcessRouting.ProcessManagment.StepRepositories
{
    public class SendAllDocumentsStepRepository
    {
        public ProcessStep GetStep(ProcessStep netPayApprovalStep, ProcessStep hmrcApprovalStep, ProcessStep fpsApprovalStep)
        {
            ProcessStep sendAllDocuments = new ProcessStep(
                "Send All Documents",
                new List<MessageType>
                {
                    MessageType.SendNetPayBacs,
                    MessageType.SendHmrcBacs,
                    MessageType.SendFps,
                    MessageType.SendEps,
                    MessageType.SendLedger
                },
                new List<MessageType>(),
                new ProcessStepDependencies
                {
                    RequiredSteps = new List<ProcessStep> { netPayApprovalStep, hmrcApprovalStep, fpsApprovalStep }
                });
            return sendAllDocuments;
        }
    }
}