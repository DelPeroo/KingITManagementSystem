using System.Windows;
using System.Windows.Controls;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void EmpsButton_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.NavigationService.Navigate(new EmployeesPage());
        }

        private void LeaseButton_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.NavigationService.Navigate(new LeasesPage());
        }

        private void Tenants_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.NavigationService.Navigate(new TenantsListPage());
        }
    }
}
