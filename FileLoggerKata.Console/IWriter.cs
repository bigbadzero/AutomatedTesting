namespace FileLoggerKata.Console;

public interface IWriter
{
    void Write(string message, string filePath);
    bool FileExists(string filePath);
    DateTime GetCreationDateTime(string filePath);
    void MoveWeekendFile(string oldPath, string newPath);
}
