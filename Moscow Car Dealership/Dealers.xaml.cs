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
    /// Логика взаимодействия для Dealers.xaml
    /// </summary>
    public partial class Dealers : Page
    {
        public Dealers()
        {
            InitializeComponent();
        }
        List<Cars> carss;

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("../../DataBaseCars.bin", FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs, Encoding.GetEncoding(1251)))
                    {
                        for (int i = 0; i < carss.Count; i++)
                        {
                            if (textBox1.Text == carss[i].Mark)
                            {
                                bw.Write(carss[i].Show());
                                listBox2.Items.Add(carss[i].Show());
                            }
                        }
                        if (listBox2.Items.Count == 0)
                        {
                            MessageBox.Show("Не удалось завершить загрузку!");
                        }
                        else
                        {
                            MessageBox.Show("Загрузка прошла успешно!");
                        }

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось произвести загрузку");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Clear();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                carss = new List<Cars>();
                listBox1.Items.Clear();
                string[] line = File.ReadAllLines("../../cars.txt", Encoding.GetEncoding(1251));
                for (int i = 0; i < line.Length; i++)
                {
                    string[] items = line[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Cars s = new Cars(items[0], items[1], items[2], int.Parse(items[3]));
                    carss.Add(s);
                    listBox1.Items.Add(s.Show());
                }
                MessageBox.Show("Загрузка завершена");
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалоь выполнить загрузку");
            }
        }
    }
}

