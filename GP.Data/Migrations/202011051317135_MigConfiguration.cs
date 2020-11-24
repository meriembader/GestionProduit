namespace GP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigConfiguration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "MyCategories");
            RenameTable(name: "dbo.ProviderProducts", newName: "Providings");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            RenameColumn(table: "dbo.Providings", name: "Provider_Id", newName: "provider_key");
            RenameColumn(table: "dbo.Providings", name: "Product_idProduct", newName: "product_key");
            RenameIndex(table: "dbo.Providings", name: "IX_Product_idProduct", newName: "IX_product_key");
            RenameIndex(table: "dbo.Providings", name: "IX_Provider_Id", newName: "IX_provider_key");
            DropPrimaryKey("dbo.Providings");
            AlterColumn("dbo.MyCategories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Adresse_StreetAddress", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.Providings", new[] { "product_key", "provider_key" });
            AddForeignKey("dbo.Products", "CategoryId", "dbo.MyCategories", "categoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.MyCategories");
            DropPrimaryKey("dbo.Providings");
            AlterColumn("dbo.Products", "Adresse_StreetAddress", c => c.String());
            AlterColumn("dbo.MyCategories", "Name", c => c.String());
            AddPrimaryKey("dbo.Providings", new[] { "Provider_Id", "Product_idProduct" });
            RenameIndex(table: "dbo.Providings", name: "IX_provider_key", newName: "IX_Provider_Id");
            RenameIndex(table: "dbo.Providings", name: "IX_product_key", newName: "IX_Product_idProduct");
            RenameColumn(table: "dbo.Providings", name: "product_key", newName: "Product_idProduct");
            RenameColumn(table: "dbo.Providings", name: "provider_key", newName: "Provider_Id");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "categoryId", cascadeDelete: true);
            RenameTable(name: "dbo.Providings", newName: "ProviderProducts");
            RenameTable(name: "dbo.MyCategories", newName: "Categories");
        }
    }
}
