namespace LibrarianMVC.Models.Interfaces
{
    public interface IBook
    {
        int Id { get; }
        string Title { get; set; }
        int Quantity { get; set; }
        int Year { get; }
        string Edition { get; set; }
    }
}
