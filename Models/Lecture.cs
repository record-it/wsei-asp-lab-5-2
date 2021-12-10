using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Models
{
    public class Lecture
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Student> Students;

        public Lecture()
        {
            Students = new HashSet<Student>();
        }
    }
}
