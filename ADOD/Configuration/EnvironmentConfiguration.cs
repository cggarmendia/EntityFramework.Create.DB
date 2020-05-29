using CreateDB.Common;
using CreateDB.ADOD.Entities;

namespace CreateDB.ADOD.Configuration
{
    public class EnvironmentConfiguration : DbContextBaseConfiguration<Environment>
    {
        #region Ctor.
        public EnvironmentConfiguration()
            : base()
        {
            ToTable("Environment");
            HasKey(e => e.Id);

            HasRequired(e => e.ReleasePipeline)
                .WithMany(rp => rp.Environments)
                .HasForeignKey(e => e.ReleasePipelineId);
        }
        #endregion
    }
}
