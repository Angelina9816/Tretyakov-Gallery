using System;
using System.Collections.Generic;
using System.IO;
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

namespace Moscow_Car_Dealership
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public string salt = "rtgyi54y6tirht4";
        public Login()
        {
            InitializeComponent();
            textBox.Focus();
        }    
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length < 3 || passwordBox.Password.Length < 3)
            {
                MessageBox.Show("Имя пользователя или пароль неправильный!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (!Directory.Exists($"data/users/{textBox.Text}"))
                {
                    MessageBox.Show("Имя пользователя или пароль неправильный!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    StreamReader sr = new StreamReader($"data/users/{textBox.Text}/data.ls");
                    string user = sr.ReadLine();
                    string passhash = sr.ReadLine();
                    sr.Close();
                    string thispass = HASH.Hashing(HASH.Hashing(passwordBox.Password + salt));

                    if (user == textBox.Text && passhash == thispass)
                    {
                        MessageBox.Show($"Добро пожаловать {user}!");
                        NavigationService.Navigate(Pages.MainPage);
                    }
                    else
                    {
                        MessageBox.Show("Имя пользователя или пароль неправильный!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(Pages.Sign_Up);
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            passwordBox.Password = "";
        }
    }
}
