using Procesiranje_posiljaka_skladiste.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesiranje_posiljaka_skladiste
{
    public static class ZP
    {
        public static bool IsChanged = false;

      //public static Podaci_posiljke svi = new Podaci_posiljke();
        public static ObservableCollection<string> damage_popis = new ObservableCollection<string> { "Nema oštećenja","Vanjsko oštećenje","Unutarnje oštećenje","Totalno oštećenje" };

        public static ObservableCollection<string> zip_popis  = new System.Collections.ObjectModel.ObservableCollection<string> { "10000", "51000", "51500" };
}
}
