using CoreScanner;
using MahApps.Metro.Controls;
using Procesiranje_posiljaka_skladiste.DAL;
using Procesiranje_posiljaka_skladiste.Global;
using Procesiranje_posiljaka_skladiste.Models;
using Procesiranje_posiljaka_skladiste.Moduli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Printing;
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
using System.Xml;
using Squirrel;

namespace Procesiranje_posiljaka_skladiste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ShipmentItem d;
        CCoreScanner cCoreScannerClass;
        Brush button_standard_color;
        Brush button_standard_border_color;
        public MainWindow()
        {
            d = new ShipmentItem();
            d.Shipment = new Shipment();
            InitializeComponent();
            d.zip_popis = ZP.zip_popis;
            d.Damage_popis = ZP.damage_popis;
            update();
        }

        public async void update() // assume we return an int from this long running operation 
        {
            using (var mgr = new UpdateManager(@"D:\VS2017\Procesiranje_posiljaka_skladiste_git\Releases"))
            {
                await mgr.UpdateApp();
            }
        }


        private void Ulaz_Click(object sender, RoutedEventArgs e)
        {
            zamjena_user_controla(sender, gridic, Grid_button);
            VaganjeUserControl x = new VaganjeUserControl(d);
            gridic.Children.Add(x);

        }

        private void Vaganje_Click(object sender, RoutedEventArgs e)
        {
            vaga_click_fun(sender, gridic, Grid_button);
           
        }

        private VaganjeOsnovno vaga_click_fun(object o, Grid gridic, Grid Grid_button)
        {
            zamjena_user_controla(o, gridic, Grid_button);
            VaganjeOsnovno x = new VaganjeOsnovno(d);
            gridic.Children.Add(x);
            //x.HorizontalAlignment = HorizontalAlignment.Center;
            return x;
           
        }


        private void zamjena_user_controla(object o,Grid gridic,Grid Grid_button)
        {

            if (((Button)o).Background == Brushes.Green) return; // već je uključen


            foreach (var v in Grid_button.Children)
            {

                string t = v.GetType().ToString();

                if (v == o)
                {
                    ((Button)v).Background = Brushes.Green;
                    ((Button)v).BorderBrush = Brushes.DarkGreen;
                }
                else if (t == "System.Windows.Controls.Button")
                {
                    ((Button)v).Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF2196F3"));
                    ((Button)v).BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF2196F3"));
                }

            }

            foreach (var v in gridic.Children)
            {
                string t = v.GetType().ToString();

                if (t == "Procesiranje_posiljaka_skladiste.Moduli.VaganjeUserControl")
                    ((VaganjeUserControl)v).gasenje();
                else if (t == "Procesiranje_posiljaka_skladiste.Moduli.UlazUserControl")
                    ((UlazUserControl)v).gasenje();
                else if (t == "Procesiranje_posiljaka_skladiste.Moduli.VaganjeOsnovno")
                    ((VaganjeOsnovno)v).gasenje();
            }
            

            gridic.Children.Clear();
           

        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {

            //Printing.Print print_class = new Printing.Print();
            //print_class.start();




        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init_scanner();
            this.DataContext = d;
            button_standard_color = Vaga_button.Background;
            button_standard_border_color = Vaga_button.BorderBrush;




        }

        private void init_scanner()
        {
            try
            {
                //Instantiate CoreScanner Class
                cCoreScannerClass = new CCoreScanner();
                //Call Open API
                short[] scannerTypes = new short[1];//Scanner Types you are interested in
                scannerTypes[0] = 1; // 1 for all scanner types
                short numberOfScannerTypes = 1; // Size of the scannerTypes array
                int status; // Extended API return code
                cCoreScannerClass.Open(0, scannerTypes, numberOfScannerTypes, out status);
                // Subscribe for barcode events in cCoreScannerClass
                cCoreScannerClass.BarcodeEvent += new
                _ICoreScannerEvents_BarcodeEventEventHandler(OnBarcodeEvent);
                // Let's subscribe for events
                int opcode = 1001; // Method for Subscribe events
                string outXML; // XML Output
                string inXML = "<inArgs>" +
                "<cmdArgs>" +
                "<arg-int>1</arg-int>" + // Number of events you want to subscribe
                "<arg-int>1</arg-int>" + // Comma separated event IDs
                "</cmdArgs>" +
                "</inArgs>";
                cCoreScannerClass.ExecCommand(opcode, ref inXML, out outXML, out status);
                //Console.WriteLine(outXML);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Something wrong please check... " + exp.Message);
            }
        }

        void OnBarcodeEvent(short eventType, ref string pscanData)
        {
            string strXml = pscanData;


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(strXml);

            string strData = String.Empty;
            string barcode = xmlDoc.DocumentElement.GetElementsByTagName("datalabel").Item(0).InnerText;
            //string symbology = xmlDoc.DocumentElement.GetElementsByTagName("datatype").Item(0).InnerText;
            string[] numbers = barcode.Split(' ');

            foreach (string number in numbers)
            {
                if (String.IsNullOrEmpty(number))
                {
                    break;
                }

                strData += ((char)Convert.ToInt32(number, 16)).ToString();
            }

            if (CRUD.spremiDANE(d)) // da li treba nešto spremit prije učitavanja nove pošiljke
            {
                this.Dispatcher.Invoke(() =>
                {
                    d.Barcode = strData;
                    CRUD.open_web_db(d);


                    after_opening();
                });
            }


        }

        private void button_enable()
        {


            Vaga_button.IsEnabled = true;
            Ulaz_button.IsEnabled = true;
        }

        private void OtvoriMenu_Click(object sender, RoutedEventArgs e)
        {
            if (CRUD.spremiDANE(d)) // da li treba nešto spremit prije učitavanja nove pošiljke
            {

                List<bool> povrat = new List<bool>();
                Menievi.OtvoriWin dlg = new Menievi.OtvoriWin(d, povrat);
                dlg.ShowDialog();
                if (povrat.Count == 1)
                {
                    after_opening();

                }
            }
        }

        private void after_opening()
        {

            if (d.Barcode != null)
            {
                //button_enable();
              VaganjeOsnovno x=  vaga_click_fun(Vaga_button,  gridic,  Grid_button);
                x.sken();
            }
            ZP.IsChanged = false;
        }

        private void SpremiMenu_Click(object sender, RoutedEventArgs e)
        {
            
            CRUD.save_web_db(d);
            CRUD.spremi(d);
        }

        private void IzlazMenu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Brisi_Posiljku_Menu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AboutMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (CRUD.spremiDANE(d)) // da li treba nešto spremit prije učitavanja nove pošiljke
            {

            }
            else
                e.Cancel = true;
        }
    }
}
