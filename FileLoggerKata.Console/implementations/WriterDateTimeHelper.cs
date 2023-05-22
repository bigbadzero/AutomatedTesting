using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Console
{
    public class WriterDateTimeHelper : IDateTimeHelper
    {
        public readonly IDateTime _dateTime;
        public WriterDateTimeHelper(IDateTime dateTime)
        {

            _dateTime = dateTime;

        }

        public DateTime ExtractDateTimeFromLine(string line)
        {
            if (line != null && line.Length >= 19)
            {
                string datePart = line.Substring(0, 19);
                if (DateTime.TryParse(datePart, out DateTime date))
                    return date;
            }
            throw new ArgumentException("Invalid line format or unable to extract the date.");
        }

        public DateTime GetLastSaturdayDate(DateTime date)
        {
            int daysToSubtract = ((int)date.DayOfWeek - (int)DayOfWeek.Saturday - 1 + 7) % 7;
            return date.AddDays(-daysToSubtract);
        }

        public bool IsCurrentWeekend(DateTime weekendDate)
        {
            DayOfWeek currentDayOfWeek = _dateTime.CurrentDateTime().DayOfWeek;

            // Determine the start and end dates of the current weekend
            DateTime startOfWeekend = _dateTime.CurrentDateTime().AddDays(-(int)currentDayOfWeek);
            DateTime endOfWeekend = startOfWeekend.AddDays(1).AddSeconds(-1);

            // Check if the given date falls within the current weekend
            return weekendDate >= startOfWeekend && weekendDate <= endOfWeekend;
        }

        public bool IsWeekend()
        {
            return _dateTime.CurrentDateTime().DayOfWeek == DayOfWeek.Saturday || _dateTime.CurrentDateTime().DayOfWeek == DayOfWeek.Sunday;
            
        }
    }
}
