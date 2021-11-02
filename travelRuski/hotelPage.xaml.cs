using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace travelRuski
{
    /// <summary>
    /// Логика взаимодействия для hotelPage.xaml
    /// </summary>
    public partial class hotelPage : Page
    {
        public hotelPage()
        {
            InitializeComponent();
            //HotelsDbGrid.ItemsSource = Entities.GetContext().Hotel.ToList();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

            Manager.mainFrame.Navigate(new addEditPage((sender as Button).DataContext as Hotel));
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new addEditPage(null));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var HotelsForRemoving = HotelsDbGrid.SelectedItems.Cast<Hotel>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {HotelsForRemoving.Count()} элементов? ", "Внимание!" , MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Hotel.RemoveRange(HotelsForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    HotelsDbGrid.ItemsSource = Entities.GetContext().Hotel.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                HotelsDbGrid.ItemsSource = Entities.GetContext().Hotel.ToList();
            }
        }
    }
}
