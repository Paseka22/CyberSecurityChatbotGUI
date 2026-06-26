using System;

namespace CyberSecurityChatbotGUI
{
    public class Chatbot

    {
        // Class objects
        private KeywordResponder keywordBot;
        private SentimentDetector moodDetector;
        private MemoryStore memorySystem;

        // Creates an object to manage all user tasks
        private TaskManager taskManager = new TaskManager();

        // Stores previous topic for follow-up responses
        private string lastTopic;

        // Tracks whether chatbot is waiting for user's name
        private bool waitingForName;

        // Constructor
        public Chatbot()
        {
            // Initialise classes
            keywordBot = new KeywordResponder();
            moodDetector = new SentimentDetector();
            memorySystem = new MemoryStore();

            // Chatbot starts by asking for the user's name first
            waitingForName = true;
        }

        // Opening greeting
        public string GetGreeting()
        {
            return "Hello! Welcome to the Cyber Security Assistant. What is your name?";
        }
         
        // Main chatbot processing method
        public string ProcessInput(string userMessage)
        {
            // Capture user's name
            if (waitingForName)
            {
                waitingForName = false;
                return "Nice to meet you, " + userMessage.Trim() + "! How may I assist you with cybersecurity today?";

            }
            // Prevent null problems
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return "Please type a message first.";
            }



            // Convert input to lowercase
            string cleanMessage = userMessage.ToLower();

            // Check if the user wants to add a task
            if (cleanMessage.ToLower().StartsWith("add task "))
            {
                // Get the task description after "add task"
                string taskDescription = cleanMessage.Substring(9);

                // Create a new task
                CyberTask task = new CyberTask
                {
                    Description = taskDescription,
                    IsCompleted = false
                };

                // Save the task
                taskManager.AddTask(task);

                // Return a confirmation message
                return "Task added successfully!";
            }

            // Check if the user wants to view all tasks
            if (cleanMessage == "view tasks")
            {
                // Get all saved tasks
                List<CyberTask> tasks = taskManager.GetAllTasks();

                // Check if there are no tasks
                if (tasks.Count == 0)
                {
                    return "You have no saved tasks.";
                }

                // Create a string to display all tasks
                string result = "Your Tasks:\n";

                // Loop through each task
                for (int i = 0; i < tasks.Count; i++)
                {
                    string status = tasks[i].IsCompleted ? "Done" : "Not Done";

                    result += $"{i + 1}. [{status}] {tasks[i].Description}\n";
                }

                // Return the completed task list
                return result;
            }

            // Check if the user wants to delete a task
            if (cleanMessage.StartsWith("delete task "))
            {
                // Get the task number entered by the user
                string taskNumber = userMessage.Substring(12);

                // Convert it into an integer
                if (int.TryParse(taskNumber, out int index))
                {
                    // Delete the selected task
                    taskManager.DeleteTask(index - 1);

                    // Return a confirmation message
                    return "Task deleted successfully!";
                }

                // Return an error if the task number is invalid
                return "Please enter a valid task number.";
            }


            // Follow-up handling
            if (cleanMessage.Contains("tell me more") ||
                cleanMessage.Contains("explain more"))
            {
                if (!string.IsNullOrWhiteSpace(lastTopic))
                {
                    return $"Here is more information about {lastTopic}. Staying informed helps protect your digital safety.";
                }

                return "Please ask about a cybersecurity topic first.";
            }

            // Detect emotional tone
            MoodType detectedMood = moodDetector.DetectMood(cleanMessage);

            // Get emotional response
            string moodReply = moodDetector.GetMoodResponse(detectedMood);

            // Get cybersecurity response
            string botReply = keywordBot.FindResponse(cleanMessage);

            // Store favourite topic if detected
            if (cleanMessage.Contains("privacy"))
            {
                memorySystem.Remember("topic", "privacy");
                lastTopic = "privacy";
            }
            else if (cleanMessage.Contains("password"))
            {
                memorySystem.Remember("topic", "password safety");
                lastTopic = "password safety";
            }
            else if (cleanMessage.Contains("phishing"))
            {
                memorySystem.Remember("topic", "phishing");
                lastTopic = "phishing";
            }
            else if (cleanMessage.Contains("malware"))
            {
                memorySystem.Remember("topic", "malware");
                lastTopic = "malware";
            }
            else if (cleanMessage.Contains("scam"))
            {
                memorySystem.Remember("topic", "online scams");
                lastTopic = "online scams";
            }

            // Show recent activity log
            if (cleanMessage.Contains("activity") ||
                cleanMessage.Contains("log") ||
                cleanMessage.Contains("history"))
            {
                return ActivityLogger.GetRecentLog();
            }
            // Generate personalised memory response
            string memoryReply = memorySystem.BuildPersonalisedReply();

            // Combine responses together
            return $"{moodReply}\n{botReply}\n{memoryReply}";
        }
    }
}