using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesiranje_posiljaka_skladiste.Models
{
    public class ShipmentNotification
    {
       

        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public int EventId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsProcessed { get; set; }
        public bool IsCanceled { get; set; }
        public int TrackTraceShipmentId { get; set; }

        public Event Event { get; set; }
        public Shipment Shipment { get; set; }
        


    }
}
