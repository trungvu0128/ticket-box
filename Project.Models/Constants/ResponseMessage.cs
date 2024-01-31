using Project.Core.Constants;

namespace Project.Models.Constants
{
    public class ResponseMessage : BaseResponseMessage
    {
        #region error code
        public const string COST_CENTER_NAME_REQUIRED = "cost_center_name_required";
        public static string NOTE_REQUIRED = "note_required";
        public static string SAP_DESC_REQUIRED = "sap_desc_required";
        public static string SAP_NAME_REQUIRED = "sap_name_required";
        public static string POSITION_ID_NOT_FOUND = "position_id_not_found";
        #endregion
    }
}
