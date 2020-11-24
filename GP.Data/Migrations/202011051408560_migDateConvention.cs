namespace GP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migDateConvention : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Biologicals", "idProduct", "dbo.Products");
            DropForeignKey("dbo.Chemicals", "idProduct", "dbo.Products");
            DropIndex("dbo.Biologicals", new[] { "idProduct" });
            DropIndex("dbo.Chemicals", new[] { "idProduct" });
            AddColumn("dbo.Products", "Herbs", c => c.String());
            AddColumn("dbo.Products", "LabName", c => c.String());
            AddColumn("dbo.Products", "Adresse_StreetAddress", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "Adresse_City", c => c.String());
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Products", "DateProd", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Providers", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropTable("dbo.Biologicals");
            DropTable("dbo.Chemicals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Chemicals",
                c => new
                    {
                        idProduct = c.Int(nullable: false),
                        LabName = c.String(),
                        Adresse_StreetAddress = c.String(maxLength: 50),
                        Adresse_City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idProduct);
            
            CreateTable(
                "dbo.Biologicals",
                c => new
                    {
                        idProduct = c.Int(nullable: false),
                        Herbs = c.String(),
                    })
                .PrimaryKey(t => t.idProduct);
            
            AlterColumn("dbo.Providers", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "DateProd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Products", "Discriminator");
            DropColumn("dbo.Products", "Adresse_City");
            DropColumn("dbo.Products", "Adresse_StreetAddress");
            DropColumn("dbo.Products", "LabName");
            DropColumn("dbo.Products", "Herbs");
            CreateIndex("dbo.Chemicals", "idProduct");
            CreateIndex("dbo.Biologicals", "idProduct");
            AddForeignKey("dbo.Chemicals", "idProduct", "dbo.Products", "idProduct");
            AddForeignKey("dbo.Biologicals", "idProduct", "dbo.Products", "idProduct");
        }
    }
}
