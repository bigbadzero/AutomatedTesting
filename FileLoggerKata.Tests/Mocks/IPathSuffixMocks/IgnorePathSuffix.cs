using FileLoggerKata.Console;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Tests.Mocks.IPathSuffixMocks
{
    public class IgnorePathSuffix
    {
        public static IPathSuffix GetIgnorePathSuffix(string path)
        {
            var mockIPathSuffix = new Mock<IPathSuffix>();
            mockIPathSuffix.Setup(x => x.FormatLogFileWithSuffix(It.IsAny<string>())).Returns(path);
            return mockIPathSuffix.Object;
        }
    }
}
