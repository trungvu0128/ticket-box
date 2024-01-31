namespace Shared.Tracking
{
    public interface ITrackingLog
    {
        void LogApiReq(string? correlationID, object request);
        void LogApiResponse(string correlationID, object response);
        void LogInfo(string message);
        void LogInfo(string correlationID, string customText, object message);
        void LogInfo(string correlationID, object message);
        void LogError(Exception ex);
        void LogError(string correlationID, string customText, Exception ex);
        void LogError(string correlationID, Exception ex);
        void LogInfoMessageIn(string message);
        void LogInfoMessageIn(string correlationID, string customText, object message);
        void LogInfoMessageIn(string correlationID, object message);
        void LogInfoMessageOut(string message);
        void LogInfoMessageOut(string correlationID, string customText, object message);
        void LogInfoMessageOut(string correlationID, object message);
    }
}