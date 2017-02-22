namespace ProcessRouting.Messaging
{
    public enum MessageType
    {
        StartPayrun,

        RealiseNetPayBacs,
        RealiseHmrcBacs,
        RealiseFps,
        RealiseEps,
        RealiseLedger,

        NetPayBacsRealised,
        HmrcBacsRealised,
        FpsRealised,
        EpsRealised,
        LedgerRealised,

        SetHmrcDeadlineImminentTimer,
        SetNetPayDeadlineImminentTimer,
        SetFpsDeadlineImminentTimer,

        HmrcDeadlineImminentAlert,
        NetPayDeadlineImminentAlert,
        FpsDeadlineImminentAlert,

        HmrcDeadlineNotification,
        NetPayDeadlineNotification,
        FpsDeadlineNotification,

        StartNetPayApprovalProcess,
        StartHmrcApprovalProcess,
        StartFpsApprovalProcess,

        NetPayApprovalProcessCompleted,
        HmrcApprovalProcessCompleted,
        FpsApprovalProcessCompleted,

        SendNetPayBacs,
        SendHmrcBacs,
        SendFps,
        SendEps,
        SendLedger,

        FpsSubmissionApprovalNeeded,
        HmrcBacsApprovalNeeded,
        NetPayBacsApprovalNeeded
    }
}