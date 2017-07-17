using System.Collections.Generic;
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
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}