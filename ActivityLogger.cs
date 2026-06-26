using System;
using System.Collections.Generic;

namespace CyberSecurityChatbotGUI
{
    public static class ActivityLogger
    {
        private static List<string> logs = new List<string>();

        public static void Log(string activity)
        {
            logs.Add(DateTime.Now.ToString("HH:mm:ss") + " - " + activity);
        }

        public static string GetRecentLog()
        {
            if (logs.Count == 0)
                return "No activities have been recorded.";

            return string.Join(Environment.NewLine, logs);
        }
    }
}
