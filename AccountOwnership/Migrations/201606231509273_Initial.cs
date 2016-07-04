namespace AccountOwnership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Records", "GL_CLT_CD", c => c.String());
            AlterColumn("dbo.Records", "POC", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Records", "POC", c => c.String(nullable: false));
            AlterColumn("dbo.Records", "GL_CLT_CD", c => c.String(nullable: false));
        }
    }
}
