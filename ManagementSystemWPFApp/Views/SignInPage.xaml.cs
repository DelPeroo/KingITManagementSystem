using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        private int errorsCount = 0;

        public SignInPage()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text;
            string password = "";
            if (passwordTextBox.Visibility == Visibility.Visible)
            {
                password = passwordTextBox.Password;
            }
            else
            {
                password = passwordShowTextBox.Text;
            }

            var CurrentUser = KingITEntities.GetContext().Employees.FirstOrDefault(a => a.Login.ToLower() == login.ToLower() && a.Password == password);
            if (CurrentUser != null)
            {
                MessageBox.Show($"Вы вошли как {CurrentUser.Roles.RoleName}");

                if (CurrentUser.RoleId == 1)
                {
                    NavigationService.Navigate(new AdminPage());
                }
                if (CurrentUser.RoleId == 3)
                {
                    NavigationService.Navigate(new ManagerCPage());
                }

                
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
                errorsCount++;

                if (errorsCount == 3)
                {
                    CaptchaWindow captchaWindow = new CaptchaWindow();
                    if (captchaWindow.ShowDialog() == true)
                    {
                        errorsCount = 0;

                    }
                }
                return;
            }
        }

        private void CheckBox_Show(object sender, RoutedEventArgs e)
        {
            passwordShowTextBox.Text = passwordTextBox.Password;
            passwordTextBox.Visibility = Visibility.Collapsed;
            passwordShowTextBox.Visibility = Visibility.Visible;
        }

        private void CheckBox_Hide(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Password = passwordShowTextBox.Text;
            passwordShowTextBox.Visibility = Visibility.Collapsed;
            passwordTextBox.Visibility = Visibility.Visible;
        }
    }
}
