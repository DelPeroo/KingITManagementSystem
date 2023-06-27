using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>
    /// Логика взаимодействия для TenantsPage.xaml
    /// </summary>
    public partial class TenantsPage : Page
    {
        public TenantsPage()
        {
            InitializeComponent();
            TenantsComboBox.ItemsSource = KingITEntities.GetContext().Tenants.ToList();
            PavilionsComboBox.ItemsSource = KingITEntities.GetContext().Pavilions.ToList();
            MallsComboBox.ItemsSource = KingITEntities.GetContext().Malls.Where(m => m.MallStatuses.MallStatus != "Удален").ToList();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Tenants selectedTenant = (Tenants)TenantsComboBox.SelectedItem;
            Pavilions selectedPavilion = (Pavilions)PavilionsComboBox.SelectedItem;
            Malls selectedMall = (Malls)MallsComboBox.SelectedItem;

            Employees selectedEmployee = KingITEntities.GetContext().Employees.FirstOrDefault(emp => emp.EmployeeId == 2);

            DateTime? leaseStartDate = LeaseStartDatePicker.SelectedDate;
            DateTime? leaseEndDate = LeaseEndDatePicker.SelectedDate;

            
            // Проверка, что все данные выбраны
            if (selectedTenant != null && selectedPavilion != null && leaseStartDate != null && leaseEndDate != null && leaseEndDate >= leaseStartDate)
            {
                int id = KingITEntities.GetContext().PavilionsLease.Count();
                // Создание новой записи аренды
                PavilionsLease newLease = new PavilionsLease
                {
                    LeaseId = id + 1,
                    Tenants = selectedTenant,
                    TenantId = selectedTenant.TenantId,
                    Employees = selectedEmployee, 
                    EmployeeId = selectedEmployee.EmployeeId,
                    Pavilions = selectedPavilion,
                    PavilionId = selectedPavilion.PavilionId,
                    LeaseStart = leaseStartDate.Value,
                    LeaseEnd = leaseEndDate.Value
                };

                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@TenantId", newLease.Tenants.TenantId);
                System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@EmpId", newLease.Employees.EmployeeId);
                System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@PavilionId", newLease.Pavilions.PavilionId);
                System.Data.SqlClient.SqlParameter param3 = new System.Data.SqlClient.SqlParameter("@LeaseStart", newLease.LeaseStart);
                System.Data.SqlClient.SqlParameter param4 = new System.Data.SqlClient.SqlParameter("@LeaseEnd", newLease.LeaseEnd);

                System.Data.SqlClient.SqlParameter[] sqlParameters = { param2, param3, param4, param, param1 };

                try
                {
                    KingITEntities.GetContext().Database.ExecuteSqlCommand("EXEC RentPavilion @PavilionId, @LeaseStart, @LeaseEnd, @TenantId, @EmpId", sqlParameters);
                    MessageBox.Show("Вы арендовали павильон");
                    KingITEntities.GetContext().SaveChanges();


                    Malls mall = newLease.Pavilions.Malls;

                    log newLog = new log
                    {
                        EmployeeId = newLease.EmployeeId,
                        LeaseId = newLease.LeaseId,
                        TenantId = newLease.TenantId,
                        MallId = mall.MallId,
                        PavilionId = newLease.PavilionId,
                        MallStatusId = mall.MallStatusId,
                        LeaseStart = newLease.LeaseStart,
                        LeaseEnd = newLease.LeaseEnd
                    };
                    KingITEntities.GetContext().log.Add(newLog);
                    KingITEntities.GetContext().SaveChanges();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                TenantsComboBox.SelectedItem = null;
                PavilionsComboBox.SelectedItem = null;
                LeaseStartDatePicker.SelectedDate = null;
                LeaseEndDatePicker.SelectedDate = null;
                LeaseStartDatePicker.BlackoutDates.Clear();
                LeaseEndDatePicker.BlackoutDates.Clear();

                
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите все данные и укажите корректный промежуток аренды.");
            }
        }

        
    }
}
