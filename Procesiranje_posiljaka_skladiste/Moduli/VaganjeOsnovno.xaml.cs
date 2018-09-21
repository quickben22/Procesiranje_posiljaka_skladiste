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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Procesiranje_posiljaka_skladiste.Moduli
{
    /// <summary>
    /// Interaction logic for VaganjeOsnovno.xaml
    /// </summary>
    public partial class VaganjeOsnovno : UserControl
    {

        ShipmentItem d;

        public VaganjeOsnovno(ShipmentItem a)
        {
            d = a;
            InitializeComponent();
            bindanje();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Obavijest_tb.Visibility = Visibility.Hidden;
        }

        public void gasenje()
        {
            d.PropertyChanged -= Computer_PropertyChanged;
        }

        public void sken()
        {
            d.RealWeightNet = 5;
            //if()  // if barcod dobar
            ((Storyboard)FindResource("animate")).Begin(Obavijest_tb);
        }

        void Computer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ZP.IsChanged = true;

        }

        private void bindanje()
        {

            d.PropertyChanged += Computer_PropertyChanged;
           
            this.DataContext = d;
        }


    }
}
