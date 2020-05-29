using CreateDB.Common;
using CreateDB.ADOD.Entities;

namespace CreateDB.ADOD.Configuration
{
    public class ReleaseEjecutionConfiguration : DbContextBaseConfiguration<ReleaseEjecution>
    {
        #region Ctor.
        public ReleaseEjecutionConfiguration()
            : base()
        {
            ToTable("ReleaseEjecution");
            HasKey(dt => dt.Id);

            HasRequired(re => re.ReleasePipeline)
                .WithMany(rp => rp.ReleaseEjecutions)
                .HasForeignKey(re => re.ReleasePipelineId);
        }
        #endregion
    }
}
