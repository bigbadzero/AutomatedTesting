using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Console
{
    public interface IDateTimeHelper
    {
        bool IsWeekend();
        DateTime ExtractDateTimeFromLine(string line);
        bool IsCurrentWeekend(DateTime weekendDate);
        DateTime GetLastSaturdayDate(DateTime date);
    }
}
