using System.Collections.Generic;

namespace CyberSecurityChatbotGUI
{
    // Manages all task operations
    public class TaskManager
    {
        // Creates an object to access JSON storage
        private TaskStorageHelper storage = new TaskStorageHelper();

        // Adds a new task and saves it to the JSON file
        public void AddTask(CyberTask task)
        {
            // Load all existing tasks
            List<CyberTask> tasks = storage.LoadTasks();

            // Add the new task to the list
            tasks.Add(task);

            // Save the updated list
            storage.SaveTasks(tasks);


        }

        // Returns all saved tasks
        public List<CyberTask> GetAllTasks()
        {
            // Load and return all tasks from the JSON file
            return storage.LoadTasks();
        }

        // Marks a task as completed
        public void CompleteTask(int index)
        {
            // Load all tasks
            List<CyberTask> tasks = storage.LoadTasks();

            // Check if the task number is valid
            if (index >= 0 && index < tasks.Count)
            {
                // Mark the task as completed
                tasks[index].IsCompleted = true;

                // Save the updated list
                storage.SaveTasks(tasks);
            }
        }


        // Deletes a task from the list
        public void DeleteTask(int index)
        {
            // Load all saved tasks
            List<CyberTask> tasks = storage.LoadTasks();

            // Check if the task number is valid
            if (index >= 0 && index < tasks.Count)
            {
                // Remove the selected task
                tasks.RemoveAt(index);

                // Save the updated task list
                storage.SaveTasks(tasks);
            }
        }

    }
}