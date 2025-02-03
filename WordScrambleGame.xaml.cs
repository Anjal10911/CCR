using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace NeuroSyncApp
{
    public partial class WordScrambleGame : Window
    {
        private int _score;
        private string _currentWord;
        private string _scrambledWord;

        public WordScrambleGame()
        {
            InitializeComponent();
            _score = 0;
            LoadNewWord();
        }

        private void LoadNewWord()
        {
            // Example word scramble: 'POTTER' scrambled to 'PTOER'
            var words = new[] { "POTTER", "GIRAFFE", "ELEPHANT", "BUTTERFLY" };
            Random random = new Random();
            _currentWord = words[random.Next(words.Length)];
            _scrambledWord = ScrambleWord(_currentWord);
            ScrambledWordTextBlock.Text = _scrambledWord;
            AnswerTextBox.Text = "";
            ErrorTextBlock.Visibility = Visibility.Collapsed;
        }

        private string ScrambleWord(string word)
        {
            var random = new Random();
            var scrambled = word.ToCharArray();
            for (int i = scrambled.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = scrambled[i];
                scrambled[i] = scrambled[j];
                scrambled[j] = temp;
            }
            return new string(scrambled);
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (AnswerTextBox.Text.Equals(_currentWord, StringComparison.OrdinalIgnoreCase))
            {
                _score += 10; // Increase score
                ScoreTextBlock.Text = $"Score: {_score}";
                LoadNewWord(); // Load next word
            }
            else
            {
                ShowErrorAnimation();
            }
        }

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The correct word is {_currentWord}.", "Answer", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowErrorAnimation()
        {
            ErrorTextBlock.Text = "Incorrect! Try Again.";
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

