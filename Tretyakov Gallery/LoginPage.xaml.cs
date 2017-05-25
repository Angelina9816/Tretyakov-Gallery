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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tretyakov_Gallery
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public string salt = "sdf5gs6dsdfg6$&/";

        public LoginPage()
        {
            InitializeComponent();
            textBox.Focus();
        }
        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {          
            if (e.Key == Key.Enter)
                signup_Click(null, null);
        }

        private void signin_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length < 5 || password.Password.Length < 5)
            {
                MessageBox.Show("Недостаточно символов в логине или пароле:(", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (!Directory.Exists($"data/users/{textBox.Text}"))
                {
                    MessageBox.Show("Неверно введён логин или пароль:(", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    StreamReader sr = new StreamReader($"data/users/{textBox.Text}/data.ls");
                    string user = sr.ReadLine();
                    string passhash = sr.ReadLine();
                    sr.Close();
                    string thispass = SHA1.Hashing(SHA1.Hashing(password.Password + salt));

                    if (user == textBox.Text && passhash == thispass)
                    {                                            
                        NavigationService.Navigate(Pages.StartPage);
                    }
                    else
                    {
                        MessageBox.Show("Неверно введён логин или пароль:(", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }                  
                }
            }
        }
            
        private void signup_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(Pages.SignUp);
        }
    }
}
