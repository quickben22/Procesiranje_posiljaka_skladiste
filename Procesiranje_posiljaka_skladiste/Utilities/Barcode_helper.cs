using Procesiranje_posiljaka_skladiste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Procesiranje_posiljaka_skladiste.Utilities
{
    public class Barcode_helper
    {
        KeyConverter mScanKeyConverter = new KeyConverter();

        public void pamti(Podaci_posiljke d,Podaci_posiljke d_pom)
        {

            d_pom.reception_number = d.reception_number;
            d_pom.weight = d.weight;
        }

        public void odpamti(Podaci_posiljke d, Podaci_posiljke d_pom)
        {
            if (d_pom.reception_number != d.reception_number)
                d.reception_number = d_pom.reception_number;
            if (d_pom.weight != d.weight)
                d.weight = d_pom.weight;
        }

        public string add_char(KeyPressedArgs e)
        {
            string xChar = mScanKeyConverter.ConvertToString(e.KeyPressed);

            return xChar;
        

        }

    }
}
