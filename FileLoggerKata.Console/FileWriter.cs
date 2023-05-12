namespace FileLoggerKata.Console;

public class FileWriter : IWriter
{
    public string FileMessageDatePrefixFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";
    public string FilePathDateSuffix { get; set; } = DateTime.Now.ToString("yyyyMMdd");

    public bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    public DateTime GetCreationDateTime(string filePath)
    {
        throw new NotImplementedException();
    }

    public void MoveWeekendFile(string oldPath, string newPath)
    {
        throw new NotImplementedException();
    }

    public string FormatMessageWithDatePrefix(string message)
    {
        var formattedDate = DateTime.Now.ToString(FileMessageDatePrefixFormat);
        var prefixedMessage = $"{formattedDate} {message}";
        return prefixedMessage ;
    }

    public string FormatLogFileWithDateSuffix(string path)
    {
        var suffixedFilePath = Path.ChangeExtension(path, null) + "_new" + Path.GetExtension(path);
        return suffixedFilePath ;
    }

    public void Write(string message, string filePath)
    {
        if (File.Exists(FormatLogFileWithDateSuffix(filePath)))
            File.AppendAllText(FormatLogFileWithDateSuffix(filePath), FormatMessageWithDatePrefix(message));
        else
        {
            File.Create(FormatLogFileWithDateSuffix(filePath));
            File.AppendAllText(FormatLogFileWithDateSuffix(filePath), FormatMessageWithDatePrefix(message));
        }
    }

    
}
