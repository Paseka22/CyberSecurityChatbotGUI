using System.Collections.Generic;

namespace CyberSecurityChatbotGUI
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswer { get; set; }
    }

    public class QuizManager
    {
        public List<QuizQuestion> Questions { get; set; }

        public QuizManager()
        {
            Questions = new List<QuizQuestion>()
            {
                new QuizQuestion
                {
                    Question = "What is phishing?",
                    Options = new List<string>
                    {
                        "A cyber attack",
                        "A fishing hobby",
                        "A computer game",
                        "A social media app"
                    },
                    CorrectAnswer = 0
                },
                new QuizQuestion
                {
                    Question = "Which password is strongest?",
                    Options = new List<string>
                    {
                        "123456",
                        "password",
                        "P@ssw0rd!2026",
                        "qwerty"
                    },
                    CorrectAnswer = 2
                },
                new QuizQuestion
                {
                    Question = "What should you do before clicking a link?",
                    Options = new List<string>
                    {
                        "Click immediately",
                        "Check the sender",
                        "Ignore every email",
                        "Share it with friends"
                    },
                    CorrectAnswer = 1
                }
            };
        }
    }
}