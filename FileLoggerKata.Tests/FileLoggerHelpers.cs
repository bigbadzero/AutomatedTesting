using FileLoggerKata.Console;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Tests
{
    public class FileLoggerHelpers
    {
        public void CreateFileIfDoesntExist(string path)
        {
            if (!File.Exists(path))
            {
                using (FileStream fileStream = File.Create(path))
                {
                    //create file
                }
            }
        }

        public bool IsTextOnLastLine(string filePath, string text)
        {
            string fileContents = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(fileContents))
                return true;

            string[] lines = fileContents.Split('\n');
            string lastLine = lines.LastOrDefault()?.Trim();

            if (lastLine == null)
                return false;

            return lastLine.Contains(text);
        }

        public string GetLastLine(string filePath)
        {
            string fileContents = File.ReadAllText(filePath);
            string[] lines = fileContents.Split('\n');
            string lastLine = lines.LastOrDefault()?.Trim();
            return lastLine;
        }

        public void DeleteAllTxtFiles()
        {
            var directoryPath = "G:\\projects\\AutomatedTesting\\FileLoggerKata.Console";
            string[] txtFiles = Directory.GetFiles(directoryPath, "*.txt");
            foreach (string txtFile in txtFiles)
            {
                File.Delete(txtFile);
            }
        }

        public void WriteToWeekendFile(DateTime date)
        {
            var path = "G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log.txt";
            var message = "test";
            var iMockDateTime = new Mock<IDateTime>();
            iMockDateTime.Setup(x => x.CurrentDateTime()).Returns(date);
            var writerDateTimeHelper = new WriterDateTimeHelper(iMockDateTime.Object);
            var messagePrefix = new MessagePrefix(iMockDateTime.Object);
            var pathSuffix = new PathSuffix(iMockDateTime.Object, writerDateTimeHelper);
            var writer = new FileWriter(messagePrefix, pathSuffix, writerDateTimeHelper);
            var logger = new FileLogger(writer, path);

            logger.Log(message);
        }

        public string FileContent(string path)
        {
            string content = string.Empty;

            content = File.ReadAllText(path);

            return content;
        }
    }
}
