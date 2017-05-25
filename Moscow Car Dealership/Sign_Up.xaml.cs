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
    /// Логика взаимодействия для Sign_Up.xaml
    /// </summary>
    public partial class Sign_Up : Page
    {
        public string salt = "rtgyi54y6tirht4";
        public Sign_Up()
        {
            InitializeComponent();
            textBox.Focus();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            passwordBox.Password = "";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Login);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length < 3 || passwordBox.Password.Length < 3)
            {
                MessageBox.Show("Недостаточно символов в логине или пароле!");
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
                    sw.WriteLine(HASH.Hashing(HASH.Hashing(passwordBox.Password + salt)));
                    sw.Close();
                    MessageBox.Show($"Пользователь '{textBox.Text}' был создан!");
                    NavigationService.Navigate(Pages.Login);
                }
            }
        }
    }
}
