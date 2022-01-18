using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Controllers
{
    public class PeopleController : Controller
    {
        public String Find(int id) 
        {
            return $"Hello from with {id}";
        }
    }
}
