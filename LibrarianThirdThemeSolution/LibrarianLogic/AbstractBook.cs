using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                 $"Title: {Title}\n" +
                 $"Quantity: {Quantity}\n" +
                 $"Year: {Year}\n" +
                 $"Edition: {Edition}\n";
        }
        public override bool Equals(object o)
        {
            AbstractBook b = o as AbstractBook;
            return b.Id == Id && b.Year == Year;
        }

        public override int GetHashCode()
        {
            return Id * Year;
        }
    }
}
