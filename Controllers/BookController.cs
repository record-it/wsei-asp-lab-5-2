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

        public String Index()
        {
            return "Index";
        }

        [HttpGet]
        public Book Add()
        {

            Book book = new Book()
            {
                PublishingYear = 2000,
                Title = "Java"
            };
            book.Authors.Add(new Author()
            {
                firstName = "Greg",
                lastName = "Frontman",
                birthDate = DateTime.Parse("1978-10-10")
            });
            book.Authors.Add(new Author()
            {
                firstName = "Alan",
                lastName = "Backend",
                birthDate = DateTime.Parse("1987-11-20")
            });
            book = books.Add(book);
            return book;
            
        }

        public String Delete(int id)
        {
            books.Delete(id);
            return "Deleted";
        }
    }
}
