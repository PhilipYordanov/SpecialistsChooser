using SpecialtySelector.Data.SpecialtySelectorEnums;
using System.Collections.Generic;

namespace SpecialtySelector.Data
{
    public class Specialty
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public FormOfEducation FormOfEducation { get; set; }
        
        public virtual ICollection<Subject> Subjects { get; set; }

        public Eqd Eqd { get; set; }
       
        public int SubDepartmentId { get; set; }

        public virtual SubDepartment SubDepartment { get; set; }
    }
}