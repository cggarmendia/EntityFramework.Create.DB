using CreateDB.Common;
using CreateDB.ADOD.Entities;

namespace CreateDB.ADOD.Configuration
{
    public class ArtifactConfiguration : DbContextBaseConfiguration<Artifact>
    {
        #region Ctor.
        public ArtifactConfiguration()
            : base()
        {
            ToTable("Artifact");
            HasKey(a => a.Id);

            HasRequired(a => a.ReleaseEjecution)
                .WithMany(re => re.Artifacts)
                .HasForeignKey(a => a.ReleaseEjecutionId);
        }
        #endregion
    }
}
