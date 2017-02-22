using System.Collections.Generic;
using ProcessRouting.Messaging;

namespace ProcessRouting.ProcessManagment.StepRepositories
{
    public class RealiseAllDocumentsStepRepository
    {
        public ProcessStep GetStep()
        {
            ProcessStep realiseAllDocuments = new ProcessStep(
                "Realise All Documents",
                new List<MessageType>
                {
                    MessageType.RealiseNetPayBacs,
                    MessageType.RealiseHmrcBacs,
                    MessageType.RealiseFps,
                    MessageType.RealiseEps,
                    MessageType.RealiseLedger
                },
                new List<MessageType>
                {
                    MessageType.NetPayBacsRealised,
                    MessageType.HmrcBacsRealised,
                    MessageType.FpsRealised,
                    MessageType.EpsRealised,
                    MessageType.LedgerRealised,
                },
                new ProcessStepDependencies());
            return realiseAllDocuments;
        }
    }
}