namespace LibrarianLogic
{
    public class Book : AbstractBook
    {
        public string Author { get; set; }
        public string Genre { get; set; }

        public Book(string title, int quantity, string author, string genre, int year, string edition)
        {
            SetId();
            Title = title;
            Quantity = quantity;
            Author = author;
            Genre = genre;
            Year = year;
            Edition = edition;
        }

        public Book(int id, string title, int quantity, string author, string genre, int year, string edition)
        {
            Id = id;
            Title = title;
            Quantity = quantity;
            Author = author;
            Genre = genre;
            Year = year;
            Edition = edition;
        }

        public override string GetInfo()
        {
            return "{\n" + base.GetInfo() +
                $"Автор книги: {Author}\n" +
                $"Жанр книги: {Genre}\n" + "}\n";
        }
    }
}
