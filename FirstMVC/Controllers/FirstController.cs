using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class FirstController : Controller
    {
        // ViewData Dictionary
        [HttpGet]
        [Route("viewdata")]
        public ActionResult TestViewData()
        {
            List<SelectListItem> roles = new List<SelectListItem> {
                new SelectListItem { Text = "Admin", Value = "1" },
                new SelectListItem { Text = "Staff", Value = "2" },
                new SelectListItem { Text = "Customer Serice", Value = "3" },
                new SelectListItem { Text = "Teller", Value = "4" }
            };
            ViewBag.Roles = roles;
            ViewData.Add("user", "galihanggara");

            TempData.Add("temp", "Test Temporary");

            return View("Index");
        }

        [HttpGet]
        [Route("first")]
        public ActionResult Index()
        {
            HttpCookie cookie = new HttpCookie("user");
            cookie.Value = "Galih";
            cookie.Path = "/";
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(cookie);
            return View();
        }

        // Bitwise
        [HttpGet]
        [Route("second")]
        public ActionResult Second()
        {
            ContentResult content = new ContentResult();
            content.Content = HttpContext.Request.Cookies["user"].Value;
            content.ContentType = "text/html";
            content.ContentEncoding = Encoding.ASCII;
            return content;
        }

        [Route("calculate/{num1}/{op}/{num2}")]
        public ActionResult Calculate(int num1, string op, int num2)
        {
            int result = 0;
            switch(op)
            {
                case "plus":
                    result = num1 + num2;
                    break;
                case "minus":
                    result = num1 - num2;
                    break;
                case "times":
                    result = num1 * num2;
                    break;
                case "divide":
                    result = num1 / num2;
                    break;
                case "mod":
                    result = num1 % num2;
                    break;
            }
            return Content("Result : " + result);
        }

        [HttpGet]
        [Route("model")]
        public ActionResult WithModel()
        {
            Person person = new Person();
            person.Name = "Galih";
            person.Address = "Tangerang";
            return View(person);
        }

        [HttpGet]
        [Route("listperson")]
        public ActionResult ListPerson()
        {
            List<Person> persons = new List<Person> {
                new Person() { Name = "Galih", Address = "Tangerang" },
                new Person() { Name = "Ujang", Address = "Bandung" },
                new Person() { Name = "Udin", Address = "Bogor" },
                new Person() { Name = "Ucup", Address = "Depok" },
                new Person() { Name = "Asep", Address = "Banten" }
            };

            // Views/First/ListPerson.cshtml
            return View(persons);
        }

        [HttpGet]
        [Route("person/{id}")]
        public ActionResult GetPerson(int id)
        {
            List<Person> persons = new List<Person> {
                new Person() { Name = "Galih", Address = "Tangerang" },
                new Person() { Name = "Ujang", Address = "Bandung" },
                new Person() { Name = "Udin", Address = "Bogor" },
                new Person() { Name = "Ucup", Address = "Depok" },
                new Person() { Name = "Asep", Address = "Banten" }
            };

            // Views/First/GetPerson.cshtml
            // Tipe dari persons[0] -> Person
            // int[] nums = {1, 2, 3};
            // Tipe nums[0] -> int
            return View("WithModel", persons[id]);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult EditForm(int id)
        {
            List<Person> persons = new List<Person> {
                new Person() { Id = 1, Name = "Galih", Address = "Tangerang" },
                new Person() { Id = 2,Name = "Ujang", Address = "Bandung" },
                new Person() { Id = 3,Name = "Udin", Address = "Bogor" },
                new Person() { Id = 4,Name = "Ucup", Address = "Depok" },
                new Person() { Id = 5,Name = "Asep", Address = "Banten" }
            };
            
            // Views/First/GetPerson.cshtml
            // Tipe dari persons[0] -> Person
            // int[] nums = {1, 2, 3};
            // Tipe nums[0] -> int
            return View(persons.First(f => f.Id == id));
        }

        [HttpPost]
        [Route("edit")]
        public ActionResult PostEdit(int id, Person person)
        {
            List<Person> persons = new List<Person> {
                new Person() { Id = 1, Name = "Galih", Address = "Tangerang" },
                new Person() { Id = 2, Name = "Ujang", Address = "Bandung" },
                new Person() { Id = 3, Name = "Udin", Address = "Bogor" },
                new Person() { Id = 4, Name = "Ucup", Address = "Depok" },
                new Person() { Id = 5, Name = "Asep", Address = "Banten" }
            };

            persons.First(f => f.Id == id).Address = person.Address;

            return View("ListPerson", persons);
        }

        [Route("test")]
        public string Test(Person person)
        {
            return person.Name + "-" + person.Address;
        }

        // Show Form
        [HttpGet]
        [Route("form")]
        public ActionResult Form()
        {
            return View();
        }

        // Post Form
        [HttpPost]
        [Route("form")]
        public ActionResult PostForm(Person person)
        {
            return View("WithModel", person);
        }
    }
}