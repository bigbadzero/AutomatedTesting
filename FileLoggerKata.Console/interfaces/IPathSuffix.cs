using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Console
{
    public interface IPathSuffix
    {
        public string FilePathSuffix { get; set; }
        string FormatLogFileWithSuffix(string path);
        string FormatLastWeekendFileSuffix(string path, DateTime lastWeekend);
    }
}
