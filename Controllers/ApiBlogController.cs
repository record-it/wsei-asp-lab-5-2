﻿using Lab_5_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Controllers
{
    [Route("api/items")]
    public class ApiBlogController : Controller
    {
        private ICRUDBlogItemRepository items;

        public ApiBlogController(ICRUDBlogItemRepository items)
        {
            this.items = items;
        }

        [HttpGet]
        public IList<BlogItem> GetAll()
        {
            return items.FindAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetOne(int id)
        {
            BlogItem blogItem = items.FindById(id);
            if (blogItem != null)
            {
                return new OkObjectResult(blogItem);
            } else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Add([FromBody] BlogItem item)
        {
            if (ModelState.IsValid)
            {
                BlogItem blogItem = items.Save(item);
                return new CreatedResult($"/api/items/{blogItem.Id}", blogItem);
            } else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (items.FindById(id) != null)
            {
                items.Delete(id);
                return Ok();
            } else
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, [FromBody] BlogItem item)
        {
            item.Id = id;
            BlogItem blogItem = items.Update(item);
            if (blogItem == null)
            {
                return NotFound();
            } else
            {
                return NoContent();
            }
        }

    }
}
