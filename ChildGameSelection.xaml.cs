using System.Windows;

namespace NeuroSyncApp
{
    public partial class ChildGameSelection : Window
    {
        public ChildGameSelection()
        {
            InitializeComponent();
        }

        private void MemoryGame_Click(object sender, RoutedEventArgs e)
        {
            // Check if the MemoryGame window is already open or if you want to create a new one
            var memoryGameWindow = new MemoryGame(); // Ensure MemoryGame is correctly defined in your project
            memoryGameWindow.Show();
            this.Close(); // Optional: Close the current window if desired
        }

        private void MathQuiz_Click(object sender, RoutedEventArgs e)
        {
            // Check if the MathQuizGame window is already open or if you want to create a new one
            var mathQuizWindow = new MathQuizGame(); // Ensure MathQuizGame is correctly defined in your project
            mathQuizWindow.Show();
            this.Close(); // Optional: Close the current window if desired
        }
    }
}

