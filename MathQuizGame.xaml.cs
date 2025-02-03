using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace NeuroSyncApp
{
    public partial class MathQuizGame : Window
    {
        private int _score;
        private int _currentAnswer;

        public MathQuizGame()
        {
            InitializeComponent();
            _score = 0;
            LoadNewQuestion();
        }

        private void LoadNewQuestion()
        {
            // Example question: 5 + 3
            Random random = new Random();
            int num1 = random.Next(1, 10);
            int num2 = random.Next(1, 10);
            _currentAnswer = num1 + num2;
            QuestionTextBlock.Text = $"What is {num1} + {num2}?";
            AnswerTextBox.Text = "";
            ErrorTextBlock.Visibility = Visibility.Collapsed;
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AnswerTextBox.Text, out int userAnswer))
            {
                if (userAnswer == _currentAnswer)
                {
                    _score += 10; // Increase score
                    ScoreTextBlock.Text = $"Score: {_score}";
                    LoadNewQuestion(); // Load next question
                }
                else
                {
                    ShowErrorAnimation();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The correct answer is {_currentAnswer}.", "Answer", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowErrorAnimation()
        {
            ErrorTextBlock.Text = "Wrong Answer. Try Again!";
            ErrorTextBlock.Visibility = Visibility.Visible;
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                AutoReverse = true
            };
            Storyboard.SetTarget(animation, ErrorTextBlock);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var childGameSelection = new ChildGameSelection();
            childGameSelection.Show();
            this.Close();
        }
    }
}
