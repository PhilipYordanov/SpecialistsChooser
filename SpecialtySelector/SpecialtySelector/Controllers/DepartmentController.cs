using SpecialtySelector.Models.Departments;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SpecialtySelector.Data;
using System.Linq;
using SpecialtySelector.Models.SubDepartment;

namespace SpecialtySelector.Controllers
{
    public class DepartmentController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateDepartment departmentModel)
        {
            if (this.ModelState.IsValid && departmentModel != null)
            {
                var adminId = this.User.Identity.GetUserId();

                var department = new Department
                {
                    Name = departmentModel.Name,
                    Description = departmentModel.Description,
                    AdminId = adminId
                };

                var db = new SpecialtySelectorDbContext();

                db.Departments.Add(department);
                db.SaveChanges();

               return RedirectToAction("Details", new { id = department.Id });
            }

            return View(departmentModel);
        }

        public ActionResult Details(int id)
        {
            var db = new SpecialtySelectorDbContext();

            var department = db.Departments
                .Where(d => d.Id == id)
                .Select(d => new DepartmentDetailsModel()
                {
                    Name = d.Name,
                    Description = d.Description
                })
                .FirstOrDefault();

            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        public ActionResult SubDepartmentInfo(int id)
        {
            var db = new SpecialtySelectorDbContext();

            var subDepartments = db.SubDepartments
                .Where(sb => sb.DepartmentId == id)
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