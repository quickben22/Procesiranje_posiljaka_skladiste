
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Procesiranje_posiljaka_skladiste.Global;

namespace Procesiranje_posiljaka_skladiste.Models
{
    public class customer : INotifyPropertyChanged
    {
        [Key]
        public int customerID { get; set; }


        private string _reception_number;
        public string reception_number { get { return _reception_number; } set { _reception_number = value; this.OnPropertyChanged("reception_number"); } }

        private string _name;
        public string name { get { return _name; } set { _name = (value); this.OnPropertyChanged("name"); } }

        private string _lastname;
        public string lastname { get { return _lastname; } set { _lastname = (value); this.OnPropertyChanged("lastname"); } }



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(
                    this, new PropertyChangedEventArgs(propName));
        }

    }
}
