namespace HelenaGerber_Promo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "FileName1", c => c.String());
            AddColumn("dbo.Product", "FileName2", c => c.String());
            AddColumn("dbo.Product", "FileName3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "FileName3");
            DropColumn("dbo.Product", "FileName2");
            DropColumn("dbo.Product", "FileName1");
        }
    }
}
