using CreateDB.Common;
using CreateDB.ADOD.Entities;

namespace CreateDB.ADOD.Configuration
{
    public class DeploymentConfiguration : DbContextBaseConfiguration<Deployment>
    {
        #region Ctor.
        public DeploymentConfiguration()
            : base()
        {
            ToTable("Deployment");
            HasKey(a => a.Id);

            HasRequired(d => d.ReleaseEjecutionEnvironment)
                .WithMany(re => re.Deployments)
                .HasForeignKey(d => d.ReleaseEjecutionEnvironmentId);
        }
        #endregion
    }
}
