using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Models
{
    public class Student
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Wpisz imię studenta!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Wpisz imię studenta!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Wpisz imię studenta!")]
        public DateTime BirthDate { get; set; }
        [MinLength(8, ErrorMessage = "Index musi mieć 8 cyfr"), MaxLength(8, ErrorMessage = "Index musi mieć 8 cyfr")]
        public string StudentIndex { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public Student()
        {
            Lectures = new HashSet<Lecture>();
        }
    }
}
