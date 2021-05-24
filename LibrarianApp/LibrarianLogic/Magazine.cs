using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LibrarianLogic
{
    public class Magazine : AbstractBook
    {
        public int Periodicity { get; set; }
        public int Number { get; set; }

        public Magazine(int id, string title, int quantity, Date date, string edition, int periodicity, int number)
        {
            Id = id;
            Title = title;
            Quantity = quantity;
            Date = date;
            Edition = edition;
            Periodicity = periodicity;
            Number = number;
        }
        public override string GetInfo()
        {
            return "{\n" + base.GetInfo() +
                $"Monthly frequency: {Periodicity}\n" +
                $"Magazine number: {Number}\n" + "}\n";
        }
    }
}
