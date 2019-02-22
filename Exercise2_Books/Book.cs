using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2_Books
{
    public class Book
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; }

        public Book(string name, decimal price, DateTime releaseDate, string category)
        {
            Name = name;
            Price = price;
            ReleaseDate = releaseDate;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name} {Price} {ReleaseDate.Date.ToShortDateString()} {Category}";
        }

    }
}
