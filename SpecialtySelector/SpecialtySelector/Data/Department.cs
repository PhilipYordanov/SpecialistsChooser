using System.Collections.Generic;

namespace SpecialtySelector.Data
{
    public class Department
    {
        private ICollection<SubDepartment> subDepartments;

        public Department()
        {
            this.subDepartments = new HashSet<SubDepartment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubDepartment> SubDepartments
        {
            get { return this.subDepartments; }
            set { this.subDepartments = value; }
        }
    }
}