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


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User logUser;
        IRepository<User> registredUsers;
       // AuthorizedUsers registredUsers;
        IRepository<Station> registredStations;

        public MainWindow()
        {
            InitializeComponent();
            //registredUsers.GetData();
            // read from file
            logUser = new User();
            registredUsers = new AuthorizedUsers();
            registredStations = new GetListOfStation();

        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration window = new Registration(registredUsers);
            //Close();

            window.ShowDialog();

            registredUsers = null; 
            registredUsers = new AuthorizedUsers();
        }
         
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(EmailBox.Text))
            {
                MessageBox.Show("Invalid name");
                return;
            }
            else
            {
                logUser.Email = EmailBox.Text;
            }

            if (string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Invalid name");
                return;
            }
            else
            {
                logUser.Password = GetHash(PasswordBox.Text);
                //logUser.Password = PasswordBox.Text;
            }

            logUser = registredUsers.Contain(logUser, registredUsers.Items);

            if (registredUsers.Contain(logUser, registredUsers.Items) != null)
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

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
           // SaveData();
                string msg = "Data is dirty. Close without saving?";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Data App",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Вынести
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }
}