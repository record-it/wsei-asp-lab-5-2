using Lab_5_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Controllers
{
    public class StudentController : Controller
    {
        private ICRUDStudentRepository students;

        public StudentController(ICRUDStudentRepository students)
        {
            this.students = students;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page(int page, int size)
        {
            return View(students.FindPage(page, size));
        }
    }
}
