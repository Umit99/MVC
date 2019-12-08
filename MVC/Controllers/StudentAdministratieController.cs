using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class StudentAdministratieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchStudents(string id)
        {
            if (id == null)
            {
                return View("Index");
            }

            ViewData["StudentsSearched"] = id;

            List<Student> students = new List<Student>()
        {
            new Student() {name = "Jimmy", age = 23 },
            new Student() {name = "Frank", age = 19 },
            new Student() {name = "Albert", age = 22 },
            new Student() {name = "James", age = 29 }
        };

            List<Student> searchStudents = students
                .Where(s => s.name.ToLower().StartsWith(id.ToLower()))
                .OrderBy(s => s.name)
                .ToList();

            return View(searchStudents);
        }


    }
}