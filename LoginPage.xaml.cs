using System.Windows;
using NeuroSyncApp;// Ensure the namespace matches where ParentChildSelection is located

namespace NeuroSync
{
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        // Logic for Login Button Click
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string age = txtAge.Text;
            string gender = txtGender.Text;
            string diagnosticDate = txtDiagnosticDate.Text;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(age) ||
                string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(diagnosticDate))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Optional: Validate age is a number
            if (!int.TryParse(age, out _))
            {
                MessageBox.Show("Please enter a valid age.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Navigate to Parent/Doctor selection page after successful login
            ParentDoctorDashboard parentChildSelectionPage = new ParentDoctorDashboard();
            parentChildSelectionPage.Show();
            this.Close(); // Close the login page
        }

        // Logic for "View Account Details" button
        private void ViewAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic to view account details (navigate to account details page)
            AccountDetailsPage accountDetailsPage = new AccountDetailsPage();
            accountDetailsPage.Show();
        }
    }
}


