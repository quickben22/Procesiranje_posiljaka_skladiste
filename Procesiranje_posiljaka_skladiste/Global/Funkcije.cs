using Procesiranje_posiljaka_skladiste.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesiranje_posiljaka_skladiste.Global
{
    static class Funkcije
    {
        public static double pretvori_inf(double a)
        {
            if (a.ToString() == "Infinity" || a.ToString() == "-Infinity" || a.ToString() == "NaN")
                return 0;
            return a;
        }

        public static double pretvori(object b)
        {
            double rezultat;
            if (b == null) return 0;
            string a = b.ToString();
            bool isNum = double.TryParse(a, NumberStyles.Any, CultureInfo.InvariantCulture, out rezultat);

            if (isNum)
            {
                rezultat = double.Parse(a.Replace(",", "."), System.Globalization.NumberStyles.Any, CultureInfo.CreateSpecificCulture("en-us"));
            }
            else
                rezultat = 0;


            return rezultat;
        }

        public static string datum()
        {
            string datum = "";
            if (DateTime.Now.Minute > 9)
            {
                if (DateTime.Now.Hour > 9)
                {
                    datum = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ". - " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                }
                else
                    datum = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ". - 0" + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            }
            else
            {
                if (DateTime.Now.Hour > 9)
                    datum = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ". - " + DateTime.Now.Hour + ":" + "0" + DateTime.Now.Minute;
                else
                    datum = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ". - 0" + DateTime.Now.Hour + ":" + "0" + DateTime.Now.Minute;
            }

            return datum;
        }

      





    }
}
