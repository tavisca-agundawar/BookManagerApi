using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTraining.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
        public string Category { get; set; }
    }
}
