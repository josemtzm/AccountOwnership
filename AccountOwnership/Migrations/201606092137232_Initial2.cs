namespace AccountOwnership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Code", c => c.String());
            AddColumn("dbo.Records", "Client_Id", c => c.Int());
            CreateIndex("dbo.Records", "Client_Id");
            AddForeignKey("dbo.Records", "Client_Id", "dbo.Clients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Records", new[] { "Client_Id" });
            DropColumn("dbo.Records", "Client_Id");
            DropColumn("dbo.Clients", "Code");
        }
    }
}
