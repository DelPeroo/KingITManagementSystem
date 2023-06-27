using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using PasswordChecker;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>w
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        private Employees _currentEmployee = new Employees();

        public AddEmployeePage(Employees selectedEmployee)
        {
            InitializeComponent();

            RolesComboBox.ItemsSource = KingITEntities.GetContext().Roles.ToList();

            if (selectedEmployee != null)
            {
                _currentEmployee = selectedEmployee; 
            }
            DataContext = _currentEmployee;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentEmployee.Surname))
                errors.AppendLine("Вы не ввели фамилию");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Name))
                errors.AppendLine("Вы не ввели имя");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Patronymic))
                errors.AppendLine("Вы не ввели отчество");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Login))
                errors.AppendLine("Вы не ввели логин");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Password))
                errors.AppendLine("Вы не ввели пароль");
            if (_currentEmployee.Password.Length < 8 || _currentEmployee.Password.Length > 20)
                errors.AppendLine("Пароль должен быть от 8 до 20 символов");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Gender))
                errors.AppendLine("Вы не ввели пол");
            if (string.IsNullOrWhiteSpace(_currentEmployee.PhoneNumber))
                errors.AppendLine("Вы не ввели номер телефона");
            if (_currentEmployee.Roles == null)
                errors.AppendLine("Вы не выбрали роль");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                if (_currentEmployee.EmployeeId == 0)
                {
                    KingITEntities.GetContext().Employees.Add(_currentEmployee);
                }
                KingITEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                NavigationService.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SafenessChecker.CheckSafeness(PasswordTextBox.Text) == 1 || SafenessChecker.CheckSafeness(PasswordTextBox.Text) == 0) 
            {
                SafenessTextBlock.Text = "Пароль не надежен";
            }
            if (SafenessChecker.CheckSafeness(PasswordTextBox.Text) == 2)
            {
                SafenessTextBlock.Text = "Пароль средней наджености";
            }
            if (SafenessChecker.CheckSafeness(PasswordTextBox.Text) == 3)
            {
                SafenessTextBlock.Text = "Пароль надежный";
            }

        }
    }
}
