using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpecialtySelector.Data
{
    public class SubDepartment
    {
        private ICollection<Specialty> specialties;

        public SubDepartment()
        {
            this.specialties = new HashSet<Specialty>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Specialty> Specialties
        {
            get { return this.specialties; }
            set { this.specialties = value; }
        }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}