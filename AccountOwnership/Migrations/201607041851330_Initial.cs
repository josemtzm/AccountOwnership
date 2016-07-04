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
                        Name = c.String(),
                        Code = c.Long(nullable: false),
                        GL_CLT_CD = c.String(),
                        Active = c.Boolean(nullable: false),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
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
                        EndTime = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        GoLiveDate = c.DateTime(nullable: false),
                        CloseDate = c.DateTime(nullable: false),
                        Client_Id = c.Int(nullable: false),
                        ED_Id = c.Int(nullable: false),
                        EVP_Id = c.Int(nullable: false),
                        eWFM_Id = c.Int(nullable: false),
                        Finance_Id = c.Int(nullable: false),
                        POC_Id = c.Int(),
                        Status_Id = c.Int(nullable: false),
                        SVP_Id = c.Int(nullable: false),
                        TAM_Id = c.Int(nullable: false),
                        VP_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Employees", t => t.ED_Id)
                .ForeignKey("dbo.Employees", t => t.EVP_Id)
                .ForeignKey("dbo.Employees", t => t.eWFM_Id)
                .ForeignKey("dbo.Employees", t => t.Finance_Id)
                .ForeignKey("dbo.Employees", t => t.POC_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .ForeignKey("dbo.Employees", t => t.SVP_Id)
                .ForeignKey("dbo.Employees", t => t.TAM_Id)
                .ForeignKey("dbo.Employees", t => t.VP_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.ED_Id)
                .Index(t => t.EVP_Id)
                .Index(t => t.eWFM_Id)
                .Index(t => t.Finance_Id)
                .Index(t => t.POC_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.SVP_Id)
                .Index(t => t.TAM_Id)
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
            DropForeignKey("dbo.Records", "TAM_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "SVP_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Records", "POC_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "Finance_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "eWFM_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "EVP_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "ED_Id", "dbo.Employees");
            DropForeignKey("dbo.Records", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Clients", "Parent_Id", "dbo.Clients");
            DropIndex("dbo.Records", new[] { "VP_Id" });
            DropIndex("dbo.Records", new[] { "TAM_Id" });
            DropIndex("dbo.Records", new[] { "SVP_Id" });
            DropIndex("dbo.Records", new[] { "Status_Id" });
            DropIndex("dbo.Records", new[] { "POC_Id" });
            DropIndex("dbo.Records", new[] { "Finance_Id" });
            DropIndex("dbo.Records", new[] { "eWFM_Id" });
            DropIndex("dbo.Records", new[] { "EVP_Id" });
            DropIndex("dbo.Records", new[] { "ED_Id" });
            DropIndex("dbo.Records", new[] { "Client_Id" });
            DropIndex("dbo.Clients", new[] { "Parent_Id" });
            DropTable("dbo.Status");
            DropTable("dbo.Records");
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
        }
    }
}
