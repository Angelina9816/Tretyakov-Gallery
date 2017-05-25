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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void portrait_Click(object sender, RoutedEventArgs e)
        {         
            NavigationService.Navigate(Pages.Portrait);
        }

        private void view_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.View);
        }

        private void ticket_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Ticket);
        }

        private void view_MouseEnter(object sender, MouseEventArgs e)
        {
            view.FontSize = 26;
        }

        private void portrait_MouseEnter(object sender, MouseEventArgs e)
        {
            portrait.FontSize = 26;
        }

        private void portrait_MouseLeave(object sender, MouseEventArgs e)
        {
            portrait.FontSize = 22;
        }

        private void view_MouseLeave(object sender, MouseEventArgs e)
        {
            view.FontSize = 22;
        }

        private void ticket_MouseEnter(object sender, MouseEventArgs e)
        {
            portrait.FontSize = 26;
        }

        private void ticket_MouseLeave(object sender, MouseEventArgs e)
        {
            portrait.FontSize = 22;
        }



    }
}
