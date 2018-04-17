using System;
using TrafficLogic;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для GetTimeWindow.xaml
    /// </summary>
    public partial class GetTimeWindow : Window
    {
        public GetTimeWindow(Station station)
        {
            GetTheNearestBusByStation thisTimeToNextBus = new GetTheNearestBusByStation(station);
            InitializeComponent();
            listBoxStation.ItemsSource = station.Name;

            listBoxTimeToNextBus1.ItemsSource = thisTimeToNextBus.TimeToNextBus;
            listBoxTimeToNextBus2.ItemsSource = thisTimeToNextBus.TimeToNextBus;
            listBoxTimeToNextBus3.ItemsSource = thisTimeToNextBus.TimeToNextBus;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}