using CreateDB.Common;
using CreateDB.ADOD.Entities;

namespace CreateDB.ADOD.Configuration
{
    public class BuildPipelineConfiguration : DbContextBaseConfiguration<BuildPipeline>
    {
        #region Ctor.
        public BuildPipelineConfiguration()
            : base()
        {
            ToTable("BuildPipeline");
            HasKey(dt => dt.Id);

            HasRequired(bp => bp.Project)
                .WithMany(p => p.BuildPipelines)
                .HasForeignKey(bp => bp.ProjectId);

            Property(bp => bp.AzureDevOpsId).IsRequired()
                      .HasUniqueIndexAnnotation("IX_BuildPipeline_AzureDevOpsId", 0);
        }
        #endregion
    }
}
