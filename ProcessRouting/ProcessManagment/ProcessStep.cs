using System.Collections.Generic;
using System.Linq;
using ProcessRouting.Messaging;

namespace ProcessRouting.ProcessManagment
{
    public class ProcessStep
    {
        private readonly IEnumerable<MessageType> _messagesToSend;

        private readonly IEnumerable<MessageType> _messagesNeededForCompletion;

        private readonly ProcessStepDependencies _processStepDependencies;

        public ProcessStep(string name, IEnumerable<MessageType> messagesToSend, IEnumerable<MessageType> messagesNeededForCompletion, ProcessStepDependencies processStepDependencies)
        {
            _messagesToSend = messagesToSend;
            _messagesNeededForCompletion = messagesNeededForCompletion;
            _processStepDependencies = processStepDependencies;
            Name = name;
        }

        public string Name { get; }

        public void Start()
        {
            foreach (MessageType messageType in _messagesToSend)
            {
                MessageSender.Send(messageType);
            }
        }

        public bool IsComplete(ProcessState processState)
        {
            return !_messagesNeededForCompletion.Any() || _messagesNeededForCompletion.All(x => processState.ReceivedMessages.Contains(x));
        }

        public bool DependenciesAreSatisfied(ProcessState processState)
        {
            if (processState.CompletedProcessStep.Contains(this) || processState.StartedProcessSteps.Contains(this))
            {
                return false;
            }

            bool dependenciesAreSatisfied = _processStepDependencies
                .RequiredSteps
                .All(dependencies 
                    => processState.CompletedProcessStep.Contains(dependencies));

            bool stepIsNotObselete = !_processStepDependencies
                .ObseleteIfAnyCompletedSteps
                .Any(obseletingStep 
                    => processState.CompletedProcessStep.Contains(obseletingStep));

            return dependenciesAreSatisfied && stepIsNotObselete;
        }
    }
}