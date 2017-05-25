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
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public string salt = "sdf5gs6dsdfg6$&/";

        public SignUp()
        {
            InitializeComponent();
            textBox.Focus();
        }
        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                signup_Click(null, null);
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length < 5 || password.Password.Length < 5)
            {
                MessageBox.Show("Недостаточно символов в логине или пароле:(");
            }
            else
            {
                if (Directory.Exists($"data/users/{textBox.Text}"))
                {
                    MessageBox.Show("Этот логин уже существует!");
                }
                else
                {
                    Directory.CreateDirectory($"data/users/{textBox.Text}");
                    StreamWriter sw = new StreamWriter($"data/users/{textBox.Text}/data.ls");
                    sw.WriteLine(textBox.Text);
                    sw.WriteLine(SHA1.Hashing(SHA1.Hashing(password.Password + salt)));
                    sw.Close();
                    MessageBox.Show($"Создан новый пользователь '{textBox.Text}'!");
                    NavigationService.Navigate(Pages.LoginPage);
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.LoginPage);
        }
    }
}

