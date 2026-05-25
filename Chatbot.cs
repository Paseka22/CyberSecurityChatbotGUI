using System;

namespace CyberSecurityChatbotGUI
{
    public class Chatbot
    {
        // Class objects
        private KeywordResponder keywordBot;
        private SentimentDetector moodDetector;
        private MemoryStore memorySystem;

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
                return "Nice to meet you, " + userMessage.Trim() + "! How can I assist you with cybersecurity today?";

            }
            // Prevent null problems
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return "Please type a message first.";
            }

            // Convert input to lowercase
            string cleanMessage = userMessage.ToLower();


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

            // Generate personalised memory response
            string memoryReply = memorySystem.BuildPersonalisedReply();

            // Combine responses together
            return $"{moodReply}\n{botReply}\n{memoryReply}";
        }
    }
}