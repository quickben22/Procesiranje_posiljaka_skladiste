using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesiranje_posiljaka_skladiste.Models
{
   public class ShipmentItem : INotifyPropertyChanged
    {


        [NotMapped]
        public ObservableCollection<string> Damage_popis { get; set; }
        [NotMapped]
        public ObservableCollection<string> zip_popis { get; set; }

        public int Id { get; set; }

     

        private string _Barcode;
        public string Barcode { get { return _Barcode; } set { _Barcode = (value); this.OnPropertyChanged("Barcode"); } }
        public int OrderId { get; set; }
        public int? ShipmentId { get; set; }
        public int? ShipmentItemTypeId { get; set; }
        public int BillingUnitId { get; set; }
        public int? OfferTariffId { get; set; }
        public int? GoodsTypeId { get; set; }
        public decimal? DefinedWeight { get; set; }
        private decimal? _RealWeightNet;
        public decimal? RealWeightNet { get { return _RealWeightNet; } set { _RealWeightNet = (value); this.OnPropertyChanged("RealWeightNet"); } }
        public decimal? RealWeightGross { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Heigth { get; set; }
        public decimal? VolumetricWeight { get; set; }
        public byte TourCount { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int Version { get; set; }
        public byte? Status { get; set; }
        public bool AdditionalCollect { get; set; }
        public int? TransportUnitId { get; set; }
        public bool ReturnToSender { get; set; }
        private byte _Damage;
        public byte Damage { get { return _Damage; } set { _Damage = (value); this.OnPropertyChanged("Damage"); } }
        public bool Missorted { get; set; }
        public bool Missrouted { get; set; }
        public string MissroutedValidZip { get; set; }
        public bool BulkyHandling { get; set; }
        public decimal? InsuranceValue { get; set; }


        private Shipment _Shipment;
        public Shipment Shipment { get { return _Shipment; } set { _Shipment = (value); this.OnPropertyChanged("Shipment"); } }



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(
                    this, new PropertyChangedEventArgs(propName));
        }


    }
}
