using FileLoggerKata.Console;
using Shouldly;
using Moq.AutoMock;
using Moq;

namespace FileLoggerKata.Tests;

public class FileLoggerTests
{
    [Fact]
    public void IWriter_ReturnsTrue_IfFileExists()
    {
        var mocker = new AutoMocker();
        var mockWriter = new Mock<IWriter>();
        mocker.Use(mockWriter.Object);
        var writer = mocker.CreateInstance<FileWriter>();
        if (!File.Exists("log.txt"))
            File.Create("log.txt");

        var result = writer.FileExists("log.txt");

        result.ShouldBeTrue();

    }

    [Fact]
    public void IWriter_ReturnsFalse_IfFileDoesNotExist()
    {
        var mocker = new AutoMocker();
        var mockWriter = new Mock<IWriter>();
        mocker.Use(mockWriter.Object);
        var writer = mocker.CreateInstance<FileWriter>();
        if (File.Exists("log.txt"))
            File.Delete("log.txt");

        var result = writer.FileExists("log.txt");

        result.ShouldBeFalse();

    }
}
