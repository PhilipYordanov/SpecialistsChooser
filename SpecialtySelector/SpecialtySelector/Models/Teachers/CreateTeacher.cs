﻿using SpecialtySelector.Data;
using SpecialtySelector.Data.SpecialtySelectorEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpecialtySelector.Models.Teachers
{
    public class CreateTeacher
    {
        [Required(ErrorMessage = "Задължително поле")]
        [Display(Name = "Име:")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме:")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        [Display(Name = "Фамилия:")]
        public string LastName { get; set; }

        [Display(Name = "Кратко описание:")]
        public string TeacherInfo { get; set; }

        [Display(Name = "Научна степен:")]
        public Degree Degree { get; set; }

        [Display(Name = "Академична титла:")]
        public AcademicTitle AcademicTitle { get; set; }

        public List<int> Subject { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}