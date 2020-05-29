using CreateDB.Common;
using CreateDB.ADOD.Entities;

namespace CreateDB.ADOD.Configuration
{
    public class OrganizationConfiguration : DbContextBaseConfiguration<Organization>
    {
        #region Ctor.
        public OrganizationConfiguration()
            : base()
        {
            ToTable("Organization");
            HasKey(dt => dt.Id);
        }
        #endregion
    }
}
