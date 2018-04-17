using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
using TrafficLogic;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        User user;
        IRepository<User> usersFromFile;

        public Registration(IRepository<User> users)
        {
            InitializeComponent();

            user = new User();
            usersFromFile = users;

            //RegistrationBtn.Click +=SaveData;

            // return usersFromFile;
        }

        public void Registration_Click(object sender, RoutedEventArgs e)//delegats
        {

            if (string.IsNullOrEmpty(FullNameBox.Text)) //repeat (TextBox)
            {
                MessageBox.Show("Invalid name");
                return;
            }
            else
            {
                user.FullName = FullNameBox.Text;
            }

            if (string.IsNullOrEmpty(EmailBox.Text))
            {
                MessageBox.Show("Invalid Email");
                return;
            }
            else
            {
                user.Email = EmailBox.Text;//repeat in List Of stations
                string eMail = user.Email;

                foreach (User userInArray in usersFromFile.Items)
                {
                    if (eMail.Contains(userInArray.Email))
                    {
                        MessageBox.Show("User already exists!");
                        PasswordBox.Text = ""; //delete writed password
                        EmailBox.Text = "";
                        return;
                    }
                }
            }

            if (string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Invalid Password");
                return;
            }
            else
            {
                string hashPas = GetHash(PasswordBox.Text);
                user.Password = hashPas;
            }

            usersFromFile.Items.Add(user); //repeat with ad favourite stations -- interface for Add function

            SaveData(sender, e);
            //    MainWindow window = new MainWindow();

            Close();
      //      window.ShowDialog();
        }

        public static string GetHash(string password) // interface
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void SaveData(object sender, RoutedEventArgs e)
        {
            var serializedItems = JsonConvert.SerializeObject(usersFromFile.Items);
            File.WriteAllText("../../../registredUsers.json", serializedItems);
        }
    }
}
