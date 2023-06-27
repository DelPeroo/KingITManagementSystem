using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
            DGridEmployees.ItemsSource = KingITEntities.GetContext().Employees.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployeePage(null));
        }


        private void SearchEmpTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var EmployeesList = KingITEntities.GetContext().Employees.ToList();

            EmployeesList = EmployeesList.Where(emp => emp.Surname.ToLower().Contains(SearchEmpTextBox.Text.ToLower())).ToList();
            DGridEmployees.ItemsSource = EmployeesList;
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var EmployeesToDelete = DGridEmployees.SelectedItems.Cast<Employees>().ToList();

            foreach (var emp in EmployeesToDelete)
            {
                emp.RoleId = 4;
            }

            try
            {
                KingITEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены");
                DGridEmployees.ItemsSource = KingITEntities.GetContext().Employees.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployeePage((sender as Button).DataContext as Employees));
        }
    }
}
