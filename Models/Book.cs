using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Models
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Musisz podać tytuł książki!")]
        [MinLength(2)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Musisz podać  autora!")]
        public ICollection<Author> Authors { get; set; }
        [Range(minimum: 2000, maximum: 2030, ErrorMessage = "Podaj rok między 2000 a 230")]
        public int PublishingYear { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   Id == book.Id &&
                   Title == book.Title &&
                   EqualityComparer<ICollection<Author>>.Default.Equals(Authors, book.Authors) &&
                   PublishingYear == book.PublishingYear;
        }

        public override string ToString()
        {
            return "{Book: " + Title +" " + PublishingYear +" " + Authors + "}";
        }


    }
}
