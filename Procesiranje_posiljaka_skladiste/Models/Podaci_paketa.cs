
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Procesiranje_posiljaka_skladiste.Global;

namespace Procesiranje_posiljaka_skladiste.Models
{
    public class Podaci_paketa : INotifyPropertyChanged
    {
        [Key]
        public int PaketID { get; set; }


        private int _posiljka_id;
        public int posiljka_id { get { return _posiljka_id; } set { _posiljka_id = value; this.OnPropertyChanged("posiljka_id"); } }
        [ForeignKey("posiljka_id")]
        public Podaci_posiljke posiljka { get; set; }


        private int _packet_type;
        public int packet_type { get { return _packet_type; } set { _packet_type = (value); this.OnPropertyChanged("packet_type"); } }

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
