using System.Windows;

namespace NeuroSyncApp
{
    public partial class SelectionPage : Window
    {
        public SelectionPage()
        {
            InitializeComponent();
        }

        private void Parent_Click(object sender, RoutedEventArgs e)
        {
            // Logic for when the "Parent/Doctor" button is clicked
            MessageBox.Show("Parent/Doctor option selected");
            // Example: Open a new window
            // var parentWindow = new ParentDoctorPage();
            // parentWindow.Show();
            // this.Close();
        }

        private void Child_Click(object sender, RoutedEventArgs e)
        {
            // Logic for when the "Child" button is clicked
            MessageBox.Show("Child option selected");
            // Example: Open a new window
            // var childWindow = new ChildPage();
            // childWindow.Show();
            // this.Close();
        }
    }
}


