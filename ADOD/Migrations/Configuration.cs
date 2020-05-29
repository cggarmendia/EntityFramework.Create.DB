namespace CreateDB.ADOD.Migrations
{
    using CreateDB.ADOD.Context;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ADODContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"ADOD\Migrations";
        }

        protected override void Seed(ADODContext context)
        {
        }
    }
}
