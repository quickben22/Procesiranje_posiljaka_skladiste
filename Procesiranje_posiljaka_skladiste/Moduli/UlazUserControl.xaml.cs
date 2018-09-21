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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Procesiranje_posiljaka_skladiste.Moduli
{
    /// <summary>
    /// Interaction logic for UlazUserControl.xaml
    /// </summary>
    public partial class UlazUserControl : UserControl
    {

        ShipmentItem d;

        public UlazUserControl(ShipmentItem a)
        {
            d = a;
            InitializeComponent();
            bindanje();
        }

        private void bindanje()
        {

            d.PropertyChanged += Computer_PropertyChanged;
            this.DataContext = d;
        }

        void Computer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {


        }

        public void gasenje()
        {
            d.PropertyChanged -= Computer_PropertyChanged;


        }

    }
}
