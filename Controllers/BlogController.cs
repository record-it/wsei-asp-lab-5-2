using Lab_5_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Lab_5_2.Controllers
{
    public class BlogController : Controller
    {
        private ICRUDBlogItemRepository repository;

        public BlogController(ICRUDBlogItemRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public String Add()
        {
            var item = new BlogItem()
            {
                Content = "TEST",
                Title = "TEST"
            };
            item.Tags.Add(new Tag{ Name = "C#"});
            item.Tags.Add(new Tag{ Name = "ASP.NET"});
            repository.Save(item);
            return "New BlogItem SAVED";
        }
    }
}
