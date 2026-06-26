using System.Collections.Generic;
using System.Windows;

namespace CyberSecurityChatbotGUI
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        // Creates an object that manages all tasks
        private TaskManager taskManager = new TaskManager();

        // Stores all loaded tasks
        private List<CyberTask> tasks = new List<CyberTask>();

        // Constructor
        public TaskWindow()
        {
            InitializeComponent();

            // Load saved tasks from the JSON file
            tasks = taskManager.GetAllTasks();

            // Display each task in the ListBox
            foreach (CyberTask task in tasks)
            {
                TaskListBox.Items.Add(task.Description);
            }
        }

        // Runs when the Add Task button is clicked
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Read the task description
            string description = TaskDescriptionBox.Text.Trim();

            // Prevent empty tasks
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please enter a task.");
                return;
            }

            // Create a new task
            CyberTask newTask = new CyberTask
            {
                Description = description,
                IsCompleted = false
            };

            // Save the task
            taskManager.AddTask(newTask);

            // Display the task immediately
            TaskListBox.Items.Add(description);

            // Clear the textbox
            TaskDescriptionBox.Clear();

            // Notify the user
            MessageBox.Show("Task added successfully.");
        }
        // Marks the selected task as completed
        private void MarkCompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedIndex >= 0)
            {
                taskManager.CompleteTask(TaskListBox.SelectedIndex);

                MessageBox.Show("Task marked as completed.");

                TaskListBox.Items.Clear();
                tasks = taskManager.GetAllTasks();

                foreach (CyberTask task in tasks)
                {
                    TaskListBox.Items.Add(task.Description);
                }
            }
        }
        // Deletes the selected task
        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedIndex >= 0)
            {
                taskManager.DeleteTask(TaskListBox.SelectedIndex);

                MessageBox.Show("Task deleted.");

                TaskListBox.Items.Clear();
                tasks = taskManager.GetAllTasks();

                foreach (CyberTask task in tasks)
                {
                    TaskListBox.Items.Add(task.Description);
                }
            }
        }
    }
}