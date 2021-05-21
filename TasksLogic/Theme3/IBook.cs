using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLogic.Theme3
{
    public interface IBook
    {
        int Id { get; }
        string Title { get; set; }
        int Quantity { get; set; }
        Date Date { get; }
        string Edition { get; set; }

        string GetInfo();
    }
}
