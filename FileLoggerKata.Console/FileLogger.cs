using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Console;

public class FileLogger
{
    private readonly string _logFolder;

    private IWriter _writer;

    public FileLogger(IWriter writer)
    {
        _logFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        _writer = writer;
    }

    public void Log(string message)
    {
        var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var log = $"{date} {message}";

        _writer.Write(log);
    }

    public void CheckAndCreateWeekendLog()
    {
        string fileName = "weekend.txt";
        var weekendLogPath = Path.Combine(_logFolder, fileName);

        if (File.Exists(weekendLogPath))
        {
            var creationTime = File.GetCreationTime(weekendLogPath);
            var saturday = GetLastSaturday(creationTime);
            if (DateTime.Now.Date > saturday.AddDays(7))
            {
                var newFileName = $"weekend-{saturday:yyyyMMdd}.txt";
                var newFilePath = Path.Combine(_logFolder, newFileName);

                if (File.Exists(newFilePath))
                {
                    File.Delete(newFilePath);
                }

                File.Move(weekendLogPath, newFilePath);
                _writer = new FileWriter(weekendLogPath);
            }
        }
        else
        {
            _writer = new FileWriter(weekendLogPath);
        }
    }

    private static DateTime GetLastSaturday(DateTime dateTime)
    {
        return dateTime.AddDays(-(int)dateTime.DayOfWeek);
    }
}
