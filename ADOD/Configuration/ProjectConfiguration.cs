using CreateDB.Common;
using CreateDB.ADOD.Entities;

namespace CreateDB.ADOD.Configuration
{
    public class ProjectConfiguration : DbContextBaseConfiguration<Project>
    {
        #region Ctor.
        public ProjectConfiguration()
            : base()
        {
            ToTable("Project");
            HasKey(dt => dt.Id);

            HasRequired(p => p.Organization)
                .WithMany(o => o.Projects)
                .HasForeignKey(p => p.OrganizationId);

            Property(p => p.AzureDevOpsId).IsRequired()
                      .HasUniqueIndexAnnotation("IX_Project_AzureDevOpsId", 0);
        }
        #endregion
    }
}
