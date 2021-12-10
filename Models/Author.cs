using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_5_2.Models
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}