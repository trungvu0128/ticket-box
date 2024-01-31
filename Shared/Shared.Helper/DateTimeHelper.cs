using System.Globalization;

namespace Shared.Helper
{
    public static class DateTimeHelper
    {
        public static int GetWeekNumber(this DateTime dateInput)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            Calendar calendar = cultureInfo.Calendar;
            CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var week = calendar.GetWeekOfYear(dateInput, calendarWeekRule, firstDayOfWeek);
            return week;
        }
    }
}
