using Procesiranje_posiljaka_skladiste.Global;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Procesiranje_posiljaka_skladiste.Converters
{
    class ConverterRound2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string izlaz;

            izlaz = (Math.Round(double.Parse((string)value.ToString().Replace(",", "."), System.Globalization.NumberStyles.Any, CultureInfo.CreateSpecificCulture("en-us")), 2)).ToString();
            return izlaz;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }


    class Converter_damage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string izlaz = ZP.damage_popis[0]; // "Nema oštećenja";
            try
            {
                izlaz = ZP.damage_popis[(int)Funkcije.pretvori(value)];// "Nema oštećenja";

            }
            catch { }
            return izlaz;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            int izlaz = 0;
            try
            {
                izlaz = ZP.damage_popis.IndexOf(value.ToString());

            }
            catch { }
            return izlaz;
        }
    }




}
