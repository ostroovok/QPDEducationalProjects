using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLogic.Theme3
{
    public class Library
    {
        public List<IBook> LibraryFund { get; }

        public Library(List<IBook> libraryFund)
        {
            LibraryFund = libraryFund;
        }
        public Library()
        {
            LibraryFund = new();
        }

        public void Insert(IBook book)
        {
            LibraryFund.Add(book);
        }
        public void Delete(IBook book)
        {
            LibraryFund.Remove(book);
        }
        public void Clear()
        {
            LibraryFund.Clear();
        }
        public IBook Find(int id)
        {
            foreach (var book in LibraryFund)
            {
                if (book.Id == id)
                    return book;
            }
            return null;
        }
        public IBook[] Find(string title)
        {
            List<IBook> outList = new();
            foreach (var book in LibraryFund)
            {
                if (book.Title == title)
                    outList.Add(book);
            }
            return outList.ToArray();
        }
    }
}
