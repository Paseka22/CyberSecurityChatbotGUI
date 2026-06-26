using System.Windows;

namespace CyberSecurityChatbotGUI
{
    public partial class QuizWindow : Window
    {
        private QuizManager quizManager = new QuizManager();
        private int currentQuestion = 0;
        private int score = 0;

        public QuizWindow()
        {
            InitializeComponent();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            QuestionText.Text = quizManager.Questions[currentQuestion].Question;

            OptionsListBox.Items.Clear();

            foreach (string option in quizManager.Questions[currentQuestion].Options)
            {
                OptionsListBox.Items.Add(option);
            }

            OptionsListBox.SelectedIndex = -1;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (OptionsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an answer.");
                return;
            }

            if (OptionsListBox.SelectedIndex ==
                quizManager.Questions[currentQuestion].CorrectAnswer)
            {
                score++;
            }

            currentQuestion++;

            if (currentQuestion < quizManager.Questions.Count)
            {
                LoadQuestion();
            }
            else
            {
                MessageBox.Show($"Quiz Finished!\n\nYour score: {score}/{quizManager.Questions.Count}");
                Close();
            }
        }
    }
}