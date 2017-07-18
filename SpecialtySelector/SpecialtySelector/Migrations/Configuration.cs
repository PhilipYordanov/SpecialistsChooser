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
        }
    }
}
