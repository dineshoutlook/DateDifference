using System;

namespace DateDifference
{
    public static class DateDifferenceExtensions
    {
        /// <summary>
        /// Gets the differenece between two dates in years, months and days.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="includeEndDay">if set to <c>true</c> [include end day].</param>
        /// <returns></returns>
        public static (int years, int months, int days) GetDateDifference(this DateTime fromDate, DateTime toDate, bool includeEndDay = false)
        {
            (fromDate, toDate) = ((fromDate > toDate) ? (toDate, fromDate) : (fromDate, toDate));

            var days = toDate.Day - fromDate.Day + (includeEndDay ? 1 : 0);
            var months = toDate.Month - fromDate.Month;
            var years = toDate.Year - fromDate.Year;

            // If days are -ve then borrow no of days from last month.
            if (days < 0)
            {
                // If its January then borrow no of days from last year December.
                if (toDate.Month == 1)
                    days = days + DateTime.DaysInMonth(toDate.Year - 1, 12);
                else // If its not January then borrow days from last month of current year.
                    days = days + DateTime.DaysInMonth(toDate.Year, toDate.Month);

                months = months - 1;
            }

            // If months are -ve then borrow 12 months from years.
            if (months < 0)
            {
                months = months + 12;
                years = years - 1;
            }

            return (years, months, days);
        }
    }
}
