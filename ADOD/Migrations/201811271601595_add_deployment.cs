namespace CreateDB.ADOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_deployment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deployment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AzureDevOpsId = c.Int(nullable: false),
                        ReleaseEjecutionEnvironmentId = c.Int(nullable: false),
                        Attemp = c.Int(nullable: false),
                        HasStarted = c.Boolean(nullable: false),
                        RequestedBy = c.String(),
                        RequestedFor = c.String(),
                        OperationStatus = c.String(),
                        Reason = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReleaseEjecutionEnvironment", t => t.ReleaseEjecutionEnvironmentId, cascadeDelete: true)
                .Index(t => t.ReleaseEjecutionEnvironmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deployment", "ReleaseEjecutionEnvironmentId", "dbo.ReleaseEjecutionEnvironment");
            DropIndex("dbo.Deployment", new[] { "ReleaseEjecutionEnvironmentId" });
            DropTable("dbo.Deployment");
        }
    }
}
