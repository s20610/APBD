using System;
using System.IO;

namespace Cwiczenie2.Services
{
    public class Logger
    {
        private static Logger loggerInstance;
        private string errorLogFilePath = "./łog.txt";
        
        public static Logger GetInstance()
        {
            if (loggerInstance == null)
            {
                loggerInstance = new Logger();
            }

            return loggerInstance;
        }

        public void Error(Exception exception)
        {
            String exceptionMessage = exception.Message + "\n";
            String errorPath = errorLogFilePath;
            
            File.AppendAllText(errorPath, exceptionMessage);
        }
    }
}