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
    }
}
