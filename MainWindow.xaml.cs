using System.Windows;
using System.Windows.Input;

namespace CyberSecurityChatbotGUI
{
    public partial class MainWindow : Window
    {
        // Main chatbot object
        private Chatbot securityBot;

        public MainWindow()
        {
            InitializeComponent();

            // Create chatbot object
            securityBot = new Chatbot();

            // Opening greeting
            ChatHistory.Text = securityBot.GetGreeting();

            // Button click event
            SendButton.Click += SendButton_Click;

            // Enter key support
            UserInputBox.KeyDown += UserInputBox_KeyDown;
        }

        // Send button clicked
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        // Press Enter to send
        private void UserInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        // Main sending method
        private void SendMessage()
        {
            string userMessage = UserInputBox.Text;

            // Prevent empty messages
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return;
            }

            // Show user message
            ChatHistory.Text += $"\n\nYOU: {userMessage}";

            // Get bot reply
            string botReply = securityBot.ProcessInput(userMessage);

            // Show bot response
            ChatHistory.Text += $"\nBOT: {botReply}";

            // Clear textbox
            UserInputBox.Clear();
        }
    }
}