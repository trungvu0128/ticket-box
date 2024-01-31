namespace Project.Core.Constants
{
    public class BaseResponseMessage
    {
        #region validate message
        public const string ID_NOT_FOUND = "id_not_found";
        #endregion

        #region base content response 
        public const string STATUS_CODE = "statusCode";
        public const string MESSAGE = "message";
        public const string ERROR_MESSAGES = "errorMessages";
        public const string DISPLAY_MESSAGE = "displayMessage";
        public const string EXCEPTION = "exception";
        public const string DATA = "data";
        public const string EXECUTION_TIME = "executionTime";
        public const string ERRORS = "errors";
        #endregion

        #region other
        public const string INTERNAL_SERVER_ERROR = "InternalServerError";
        public const string BAD_REQUEST = "BadRequest";
        public const string SUCCESS = "Success";
        public const string JSON_CONTENT_TYPE = "application/json";
        #endregion
    }
}
