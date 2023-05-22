using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Console;

public class FileLogger
{
    private IWriter _writer;
    private string _filePath;
    public FileLogger(IWriter writer, string filePath)
    {

        _writer = writer;
        _filePath = filePath;
    }

    public void Log(string message)
    {
       _writer.Write(message, _filePath);
    }
}
