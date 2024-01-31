using Serilog.Core;

namespace Shared.Tracking
{
    public class TrackingLog : ITrackingLog
    {
        private readonly Logger logger;
        public TrackingLog(Logger _logger)
        {
            logger = _logger;
        }
        public void LogApiReq(string? correlationID, object request)
        {
            logger.Information("[REQUEST] CorrelationID: {@CorrelationID} {@Message}", correlationID, request);
        }
        public void LogApiResponse(string correlationID, object response)
        {
            logger.Information("[RESPONSE] CorrelationID: {@CorrelationID} {@Message}", correlationID, response);
        }
        public void LogInfo(string message)
        {
            logger.Information("[PROCESS] {@Message}", message);
        }
        public void LogInfo(string correlationID, object message)
        {
            logger.Information("[PROCESS] CorrelationID: {@CorrelationID} {@Message}", correlationID, message);
        }
        public void LogInfo(string correlationID, string customText, object message)
        {
            logger.Information("[PROCESS] {@CustomText} CorrelationID: {@CorrelationID} {@Message}", customText, correlationID, message);
        }
        public void LogError(Exception ex)
        {
            logger.Error("[ERROR] Message: {@Message}-Source: {@Source}-StackTrace: {@StackTrace}", ex.Message, ex.Source, ex.StackTrace);
        }
        public void LogError(string correlationID, Exception ex)
        {
            logger.Error("[ERROR] CorrelationID: {@CorrelationID}-Message: {@Message}-Source: {@Source}-StackTrace: {@StackTrace}",
                correlationID, ex.Message, ex.Source, ex.StackTrace);
        }
        public void LogError(string correlationID, string customText, Exception ex)
        {
            logger.Error("[ERROR] {@CustomText} CorrelationID: {@CorrelationID}-Message: {@Message}-Source: {@Source}-StackTrace: {@StackTrace}",
                customText, correlationID, ex.Message, ex.Source, ex.StackTrace);
        }
        public void LogInfoMessageIn(string message)
        {
            logger.Information("[MESSAGE-IN] {@Message}", message);
        }
        public void LogInfoMessageIn(string correlationID, object message)
        {
            logger.Information("[MESSAGE-IN] CorrelationID: {@CorrelationID} {@Message}", correlationID, message);
        }
        public void LogInfoMessageIn(string correlationID, string customText, object message)
        {
            logger.Information("[MESSAGE-IN] {@CustomText} CorrelationID: {@CorrelationID} {@Message}", customText, correlationID, message);
        }
        public void LogInfoMessageOut(string message)
        {
            logger.Information("[MESSAGE-OUT] {@Message}", message);
        }
        public void LogInfoMessageOut(string correlationID, object message)
        {
            logger.Information("[MESSAGE-OUT] CorrelationID: {@CorrelationID} {@Message}", correlationID, message);
        }
        public void LogInfoMessageOut(string correlationID, string customText, object message)
        {
            logger.Information("[MESSAGE-OUT] {@CustomText} CorrelationID: {@CorrelationID} {@Message}", customText, correlationID, message);
        }
    }
}
