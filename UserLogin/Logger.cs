using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class Logger
    {
        private const string logFileName = "Test.txt";
        static private List<Log> currentSessionActivities = new List<Log>();

        static public void LogActivity(string activity)
        {
            Log log = new Log()
            {
                Activity = activity,
                Username = LoginValidation.currentUserUsername,
                UserRole = (int) LoginValidation.currentUserRole
            };
            currentSessionActivities.Add(log);
            SaveLogsToDb(log);
            if (File.Exists(logFileName))
            {
                File.AppendAllText(logFileName, log.ToString());
            }
        }

        private static void SaveLogsToDb(Log log)
        {
            LogContext dbContext = new LogContext();
            dbContext.Logs.Add(log);
            dbContext.SaveChanges();
        }

        static public string ReadLoggFileContent()
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = File.ReadAllLines(logFileName);
            foreach (string line in lines)
            {
                sb.Append($"{line} \n");
            }
            return sb.ToString();
        }

        static public Log GetCurrentSessionActivities()
        {
            Log currentActivity = currentSessionActivities[currentSessionActivities.Count - 1];
            return currentActivity;
        }
    }
}
