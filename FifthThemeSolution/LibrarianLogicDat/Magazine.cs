namespace LibrarianLogic
{
    public class Magazine : AbstractBook
    {
        public string Periodicity { get; set; }
        public int Number { get; set; }

        public Magazine(int id, string title, int quantity, int year, string edition, string periodicity, int number)
        {
            Id = id;
            Title = title;
            Quantity = quantity;
            Year = year;
            Edition = edition;
            Periodicity = periodicity;
            Number = number;
        }
        public Magazine(string title, int quantity, int year, string edition, string periodicity, int number)
        {
            SetId();
            Title = title;
            Quantity = quantity;
            Year = year;
            Edition = edition;
            Periodicity = periodicity;
            Number = number;
        }
        public override string GetInfo()
        {
            return "{\n" + base.GetInfo() +
                $"Периодичность: {Periodicity}\n" +
                $"Номер журнала: {Number}\n" + "}\n";
        }
    }
}
