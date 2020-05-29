namespace CreateDB.ADOD.Context
{
    using CreateDB.Common;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Reflection;

    public class ADODContext : DbContext
    {
        #region Ctor.        
        public ADODContext()
            : base("name=ADODContext")
        {
        }
        #endregion

        #region DBSets.
        //public DbSet<Organization> Organizations { get; set; }
        //public DbSet<Project> Projects { get; set; }
        //public DbSet<BuildPipeline> BuildPipelines { get; set; }
        //public DbSet<BuildEjecution> BuildEjecutions { get; set; }
        //public DbSet<BuildChange> BuildChanges { get; set; }
        //public DbSet<ReleasePipeline> ReleasePipelines { get; set; }
        //public DbSet<ReleaseEjecution> ReleaseEjecutions { get; set; }
        #endregion

        #region Methods.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            LoadEntityTypeConfiguration(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void LoadEntityTypeConfiguration(DbModelBuilder modelBuilder)
        {
            // Load entityTypeConfiguration by reflection.
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type != typeof(DbContextBaseConfiguration<>) &&
                               (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>) ||
                                type.BaseType.GetGenericTypeDefinition() == typeof(DbContextBaseConfiguration<>)));

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
                modelBuilder.Configurations.Add((dynamic)configurationInstance);
        }
        #endregion
    }

}