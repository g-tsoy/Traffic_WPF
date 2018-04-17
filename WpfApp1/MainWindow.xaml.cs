using TrafficLogic;
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
using System.Security.Cryptography;
using System.ComponentModel; // CancelEventArgs
using Newtonsoft.Json;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User logUser;
        IRepository<User> registredUsers;
        IRepository<Station> registredStations;

        public MainWindow()
        {
            logUser = new User();
            registredUsers = new AuthorizedUsers();
            registredStations = new GetListOfStation();

            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration window = new Registration(registredUsers);
            window.ShowDialog();

            Renew();
        }

        private void Renew()
        {
            registredUsers = null; // renew
            registredUsers = new AuthorizedUsers();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(EmailBox.Text))
            {
                MessageBox.Show("Invalid Email");
                return;
            }
            else
            {
                logUser.Email = null;
                logUser.Email = EmailBox.Text;
            }

            if (string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Invalid password");
                return;
            }
            else
            {
                logUser.Password = StaticMethods.GetHashMethod(PasswordBox.Text);
            }

            logUser = registredUsers.Contain(logUser, registredUsers.Items);

            if (logUser != null)
            {
                ListOfStation window = new ListOfStation(logUser, registredUsers, registredStations);
                this.Close();

                window.Show();
            }

            else
            {
                MessageBox.Show("Check your login or password");
                PasswordBox.Text = ""; //delete writed password
                EmailBox.Text = "";
                return;
            }
        }
        private void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            StaticMethods.saveData(registredUsers);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //StaticMethods.DataWindow_Closing(sender, e, registredUsers);
            Close();
        }
    }
}