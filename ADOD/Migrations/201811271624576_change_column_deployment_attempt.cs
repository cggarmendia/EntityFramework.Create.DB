namespace CreateDB.ADOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_column_deployment_attempt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deployment", "Attempt", c => c.Int(nullable: false));
            DropColumn("dbo.Deployment", "Attemp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deployment", "Attemp", c => c.Int(nullable: false));
            DropColumn("dbo.Deployment", "Attempt");
        }
    }
}
