using System.Collections.Generic;
using ProcessRouting.Messaging;

namespace ProcessRouting.ProcessManagment.StepRepositories
{
    public class DocumentApprovalStepsRepository
    {
        public DocumentApprovalStepsDto GetSteps(ProcessStep realiseAllDocuments)
        {
            ProcessStep netPayApprovalProcess = new ProcessStep(
                "NetPayApprovalProcess",
                new List<MessageType> { MessageType.StartNetPayApprovalProcess },
                new List<MessageType> { MessageType.NetPayApprovalProcessCompleted },
                new ProcessStepDependencies
                {
                    RequiredSteps = new List<ProcessStep> { realiseAllDocuments }
                });

            ProcessStep hmrcApprovalProcess = new ProcessStep(
                "NetPayApprovalProcess",
                new List<MessageType> { MessageType.StartHmrcApprovalProcess },
                new List<MessageType> { MessageType.HmrcApprovalProcessCompleted },
                new ProcessStepDependencies
                {
                    RequiredSteps = new List<ProcessStep> { realiseAllDocuments }
                });

            ProcessStep fpsApprovalProcess = new ProcessStep(
                "NetPayApprovalProcess",
                new List<MessageType> { MessageType.StartFpsApprovalProcess },
                new List<MessageType> { MessageType.FpsApprovalProcessCompleted },
                new ProcessStepDependencies
                {
                    RequiredSteps = new List<ProcessStep> { realiseAllDocuments }
                });

            return new DocumentApprovalStepsDto
            {
                NetPay =  netPayApprovalProcess,
                Hmrc = hmrcApprovalProcess,
                Fps = fpsApprovalProcess
            };
        }
    }
}