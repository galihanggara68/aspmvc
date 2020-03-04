using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        [HttpGet]
        [Route("employees")]
        public ActionResult Index()
        {
            using(HREntities hr = new HREntities())
            {
                var employees = hr.COPY_EMP.ToList();
                return View(employees);
            }
        }

        [Route("employees/{id}")]
        public ActionResult GetOneEmployee(int id)
        {
            using(HREntities hr = new HREntities())
            {
                var employee = hr.COPY_EMP.Find(id);
                return View("Employee", employee);
            }
        }

        [HttpGet]
        [Route("employees/add")]
        public ActionResult EmployeeForm()
        {
            return View();
        }

        [HttpPost]
        [Route("employees/add")]
        public ActionResult PostEmployee(COPY_EMP emp)
        {
            using(HREntities hr = new HREntities())
            {
                hr.COPY_EMP.Add(emp);
                hr.SaveChanges();
                return Redirect("~/employees");
            }
        }

        [HttpGet]
        [Route("employees/{employeeId}/delete")]
        public ActionResult DeleteEmployee(int employeeId)
        {
            using(HREntities hr = new HREntities())
            {
                var employee = hr.COPY_EMP.Find(employeeId);
                hr.COPY_EMP.Remove(employee);
                hr.SaveChanges();
                return Redirect("~/employees");
            }
        }
    }
}