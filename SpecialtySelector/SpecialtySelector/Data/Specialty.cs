using SpecialtySelector.Data.SpecialtySelectorEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [MaxLength(1000)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public Eqd Eqd { get; set; }

        [Required]
        public FormOfEducation FormOfEducation { get; set; }

        [StringLength(600)]
        public string Description { get; set; }

        public virtual ICollection<Subject> Subjects
        {
            get { return this.subjects; }
            set { this.subjects = value; }
        }

        public int SubDepartmentId { get; set; }
        public virtual SubDepartment SubDepartment { get; set; }
    }
}