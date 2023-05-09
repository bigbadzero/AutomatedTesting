using FileLoggerKata.Console;
using Shouldly;

namespace FileLoggerKata.Tests;

public class FileLoggerTests
{
    [Fact]
    public void Log_LogsText_ToLogtxtFile()
    {
        var test = "test";
        var logDate = DateTime.Now.ToString("yyyyMMdd");
        string fileLocation = $"G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log{logDate}.txt";
        File.Delete(fileLocation);
        var logger = new FileLogger();

        logger.Log(test);
        var fileContents = File.ReadAllText(fileLocation);

        fileContents.ShouldNotBeEmpty();
    }

    [Fact]
    public void Log_Should_Prepend_Timestamp_To_Message_In_File()
    {
        var logDate = DateTime.Now.ToString("yyyyMMdd");
        string filePath = $"G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log{logDate}.txt";
        var logger = new FileLogger();
        File.Delete(filePath);

        logger.Log("Test message");
        var lines = File.ReadAllLines(filePath);

        var lastLine = lines[lines.Length - 1];
        var expectedPrefix = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        lastLine.ShouldStartWith(expectedPrefix);
    }

    [Fact]
    public void Log_ShouldCreateLogFile_WithCorrectNamingConvention()
    {
        var logDate = DateTime.Now.ToString("yyyyMMdd");
        string filePath = $"G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log{logDate}.txt";
        File.Delete(filePath);

        var logger = new FileLogger();
        logger.Log("Test message");
        var result = File.Exists(filePath);

        result.ShouldBeTrue();
    }
}
