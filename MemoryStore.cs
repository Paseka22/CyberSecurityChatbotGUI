using System;

namespace CyberSecurityChatbotGUI
{
    public class MemoryStore
    {
        // Stores user information
        public string UserName { get; set; }

        public string FavouriteTopic { get; set; }

        // Save memory
        public void Remember(string key,string value)
        {
            if (key == "name")
            {

               UserName = value;
            }
            else if (key == "topic")
            {
                FavouriteTopic = value;
            }
        }

        // Create personalised response
        public string BuildPersonalisedReply()
        {
            if (!string.IsNullOrEmpty(UserName) &&
                !string.IsNullOrEmpty(FavouriteTopic))
            {
                return $"I remember that you are interested in {FavouriteTopic}, {UserName}.";
            }

            return "";
        }
    }
}