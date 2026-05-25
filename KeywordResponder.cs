using System;
using System.Collections.Generic;

namespace CyberSecurityChatbotGUI
{
    public class KeywordResponder
    {
        private Dictionary<string, List<string>> topicReplies;
        private Random responsePicker;

        //Random object used to choose different replies
        public  KeywordResponder()
        {
            responsePicker = new Random();

            // Dictionary storing cybersecurity topics and responses
            topicReplies = new Dictionary<string, List<string>>()
            {
                {
                    //Password saftey responses
                    "password",new List<string>
                    {
                        "Make your passwords difficult to guess by adding symbols and numbers mixed with letters.",
                        "Never use personal details like your birthday in a password.",
                        "Changing passwords often improves your online security."
                    }
                },

                {
                    //Phishing awerness responses 
                    "phishing",
                    new List<string>
                    {
                        "Be careful of suspicious emails asking for personal information.",
                        "Phishing attacks often pretend to come from trusted companies.",
                        "Avoid clicking links from unknown senders especially in websites."
                    }
                },

                {
                    //Privacy protection responses 
                    "privacy",
                    new List<string>
                    {
                        "Keep your personal information private online.",
                        "Check your social media privacy settings regularly.",
                        "Think carefully before sharing personal details on websites."
                    }
                },

                {
                    //Malware protection responses
                    "malware",
                    new List<string>
                    {
                        "Malware can damage your computer and steal information.",
                        "Install trusted antivirus software for extra protection.",
                        "Avoid downloading files from suspicious websites."
                    }
                },

                {
                    // Scam awerness responses
                    "scam",
                    new List<string>
                    {
                        "Online scams usually try to create panic or urgency.",
                        "Never send money to strangers you meet online.",
                        "If something seems too good to be true, it probably is."
                    }
                },

                {
                    "vpn",
                    new List<string>
                    {
                        "A VPN helps keep your internet activity private.",
                        "Using a VPN is safer when connected to public Wi-Fi.",
                        "VPNs protect your connection through encryption."
                    }
                },

                {
                    "encryption",
                    new List<string>
                    {
                        "Encryption helps keep sensitive data secure.",
                        "Encrypted information is harder for hackers to read.",
                        "Many websites use encryption to protect user accounts."
                    }
                }
            };
        }

        public string FindResponse(string userMessage)
        {
            string message = userMessage.ToLower();

            foreach (var topic in topicReplies)
            {
                if (message.Contains(topic.Key))
                {
                    List<string> replies = topic.Value;

                    int randomNumber = responsePicker.Next(replies.Count);

                    return replies[randomNumber];
                }
            }

            return "I'm still learning about that topic. Try asking another cybersecurity question.";
        }
    }
}