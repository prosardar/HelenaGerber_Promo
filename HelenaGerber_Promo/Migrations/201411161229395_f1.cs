namespace HelenaGerber_Promo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Name", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
