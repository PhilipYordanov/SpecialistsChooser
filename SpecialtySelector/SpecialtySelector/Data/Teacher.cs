using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SpecialtySelector.Data.SpecialtySelectorEnums;

namespace SpecialtySelector.Data
{
    public class Teacher
    {
        private ICollection<Subject> subjects;
        
        public Teacher()
        {
            this.subjects = new HashSet<Subject>();
        }

        public virtual ICollection<Subject> Subjects
        {
            get { return this.subjects; }
            set { this.subjects = value; }
        }
        
        public int Id { get; set; }
        public Degree Degree { get; set; }
        public AcademicTitle AcademicTitle { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string TeacherInfo { get; set; }

        public DateTime? FiredOn { get; set; }
    }
}