// ReactionTimeGame.xaml.cs
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace NeuroSyncApp
{
    public partial class ReactionTimeGame : Window
    {
        private Stopwatch stopwatch = new Stopwatch();
        private Random random = new Random();

        public ReactionTimeGame()
        {
            InitializeComponent();
            StartReactionGame();
        }

        private async void StartReactionGame()
        {
            // Wait for a random amount of time (1-5 seconds)
            await Task.Delay(random.Next(1000, 5000));

            // Change the button to green and start the stopwatch
            ReactionButton.Background = new SolidColorBrush(Colors.Green);
            ReactionButton.Content = "Click me!";
            stopwatch.Restart();
        }

        private void ReactionButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReactionButton.Background.ToString() == Brushes.Green.ToString())
            {
                stopwatch.Stop();
                ReactionButton.IsEnabled = false;
                ResultText.Text = $"Your reaction time is: {stopwatch.ElapsedMilliseconds} ms!";
            }
            else
            {
                ResultText.Text = "Too soon! Wait for it to turn green.";
            }
        }
    }
}
