using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название книги")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите автора книги")]
        public string Author { get; set; }
        [Range(1000, 2020, ErrorMessage = "Год издания должен быть в промежутке от 1000 до 2020")]
        [Required(ErrorMessage = "Укажите год издания книги книги")]
        public int Year { get; set; }
        public Book()
        {

        }
        public Book(int id, string name, string author, int year)
        {
            this.Id = id;
            this.Name = name;
            this.Author = author;
            this.Year = year;

        }
    }
}
