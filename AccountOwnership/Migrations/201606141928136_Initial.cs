namespace AccountOwnership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdParent = c.Int(nullable: false),
                        Code = c.Long(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Kronos = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        GL_CLT_CD = c.String(),
                        EndTime = c.DateTime(nullable: false),
                        POC = c.String(),
                        LastModifiedDate = c.DateTime(nullable: false),
                        GoLiveDate = c.DateTime(nullable: false),
                        CloseDate = c.DateTime(nullable: false),
                        Client_Id = c.Int(),
                        ED_Id = c.Int(),
                        EVP_Id = c.Int(),
                        Status_Id = c.Int(nullable: false),
                        SVP_Id = c.Int(),
                        VP_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Employees", t => t.ED_Id)
                .ForeignKey("dbo.Employees", t => t.EVP_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.SVP_Id)
                .ForeignKey("dbo.Employees", t => t.VP_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.ED_Id)
                .Index(t => t.EVP_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.SVP_Id)
                .Index(t => t.VP_Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "VP_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "SVP_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Records", "EVP_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "ED_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Records", new[] { "VP_Id" });
            DropIndex("dbo.Records", new[] { "SVP_Id" });
            DropIndex("dbo.Records", new[] { "Status_Id" });
            DropIndex("dbo.Records", new[] { "EVP_Id" });
            DropIndex("dbo.Records", new[] { "ED_Id" });
            DropIndex("dbo.Records", new[] { "Client_Id" });
            DropTable("dbo.Status");
            DropTable("dbo.Records");
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
        }
    }
}
