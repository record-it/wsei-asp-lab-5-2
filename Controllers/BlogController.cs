using Lab_5_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Controllers
{
    public class BlogController : Controller
    {
        private ICRUDBlogItemRepository repository;

        public BlogController(ICRUDBlogItemRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BlogItem item)
        {
            if (ModelState.IsValid)
            {
                item = repository.Save(item);
                return View("Confirm", item);
            }
            return View();
        }
    }
}
