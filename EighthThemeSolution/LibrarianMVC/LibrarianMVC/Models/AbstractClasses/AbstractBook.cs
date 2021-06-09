using LibrarianMVC.Models.Interfaces;

namespace LibrarianMVC.Models.AbstractClasses
{
    public class AbstractBook : IBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public int Year { get; set; }
        public string Edition { get; set; }
    }
}
