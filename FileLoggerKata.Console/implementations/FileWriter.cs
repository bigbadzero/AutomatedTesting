using System.IO;

namespace FileLoggerKata.Console;

public class FileWriter : IWriter
{
    private readonly IMessagePrefix _messagePrefix;
    private readonly IPathSuffix _pathSuffix;
    private readonly IDateTimeHelper _dateTimeHelper;
    public FileWriter(IMessagePrefix messagePrefix, IPathSuffix pathSuffix,  IDateTimeHelper dateTimeHelper)
    {
        _messagePrefix = messagePrefix;
        _pathSuffix = pathSuffix;
        _dateTimeHelper = dateTimeHelper;

    }

    public bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    public string GetLastLine(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        string lastLine = string.Empty;
        if (lines.Length > 0)
        {
            // Get the last line
            lastLine = lines[lines.Length - 1];
        }
        return lastLine;
    }

    public void MoveLastWeekendContent(string filePath, DateTime LastSaturdayDate)
    {
        var newPath = _pathSuffix.FormatLastWeekendFileSuffix(filePath, LastSaturdayDate);

        using (StreamReader reader = new StreamReader(filePath))
        using (StreamWriter writer = new StreamWriter(newPath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
            }
        }

        File.WriteAllText(filePath, string.Empty);
    }

    public void Write(string message, string filePath)
    {
        string formattedFilePath = _pathSuffix.FormatLogFileWithSuffix(filePath);
        if (FileExists(formattedFilePath))
            WriteToExistingFile(formattedFilePath, message);
        else
            WriteToNewFile(formattedFilePath, message);
    }

    private void WriteToExistingFile(string path, string message)
    {
        if (path == "G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\Weekend.txt")
        {
            var lastLine = GetLastLine(path);
            var lastLoggedDate = _dateTimeHelper.ExtractDateTimeFromLine(lastLine);
            var isCurrentWeekend = _dateTimeHelper.IsCurrentWeekend(lastLoggedDate);
            if (isCurrentWeekend)
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.Write(Environment.NewLine);
                    writer.Write(_messagePrefix.FormatMessageWithPrefix(message));
                }
            }
            else
            {
                MoveLastWeekendContent(path, lastLoggedDate);
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    writer.Write(_messagePrefix.FormatMessageWithPrefix(message).Trim());
                }
            }
        }
        else
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(Environment.NewLine);
                writer.Write(_messagePrefix.FormatMessageWithPrefix(message));
            }
        }
    }

    private void WriteToNewFile(string path, string message)
    {
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            writer.Write(_messagePrefix.FormatMessageWithPrefix(message));
        }
    }

}
