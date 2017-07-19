using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        
        [Required]
        [MaxLength(1000)]
        [MinLength(3)]
        public string Name { get; set; }

        [StringLength(1600)]
        public string Description { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string AdminId { get; set; }

        public virtual User Admin { get; set; }

        public virtual ICollection<SubDepartment> SubDepartments
        {
            get { return this.subDepartments; }
            set { this.subDepartments = value; }
        }
    }
}