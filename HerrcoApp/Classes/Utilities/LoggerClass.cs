using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using HerrcoApp.Classes.Constants;
using HerrcoApp.Classes.Entities;

namespace HerrcoApp.Classes
{
    public class LoggerClass
    {
        /// <summary>
        /// Writes a line of text to the log file.
        /// </summary>
        /// <param name="v">Log string.</param>
        /// <returns>void</returns>
        public static void Log(string v)
        {
            LogTextEntry($"{getTheadInfo()} {v}\n");
        }

        /// <summary>
        /// Prepares a line of text for the log file.
        /// </summary>
        /// <returns>string</returns>
        private static string getTheadInfo()
        {
            string threadId = Thread.GetCurrentProcessorId().ToString();
            string rtnMsg = $"Thread: [{threadId}]";
            return rtnMsg;
        }

        /// <summary>
        /// Writes a line of text to the log file.
        /// </summary>
        /// <param name="logText">Log string.</param>
        /// <returns>void</returns>
        private static void LogTextEntry(
            string logText)
        {
            File.AppendAllText(ConstantsClass.LOG_FILE_NAME, logText);
            
        }

        /// <summary>
        /// Clears the Log file.
        /// </summary>
        /// <returns>void</returns>
        public static void ClearLogFile()
        {
            File.WriteAllTextAsync(
                    ConstantsClass.LOG_FILE_NAME, "");
        }
    }
}
