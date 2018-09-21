namespace Procesiranje_posiljaka_skladiste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        ShortName = c.String(),
                        HarmonizedName = c.String(),
                        EventTypeId = c.Int(nullable: false),
                        EventGroupId = c.Int(),
                        ShowOnWeb = c.Boolean(),
                        UseForNotification = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShipmentNotifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShipmentId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsProcessed = c.Boolean(nullable: false),
                        IsCanceled = c.Boolean(nullable: false),
                        TrackTraceShipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Shipments", t => t.ShipmentId, cascadeDelete: true)
                .Index(t => t.ShipmentId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        OrderId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        ShippingDateTime = c.DateTime(),
                        DeliveryDateTime = c.DateTime(),
                        DeliveryDateTimeStart = c.DateTime(nullable: false),
                        DeliveryDateTimeEnd = c.DateTime(nullable: false),
                        SenderId = c.Int(),
                        SenderDropoffFacilityId = c.Int(),
                        SenderAddressId = c.Int(),
                        SenderName = c.String(),
                        SenderStreet = c.String(),
                        SenderHouseNumber = c.Int(nullable: false),
                        SenderHouseNumberSuffix = c.String(),
                        SenderZip = c.String(),
                        SenderCity = c.String(),
                        SenderCountryIsoNumeric = c.Short(nullable: false),
                        SenderContactPerson = c.String(),
                        SenderPhone = c.String(),
                        SenderGsm = c.String(),
                        SenderEmail = c.String(),
                        RecipientId = c.Int(),
                        RecipientPickupFacilityId = c.Int(),
                        RecipientAddressId = c.Int(),
                        RecipientName = c.String(),
                        RecipientStreet = c.String(),
                        RecipientHouseNumber = c.Int(nullable: false),
                        RecipientHouseNumberSuffix = c.String(),
                        RecipientZip = c.String(),
                        RecipientCity = c.String(),
                        RecipientCountryIsoNumeric = c.Short(nullable: false),
                        RecipientContactPerson = c.String(),
                        RecipientPhone = c.String(),
                        RecipientGsm = c.String(),
                        RecipientEmail = c.String(),
                        DefinedQuantityOfItems = c.Int(nullable: false),
                        RealQuantityOfItems = c.Int(),
                        ShippingType = c.Byte(nullable: false),
                        ShipmentTypeId = c.Int(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        PayerTypeId = c.Int(nullable: false),
                        DeliveryTypeId = c.Int(nullable: false),
                        DeliveryRouteId = c.Int(),
                        ShipmentLinkId = c.Int(),
                        ShipmentLinkNumber = c.String(),
                        ArepRoute = c.String(),
                        ArepRouteSeqNum = c.String(),
                        ArepSortInfo = c.String(),
                        CustomsCurrencyId = c.Int(),
                        CustomsAmount = c.Decimal(precision: 18, scale: 2),
                        InfoValue = c.Decimal(precision: 18, scale: 2),
                        Priority = c.Byte(nullable: false),
                        Status = c.Byte(nullable: false),
                        Note = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Version = c.Int(nullable: false),
                        InfoValueCurrencyId = c.Int(),
                        SenderEntity = c.Short(nullable: false),
                        RecipientEntity = c.Short(nullable: false),
                        SenderLastName = c.String(),
                        RecipientLastName = c.String(),
                        SenderOib = c.String(),
                        RecipientOib = c.String(),
                        SenderContactPersonLastName = c.String(),
                        RecipientContactPersonLastName = c.String(),
                        BillingUnitId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShipmentItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Barcode = c.String(),
                        OrderId = c.Int(nullable: false),
                        ShipmentId = c.Int(),
                        ShipmentItemTypeId = c.Int(),
                        BillingUnitId = c.Int(nullable: false),
                        OfferTariffId = c.Int(),
                        GoodsTypeId = c.Int(),
                        DefinedWeight = c.Decimal(precision: 18, scale: 2),
                        RealWeightNet = c.Decimal(precision: 18, scale: 2),
                        RealWeightGross = c.Decimal(precision: 18, scale: 2),
                        Length = c.Decimal(precision: 18, scale: 2),
                        Width = c.Decimal(precision: 18, scale: 2),
                        Heigth = c.Decimal(precision: 18, scale: 2),
                        VolumetricWeight = c.Decimal(precision: 18, scale: 2),
                        TourCount = c.Byte(nullable: false),
                        Note = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Version = c.Int(nullable: false),
                        Status = c.Byte(),
                        AdditionalCollect = c.Boolean(nullable: false),
                        TransportUnitId = c.Int(),
                        ReturnToSender = c.Boolean(nullable: false),
                        Damage = c.Byte(nullable: false),
                        Missorted = c.Boolean(nullable: false),
                        Missrouted = c.Boolean(nullable: false),
                        MissroutedValidZip = c.String(),
                        BulkyHandling = c.Boolean(nullable: false),
                        InsuranceValue = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shipments", t => t.ShipmentId)
                .Index(t => t.ShipmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipmentNotifications", "ShipmentId", "dbo.Shipments");
            DropForeignKey("dbo.ShipmentItems", "ShipmentId", "dbo.Shipments");
            DropForeignKey("dbo.ShipmentNotifications", "EventId", "dbo.Events");
            DropIndex("dbo.ShipmentItems", new[] { "ShipmentId" });
            DropIndex("dbo.ShipmentNotifications", new[] { "EventId" });
            DropIndex("dbo.ShipmentNotifications", new[] { "ShipmentId" });
            DropTable("dbo.ShipmentItems");
            DropTable("dbo.Shipments");
            DropTable("dbo.ShipmentNotifications");
            DropTable("dbo.Events");
        }
    }
}
