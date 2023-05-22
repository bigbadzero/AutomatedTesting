using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Console
{
    public class PathSuffix : IPathSuffix
    {
        private readonly IDateTime _dateTime;
        private readonly IDateTimeHelper _dateTimeHelper;
        public PathSuffix(IDateTime dateTime, IDateTimeHelper dateTimeHelper)
        {
            _dateTime = dateTime;
            _dateTimeHelper = dateTimeHelper;

        }
        public string FilePathSuffix { get; set; } = "yyyyMMdd";

        public string FormatLastWeekendFileSuffix(string path, DateTime lastWeekend)
        {
            string fileName = Path.GetFileName(path);
            var fileNameWithoutExtension = Path.ChangeExtension(fileName, null);
            var formattedDate = lastWeekend.ToString(FilePathSuffix);
            var suffixedFileName = fileNameWithoutExtension + formattedDate + Path.GetExtension(path);
            return Path.Combine(Path.GetDirectoryName(path), suffixedFileName);
        }

        public string FormatLogFileWithSuffix(string path)
        {
            if (_dateTimeHelper.IsWeekend())
            {
                var directory = Path.GetDirectoryName(path);
                return Path.Combine(directory, "Weekend.txt");
            }
            else
            {
                string fileName = Path.GetFileName(path);
                var fileNameWithoutExtension = Path.ChangeExtension(fileName, null);
                var formattedDate = _dateTime.CurrentDateTime().ToString(FilePathSuffix);
                var suffixedFileName = fileNameWithoutExtension + formattedDate + Path.GetExtension(path);
                return Path.Combine(Path.GetDirectoryName(path), suffixedFileName);
            }
            
        }


    }
}
