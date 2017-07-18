using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            if (!context.Users.Any())
            {
                CreateUser(context, "Admin@gmail.com", "Admin@gmail.com");
                
            }
            if (context.Departments.Any())
            {
                return;
            }
            context.Departments.Add(new Department()
            {
                Name = "Test",
            });
        }

        private void CreateUser(SpecialtySelectorDbContext context,
            string email,
            string password
        )
        {
            var userManager = new UserManager<User>(new UserStore<User>(context))
            {
                PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 1,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                }
            };
            var user = new User
            {
                UserName = email,
                Email = email,
            };
            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }
    }
}
