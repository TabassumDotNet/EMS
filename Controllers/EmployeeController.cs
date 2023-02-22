using aim_sol.Data;
using aim_sol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace aim_sol.Controllers
{
    public class EmployeeController : Controller
    {


        private readonly EmployeeContext employeeContexts;

        public int EmpId { get;  set; }
        public object GetallDepartments { get; set; }

        public EmployeeController(EmployeeContext Employeecontext)
        {
            this.employeeContexts = Employeecontext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ////    EmployeeContext db = new EmployeeContext();
            ////    var obj = db.Employees.FirstOrDefault(x=> x.DepartmentId == 1);
            ////    obj.EmpEmail = "xyz@xyz.com";
            ////    db.SaveChanges();
            ////    Employee e = new Employee();
            ////    e.EmpN                                  ame = "tabassum";
            ////    db.Employees.Add(e);
            ////    db.SaveChanges();
            //    //var obj2 = from data in db.Employees where data.DepartmentId ==1 select data;
            //    //veiw list
            var data = employeeContexts.Employees.Include("Department").ToList();
            
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var data = employeeContexts.Departments.ToList();

            ViewBag.Departments = data;

            return View();

        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            employeeContexts.Employees.Add(emp);
            employeeContexts.SaveChanges();

            return RedirectToAction("Index");

        }



        //[HttpGet]
        //public IActionResult Edit(int EmpId)
        //{
        //       var data = employeeContexts.Employees.Where(model => model.EmpId==EmpId).FirstOrDefault();

        //  //  ViewBag.Employees = data;

        //    return View("Create");

        //}

        [HttpGet]
        public ActionResult Edit(int EmpId)
        {
            var Employee = employeeContexts.Employees.Where(model => model.EmpId == EmpId).FirstOrDefault();
            var departments = employeeContexts.Departments.ToList();
            ViewBag.Departments = departments;
            return View(Employee);
        }


            [HttpPost]
            public IActionResult Edit(Employee emp)

            {
                var employee = employeeContexts.Employees.Where(x => x.EmpId == emp.EmpId).FirstOrDefault();

                employee.EmpName = emp.EmpName;
                employee.EmpSalary = emp.EmpSalary;
                employee.EmpEmail = emp.EmpEmail;
                employeeContexts.SaveChanges();
                return RedirectToAction("Index");

            }


            //public ActionResult Update(int EmpId, Employee emp)
            //{
            //    //using (var employeeContexts = new ())
            //    //{

            //        // Use of lambda expression to access
            //        // particular record from a database
            //        var data = employeeContexts.Employees.FirstOrDefault(x => x.EmpId == EmpId);

            //        // Checking if any such record exist
            //        if (data != null)
            //        {

            //            data.EmpName = emp.EmpName;
            //            data.EmpSalary = emp.EmpSalary;
            //            data.EmpEmail = emp.EmpEmail;
            //            //data. = model.Section;
            //            //data.EmailId = model.EmailId;
            //            //data.Branch = model.Branch;
            //            employeeContexts.SaveChanges();

            //            // It will redirect to
            //            // the Read method
            //            return RedirectToAction("Index");
            //        }
            //        else
            //            return View();
            //    }

















            //[HttpPost]
            //public ActionResult Edit(Employee emp)
            //{

            //    var employee = employeeContexts.Employees.Where(model => model.EmpId == EmpId).FirstOrDefault();
            //    //employeeContexts.Remove(employee);
            //    employeeContexts.Add(emp);

            //    return RedirectToAction("Index");
            //}

        }




    }

