using Lab_5_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class ApiBookController : ControllerBase
    {
        //deklaracja zmiennej repozytorium
        [HttpGet]
        public List<Book> GetBooks()
        {
            //zwrócić listę obiektów pobranych z repozytorium
            return new List<Book>()
            {
                new Book()
                {
                    Title="AAAA"
                },
                new Book()
                {
                    Title="BBBB"
                }
            };
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            //dodanie obiektu do repozytorium
            //pobrać z utworzonego Id i utworzyć location
            book.Id = 5;
            return new CreatedResult($"/api/books/{book.Id}", book);
        }


        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            //pobieranie obiektu z repozytorium o danym id
            //testujemu czy obiekt istnieje, różny od null
            if (id < 5 && id > 0)
            {
                return new OkObjectResult(new Book() { Id = id, Title = "tytuł" });
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
