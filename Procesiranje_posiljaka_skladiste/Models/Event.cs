using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesiranje_posiljaka_skladiste.Models
{
    public class Event
    {
        public Event()
        {
            ShipmentNotification = new HashSet<ShipmentNotification>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string HarmonizedName { get; set; }
        public int EventTypeId { get; set; }
        public int? EventGroupId { get; set; }
        public bool? ShowOnWeb { get; set; }
        public bool UseForNotification { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int Version { get; set; }

        public ICollection<ShipmentNotification> ShipmentNotification { get; set; }
    }
}
