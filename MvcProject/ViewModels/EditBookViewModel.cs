using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.ViewModels
{
    public class EditBookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }
    }
}
