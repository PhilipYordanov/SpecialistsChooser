using System.Collections.Generic;

namespace SpecialtySelector.Data
{
    public class Subject
    {
        private ICollection<Teacher> teachers;

        public Subject()
        {
            this.teachers = new HashSet<Teacher>();
        }

        public virtual ICollection<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMandatory { get; set; }
        public int Credits { get; set; }
        public int Course { get; set; }

        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }

        // Introducing FOREIGN KEY constraint 'FK_dbo.Subjects_dbo.Teachers_TeacherId' 
        // on table 'Subjects' may cause cycles or multiple cascade paths
        // Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints

        // public int TeacherId { get; set; }
        // public virtual Teacher Teacher { get; set; }
    }
}