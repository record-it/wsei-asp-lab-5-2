using Lab_5_2.Filtr;
using Lab_5_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lab_5_2.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class ApiBookController : ControllerBase
    {
        private ICRUDBookRepository books;

        public ApiBookController(ICRUDBookRepository books)
        {
            this.books = books;
        }

        //deklaracja zmiennej repozytorium
        [HttpGet]
        [DisableBasicAuthorization]
        public IList<Book> GetBooks()
        {
            return books.FindAll();
        }

        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book book)
        {
            Book book1 = books.Add(book);
            return new CreatedResult($"/api/books/{book1.Id}", book1);
        }


        [HttpGet("{id}")]
        [DisableBasicAuthorization]
        public ActionResult<Book> GetBook(int id)
        {
            Book book = books.FindById(id);
            if (book != null)
            {
                return new OkObjectResult(book);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Book> EditBook(int id, [FromBody] Book book)
        {
            //wywołanie metody z repozytorium zmieniającej wartości w obiekcie
            //testujemy, czy obiekt jest różny od null
            if (id < 5 && id > 0)
            {
                book.Id = id;
                return new OkObjectResult(book);
            } else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            //usunięcie z repozytorium obiektu o podanym id
            //jeśli nie ma obiektu do usunięcia to zwracamy NotFound
            if (id < 5 && id > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
