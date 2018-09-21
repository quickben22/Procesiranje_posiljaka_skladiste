namespace Procesiranje_posiljaka_skladiste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Podaci_paketa", "posiljka_id");
            AddForeignKey("dbo.Podaci_paketa", "posiljka_id", "dbo.Podaci_posiljke", "PosiljkaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Podaci_paketa", "posiljka_id", "dbo.Podaci_posiljke");
            DropIndex("dbo.Podaci_paketa", new[] { "posiljka_id" });
        }
    }
}
