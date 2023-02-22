using aim_sol.Data;
using aim_sol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

namespace aim_sol.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly EmployeeContext employeeContexts;

        public DepartmentController(EmployeeContext employeeContexts)
        {
            this.employeeContexts = employeeContexts;
        }
        [HttpGet]
        public IActionResult Index()
        {


            //var data = from Departments in IEnumerable
            //           select Departments.ToList();
            var data = employeeContexts.Departments.ToList();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Department Dept)
        {


            employeeContexts.Departments.Add(Dept);
            employeeContexts.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int DepartmentId)
        {
            if (DepartmentId > 0)
            {
                var dep = employeeContexts.Departments.Where(model => 
                model.DepartmentId == DepartmentId).FirstOrDefault();
                if (dep != null)
                {
                    employeeContexts.Entry(dep).State = EntityState.Deleted;
                    employeeContexts.SaveChanges();


                }
            }
            return RedirectToAction("Index");

        }

        public IActionResult Details(int DepartmentId)
        {

var DetailsbyId = employeeContexts.Departments.Include("Employees")
                .Where(model => model.DepartmentId == DepartmentId).FirstOrDefault();


            //employeeContexts.Departments.Add(DetailsbyId);
            //employeeContexts.SaveChanges();

            return View(DetailsbyId);

        }
    }

}


























  