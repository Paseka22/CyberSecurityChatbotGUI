using System;
using System.Collections.Generic;

namespace CyberSecurityChatbotGUI
{
    // Different emotional moods the chatbot can detect
    public enum MoodType
    {
        Neutral,
        Worried,
        Curious,
        Frustrated,
        Happy
    }

    public class SentimentDetector
    {
        // Dictionary storing moods and their trigger words
        private Dictionary<MoodType, List<string>> moodKeywords;

        // Constructor
        public SentimentDetector()
        {
            // Initialise dictionary
            moodKeywords = new Dictionary<MoodType, List<string>>()
            {
                {
                    MoodType.Worried,
                    new List<string>
                    {
                        "worried",
                        "scared",
                        "afraid",
                        "nervous",
                        "unsafe"
                    }
                },

                {
                    MoodType.Curious,
                    new List<string>
                    {
                        "curious",
                        "interested",
                        "wondering",
                        "learn",
                        "how"
                    }
                },

                {
                    MoodType.Frustrated,
                    new List<string>
                    {
                        "frustrated",
                        "annoyed",
                        "confused",
                        "upset"
                    }
                },

                {
                    MoodType.Happy,
                    new List<string>
                    {
                        "happy",
                        "great",
                        "awesome",
                        "thanks"
                    }
                }
            };
        }

        // Detects the emotional tone of the message
        public MoodType DetectMood(string message)
        {
            // Convert message to lowercase
            message = message.ToLower();

            // Loop through each mood category
            foreach (MoodType mood in moodKeywords.Keys)
            {
                // Check trigger words for each mood
                foreach (string triggerWord in moodKeywords[mood])
                {
                    // If trigger word exists in message
                    if (message.Contains(triggerWord))
                    {
                        return mood;
                    }
                }
            }

            // Return Neutral if no mood is detected
            return MoodType.Neutral;
        }

        // Returns an empathetic response
        public string GetMoodResponse(MoodType mood)
        {
            switch (mood)
            {
                case MoodType.Worried:
                    return "It sounds like you're worried. Let's improve your cybersecurity knowledge today !.";

                case MoodType.Curious:
                    return "I like your curiosity about online safety.";

                case MoodType.Frustrated:
                    return "Cybersecurity can definitely feel frustrating sometimes.";

                case MoodType.Happy:
                    return "I'm glad you're enjoying learning about cybersecurity.";

                default:
                    return "";
            }
        }
    }
}