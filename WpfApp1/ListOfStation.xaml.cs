using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        GetListOfStation listOfStations = new GetListOfStation();
        AuthorizedUsers usersFromFile;
        User thisUser;
        

        public ListOfStation(User logUser, AuthorizedUsers users, GetListOfStation listFromFile)
        {
            InitializeComponent();

            listOfStations.StationsFromRoutes.Sort(delegate (Station st1, Station st2) // repeat вынести 
            { return st1.Name.CompareTo(st2.Name); });

            listBoxStations.ItemsSource = listOfStations.StationsFromRoutes;
            listBoxFavouritesStations.ItemsSource = logUser.favouriteStation;

            thisUser = logUser;
            usersFromFile = users;
            listOfStations = listFromFile;
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
            SaveData(sender, e);
            Close();

            MainWindow window = new MainWindow();
            window.ShowDialog();

            SaveData(sender, e);
        }
        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var selectedStation = listBoxStations.SelectedItem as Station;
            if (selectedStation == null)
                MessageBox.Show("Select station");
            else
            {
                List<Station> fs = thisUser.favouriteStation;

                if (fs == null) // repeaet Authorazed users
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

                int index = usersFromFile.Users.FindIndex(
                    delegate (User user)
                    {
                        return user.Email.Equals(thisUser.Email, StringComparison.Ordinal);
                    });

               usersFromFile = usersFromFile.AddFavouriteStation(selectedStation, index, usersFromFile);
               

               fs.Sort(delegate (Station st1, Station st2) // repeat
               { return st1.Name.CompareTo(st2.Name); });

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

        void SaveData(object sender, RoutedEventArgs e)
        {
            var serializedItems = JsonConvert.SerializeObject(usersFromFile.Users);
            File.WriteAllText("../../../registredUsers.json", serializedItems);
        }
    }
}
