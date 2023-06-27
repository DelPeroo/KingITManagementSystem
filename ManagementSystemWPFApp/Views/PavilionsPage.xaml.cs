using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ManagementSystemWPFApp.Views
{
    /// <summary>
    /// Логика взаимодействия для PavilionsPage.xaml
    /// </summary>
    public partial class PavilionsPage : Page
    {
        public PavilionsPage()
        {
            InitializeComponent();

            DGridPavilions.ItemsSource = KingITEntities.GetContext().Pavilions.ToList();

            var MallsList = KingITEntities.GetContext().Malls.ToList();
            MallsList.Insert(0, new Malls { MallName = "Все ТЦ" });

            MallsComboBox.ItemsSource = MallsList;
        }

        private void MallsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentPavilions = KingITEntities.GetContext().Pavilions.ToList();

            if (MallsComboBox.SelectedIndex > 0)
            {
                var selectedMall = MallsComboBox.SelectedItem as Malls;
                currentPavilions = currentPavilions.Where(m => m.Malls.MallName.ToLower().Contains(selectedMall.MallName.ToLower())).ToList();
            }
            DGridPavilions.ItemsSource = currentPavilions;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var PavilionsToDelete = DGridPavilions.SelectedItems.Cast<Pavilions>().ToList();

            foreach (var p in PavilionsToDelete)
            {
                p.PavilionStatusId = 3;
            }

            try
            {
                KingITEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены");
                DGridPavilions.ItemsSource = KingITEntities.GetContext().Pavilions.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPavilionPage(null));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPavilionPage((sender as Button).DataContext as Pavilions));
        }

    }
}
