using System.Linq;
using SpecialtySelector.Data;

namespace SpecialtySelector.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<SpecialtySelector.Data.SpecialtySelectorDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "SpecialtySelector.Data.SpecialtySelectorDbContext";
        }

        protected override void Seed(SpecialtySelectorDbContext context)
        {
            if (context.Departments.Any())
            {
                return;
            }
            context.Departments.Add(new Department()
            {
                Name = "Test",
            });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
