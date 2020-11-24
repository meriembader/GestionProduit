namespace GP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_categoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_categoryId" });
            RenameColumn(table: "dbo.Products", name: "Category_categoryId", newName: "CategoryId");
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Providers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Providers", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "categoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Providers", "Password", c => c.String());
            AlterColumn("dbo.Providers", "Email", c => c.String());
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            AlterColumn("dbo.Products", "Name", c => c.String());
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_categoryId");
            CreateIndex("dbo.Products", "Category_categoryId");
            AddForeignKey("dbo.Products", "Category_categoryId", "dbo.Categories", "categoryId");
        }
    }
}
