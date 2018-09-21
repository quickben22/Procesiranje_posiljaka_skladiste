using MahApps.Metro.Controls;
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
    /// Interaction logic for VaganjeUserControl.xaml
    /// </summary>
    public partial class VaganjeUserControl : UserControl
    {
        ShipmentItem d;

        public VaganjeUserControl(ShipmentItem a)
        {

            d = a;
            InitializeComponent();
            bindanje();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Obavijest_tb.Visibility = Visibility.Hidden;
        }

        private void Skeniraj_Click(object sender, RoutedEventArgs e)
        {

            ((Storyboard)FindResource("animate")).Begin(Obavijest_tb);


        }

        private void Vazi_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Spremi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bindanje()
        {

            d.PropertyChanged += Computer_PropertyChanged;
            d.Shipment.PropertyChanged += Computer_PropertyChanged;
            this.DataContext = d;
        }

        void Computer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ZP.IsChanged = true;

        }

        public void gasenje()
        {
            d.PropertyChanged -= Computer_PropertyChanged;
            d.Shipment.PropertyChanged -= Computer_PropertyChanged;

        }

       
    }
}
