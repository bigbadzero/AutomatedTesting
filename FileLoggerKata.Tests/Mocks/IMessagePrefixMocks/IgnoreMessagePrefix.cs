using FileLoggerKata.Console;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Tests.Mocks.IMessagePrefixMocks
{
    public class IgnoreMessagePrefix
    {
        public static IMessagePrefix GetIgnoreMessagePrefixMock(string message)
        {
            var mockIMessagePrefix = new Mock<IMessagePrefix>();
            mockIMessagePrefix.Setup(x => x.FormatMessageWithPrefix(It.IsAny<string>())).Returns(message);
            return mockIMessagePrefix.Object;
        }
    }
}
