using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianLogic
{
    public class Library
    {
        public List<IBook> LibraryFund { get; }
        public int Count { get => LibraryFund.Count; }

        public Library(List<IBook> libraryFund)
        {
            LibraryFund = libraryFund;
        }
        public Library()
        {
            LibraryFund = new();
        }

        public bool Insert(IBook book)
        {
            if (Find(book.Id) == null)
            {
                LibraryFund.Add(book);
            }
            return false;
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
