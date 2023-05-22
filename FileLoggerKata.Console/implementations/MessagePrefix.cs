using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Console
{
    public class MessagePrefix : IMessagePrefix
    {
        private readonly IDateTime _dateTime;
        public MessagePrefix(IDateTime dateTime)
        {

            _dateTime = dateTime;

        }
        public string FileMessagePrefixFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";

        public string FormatMessageWithPrefix(string message)
        {
            var formattedDate = _dateTime.CurrentDateTime().ToString(FileMessagePrefixFormat);
            var prefixedMessage = $"{formattedDate} {message}";
            return prefixedMessage;
        }
    }
}
