using System.Collections.Generic;

namespace ProcessRouting.ProcessManagment
{
    public class ProcessStepDependencies
    {
        public ProcessStepDependencies()
        {
            RequiredSteps = new List<ProcessStep>();
            ObseleteIfAnyCompletedSteps = new List<ProcessStep>();
        }

        public IEnumerable<ProcessStep> RequiredSteps { get; set; }

        public IEnumerable<ProcessStep> ObseleteIfAnyCompletedSteps { get; set; }
    }
}