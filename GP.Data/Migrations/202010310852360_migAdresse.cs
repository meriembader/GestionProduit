namespace GP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migAdresse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Adresse_StreetAddress", c => c.String());
            AddColumn("dbo.Products", "Adresse_City", c => c.String());
            DropColumn("dbo.Products", "City");
            DropColumn("dbo.Products", "StreetAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "StreetAddress", c => c.String());
            AddColumn("dbo.Products", "City", c => c.String());
            DropColumn("dbo.Products", "Adresse_City");
            DropColumn("dbo.Products", "Adresse_StreetAddress");
        }
    }
}
