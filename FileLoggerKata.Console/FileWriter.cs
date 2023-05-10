namespace FileLoggerKata.Console;

public class FileWriter : IWriter
{
    private readonly string _filePath;

    public FileWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void Write(string message)
    {
        using (StreamWriter sw = File.AppendText(_filePath))
        {
            sw.WriteLine(message);
        }
    }
}
