using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
