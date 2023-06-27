using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        private static string GenerateCaptcha()
        {
            const string chars = "abcdefghiklmnopqrstuvwxyzABCDEFGHIKLMNOPQRSTUVWXYZ";

            Random rnd = new Random();
            string randomString = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
            return randomString;
        }

        public CaptchaWindow()
        {
            InitializeComponent();
            CatchaLabel.Content = GenerateCaptcha();
        }

        private void CheckCaptcha_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaTextBox.Text == CatchaLabel.Content.ToString())
            {
                DialogResult = true;
                MessageBox.Show("Успешно");
                this.Close();
            }
            else
            {
                MessageBox.Show("Попробуйте еще раз");
                CatchaLabel.Content = GenerateCaptcha();
            }
        }
    }
}
