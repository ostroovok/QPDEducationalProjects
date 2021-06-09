using LibrarianMVC.Models.AbstractClasses;

namespace LibrarianMVC.Models
{
    public class Book : AbstractBook
    {
        public string Author { get; set; }
        public string Genre { get; set; }

    }
}
