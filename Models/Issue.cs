using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Models
{
    public class Issue
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public Contact Contact { get; set; }
    }
}
