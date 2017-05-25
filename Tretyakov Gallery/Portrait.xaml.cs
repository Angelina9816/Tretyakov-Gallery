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

namespace Tretyakov_Gallery
{
    /// <summary>
    /// Логика взаимодействия для Portrait.xaml
    /// </summary>
    public partial class Portrait : Page
    {
        public Portrait()
        {
            InitializeComponent();
            textBox.Focus();
        }
        List<Pictures> pictures;
        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                show_Click(null, null);
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pictures = new List<Pictures>();
                listBox1.Items.Clear();
                string[] line = File.ReadAllLines("../../portrait.txt", Encoding.GetEncoding(1251));
                for (int i = 0; i < line.Length; i++)
                {
                    string[] items = line[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Pictures p = new Pictures(items[0], items[1], int.Parse(items[2]));
                    pictures.Add(p);
                    listBox1.Items.Add(p.Show());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалоcь загрузить данные:( ");
            }

        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("../../DataBasePortrait.bin", FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs, Encoding.GetEncoding(1251)))
                    {
                        for (int i = 0; i < pictures.Count; i++)
                        {
                            if (textBox.Text == pictures[i].Author)
                            {
                                bw.Write(pictures[i].Show());
                                listBox2.Items.Add(pictures[i].Show());
                            }
                        }
                        if (listBox2.Items.Count == 0)
                        {
                            MessageBox.Show("Не удалось загрузить:(");
                        }


                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить:(");
            }

        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox.Clear();
        }
    }
}
