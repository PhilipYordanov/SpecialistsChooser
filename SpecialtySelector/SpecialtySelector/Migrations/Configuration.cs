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
            else
            {
                context.Departments.Add(new Department()
                {
                    Name = "test specialty",
                    Description = "Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Donec sollicitudin molestie malesuada. Donec rutrum congue leo eget malesuada. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui. Donec rutrum congue leo eget malesuada. Quisque velit nisi, pretium ut lacinia in, elementum id enim. Nulla porttitor accumsan tincidunt. Quisque velit nisi, pretium ut lacinia in, elementum id enim. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                });
                context.Departments.Add(new Department()
                {
                    Name = "test specialty 2",
                    Description = "Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Donec sollicitudin molestie malesuada. Donec rutrum congue leo eget malesuada. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui. Donec rutrum congue leo eget malesuada. Quisque velit nisi, pretium ut lacinia in, elementum id enim. Nulla porttitor accumsan tincidunt. Quisque velit nisi, pretium ut lacinia in, elementum id enim. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                });
            }

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
