using SpecialtySelector.Data.SpecialtySelectorEnums;

namespace SpecialtySelector.Data
{
    public class Teacher
    {
        public int Id { get; set; }

        public Degree Degree { get; set; }

        public AcademicTitle AcademicTitle { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }
    }
}