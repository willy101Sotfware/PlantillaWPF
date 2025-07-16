using System;
using System.IO;

namespace PlantillaWPF.Services
{
    public static class LogService
    {
        private static readonly string logFilePath = "log.txt";

        public static void Log(string message)
        {
            string logEntry = $"[{DateTime.Now}] {message}";
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
    }
} 