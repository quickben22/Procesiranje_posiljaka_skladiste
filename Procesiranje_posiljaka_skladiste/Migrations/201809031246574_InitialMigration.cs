namespace Procesiranje_posiljaka_skladiste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Podaci_posiljke",
                c => new
                    {
                        PosiljkaID = c.Int(nullable: false, identity: true),
                        reception_number = c.Double(nullable: false),
                        weight = c.Double(nullable: false),
                        destinacija = c.String(),
                        arrival_terminal = c.String(),
                        arrival_depot = c.String(),
                        arrival_sorting_center = c.String(),
                    })
                .PrimaryKey(t => t.PosiljkaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Podaci_posiljke");
        }
    }
}
