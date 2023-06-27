using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>
    /// Логика взаимодействия для TenantsListPage.xaml
    /// </summary>
    public partial class TenantsListPage : Page
    {
        public TenantsListPage()
        {
            InitializeComponent();

            var TenantsList = KingITEntities.GetContext().Tenants.ToList();
            DGridTenants.ItemsSource = TenantsList;
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTenantPage());
        }
    }
}
