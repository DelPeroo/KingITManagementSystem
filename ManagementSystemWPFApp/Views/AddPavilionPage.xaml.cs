using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AddPavilionPage.xaml
    /// </summary>
    public partial class AddPavilionPage : Page
    {
        private Pavilions _currentPavilion = new Pavilions();

        public AddPavilionPage(Pavilions selectedPavilion)
        {
            InitializeComponent();

            MallsComboBox.ItemsSource = KingITEntities.GetContext().Malls.ToList();
            PavilionStatusesComboBox.ItemsSource = KingITEntities.GetContext().PavilionsStatuses.ToList();

            if (selectedPavilion != null)
            {
                _currentPavilion = selectedPavilion;
            }
            DataContext = _currentPavilion;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            Malls currentMall = MallsComboBox.SelectedItem as Malls;
            int currentPavilionsCount = KingITEntities.GetContext().Pavilions.Where(p => p.MallId == currentMall.MallId).Count() + 1;

            if (currentPavilionsCount >= currentMall.PavilionsCount)
                errors.AppendLine("В этом тц больше нет места под павильоны");
            if (_currentPavilion.LevelNumber > currentMall.LevelsCount)
                errors.AppendLine("Вы указали этаж которого нет в ТЦ");
            if (string.IsNullOrWhiteSpace(_currentPavilion.PavilionNumber))
                errors.AppendLine("Вы не ввели номер павильона");
            if (_currentPavilion.Malls == null)
                errors.AppendLine("Вы не выбрали ТЦ");
            if (_currentPavilion.PavilionsStatuses == null)
                errors.AppendLine("Вы не выбрали статус павильона");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentPavilion.PavilionId == 0)
            {
                KingITEntities.GetContext().Pavilions.Add(_currentPavilion);
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



    }
}
