using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata.Console
{
    public class FileLogger
    {
        public void Log(string message)
        {
            var logDate = DateTime.Now.ToString("yyyyMMdd");
            string filePath = $"G:\\projects\\AutomatedTesting\\FileLoggerKata.Console\\log{logDate}.txt";
            var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            bool fileExists = File.Exists(message);
            var log = $"{date} {message}";
            if (fileExists)
                File.AppendAllText(filePath, log);
            
            else
            {
                using (FileStream fs = File.Create(filePath))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine(log);
                        writer.Close();
                    }
                    fs.Close();
                }

            }
        }
    }
}
