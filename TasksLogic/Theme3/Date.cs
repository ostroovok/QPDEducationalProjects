﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLogic.Theme3
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
    }
}