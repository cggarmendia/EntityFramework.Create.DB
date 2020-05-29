namespace CreateDB.ADOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_column_releaseEjecutionEnvironment_environmentId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReleaseEjecutionEnvironment", "EnvironmentId", "dbo.Environment");
            DropIndex("dbo.ReleaseEjecutionEnvironment", new[] { "EnvironmentId" });
            AlterColumn("dbo.ReleaseEjecutionEnvironment", "EnvironmentId", c => c.Int());
            CreateIndex("dbo.ReleaseEjecutionEnvironment", "EnvironmentId");
            AddForeignKey("dbo.ReleaseEjecutionEnvironment", "EnvironmentId", "dbo.Environment", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReleaseEjecutionEnvironment", "EnvironmentId", "dbo.Environment");
            DropIndex("dbo.ReleaseEjecutionEnvironment", new[] { "EnvironmentId" });
            AlterColumn("dbo.ReleaseEjecutionEnvironment", "EnvironmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReleaseEjecutionEnvironment", "EnvironmentId");
            AddForeignKey("dbo.ReleaseEjecutionEnvironment", "EnvironmentId", "dbo.Environment", "Id", cascadeDelete: true);
        }
    }
}
