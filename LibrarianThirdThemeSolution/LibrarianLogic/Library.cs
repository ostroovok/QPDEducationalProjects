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
        public Library()
        {
            LibraryFund = new();
        }
        /// <summary>
        /// Добавляет эл-т в список
        /// </summary>
        /// <param name="book">Эл-т для добавления</param>
        public void Insert(IBook book)
        {
            LibraryFund.Add(book);
        }
        /// <summary>
        /// Ищет эл-т по переданному id и удаляет его
        /// </summary>
        /// <param name="id">Необходим для поиска</param>
        public void Delete(int id)
        {
            IBook objToDelete = Find(id);
            LibraryFund.Remove(objToDelete);
        }
        /// <summary>
        /// Производит поиск по id эл-та
        /// В случае если эл-т с переданным id имеется в списке, то вернет его, иначе null
        /// </summary>
        /// <param name="id">Id по которому будет идти поиск</param>
        /// <returns>Эл-т списка LibraryFund</returns>
        public IBook Find(int id)
        {
            foreach (var book in LibraryFund)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }
        /// <summary>
        /// Производит поиск по имени
        /// Просматривает все объекты в списке
        /// Если название объекта содержит переданную строку, то добавляет вв выходной список
        /// </summary>
        /// <param name="title">Название по которому будет идти поиск</param>
        /// <returns>Эл-т списка LibraryFund</returns>
        public IBook[] Find(string title)
        {
            List<IBook> outList = new();
            foreach (var book in LibraryFund)
            {
                if (book.Title.ToLower().Contains(title.ToLower()))
                {
                    outList.Add(book);
                }  
            }
            return outList.ToArray();
        }
        /// <summary>
        /// Проверяет, содержится ли эл-т с переданным id в списке
        /// </summary>
        /// <param name="id">Необходим для поиска</param>
        /// <returns></returns>
        public bool Contains(int id)
        {
            if(Find(id) != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Возвращает св-ва объекта с переданным id 
        /// </summary>
        /// <param name="id">Необходим для поиска</param>
        /// <returns></returns>
        public PropertyInfo[] GetElementProperties(int id)
        {
            IBook b = Find(id);
            return b.GetType().GetTypeInfo().GetProperties();
        }
        /// <summary>
        /// Меняет св-во объекта, найденного по id на новое, переданное значение
        /// </summary>
        /// <param name="elementId">id изменяемого объекта</param>
        /// <param name="propertyToChange">Св-во для изменения</param>
        /// <param name="newValue">Новое значение для изменяемого св-ва типа int</param>
        /// <returns></returns>
        public bool ChangeElementProperty(int elementId, PropertyInfo propertyToChange, int newValue)
        {
            if(propertyToChange.Name == "Id")
            {
                return false;
            }
            else
            {
                propertyToChange.SetValue(Find(elementId), newValue);
                return true;
            }
        }
        /// <summary>
        /// Меняет св-во объекта, найденного по id на новое, переданное значение
        /// </summary>
        /// <param name="elementId">id изменяемого объекта</param>
        /// <param name="propertyToChange">Св-во для изменения</param>
        /// <param name="newValue">Новое значение для изменяемого св-ва типа string</param>
        /// <returns></returns>
        public bool ChangeElementProperty(int elementId, PropertyInfo propertyToChange, string newValue)
        {
            if (propertyToChange.Name == "Id")
            {
                return false;
            }
            else
            {
                propertyToChange.SetValue(Find(elementId), newValue);
                return true;
            }
        }


        /// <summary>
        /// Метод сохранения списка LibraryFund файл расширения .dat
        /// Так как типа данных 2. то и цикла в методе, тоже 2, первый создает файл с книгами, второй с журналами
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(fileName + "Books.dat", FileMode.Create)))
                {
                    foreach (var b in LibraryFund)
                    {
                        if (b is Book)
                        {
                            var temp = b as Book;

                            bw.Write(temp.Author);
                            bw.Write(temp.Genre);
                            bw.Write(temp.Id);
                            bw.Write(temp.Title);
                            bw.Write(temp.Quantity);
                            bw.Write(temp.Year);
                            bw.Write(temp.Edition);

                        }
                    }
                }
                using (BinaryWriter bw = new BinaryWriter(File.Open(fileName + "Magazines.dat", FileMode.Create)))
                {
                    foreach (var b in LibraryFund)
                    {
                        if (b is Magazine)
                        {
                            var temp = b as Magazine;

                            bw.Write(temp.Periodicity);
                            bw.Write(temp.Number);
                            bw.Write(temp.Id);
                            bw.Write(temp.Title);
                            bw.Write(temp.Quantity);
                            bw.Write(temp.Year);
                            bw.Write(temp.Edition);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Не удалось сохранить данные. Текст ошибки: {e.Message}");
            }
        }
        /// <summary>
        /// Метод загрузки списка из файлов расширения .dat
        /// В начале метода стоит проверка, если один из файлов не будет найден метод прекратит работу
        /// Далее идут два цикла, первый загружает в списко книги, второй журналы
        /// </summary>
        /// <param name="fileName"></param>
        public bool Load(string fileName)
        {
            if (!File.Exists(fileName + "Books.dat") || !File.Exists(fileName + "Magazines.dat"))
            {
                return false;
            }
            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(fileName + "Books.dat", FileMode.Open)))
                {
                    while (br.PeekChar() > -1)
                    {
                        var author = br.ReadString();
                        var genre = br.ReadString();
                        var id = br.ReadInt32();
                        var title = br.ReadString();
                        var quantity = br.ReadInt32();
                        var year = br.ReadInt32();
                        var edition = br.ReadString();
                        LibraryFund.Add(new Book(id, title, quantity, author, genre, year, edition));
                    }
                }
                using (BinaryReader br = new BinaryReader(File.Open(fileName + "Magazines.dat", FileMode.Open)))
                {
                    while (br.PeekChar() > -1)
                    {
                        var periodicity = br.ReadInt32();
                        var number = br.ReadInt32();
                        var id = br.ReadInt32();
                        var title = br.ReadString();
                        var quantity = br.ReadInt32();
                        var year = br.ReadInt32();
                        var edition = br.ReadString();
                        LibraryFund.Add(new Magazine(id, title, quantity, year, edition, periodicity, number));
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw new Exception($"Не удалось загрузить данные. Текст ошибки: {e.Message}");
            }
        }
    }
}
