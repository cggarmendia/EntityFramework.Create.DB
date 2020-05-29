using CreateDB.Common;
using CreateDB.ADOD.Entities;

namespace CreateDB.ADOD.Configuration
{
    public class ReleaseEjecutionEnvironmentConfiguration : DbContextBaseConfiguration<ReleaseEjecutionEnvironment>
    {
        #region Ctor.
        public ReleaseEjecutionEnvironmentConfiguration()
            : base()
        {
            ToTable("ReleaseEjecutionEnvironment");
            HasKey(dt => dt.Id);

            HasRequired(ree => ree.ReleaseEjecution)
                .WithMany(re => re.ReleaseEjecutionEnvironments)
                .HasForeignKey(ree => ree.ReleaseEjecutionId);

            HasOptional(ree => ree.Environment)
                .WithMany(e => e.ReleaseEjecutionEnvironments)
                .HasForeignKey(ree => ree.EnvironmentId);
        }
        #endregion
    }
}
