using SpecialtySelector.Data.SpecialtySelectorEnums;
using System.Collections.Generic;

namespace SpecialtySelector.Data
{
    public class Specialty
    {
        private ICollection<Subject> subjects;

        public Specialty()
        {
            this.subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Eqd Eqd { get; set; }
        public FormOfEducation FormOfEducation { get; set; }

        public virtual ICollection<Subject> Subjects
        {
            get { return this.subjects; }
            set { this.subjects = value; }
        }

        public int SubDepartmentId { get; set; }
        public virtual SubDepartment SubDepartment { get; set; }
    }

}