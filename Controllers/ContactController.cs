using Lab_5_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Controllers
{
    public class ContactController : Controller
    {
        static List<Contact> contacts = new List<Contact>()
        {
            new Contact(){Id=1, Name="Tomek", Email="tom@wsei.edu.pl"},
            new Contact(){Id=2, Name="Ola", Email="ola@wsei.edu.pl"}
        };
        static int index = 3;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Id = index++;
                contacts.Add(contact);
                return View("ConfirmContact", contact);
            }
            else
            {
                return View("AddForm");
            }
        }

        public IActionResult List()
        {
            return View(contacts);
        }

        public IActionResult Delete(int id)
        {
            Contact found = null;
            foreach (var contact in contacts)
            {
                if (contact.Id == id)
                {
                    found = contact;
                    break;
                }
            }
            if (found != null)
            {
                contacts.Remove(found);
            }
            return View("List", contacts);
        }
    }
}

