using Procesiranje_posiljaka_skladiste.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Procesiranje_posiljaka_skladiste.DAL
{
    class PodaciContext : DbContext
    {

        public PodaciContext()
          : base("Procesiranje_lokalna_baza")
        {
            
            AppDomain.CurrentDomain.SetData("DataDirectory", @"D:\VS2017\Procesiranje_posiljaka_skladiste\Procesiranje_posiljaka_skladiste\Procesiranje_posiljaka_skladiste\bin\Debug\");
        }

        public DbSet<Podaci_posiljke> Podaci_posiljkes { get; set; }
        public DbSet<Podaci_paketa> Podaci_paketas { get; set; }
        public DbSet<customer> customers { get; set; }

        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
        public DbSet<ShipmentNotification> ShipmentNotifications { get; set; }
        public DbSet<Event> Events { get; set; }

    }
}
