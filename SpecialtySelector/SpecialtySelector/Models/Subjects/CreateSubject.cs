using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SpecialtySelector.Data;

namespace SpecialtySelector.Models.Subjects
{
    public class CreateSubject
    {
        [Required(ErrorMessage = "Името трябва да бъде между 1-1000 символа !!!")]
        [Display(Name = "Име на предмет:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        [Display(Name = "Задължителен:")]
        public bool IsMandatory { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        [Display(Name = "Кредити:")]
        public int Credits { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        [Display(Name = "Курс:")]
        public int Course { get; set; }

        [Required(ErrorMessage = "Описанието трябва да бъде между 1-1600 символа !!!")]
        [Display(Name = "Кратко описание на предмета:")]
        public string Description { get; set; }

       // public int? SpecialtyId { get; set; }

       // public int? TeacherId { get; set; }

        public List<int> Specialty { get; set; }

        public ICollection<Subject> Specialties { get; set; }

        public List<int> Teacher { get; set; }

        public ICollection<Subject> Teachers { get; set; }
    }
}