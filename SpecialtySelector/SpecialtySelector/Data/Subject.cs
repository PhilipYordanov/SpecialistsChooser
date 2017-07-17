using System.Collections.Generic;

namespace SpecialtySelector.Data
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsMandatory { get; set; }
        
        public virtual ICollection<Teacher> Teachers { get; set; }

        public int Credits { get; set; }

        public int Course { get; set; }
    }
}