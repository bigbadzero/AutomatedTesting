﻿using FileLoggerKata.Console;
using FileLoggerKata.Console.implementations;
using FileLoggerKata.Tests.Mocks.IMessagePrefixMocks;
using FileLoggerKata.Tests.Mocks.IPathSuffixMocks;
using Moq;
using Shouldly;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
namespace FileLoggerKata.Tests;
public class LoggerTests
{
    private readonly FileLoggerHelpers LoggerHelper = new FileLoggerHelpers();
    public LoggerTests()
    {
        LoggerHelper.DeleteAllTxtFiles();
    }

    [Fact]
    public void FileLogger_AppendsMessageTo_LogFile()
    {
        var path = "G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log.txt";
        var message = "test";
        var mockIPathSuffix = IgnorePathSuffix.GetIgnorePathSuffix(path);
        var mockIMessagePrefix = IgnoreMessagePrefix.GetIgnoreMessagePrefixMock(message);
        var IDateTime = new WriterDateTime();
        var IDateTimeHelper = new WriterDateTimeHelper(IDateTime);
        var writer = new FileWriter(mockIMessagePrefix, mockIPathSuffix, IDateTimeHelper);
        var logger = new FileLogger(writer, path);

        logger.Log(message);

        LoggerHelper.IsTextOnLastLine(path, message).ShouldBeTrue();
    }

    [Fact]
    public void FileLogger_Creates_LogFile()
    {
        var path = "G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log.txt";
        var message = "test";
        var mockIPathSuffix = IgnorePathSuffix.GetIgnorePathSuffix(path);
        var mockIMessagePrefix = IgnoreMessagePrefix.GetIgnoreMessagePrefixMock(message);
        var IDateTime = new WriterDateTime();
        var IDateTimeHelper = new WriterDateTimeHelper(IDateTime);
        var writer = new FileWriter(mockIMessagePrefix, mockIPathSuffix, IDateTimeHelper);
        var logger = new FileLogger(writer, path);

        logger.Log(message);

        File.Exists(path).ShouldBeTrue();
    }

    [Fact]
    public void FileLogger_LogsToExistingFile_IfFileExists()
    {
        var path = "G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log.txt";
        var message = "test";
        LoggerHelper.CreateFileIfDoesntExist(path);
        var mockIPathSuffix = IgnorePathSuffix.GetIgnorePathSuffix(path);
        var mockIMessagePrefix = IgnoreMessagePrefix.GetIgnoreMessagePrefixMock(message);
        var IDateTime = new WriterDateTime();
        var IDateTimeHelper = new WriterDateTimeHelper(IDateTime);
        var writer = new FileWriter(mockIMessagePrefix, mockIPathSuffix, IDateTimeHelper);
        var logger = new FileLogger(writer, path);

        logger.Log(message);

        LoggerHelper.IsTextOnLastLine(path, message).ShouldBeTrue();
    }

    [Fact]
    public void FileLogger_LogsMessageWith_RequiredPrefix()
    {
        var path = "G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log.txt";
        var message = "test";
        var mockIPathSuffix = IgnorePathSuffix.GetIgnorePathSuffix(path);
        var mockIDateTime = new Mock<IDateTime>();
        mockIDateTime.Setup(x => x.CurrentDateTime()).Returns(new DateTime(2023, 5, 22));
        var IDateTimeHelper = new WriterDateTimeHelper(mockIDateTime.Object);
        var IMessagePrefix = new MessagePrefix(mockIDateTime.Object);
        var writer = new FileWriter(IMessagePrefix, mockIPathSuffix, IDateTimeHelper);
        var logger = new FileLogger(writer, path);

        logger.Log(message);

        var result = LoggerHelper.GetLastLine(path);
        result.ShouldMatch(@"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\s.+", result);
    }

    [Fact]
    public void FileLogger_CreatesFileWith_RequiredSuffix()
    {
        var path = "G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log.txt";
        var message = "test";
        var mockIDateTime = new Mock<IDateTime>();
        mockIDateTime.Setup(x => x.CurrentDateTime()).Returns(new DateTime(2023, 5, 22));
        var mockIDateTimeHelper = new Mock<IDateTimeHelper>();
        mockIDateTimeHelper.Setup(x => x.IsWeekend()).Returns(false);
        var IPathSuffix = new PathSuffix(mockIDateTime.Object, mockIDateTimeHelper.Object);
        var MockIMessagePrefix = IgnoreMessagePrefix.GetIgnoreMessagePrefixMock(message);
        var writer = new FileWriter(MockIMessagePrefix, IPathSuffix, mockIDateTimeHelper.Object);
        var logger = new FileLogger(writer, path);
        var expectedSuffixFormat = mockIDateTime.Object.CurrentDateTime().ToString("yyyyMMdd"); ;
        var expectedPath = $"G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log{expectedSuffixFormat}.txt";

        logger.Log(message);

        File.Exists(expectedPath).ShouldBeTrue();
    }


    [Theory]
    [InlineData(2023, 5, 22)]
    [InlineData(2023, 5, 23)]
    [InlineData(2023, 5, 24)]
    [InlineData(2023, 5, 25)]
    [InlineData(2023, 5, 26)]
    public void FileLogger_CreatesFile_ForeachNewDay(int year, int month, int day)
    {
        var mockIDateTime = new Mock<IDateTime>();
        mockIDateTime.Setup(x => x.CurrentDateTime()).Returns(new DateTime(year, month, day));
        var writerDateTimeHelper = new WriterDateTimeHelper(mockIDateTime.Object);
        var path = "G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log.txt";
        var message = "test";
        var IPathSuffix = new PathSuffix(mockIDateTime.Object, writerDateTimeHelper);
        var MockIMessagePrefix = IgnoreMessagePrefix.GetIgnoreMessagePrefixMock(message);
        var writer = new FileWriter(MockIMessagePrefix, IPathSuffix, writerDateTimeHelper);
        var logger = new FileLogger(writer, path);
        var expectedSuffixFormat = mockIDateTime.Object.CurrentDateTime().ToString("yyyyMMdd"); ;
        var expectedPath = $"G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log{expectedSuffixFormat}.txt";

        logger.Log(message);

        File.Exists(expectedPath).ShouldBeTrue();

    }

    [Theory]
    [InlineData(2023, 5, 21)]
    public void FileLogger_CreatesWeekendFile_IfCurrentDateIsWeekend(int year, int month, int day)
    {
        var path = "G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log.txt";
        var message = "test";
        var mockIDateTime = new Mock<IDateTime>();
        mockIDateTime.Setup(x => x.CurrentDateTime()).Returns(new DateTime(year, month, day));
        var writerDateTimeHelper = new WriterDateTimeHelper(mockIDateTime.Object);
        var writer = new FileWriter(new MessagePrefix(mockIDateTime.Object), new PathSuffix(mockIDateTime.Object, writerDateTimeHelper), writerDateTimeHelper);
        var logger = new FileLogger(writer, path);

        logger.Log(message);

        File.Exists("G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\Weekend.txt");
    }

    [Fact]
    public void Logger_MovesOldWeekendFileContent_ToWeekendFileWithDate()
    {
        LoggerHelper.WriteToWeekendFile(new DateTime(2023, 5, 20));
        var oldWeekendFileContent = LoggerHelper.FileContent("G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\Weekend.txt");
        LoggerHelper.WriteToWeekendFile(new DateTime(2023, 5, 27));
        var newWeekendFileContent = LoggerHelper.FileContent("G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\Weekend20230520.txt");

        oldWeekendFileContent.ShouldBe(newWeekendFileContent.TrimEnd());
    }
}

