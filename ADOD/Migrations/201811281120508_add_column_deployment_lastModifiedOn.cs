namespace CreateDB.ADOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_deployment_lastModifiedOn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deployment", "LastModifiedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deployment", "LastModifiedOn");
        }
    }
}
