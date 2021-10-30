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
    /// Логика взаимодействия для toursPage.xaml
    /// </summary>
    public partial class toursPage : Page
    {
        public toursPage()
        {
            InitializeComponent();
        }

        private void toursBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new trueTourPage());
        }

        private void hotelsBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new hotelPage());
        }
    }
}
