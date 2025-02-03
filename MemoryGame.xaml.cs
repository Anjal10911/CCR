using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NeuroSyncApp
{
    public partial class MemoryGame : Window
    {
        private List<Button> _buttons;
        private Button _firstClickedButton;
        private Button _secondClickedButton;
        private int _score;
        private const int GridSize = 4; // 4x4 grid
        private List<int> _cardValues;

        public MemoryGame()
        {
            InitializeComponent();
            _score = 0;
            _buttons = new List<Button>();
            _cardValues = GenerateCardValues();
            CreateGameBoard();
        }

        private List<int> GenerateCardValues()
        {
            var values = Enumerable.Range(1, (GridSize * GridSize) / 2).ToList();
            values.AddRange(values); // duplicate values for pairs
            var random = new Random();
            return values.OrderBy(x => random.Next()).ToList();
        }

        private void CreateGameBoard()
        {
            GamePanel.Children.Clear();
            _buttons.Clear();
            for (int i = 0; i < GridSize * GridSize; i++)
            {
                var button = new Button
                {
                    Width = 80,
                    Height = 80,
                    FontSize = 24,
                    Content = "",
                    Tag = _cardValues[i],
                    Background = System.Windows.Media.Brushes.LightGray
                };
                button.Click += Card_Click;
                _buttons.Add(button);
                GamePanel.Children.Add(button);
            }
        }

        private void Card_Click(object sender, RoutedEventArgs e)
        {
            if (_firstClickedButton == null)
            {
                _firstClickedButton = sender as Button;
                _firstClickedButton.Content = _firstClickedButton.Tag.ToString();
                _firstClickedButton.IsEnabled = false;
            }
            else if (_secondClickedButton == null)
            {
                _secondClickedButton = sender as Button;
                _secondClickedButton.Content = _secondClickedButton.Tag.ToString();
                _secondClickedButton.IsEnabled = false;

                CheckForMatch();
            }
        }

        private void CheckForMatch()
        {
            if (_firstClickedButton.Tag.ToString() == _secondClickedButton.Tag.ToString())
            {
                _score += 10;
                ScoreTextBlock.Text = $"Score: {_score}";
                _firstClickedButton = null;
                _secondClickedButton = null;
            }
            else
            {
                var first = _firstClickedButton;
                var second = _secondClickedButton;
                Dispatcher.InvokeAsync(async () =>
                {
                    await System.Threading.Tasks.Task.Delay(500);
                    first.Content = "";
                    second.Content = "";
                    first.IsEnabled = true;
                    second.IsEnabled = true;
                    _firstClickedButton = null;
                    _secondClickedButton = null;
                });
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var childGameSelection = new ChildGameSelection();
            childGameSelection.Show();
            this.Close();
        }
    }
}
