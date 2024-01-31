namespace Shared.Helper
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {

        /// <summary>
        /// Get enum value
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumMember"></param>
        /// <returns>Value of enum</returns>
        public static int GetEnumValue<TEnum>(this TEnum enumMember) where TEnum : Enum
        {
            return Convert.ToInt32(enumMember);
        }
    }
}
