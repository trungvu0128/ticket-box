namespace Project.Models.Constants
{
    public class ProcName
    {
        #region Cost center
        public const string AddCostCenter = "dbo.SP_IN_CostCenter";
        public const string UpdateCostCenter = "dbo.SP_UP_CostCenter";
        public const string DeleteCostCenter = "dbo.SP_DE_CostCenter";
        public const string GetAllCostCenter = "dbo.SP_GA_CostCenter";
        public const string GetDetailCostCenter = "dbo.SP_GD_CostCenter";
        #endregion

        #region Position
        public const string GetDetailPosition = "dbo.SP_GD_Position";
        #endregion
    }
}
