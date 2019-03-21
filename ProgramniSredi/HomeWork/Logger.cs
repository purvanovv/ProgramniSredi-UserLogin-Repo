using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(String activity)
        {
            string activityLine = $"{DateTime.Now};{LoginValidation.Username};{LoginValidation.currentUserRole};{activity}";
            currentSessionActivities.Add(activityLine);
            if (File.Exists("log_data.txt"))
            {
                File.AppendAllText("log_data.txt", activityLine);
            }
        }
        static public String GetCurrentSessionActivities()
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in currentSessionActivities)
            {
                result.Append(item).Append("\n");
            }
            return result.ToString();
        }
        static public String GetAllUsersActivity()
        {
            StringBuilder result = new StringBuilder();
            StreamReader reader = new StreamReader("log_data.txt");
            String line = reader.ReadLine();
            while (line != null)
            {
                result.Append(line);
                result.Append("\n");
                line = reader.ReadLine();
            }
            return result.ToString();

        }
    }
}
