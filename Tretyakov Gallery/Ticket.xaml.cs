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

namespace Tretyakov_Gallery
{
    /// <summary>
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Page
    {
        Online t = null;
        public Ticket()
        {
            InitializeComponent();
            textBox.Focus();
            t = Online.GetOnline();
            initControlls();
        }
      
        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                buy_Click(null, null);
        }

        private void initControlls()
        {
            textBox.Text =  t.Surname;
            textBox1.Text = t.Name;          
            textBox2.Text = t.Email;          
        }

        private void buy_Click(object sender, RoutedEventArgs e)
        {
            t.Surname = textBox.Text;
            t.Name = textBox1.Text;
            t.Email = textBox2.Text;           
            NavigationService.Navigate(Pages.StartPage);
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.StartPage);
        }
    }
}
