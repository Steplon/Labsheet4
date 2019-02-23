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
            Category = category;
            ReleaseDate = releaseDate;
        }

        public override string ToString()
        {
            return $"{Name.PadRight(25)}\t {Price:C02}\t {Category.PadRight(20)}\t {ReleaseDate.Date.ToShortDateString()}";
        }

    }
}
