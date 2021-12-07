using Lab_5_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Controllers
{
    public class BookController : Controller
    {
        private ICRUDBookRepository books;

        public BookController(ICRUDBookRepository books)
        {
            this.books = books;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                book = books.Add(book);
                return View("Confirm", book);
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            books.Delete(id);
            return View("List", books.FindAll());
        }
    }
}
