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
    /// Логика взаимодействия для addEditPage.xaml
    /// </summary>
    public partial class addEditPage : Page
    {
        private Hotel _currentHotel = new Hotel();
        public addEditPage(Hotel selectedHotel)
        {
            InitializeComponent();

            if (selectedHotel != null)
                _currentHotel = selectedHotel;
            DataContext = _currentHotel;
            CountryCB.ItemsSource = Entities.GetContext().Country.ToList();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentHotel.Name))
                errors.AppendLine("Укажите название");
            if (_currentHotel.CountOfStars < 1 || _currentHotel.CountOfStars > 5)
                errors.AppendLine("Укажите количество звезд от 1 до 5");
            if (_currentHotel.Country == null)
                errors.AppendLine("Выберете страну");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentHotel.Id == 0)
                Entities.GetContext().Hotel.Add(_currentHotel);

            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Отель сохранен");
                Manager.mainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
