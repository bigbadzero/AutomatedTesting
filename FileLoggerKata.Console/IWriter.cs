namespace FileLoggerKata.Console;

public interface IWriter
{
    public string FileMessageDatePrefixFormat { get; set; }
    public string FilePathDateSuffix { get; set; }
    void Write(string message, string filePath);
    bool FileExists(string filePath);
    DateTime GetCreationDateTime(string filePath);
    string FormatMessageWithDatePrefix(string message);
    string FormatLogFileWithDateSuffix(string path);
}
