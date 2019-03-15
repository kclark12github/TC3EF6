using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TC3EF6.Data.CustomMigrationOperations;

namespace TC3EF6.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TCContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new TCMigrationSqlGenerator());
        }
        protected override void Seed(TCContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            CustomSeed.Seed(context);
        }
    }
}
