using CreateDB.Common;
using CreateDB.ADOD.Entities;

namespace CreateDB.ADOD.Configuration
{
    public class BuildChangeConfiguration : DbContextBaseConfiguration<BuildChange>
    {
        #region Ctor.
        public BuildChangeConfiguration()
            : base()
        {
            ToTable("BuildChange");
            HasKey(dt => dt.Id);

            HasRequired(bc => bc.BuildEjecution)
                .WithMany(be => be.BuildChanges)
                .HasForeignKey(bc => bc.BuildEjecutionId);

            // ToDo: Add index for AzureDevOpsId (Type > string).
            //Property(bc => bc.AzureDevOpsId).IsRequired()
            //          .HasUniqueIndexAnnotation("IX_BuildChange_AzureDevOpsId", 0);
        }
        #endregion
    }
}
