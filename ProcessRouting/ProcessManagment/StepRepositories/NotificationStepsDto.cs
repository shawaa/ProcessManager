namespace ProcessRouting.ProcessManagment.StepRepositories
{
    public class NotificationStepsDto
    {
        public ProcessStep HmrcDealineTimer { get; set; }

        public ProcessStep NetPayDeadlineTimer { get; set; }

        public ProcessStep FpsDeadlineTimer { get; set; }

        public ProcessStep NotifyFpsDeadline { get; set; }

        public ProcessStep NotifyHmrcDeadline { get; set; }

        public ProcessStep NotifyNetPayDeadline { get; set; }
    }
}