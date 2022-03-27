using DateDifference;
using System;

namespace DateDifferenceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fromDate = new DateTime(2017, 11, 13);
            var toDate = DateTime.Today;

            var (years, months, days) = fromDate.GetDateDifference(toDate);
            Console.WriteLine($"{years} years, {months} months, {days} days");
        }
    }
}
