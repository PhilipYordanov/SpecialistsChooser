using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpecialtySelector.Data
{
    public class Subject
    {
        private ICollection<Teacher> teachers;
        private ICollection<Specialty> specialties;

        public Subject()
        {
            this.teachers = new HashSet<Teacher>();
            this.specialties = new HashSet<Specialty>();
        }

        public virtual ICollection<Specialty> Specialties
        {
            get { return this.specialties; }
            set { this.specialties = value; }
        }

        public virtual ICollection<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        [MinLength(1)]
        public string Name { get; set; }
        
        public bool IsMandatory { get; set; }
        
        public int Credits { get; set; }

        [Required]
        public int Course { get; set; }

        [StringLength(600)]
        public string Description { get; set; }
    }
}