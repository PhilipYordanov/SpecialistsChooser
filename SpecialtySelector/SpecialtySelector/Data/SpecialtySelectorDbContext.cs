using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SpecialtySelector.Data
{
    public class SpecialtySelectorDbContext : IdentityDbContext<User>
    {
        public SpecialtySelectorDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<SubDepartment> SubDepartments { get; set; }

        public virtual DbSet<Specialty> Specialties { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public static SpecialtySelectorDbContext Create()
        {
            return new SpecialtySelectorDbContext();
        }
    }
}