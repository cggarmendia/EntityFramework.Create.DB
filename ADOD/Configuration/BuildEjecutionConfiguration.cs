using CreateDB.Common;
using CreateDB.ADOD.Entities;

namespace CreateDB.ADOD.Configuration
{
    public class BuildEjecutionConfiguration : DbContextBaseConfiguration<BuildEjecution>
    {
        #region Ctor.
        public BuildEjecutionConfiguration()
            : base()
        {
            ToTable("BuildEjecution");
            HasKey(dt => dt.Id);

            HasRequired(be => be.BuildPipeline)
                .WithMany(bp => bp.BuildEjecutions)
                .HasForeignKey(be => be.BuildPipelineId);

            Property(be => be.AzureDevOpsId).IsRequired()
                      .HasUniqueIndexAnnotation("IX_BuildEjecution_AzureDevOpsId", 0);
        }
        #endregion
    }
}
