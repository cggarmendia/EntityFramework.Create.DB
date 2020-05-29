using CreateDB.Common;
using CreateDB.ADOD.Entities;

namespace CreateDB.ADOD.Configuration
{
    public class ReleasePipelineConfiguration : DbContextBaseConfiguration<ReleasePipeline>
    {
        #region Ctor.
        public ReleasePipelineConfiguration()
            : base()
        {
            ToTable("ReleasePipeline");
            HasKey(dt => dt.Id);

            HasRequired(rp => rp.Project)
                .WithMany(p => p.ReleasePipelines)
                .HasForeignKey(rp => rp.ProjectId);
        }
        #endregion
    }
}
