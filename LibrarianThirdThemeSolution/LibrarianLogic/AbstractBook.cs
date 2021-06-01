using System;

namespace LibrarianLogic
{
    public class AbstractBook : IBook
    {
        public int Id { get; protected set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public virtual int Year { get; protected set; }
        public string Edition { get; set; }

        public virtual string GetInfo()
        {
            return $"Id: {Id}\n" +
                 $"Название: {Title}\n" +
                 $"Количество: {Quantity}\n" +
                 $"Год: {Year}\n" +
                 $"Издание: {Edition}\n";
        }
        public void SetId()
        {
            var ticksForNewId = DateTime.Now.Ticks.ToString();
            var first = ticksForNewId.Substring(0,4);
            var last = ticksForNewId.Substring(14);
            Id = int.Parse(first + last);
        }
    }
}
