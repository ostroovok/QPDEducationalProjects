using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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
        public void Save(string fileName)
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
                {
                    foreach (var b in LibraryFund)
                    {
                        //var properties = b.GetType().GetTypeInfo().GetProperties();
                        if(b is Book)
                        {
                            var temp = b as Book;

                            bw.Write(temp.Author);
                            bw.Write(temp.Genre);
                            bw.Write(temp.Id);
                            bw.Write(temp.Title);
                            bw.Write(temp.Quantity);
                            bw.Write(temp.Date.ToString());
                            bw.Write(temp.Edition);

                        }
                        else if(b is Magazine)
                        {
                            var temp = b as Magazine;

                            bw.Write(temp.Periodicity);
                            bw.Write(temp.Number);
                            bw.Write(temp.Id);
                            bw.Write(temp.Title);
                            bw.Write(temp.Quantity);
                            bw.Write(temp.Date.ToString());
                            bw.Write(temp.Edition);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Load(string fileName)
        {
            IBook b;
            try
            {
                using(BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    while(br.PeekChar() > -1)
                    {
                        var author = br.ReadString();
                        var genre = br.ReadString();
                        var id = br.ReadInt32();
                        var title = br.ReadString();
                        var quantity = br.ReadInt32();
                        var date = 
                        //b = new Book(, );
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Save(string fileName)
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
                {
                    foreach (var b in LibraryFund)
                    {
                        //var properties = b.GetType().GetTypeInfo().GetProperties();
                        if(b is Book)
                        {
                            var temp = b as Book;

                            bw.Write(temp.Author);
                            bw.Write(temp.Genre);
                            bw.Write(temp.Id);
                            bw.Write(temp.Title);
                            bw.Write(temp.Quantity);
                            bw.Write(temp.Date.ToString());
                            bw.Write(temp.Edition);

                        }
                        else if(b is Magazine)
                        {
                            var temp = b as Magazine;

                            bw.Write(temp.Periodicity);
                            bw.Write(temp.Number);
                            bw.Write(temp.Id);
                            bw.Write(temp.Title);
                            bw.Write(temp.Quantity);
                            bw.Write(temp.Date.ToString());
                            bw.Write(temp.Edition);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Load(string fileName)
        {
            IBook b;
            try
            {
                using(BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    while(br.PeekChar() > -1)
                    {
                        var author = br.ReadString();
                        var genre = br.ReadString();
                        var id = br.ReadInt32();
                        var title = br.ReadString();
                        var quantity = br.ReadInt32();
                        //var date = 
                        //b = new Book(, );
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
