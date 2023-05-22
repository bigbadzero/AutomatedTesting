namespace FileLoggerKata.Console;

public interface IWriter
{
    void Write(string message, string filePath);
    bool FileExists(string filePath);
    string GetLastLine(string filePath);
    void MoveLastWeekendContent(string filePath, DateTime lastSaturdayDate);
}
