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
    public class Shipment : INotifyPropertyChanged
    {

        public Shipment()
        {
            ShipmentItem = new HashSet<ShipmentItem>();
            ShipmentNotification = new HashSet<ShipmentNotification>();
        }

 

        public int Id { get; set; }
        public string Number { get; set; }
        public int OrderId { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? ShippingDateTime { get; set; }
        public DateTime? DeliveryDateTime { get; set; }
        public DateTime DeliveryDateTimeStart { get; set; }
        public DateTime DeliveryDateTimeEnd { get; set; }
        public int? SenderId { get; set; }
        public int? SenderDropoffFacilityId { get; set; }
        public int? SenderAddressId { get; set; }
        public string SenderName { get; set; }
        public string SenderStreet { get; set; }
        public int SenderHouseNumber { get; set; }
        public string SenderHouseNumberSuffix { get; set; }
        public string SenderZip { get; set; }
        public string SenderCity { get; set; }
        public short SenderCountryIsoNumeric { get; set; }
        public string SenderContactPerson { get; set; }
        public string SenderPhone { get; set; }
        public string SenderGsm { get; set; }
        public string SenderEmail { get; set; }
        public int? RecipientId { get; set; }
        public int? RecipientPickupFacilityId { get; set; }
        public int? RecipientAddressId { get; set; }
        private string _RecipientName;
        public string RecipientName { get { return _RecipientName; } set { _RecipientName = (value); this.OnPropertyChanged("RecipientName"); } }
        private string _RecipientStreet;
        public string RecipientStreet { get { return _RecipientStreet; } set { _RecipientStreet = (value); this.OnPropertyChanged("RecipientStreet"); } }
        private int _RecipientHouseNumber;
        public int RecipientHouseNumber { get { return _RecipientHouseNumber; } set { _RecipientHouseNumber = (value); this.OnPropertyChanged("RecipientHouseNumber"); } }
        private string _RecipientHouseNumberSuffix;
        public string RecipientHouseNumberSuffix { get { return _RecipientHouseNumberSuffix; } set { _RecipientHouseNumberSuffix = (value); this.OnPropertyChanged("RecipientHouseNumberSuffix"); } }
        private string _RecipientZip;
        public string RecipientZip { get { return _RecipientZip; } set { _RecipientZip = (value); this.OnPropertyChanged("RecipientZip"); } }
        private string _RecipientCity;
        public string RecipientCity { get { return _RecipientCity; } set { _RecipientCity = (value); this.OnPropertyChanged("RecipientCity"); } }
        public short RecipientCountryIsoNumeric { get; set; }
        public string RecipientContactPerson { get; set; }
        public string RecipientPhone { get; set; }
        public string RecipientGsm { get; set; }
        public string RecipientEmail { get; set; }
        public int DefinedQuantityOfItems { get; set; }
        public int? RealQuantityOfItems { get; set; }
        public byte ShippingType { get; set; }
        public int ShipmentTypeId { get; set; }
        public int PaymentTypeId { get; set; }
        public int PayerTypeId { get; set; }
        public int DeliveryTypeId { get; set; }
        public int? DeliveryRouteId { get; set; }
        public int? ShipmentLinkId { get; set; }
        public string ShipmentLinkNumber { get; set; }
        public string ArepRoute { get; set; }
        public string ArepRouteSeqNum { get; set; }
        public string ArepSortInfo { get; set; }
        public int? CustomsCurrencyId { get; set; }
        public decimal? CustomsAmount { get; set; }
        public decimal? InfoValue { get; set; }
        public byte Priority { get; set; }
        public byte Status { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int Version { get; set; }
        public int? InfoValueCurrencyId { get; set; }
        public short SenderEntity { get; set; }
        public short RecipientEntity { get; set; }
        public string SenderLastName { get; set; }
        private string _RecipientLastName;
        public string RecipientLastName { get { return _RecipientLastName; } set { _RecipientLastName = (value); this.OnPropertyChanged("RecipientLastName"); } }

        public string SenderOib { get; set; }
        public string RecipientOib { get; set; }
        public string SenderContactPersonLastName { get; set; }
        public string RecipientContactPersonLastName { get; set; }
        public int? BillingUnitId { get; set; }

        public ICollection<ShipmentItem> ShipmentItem { get; set; }
        public ICollection<ShipmentNotification> ShipmentNotification { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(
                    this, new PropertyChangedEventArgs(propName));
        }

    }
}
