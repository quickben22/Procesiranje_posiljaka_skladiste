using Procesiranje_posiljaka_skladiste.DAL;
using Procesiranje_posiljaka_skladiste.Global;
using Procesiranje_posiljaka_skladiste.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Procesiranje_posiljaka_skladiste.Menievi
{
    /// <summary>
    /// Interaction logic for OtvoriWin.xaml
    /// </summary>
    public partial class OtvoriWin : Window
    {

        private List<string> svi_projekti = new List<string>();
        ShipmentItem d;
        List<bool> povrat;
        public OtvoriWin(ShipmentItem a, List<bool> b)
        {
            d = a;
            povrat = b;
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox1.Focus();

            using (var db = new PodaciContext())
            {
                var query = from b in db.ShipmentItems
                            select b.Barcode;
                svi_projekti = new List<string>(query);
            }

            comboBox1.ItemsSource = svi_projekti;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            if (d != null)
            {
                CRUD.otvori(textBox1.Text, d, povrat);

                Close();



            }
            else
                MessageBox.Show("Neuspjeh");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }




        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {


                foreach (string str in svi_projekti)
                {
                    if (str == textBox1.Text)
                    {

                        button1.IsEnabled = true;
                        break;
                    }
                    else
                        button1.IsEnabled = false;

                }

            }
            else
            {
                button1.IsEnabled = false;

            }
        }
    }
}
