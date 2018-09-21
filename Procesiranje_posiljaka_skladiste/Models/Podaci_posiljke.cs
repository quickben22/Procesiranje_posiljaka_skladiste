
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Procesiranje_posiljaka_skladiste.Global;

namespace Procesiranje_posiljaka_skladiste.Models
{
   public class Podaci_posiljke : INotifyPropertyChanged
    {
        [Key]
        public int PosiljkaID { get; set; }


        private string _reception_number;
        public string reception_number { get { return _reception_number; } set { _reception_number = value; this.OnPropertyChanged("reception_number"); } }

     
        private string _pickup_name;
        public string pickup_name { get { return _pickup_name; } set { _pickup_name = (value); this.OnPropertyChanged("pickup_name"); } }

        private string _pickup_street;
        public string pickup_street { get { return _pickup_street; } set { _pickup_street = (value); this.OnPropertyChanged("pickup_street"); } }

        private string _pickup_house_number;
        public string pickup_house_number { get { return _pickup_house_number; } set { _pickup_house_number = (value); this.OnPropertyChanged("pickup_house_number"); } }

        private string _pickup_house_number_suffix;
        public string pickup_house_number_suffix { get { return _pickup_house_number_suffix; } set { _pickup_house_number_suffix = (value); this.OnPropertyChanged("pickup_house_number_suffix"); } }

      
        [NotMapped]
        public ObservableCollection<string> pickup_zip_popis { get; set; }

        private string _pickup_zip;
        public string pickup_zip { get { return _pickup_zip; } set { _pickup_zip = (value); this.OnPropertyChanged("pickup_zip"); } }

        private string _pickup_city;
        public string pickup_city { get { return _pickup_city; } set { _pickup_city = (value); this.OnPropertyChanged("pickup_city"); } }

        [NotMapped]
        public ObservableCollection<string> damage_popis { get; set; }
        private int _damage;
        public int damage { get { return _damage; } set { _damage = (value); this.OnPropertyChanged("damage"); } }

        private double _weight;
        public double weight { get { return _weight; } set { _weight = Funkcije.pretvori_inf(value); this.OnPropertyChanged("weight"); } }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(
                        this, new PropertyChangedEventArgs(propName));
        }

    }
}
