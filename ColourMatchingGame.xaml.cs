using System.Windows;
using System.Windows.Media.Animation;

namespace NeuroSyncApp
{
    public partial class ColorMatchingGame : Window
    {
        public ColorMatchingGame()
        {
            InitializeComponent();
        }

        private void MatchColors_Click(object sender, RoutedEventArgs e)
        {
            // Handle color matching completion and reward
            ShowReward();
        }

        private void TestErrorAnimation_Click(object sender, RoutedEventArgs e)
        {
            // Trigger error animation
            ShowErrorAnimation();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            // Go back to the game selection page
            var childGameSelection = new ChildGameSelection();
            childGameSelection.Show();
            this.Close();
        }

        private void ShowReward()
        {
            MessageBox.Show("Great job! You matched the colors!", "Reward", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowErrorAnimation()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                AutoReverse = true
            };
            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}

