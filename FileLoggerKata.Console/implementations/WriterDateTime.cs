using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Console.implementations
{
    public class WriterDateTime : IDateTime
    {
        public DateTime CurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
