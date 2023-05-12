using FileLoggerKata.Console;
using Shouldly;
using Moq.AutoMock;
using Moq;

namespace FileLoggerKata.Tests;

//these tests should test the IWriter interface
public class IWriterTests
{
    [Theory]
    [InlineData("G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log.txt")]
    public void IWriter_ReturnsTrue_IfFileExists(string path)
    {
        if(!File.Exists(path))
            File.Create(path);
        var mocker = new AutoMocker();
        var mockWriter = new Mock<IWriter>();
        mockWriter.Setup(x => x.FileExists(path)).Returns(() =>
        {
            return File.Exists(path);
        });
        mocker.Use(mockWriter.Object);
        var fileLogger = mocker.CreateInstance<FileWriter>();
        
        var result = fileLogger.FileExists(path);
        
        result.ShouldBeTrue();
    }

    [Theory]
    [InlineData("G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log.txt")]
    public void IWriter_ReturnsFalse_IfFileDoesNotExist(string path)
    {
        if (File.Exists(path))
            File.Delete(path);

        var mocker = new AutoMocker();
        var mockWriter = new Mock<IWriter>();
        mockWriter.Setup(x => x.FileExists(path)).Returns(() =>
        {
            return File.Exists(path);
        });
        mocker.Use(mockWriter.Object);
        var fileLogger = mocker.CreateInstance<FileWriter>();
        
        var result = fileLogger.FileExists(path);
        
        result.ShouldBeFalse();
    }

    [Theory]
    [InlineData("yyyy-MM-dd HH:mm:ss")]
    public void IWriter_FormatMessageWithDatePrefix_ReturnsMessageWithDateFormatPrefixed(string prefixFormat)
    {
        var mocker = new AutoMocker();
        var mockWriter = new Mock<IWriter>();
        var message = "test";
        mockWriter.Setup(x => x.FileMessageDatePrefixFormat).Returns(prefixFormat);
        mockWriter.Setup(x => x.FormatMessageWithDatePrefix(message)).Returns(() =>
        {
            var formattedDate = DateTime.Now.ToString(mockWriter.Object.FileMessageDatePrefixFormat);
            var prefixedMessage = $"{formattedDate} {message}";
            return prefixedMessage;
        });

        mocker.Use(mockWriter.Object);

        var writer = mocker.CreateInstance<FileWriter>();
        var result = writer.FormatMessageWithDatePrefix(message);
        result.ShouldBeEquivalentTo($"{DateTime.Now.ToString(prefixFormat)} {message}");
    }
}
