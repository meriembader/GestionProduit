namespace GP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migF : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ClientProducts", newName: "Factures");
            RenameColumn(table: "dbo.Factures", name: "Client_id", newName: "ProductFK");
            RenameColumn(table: "dbo.Factures", name: "Product_idProduct", newName: "ClientFK");
            RenameIndex(table: "dbo.Factures", name: "IX_Product_idProduct", newName: "IX_ClientFK");
            RenameIndex(table: "dbo.Factures", name: "IX_Client_id", newName: "IX_ProductFK");
            DropPrimaryKey("dbo.Factures");
            CreateTable(
                "dbo.Factures1",
                c => new
                    {
                        id_facture = c.Int(nullable: false, identity: true),
                        DateAchat = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        prix = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id_facture);
            
            AddColumn("dbo.Products", "Facture_id_facture", c => c.Int());
            AddColumn("dbo.Clients", "Product_idProduct", c => c.Int());
            AddPrimaryKey("dbo.Factures", new[] { "ClientFK", "ProductFK" });
            CreateIndex("dbo.Products", "Facture_id_facture");
            CreateIndex("dbo.Clients", "Product_idProduct");
            AddForeignKey("dbo.Clients", "Product_idProduct", "dbo.Products", "idProduct");
            AddForeignKey("dbo.Products", "Facture_id_facture", "dbo.Factures1", "id_facture");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Facture_id_facture", "dbo.Factures1");
            DropForeignKey("dbo.Clients", "Product_idProduct", "dbo.Products");
            DropIndex("dbo.Clients", new[] { "Product_idProduct" });
            DropIndex("dbo.Products", new[] { "Facture_id_facture" });
            DropPrimaryKey("dbo.Factures");
            DropColumn("dbo.Clients", "Product_idProduct");
            DropColumn("dbo.Products", "Facture_id_facture");
            DropTable("dbo.Factures1");
            AddPrimaryKey("dbo.Factures", new[] { "Client_id", "Product_idProduct" });
            RenameIndex(table: "dbo.Factures", name: "IX_ProductFK", newName: "IX_Client_id");
            RenameIndex(table: "dbo.Factures", name: "IX_ClientFK", newName: "IX_Product_idProduct");
            RenameColumn(table: "dbo.Factures", name: "ClientFK", newName: "Product_idProduct");
            RenameColumn(table: "dbo.Factures", name: "ProductFK", newName: "Client_id");
            RenameTable(name: "dbo.Factures", newName: "ClientProducts");
        }
    }
}
