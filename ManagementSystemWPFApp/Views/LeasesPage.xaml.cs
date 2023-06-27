using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>
    /// Логика взаимодействия для LeasesPage.xaml
    /// </summary>
    public partial class LeasesPage : Page
    {
        public LeasesPage()
        {
            InitializeComponent();
            DGridLeases.ItemsSource = KingITEntities.GetContext().PavilionsLease.ToList();

            var TenantsList = KingITEntities.GetContext().Tenants.ToList();
            TenantsList.Insert(0, new Tenants { TenantName = "Все арендаторы" });

            TenantsComboBox.ItemsSource = TenantsList;
        }

        private void TenantsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var PavilionsList = KingITEntities.GetContext().PavilionsLease.ToList();
            
            if (TenantsComboBox.SelectedIndex > 0)
            {
                var selectedTenant = TenantsComboBox.SelectedItem as Tenants;

                PavilionsList = PavilionsList.Where(pl => pl.Tenants.TenantName.Contains(selectedTenant.TenantName)).ToList();
            }
            DGridLeases.ItemsSource = PavilionsList;
            
        }
    }
}
