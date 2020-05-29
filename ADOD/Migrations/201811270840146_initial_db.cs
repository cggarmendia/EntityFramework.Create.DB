namespace CreateDB.ADOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Environment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AzureDevOpsId = c.Int(nullable: false),
                        ReleasePipelineId = c.Int(nullable: false),
                        Rank = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReleasePipeline", t => t.ReleasePipelineId, cascadeDelete: true)
                .Index(t => t.ReleasePipelineId);
            
            CreateTable(
                "dbo.ReleasePipeline",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        AzureDevOpsId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AzureDevOpsId = c.Guid(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.AzureDevOpsId, unique: true, name: "IX_Project_AzureDevOpsId")
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.BuildPipeline",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        AzureDevOpsId = c.Int(nullable: false),
                        Revision = c.Int(nullable: false),
                        Name = c.String(),
                        AuthoredBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.AzureDevOpsId, unique: true, name: "IX_BuildPipeline_AzureDevOpsId");
            
            CreateTable(
                "dbo.BuildEjecution",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        BuildPipelineId = c.Int(nullable: false),
                        AzureDevOpsId = c.Int(nullable: false),
                        Url = c.String(),
                        Status = c.String(),
                        Result = c.String(),
                        RequestedFor = c.String(),
                        RequestedBy = c.String(),
                        StartOn = c.DateTime(nullable: false),
                        FinishOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BuildPipeline", t => t.BuildPipelineId, cascadeDelete: true)
                .Index(t => t.BuildPipelineId)
                .Index(t => t.AzureDevOpsId, unique: true, name: "IX_BuildEjecution_AzureDevOpsId");
            
            CreateTable(
                "dbo.BuildChange",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildEjecutionId = c.Int(nullable: false),
                        AzureDevOpsId = c.String(),
                        Message = c.String(),
                        Author = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BuildEjecution", t => t.BuildEjecutionId, cascadeDelete: true)
                .Index(t => t.BuildEjecutionId);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AzureDevOpsName = c.String(),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReleaseEjecution",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReleasePipelineId = c.Int(nullable: false),
                        AzureDevOpsId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReleasePipeline", t => t.ReleasePipelineId, cascadeDelete: true)
                .Index(t => t.ReleasePipelineId);
            
            CreateTable(
                "dbo.Artifact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReleaseEjecutionId = c.Int(nullable: false),
                        AzureDevOpsId = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReleaseEjecution", t => t.ReleaseEjecutionId, cascadeDelete: true)
                .Index(t => t.ReleaseEjecutionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Environment", "ReleasePipelineId", "dbo.ReleasePipeline");
            DropForeignKey("dbo.ReleaseEjecution", "ReleasePipelineId", "dbo.ReleasePipeline");
            DropForeignKey("dbo.Artifact", "ReleaseEjecutionId", "dbo.ReleaseEjecution");
            DropForeignKey("dbo.ReleasePipeline", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Project", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.BuildPipeline", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.BuildEjecution", "BuildPipelineId", "dbo.BuildPipeline");
            DropForeignKey("dbo.BuildChange", "BuildEjecutionId", "dbo.BuildEjecution");
            DropIndex("dbo.Artifact", new[] { "ReleaseEjecutionId" });
            DropIndex("dbo.ReleaseEjecution", new[] { "ReleasePipelineId" });
            DropIndex("dbo.BuildChange", new[] { "BuildEjecutionId" });
            DropIndex("dbo.BuildEjecution", "IX_BuildEjecution_AzureDevOpsId");
            DropIndex("dbo.BuildEjecution", new[] { "BuildPipelineId" });
            DropIndex("dbo.BuildPipeline", "IX_BuildPipeline_AzureDevOpsId");
            DropIndex("dbo.BuildPipeline", new[] { "ProjectId" });
            DropIndex("dbo.Project", new[] { "OrganizationId" });
            DropIndex("dbo.Project", "IX_Project_AzureDevOpsId");
            DropIndex("dbo.ReleasePipeline", new[] { "ProjectId" });
            DropIndex("dbo.Environment", new[] { "ReleasePipelineId" });
            DropTable("dbo.Artifact");
            DropTable("dbo.ReleaseEjecution");
            DropTable("dbo.Organization");
            DropTable("dbo.BuildChange");
            DropTable("dbo.BuildEjecution");
            DropTable("dbo.BuildPipeline");
            DropTable("dbo.Project");
            DropTable("dbo.ReleasePipeline");
            DropTable("dbo.Environment");
        }
    }
}
