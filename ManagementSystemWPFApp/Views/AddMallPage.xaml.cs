using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LoadImages;
using Microsoft.Win32;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AddMallPage.xaml
    /// </summary>
    public partial class AddMallPage : Page
    {
        private Malls _currentMall = new Malls();
        public AddMallPage(Malls selectedMall)
        {
            InitializeComponent();

            StatusesComboBox.ItemsSource = KingITEntities.GetContext().MallStatuses.ToList();
            CitiesComboBox.ItemsSource = KingITEntities.GetContext().Cities.ToList();

            if (selectedMall != null)
            {
                _currentMall = selectedMall;
            }

            DataContext = _currentMall;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentMall.MallId == 0)
            {
                KingITEntities.GetContext().Malls.Add(_currentMall);
            }
            try
            {
                KingITEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ChoosePictureButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _currentMall.MallPicture = ImageLoader.LoadImage(openFileDialog.FileName);
            }
        }
    }
}
