using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CyberSecurityChatbotGUI
{
    // Handles saving and loading tasks using a JSON file
    public class TaskStorageHelper
    {
        // Stores the location of the JSON file
        private readonly string filePath = "tasks.json";

        // Loads all tasks from the JSON file
        public List<CyberTask> LoadTasks()
        {
            // Check if the JSON file exists
            if (!File.Exists(filePath))
            {
                // Return an empty list if the file does not exist
                return new List<CyberTask>();
            }

            // Read all text from the JSON file
            string json = File.ReadAllText(filePath);

            // Convert the JSON data into a list of CyberTask objects
            return JsonConvert.DeserializeObject<List<CyberTask>>(json) ?? new List<CyberTask>();
        }

        // Saves all tasks to the JSON file
        public void SaveTasks(List<CyberTask> tasks)
        {
            // Convert the task list into JSON format
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);

            // Write the JSON data to the JSON file
            File.WriteAllText(filePath, json);
        }
    }
}