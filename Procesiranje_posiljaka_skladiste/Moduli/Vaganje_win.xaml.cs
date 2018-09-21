using CoreScanner;
using Procesiranje_posiljaka_skladiste.Global;
using Procesiranje_posiljaka_skladiste.Models;
using System;
using System.ComponentModel;
using System.Windows;
using System.Xml;

namespace Procesiranje_posiljaka_skladiste.Moduli
{
    /// <summary>
    /// Interaction logic for Vaganje_win.xaml
    /// </summary>
    public partial class Vaganje_win : Window
    {
        Podaci_posiljke d = new Podaci_posiljke();
  
        CCoreScanner cCoreScannerClass;

    
        public Vaganje_win()
        {
            bindanje();
            InitializeComponent();
  
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init_scanner();
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

       
        private void bindanje()
        {

            d.PropertyChanged += Computer_PropertyChanged;
            this.DataContext = d;
        }

        void Computer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {


        }


        private void Skeniraj_Click(object sender, RoutedEventArgs e)
        {


            Random rand = new Random();

            //d.reception_number = rand.Next(1, 1000000);
        }

        private void Vazi_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            d.weight = rand.Next(1, 10000);

            //d.arrival_depot = Funkcije.datum();
        }




        protected override void OnClosing(CancelEventArgs e)
        {
            d.PropertyChanged -= Computer_PropertyChanged;
         
        }




        private void Spremi_Click(object sender, RoutedEventArgs e)
        {
            int povrat = CRUD.spremi(d);
            if (povrat == 0)
                MessageBox.Show("Vec postoji!");
            else if (povrat == -1)
                MessageBox.Show("Nešto ne valja!");
            else if (povrat == 1)
                MessageBox.Show("Uspješno spremljeno!");
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


            this.Dispatcher.Invoke(() =>
            {
                d.reception_number = strData;
            });


        }


    }
}
