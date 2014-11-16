namespace HelenaGerber_Promo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductColor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Description",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductColor", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Model", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductSize", t => t.SizeId, cascadeDelete: true)
                .ForeignKey("dbo.ProductType", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.TypeId)
                .Index(t => t.ModelId)
                .Index(t => t.SizeId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Goal = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        SKU = c.Int(nullable: false),
                        ImageStoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ImageStore", t => t.ImageStoreId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ImageStoreId);
            
            CreateTable(
                "dbo.ImageStore",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName1 = c.String(),
                        FileName2 = c.String(),
                        FileName3 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductSize",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fabric",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Сontents = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Material", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fabric", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Fabric", "MaterialId", "dbo.Material");
            DropForeignKey("dbo.Description", "TypeId", "dbo.ProductType");
            DropForeignKey("dbo.Description", "SizeId", "dbo.ProductSize");
            DropForeignKey("dbo.Description", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ImageStoreId", "dbo.ImageStore");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Description", "ModelId", "dbo.Model");
            DropForeignKey("dbo.Description", "ColorId", "dbo.ProductColor");
            DropIndex("dbo.Fabric", new[] { "MaterialId" });
            DropIndex("dbo.Fabric", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "ImageStoreId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Description", new[] { "ColorId" });
            DropIndex("dbo.Description", new[] { "SizeId" });
            DropIndex("dbo.Description", new[] { "ModelId" });
            DropIndex("dbo.Description", new[] { "TypeId" });
            DropIndex("dbo.Description", new[] { "ProductId" });
            DropTable("dbo.Material");
            DropTable("dbo.Fabric");
            DropTable("dbo.ProductType");
            DropTable("dbo.ProductSize");
            DropTable("dbo.ImageStore");
            DropTable("dbo.Product");
            DropTable("dbo.Model");
            DropTable("dbo.Description");
            DropTable("dbo.ProductColor");
            DropTable("dbo.Category");
        }
    }
}
