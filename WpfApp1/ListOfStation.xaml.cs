using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using TrafficLogic;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ListOfStation.xaml
    /// </summary>
    public partial class ListOfStation : Window
    {
        IRepository<Station> listOfStations;
        IRepository<User> usersFromFile;
        User thisUser;
        
        public ListOfStation(User logUser, IRepository<User> users, IRepository<Station> listFromFile)
        {
            InitializeComponent();

            thisUser = logUser;
            usersFromFile = users;
            listOfStations = listFromFile;

            //listOfStations.Items.Sort(delegate (Station st1, Station st2) // repeat вынести 
            //{ return st1.Name.CompareTo(st2.Name); });
            StaticMethods.SortList(listOfStations.Items);

            listBoxStations.ItemsSource = listOfStations.Items;
            listBoxFavouritesStations.ItemsSource = logUser.favouriteStation;
        }

        private void RenewItemSource(User logUser)
        {
            listBoxFavouritesStations.ItemsSource = null;
            listBoxFavouritesStations.ItemsSource = thisUser.favouriteStation;
 
        }

        private void Get_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = listBoxStations.SelectedItem as Station;
            GetTimeWindow TimeToNearestBusWindow = new GetTimeWindow(selectedItem);
            TimeToNearestBusWindow.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //SaveData(sender, e);
            Close();

            MainWindow window = new MainWindow();
            window.ShowDialog();

            //SaveData(sender, e);
        }
        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var selectedStation = listBoxStations.SelectedItem as Station;
            if (selectedStation == null)
                MessageBox.Show("Select station");
            else
            {
                List<Station> fs = thisUser.favouriteStation;

                if (fs == null)
                {
                    fs = new List<Station>();
                }

                foreach (Station station in fs) //repeat
                {
                    if (selectedStation.Name.Contains(station.Name))
                    {
                        MessageBox.Show("Station has been already added in list!");
                        return;
                    }
                }

                int index = usersFromFile.Items.FindIndex(
                    delegate (User user)
                    {
                        return user.Email.Equals(thisUser.Email, StringComparison.Ordinal);
                    });

               usersFromFile = usersFromFile.AddFavouriteStation(selectedStation, index, usersFromFile);

                StaticMethods.SortList(fs);
               //fs.Sort(delegate (Station st1, Station st2) // repeat
               //{ return st1.Name.CompareTo(st2.Name); });

                RenewItemSource(thisUser);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
           var selectedFavouriteStation = listBoxFavouritesStations.SelectedItem as Station;

            if (selectedFavouriteStation == null)
               MessageBox.Show("Select station");
           else
           {
                thisUser.favouriteStation.Remove(selectedFavouriteStation);
           }
           RenewItemSource(thisUser);
        }
        /*
        void SaveData(object sender, RoutedEventArgs e)
        {
            var serializedItems = JsonConvert.SerializeObject(usersFromFile.Items);
            File.WriteAllText("../../../registredUsers.json", serializedItems);
        }*/
        public void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            StaticMethods.saveData(usersFromFile);
            string m = "Leaving us? Are you sure?";
            MessageBoxResult result =
              MessageBox.Show(
                m,
                "Data App",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
