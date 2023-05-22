using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Console
{
    public interface IMessagePrefix
    {
        public string FileMessagePrefixFormat { get; set; }
        string FormatMessageWithPrefix(string message);
    }
}
