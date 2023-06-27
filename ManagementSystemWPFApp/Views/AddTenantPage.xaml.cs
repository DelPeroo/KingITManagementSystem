using GenericJsonSerializer;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AddTenantPage.xaml
    /// </summary>
    public partial class AddTenantPage : Page
    {
        private Tenants _currentTenant = new Tenants();
        public AddTenantPage()
        {
            InitializeComponent();

            DataContext = _currentTenant;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            AdditionalInformation additionalInformation = new AdditionalInformation();
            additionalInformation.FieldOfActivity = FieldOfActivityTextBox.Text;

            string[] services = ServiceListTextBox.Text.Split(',');
            additionalInformation.ServiceList = services.ToList();

            additionalInformation.License = LicenseTextBox.Text;

            _currentTenant.AdditionalInformation = additionalInformation.Serialize();

            if (_currentTenant.TenantId == 0)
            {
                KingITEntities.GetContext().Tenants.Add(_currentTenant);
            }
            try
            {
                KingITEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                NavigationService.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
