using System.ComponentModel.DataAnnotations;

namespace SpecialtySelector.Models.Departments
{
    public class CreateDepartment
    {
        [Required]
        [MaxLength(1000)]
        [MinLength(3)]
        [Display(Name = "Име на Направлението")]
        public string Name { get; set; }
        
        [Display(Name = "Кратко описание на Направлението")]
        [StringLength(1600)]
        public string Description { get; set; }
    }
}