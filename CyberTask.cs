using System;

namespace CyberSecurityChatbotGUI
{
    // Stores information about each cybersecurity task
    public class CyberTask
    {
        // Unique ID for each task
        public int Id { get; set; }

        // Task title
        public string Title { get; set; }

        // Detailed description of the task
        public string Description { get; set; }

        // Reminder date or time
        public string Reminder { get; set; }

        // Checks whether the task has been completed
        public bool IsCompleted { get; set; }
    }
}