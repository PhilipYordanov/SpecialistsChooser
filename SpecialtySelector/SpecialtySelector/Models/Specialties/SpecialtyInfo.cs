using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SpecialtySelector.Data;
using SpecialtySelector.Data.SpecialtySelectorEnums;

namespace SpecialtySelector.Models.Specialties
{
    public class SpecialtyInfo
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public Eqd Eqd { get; set; }

        public FormOfEducation FormOfEducation { get; set; }
        
        public string Description { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int? SubDepartmentId { get; set; }
    }
}