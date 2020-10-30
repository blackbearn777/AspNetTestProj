using System;
using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models.Entities
{
    public class Book
    {
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

        [Required(ErrorMessage = "Укажите автора книги")]
        public string Author { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название книги")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите год издания книги книги")]
        public int Year { get; set; }
    }
}