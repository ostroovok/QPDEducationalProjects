using LibrarianMVC.Models.AbstractClasses;

namespace LibrarianMVC.Models
{
    public class Magazine : AbstractBook
    {
        public string Periodicity { get; set; }
        public int Number { get; set; }

    }
}
