using System.Linq;
using System.Web.Mvc;
using SpecialtySelector.Data;
using SpecialtySelector.Models.Departments;

namespace SpecialtySelector.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var db = new SpecialtySelectorDbContext();

            var departments = db.Departments
                .Select(x => new HomeIndexDepartmentsModel
                {
                    Name = x.Name
                });

            return View(departments);
        }
    }
}