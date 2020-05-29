namespace CreateDB.ADOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_releaseEjecutionEnvironment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReleaseEjecutionEnvironment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AzureDevOpsId = c.Int(nullable: false),
                        ReleaseEjecutionId = c.Int(nullable: false),
                        EnvironmentId = c.Int(nullable: false),
                        EnvironmentName = c.String(),
                        LastDeploymentStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Environment", t => t.EnvironmentId, cascadeDelete: false)
                .ForeignKey("dbo.ReleaseEjecution", t => t.ReleaseEjecutionId, cascadeDelete: false)
                .Index(t => t.ReleaseEjecutionId)
                .Index(t => t.EnvironmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReleaseEjecutionEnvironment", "ReleaseEjecutionId", "dbo.ReleaseEjecution");
            DropForeignKey("dbo.ReleaseEjecutionEnvironment", "EnvironmentId", "dbo.Environment");
            DropIndex("dbo.ReleaseEjecutionEnvironment", new[] { "EnvironmentId" });
            DropIndex("dbo.ReleaseEjecutionEnvironment", new[] { "ReleaseEjecutionId" });
            DropTable("dbo.ReleaseEjecutionEnvironment");
        }
    }
}
