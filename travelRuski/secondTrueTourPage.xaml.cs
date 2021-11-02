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
    /// Логика взаимодействия для secondTrueTourPage.xaml
    /// </summary>
    public partial class secondTrueTourPage : Page
    {
        public secondTrueTourPage()
        {
            InitializeComponent();

            var allTypes = Entities.GetContext().Type.ToList();
            allTypes.Insert(0, new Type
            {
                Name = "Все типы"
            });
            Combotype.ItemsSource = allTypes;

            CheckActual.IsChecked = true;
            Combotype.SelectedIndex = 0;

            var currentTours = Entities.GetContext().Tour.ToList();
            LVTour.ItemsSource = currentTours;
        }

        private void UpdateTours()
        {
            var currentTours = Entities.GetContext().Tour.ToList();

            if (Combotype.SelectedIndex > 0)
                currentTours = currentTours.Where(p => p.Type.Contains(Combotype.SelectedItem as Type)).ToList();

            currentTours = currentTours.Where(p => p.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (CheckActual.IsChecked.Value)
                currentTours = currentTours.Where(p => p.IsActual).ToList();

            LVTour.ItemsSource = currentTours.OrderBy(p => p.TicketCount).ToList();
        }

        private void LVTour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void Combotype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }

        private void CheckActual_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }
    }
}
