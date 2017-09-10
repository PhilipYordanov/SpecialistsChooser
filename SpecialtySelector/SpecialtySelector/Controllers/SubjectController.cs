using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using SpecialtySelector.Data;
using System.Linq;
using System.Web.Mvc;
using SpecialtySelector.Models.Specialties;
using SpecialtySelector.Models.SubDepartment;
using SpecialtySelector.Models.Subjects;

namespace SpecialtySelector.Controllers
{
    public class SubjectController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            using (var db = new SpecialtySelectorDbContext())
            {
                var teachers = db.Teachers.ToList();
                var specialties = db.Specialties.ToList();

                ViewBag.Teachers = teachers;
                ViewBag.Specialties = specialties;

                return View();
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateSubject createSubject)
        {
            if (createSubject != null && ModelState.IsValid)
            {
                using (var db = new SpecialtySelectorDbContext())
                {
                    var adminId = this.User.Identity.GetUserId();

                    var listOfTeachers = new List<Teacher>();
                    var listOfSpecialties = new List<Specialty>();

                    foreach (var teacher in createSubject.Teacher)
                    {
                        var currentTeacher = db.Teachers.FirstOrDefault(t => t.Id == teacher);
                        listOfTeachers.Add(currentTeacher);
                    }

                    foreach (var specialty in createSubject.Specialty)
                    {
                        var currentSpecialty = db.Specialties.FirstOrDefault(s => s.Id == specialty);
                        listOfSpecialties.Add(currentSpecialty);
                    }

                    var subject = new Subject()
                    {
                        Name = createSubject.Name,
                        IsMandatory = createSubject.IsMandatory,
                        Credits = createSubject.Credits,
                        Course = createSubject.Course,
                        Description = createSubject.Description,
                        Specialties = listOfSpecialties,
                        Teachers = listOfTeachers,
                        AdminId = adminId
                    };

                    db.Subjects.Add(subject);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }

            using (var db = new SpecialtySelectorDbContext())
            {
                var teachers = db.Teachers.ToList();
                var specialties = db.Specialties.ToList();


                ViewBag.Teachers = teachers;

                ViewBag.Specialties = specialties;

                return View(createSubject);
            }
        }

        public ActionResult AllSubjects()
        {
            using (var db = new SpecialtySelectorDbContext())
            {
                var subjects = db.Subjects
                    .Include(x => x.Teachers)
                    .Include(x=>x.Specialties)
                    .Where(sp => sp.DeletedOn.Equals(null))
                    .Select(sp => new AllSubjects()
                    {
                        Id = sp.Id,
                        Name = sp.Name,
                        Credits = sp.Credits,
                        Course = sp.Course,
                        IsMandatory = sp.IsMandatory
                    })
                    .ToList();

                return View(subjects);
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new SpecialtySelectorDbContext())
            {
                var specialties = db.Subjects
                    .Where(sp => sp.Id == id)
                    .Where(sp => sp.DeletedOn.Equals(null))
                    .Select(sp => new SubjectInfo
                    {
                        Id = sp.Id,
                        Name = sp.Name,
                        Description = sp.Description,
                        Specialties = sp.Specialties,
                        Teachers = sp.Teachers,
                        Course = sp.Course,
                        Credits = sp.Credits,
                        IsMandatory = sp.IsMandatory
                    })
                    .FirstOrDefault();

                if (specialties == null)
                {
                    return HttpNotFound();
                }

                return View(specialties);
            }
        }
    }
}