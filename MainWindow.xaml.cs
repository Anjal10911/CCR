using System.Windows;
using NeuroSync;

// Assuming LoginPage is in a namespace like NeuroSyncApp.Pages
using NeuroSyncApp;

namespace NeuroSyncApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Navigate to the LoginPage when the "Get Started" button is clicked
        private void GetStarted_Click(object sender, RoutedEventArgs e)
        {
            // Ensure LoginPage class is defined and correctly referenced
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close(); // Close the MainWindow after navigation
        }
    }
}

