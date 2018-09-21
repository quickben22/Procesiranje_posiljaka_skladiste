namespace Procesiranje_posiljaka_skladiste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Podaci_posiljke", "pickup_name", c => c.String());
            AddColumn("dbo.Podaci_posiljke", "pickup_street", c => c.String());
            AddColumn("dbo.Podaci_posiljke", "pickup_house_number", c => c.String());
            AddColumn("dbo.Podaci_posiljke", "pickup_house_number_suffix", c => c.String());
            AddColumn("dbo.Podaci_posiljke", "pickup_zip", c => c.String());
            AddColumn("dbo.Podaci_posiljke", "pickup_city", c => c.String());
            AddColumn("dbo.Podaci_posiljke", "damage", c => c.Int(nullable: false));
            AlterColumn("dbo.Podaci_posiljke", "reception_number", c => c.String());
            DropColumn("dbo.Podaci_posiljke", "destinacija");
            DropColumn("dbo.Podaci_posiljke", "arrival_terminal");
            DropColumn("dbo.Podaci_posiljke", "arrival_depot");
            DropColumn("dbo.Podaci_posiljke", "arrival_sorting_center");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Podaci_posiljke", "arrival_sorting_center", c => c.String());
            AddColumn("dbo.Podaci_posiljke", "arrival_depot", c => c.String());
            AddColumn("dbo.Podaci_posiljke", "arrival_terminal", c => c.String());
            AddColumn("dbo.Podaci_posiljke", "destinacija", c => c.String());
            AlterColumn("dbo.Podaci_posiljke", "reception_number", c => c.Int(nullable: false));
            DropColumn("dbo.Podaci_posiljke", "damage");
            DropColumn("dbo.Podaci_posiljke", "pickup_city");
            DropColumn("dbo.Podaci_posiljke", "pickup_zip");
            DropColumn("dbo.Podaci_posiljke", "pickup_house_number_suffix");
            DropColumn("dbo.Podaci_posiljke", "pickup_house_number");
            DropColumn("dbo.Podaci_posiljke", "pickup_street");
            DropColumn("dbo.Podaci_posiljke", "pickup_name");
        }
    }
}
