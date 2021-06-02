namespace LibrarianLogic
{
    public interface IBook
    {
        int Id { get; }
        string Title { get; set; }
        int Quantity { get; set; }
        int Year { get; }
        string Edition { get; set; }

        string GetInfo();
        void SetId();
    }
}
