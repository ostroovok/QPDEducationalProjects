using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianLogic
{
    public class Date
    {
        public int Year { get; }
        public int Month { get; }
        public int Day { get; }

        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
        public static bool operator ==(Date d1, Date d2)
        {
            return d1.Year == d2.Year && d1.Month == d2.Month && d1.Day == d2.Day;
        }
        public static bool operator !=(Date d1, Date d2)
        {
            return d1.Year != d2.Year && d1.Month != d2.Month && d1.Day != d2.Day;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Date); 
        }
        private bool Equals(Date other) 
        {
            return this == other;
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            if (Day < 10)
                sb.Append($"0{Day}.");
            else
                sb.Append($"{Day}.");
            if (Month < 10)
                sb.Append($"0{Month}.");
            else
                sb.Append($"{Month}.");
            if (Year < 10)
                sb.Append($"0{Year}");
            sb.Append(Year);

            return sb.ToString();
        }
    }
}
