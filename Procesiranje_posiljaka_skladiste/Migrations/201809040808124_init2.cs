namespace Procesiranje_posiljaka_skladiste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Podaci_posiljke", "reception_number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Podaci_posiljke", "reception_number", c => c.Double(nullable: false));
        }
    }
}
