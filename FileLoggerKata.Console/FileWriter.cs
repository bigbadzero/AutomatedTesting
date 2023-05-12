namespace FileLoggerKata.Console;

public class FileWriter : IWriter
{
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

    public void Write(string message, string filePath)
    {
        throw new NotImplementedException();
    }
}
