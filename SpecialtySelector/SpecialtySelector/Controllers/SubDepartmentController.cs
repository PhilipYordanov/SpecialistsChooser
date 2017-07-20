using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SpecialtySelector.Data;
using SpecialtySelector.Models.Departments;
using SpecialtySelector.Models.SubDepartment;

namespace SpecialtySelector.Controllers
{
    public class SubDepartmentController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateSubDepartment subDepartmentModel)
        {
            if (this.ModelState.IsValid && subDepartmentModel.Description != null && subDepartmentModel.Name != null)
            {
                var adminId = this.User.Identity.GetUserId();

                var subDepartment = new SubDepartment()
                {
                    Name = subDepartmentModel.Name,
                    Description = subDepartmentModel.Description,
                    DepartmentId = subDepartmentModel.DepartmentId,
                    AdminId = adminId
                };

                var db = new SpecialtySelectorDbContext();

                db.SubDepartments.Add(subDepartment);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = subDepartment.Id });
            }

            return View(subDepartmentModel);
        }

        public ActionResult Details(int id)
        {
            var db = new SpecialtySelectorDbContext();

            var subDepartment = db.SubDepartments
                .Where(d => d.Id == id)
                .Select(d => new SubDepartmentInfo()
                {
                   Name = d.Name,
                   Description = d.Description
                })
                .FirstOrDefault();

            if (subDepartment == null)
            {
                return HttpNotFound();
            }

            return View(subDepartment);
        }

        public ActionResult SubDepartmentInfo(int id)
        {
            var db = new SpecialtySelectorDbContext();

            var subDepartments = db.SubDepartments
                .Where(sb => sb.DepartmentId == id)
                .Where(sb => sb.DeletedOn.Equals(null))
                .Select(sb => new SubDepartmentInfo()
                {
                    Id = sb.Id,
                    Name = sb.Name,
                    Description = sb.Description
                })
                .ToList();

            return View(subDepartments);
        }
    }
}