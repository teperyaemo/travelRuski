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
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new addEditPage());
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new addEditPage());
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сделаем вид что строка удалилась");
        }
    }
}
