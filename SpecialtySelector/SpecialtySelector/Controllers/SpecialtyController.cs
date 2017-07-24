using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using SpecialtySelector.Data;
using SpecialtySelector.Models.Specialties;
using System.Linq;
using System.Web.Mvc;

namespace SpecialtySelector.Controllers
{
    public class SpecialtyController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            using (var db = new SpecialtySelectorDbContext())
            {
                var subDepartments = db.SubDepartments.ToList();

                ViewBag.SubDepartments = subDepartments;

                return View();
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateSpecialty createSpecialty)
        {
            if (this.ModelState.IsValid)
            {
                var adminId = this.User.Identity.GetUserId();

                var specialty = new Specialty()
                {
                    Name = createSpecialty.Name,
                    Description = createSpecialty.Description,
                    Eqd = createSpecialty.Eqd,
                    FormOfEducation = createSpecialty.FormOfEducation,
                    SubDepartmentId = createSpecialty.SubDepartmentId,
                    AdminId = adminId
                };

                using (var db = new SpecialtySelectorDbContext())
                {
                    db.Specialties.Add(specialty);
                    db.SaveChanges();
                    var subDepartments = db.SubDepartments.ToList();
                    ViewBag.SubDepartments = subDepartments;
                    // return RedirectToAction("Details", new { id = specialty.Id });
                }
            }

            return View(createSpecialty);
        }

        public ActionResult SpecialtyInfo(int id)
        {
            using (var db = new SpecialtySelectorDbContext())
            {
                var subDepartments = db.Specialties
                    .Where(sb => sb.SubDepartmentId == id)
                    .Where(sb => sb.DeletedOn.Equals(null))
                    .Select(sb => new SpecialtyInfo()
                    {
                        Id = sb.Id,
                        Name = sb.Name,
                        Description = sb.Description,
                        Eqd = sb.Eqd,
                        FormOfEducation = sb.FormOfEducation,
                       SubDepartmentId = sb.SubDepartmentId
                    })
                    .ToList();

                return View(subDepartments);
            }
        }
    }
}