namespace AccountOwnership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Code", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Code", c => c.String());
        }
    }
}
