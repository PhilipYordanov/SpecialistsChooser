using System.ComponentModel.DataAnnotations;
using SpecialtySelector.Data.SpecialtySelectorEnums;

namespace SpecialtySelector.Models.Specialties
{
    public class SpecialtyDetailModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        [MinLength(3)]
        public string Name { get; set; }

        [StringLength(1600)]
        public string Description { get; set; }

        public Eqd Eqd { get; set; }

        public FormOfEducation FormOfEducation { get; set; }
    }
}