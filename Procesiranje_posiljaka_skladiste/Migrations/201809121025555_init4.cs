namespace Procesiranje_posiljaka_skladiste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.customers",
                c => new
                    {
                        customerID = c.Int(nullable: false, identity: true),
                        reception_number = c.String(),
                        name = c.String(),
                        lastname = c.String(),
                    })
                .PrimaryKey(t => t.customerID);
            
            CreateTable(
                "dbo.Podaci_paketa",
                c => new
                    {
                        PaketID = c.Int(nullable: false, identity: true),
                        posiljka_id = c.Int(nullable: false),
                        packet_type = c.Int(nullable: false),
                        damage = c.Int(nullable: false),
                        weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PaketID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Podaci_paketa");
            DropTable("dbo.customers");
        }
    }
}
