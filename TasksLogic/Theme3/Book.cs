using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLogic.Theme3
{
    public class Book: AbstractBook
    {
        public string Author { get; set; }
        public string Genre { get; set; }

        public Book(int id, string title, int quantity, string author, string genre, Date date, string edition)
        {
            Id = id;
            Title = title;
            Quantity = quantity;
            Author = author;
            Genre = genre;
            Date = date;
            Edition = edition;
        }
        public override string GetInfo()
        {
            return "Book Info:\n" + base.GetInfo() + 
                $"Book author: {Author}\n" +
                $"Book genre: {Genre}\n";
        }
    }
}
