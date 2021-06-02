using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

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
        public bool Delete(int id)
        {
            IBook objToDelete = Find(id);
            if(objToDelete == null)
            {
                return false;
            }
            else
            {
                LibraryFund.Remove(objToDelete);
                return true;
            }
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
        /// Проводит поиск, если эл-т не найден, возвращает false
        /// Далее составляет массив св-в найденного эл-та
        /// Если было передано св-во на изменение с именем id возвращает false
        /// Далее выбирает, если св-во типа int проверяет переданное значение и конвертирует
        /// Если ковертировать не получилось, то переданное значение некорректно, возвращает false
        /// Если string присваивает
        /// </summary>
        /// <param name="id">идентификатор. по которому идет поиск объекта</param>
        /// <param name="propertyNumber">номер св-ва по списку, составленному с помощью рефлексии</param>
        /// <param name="value">новое значение св-ва для изменения</param>
        /// <returns></returns>
        public bool ChangeElementProperty(int id, int propertyNumber, string value)
        {
            var obj = Find(id);

            if(obj == null)
            {
                return false;
            }

            PropertyInfo[] objProperties= obj.GetType().GetProperties();
            if(objProperties[propertyNumber].Name == "Id")
            {
                return false;
            }

            if (objProperties[propertyNumber].PropertyType == typeof(int))
            {
                int convertValue;
                if (!int.TryParse(value, out convertValue))
                {
                    return false;
                }
                objProperties[propertyNumber].SetValue(obj, convertValue);
                return true;
            }
            else
            {
                objProperties[propertyNumber].SetValue(obj, value);
                return true;
            }
            
        }
        /// <summary>
        /// Составляет список эл-в типа string с именами св-в объекта
        /// В случае, если эл-т не был найден вернет список с единственным значением "notFound"
        /// Конвертирует в массив и возвращает его
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string[] GetElementPropertiesInfo(int id)
        {
            var obj = Find(id);
            if(obj == null)
            {
                return new string[] { "notFound" };
            }
            PropertyInfo[] objProperties = obj.GetType().GetProperties();

            List<string> propertiesNames = new();

            for (int i = 0; i < objProperties.Length; i++)
            {
                propertiesNames.Add(objProperties[i].Name);
            }

            return propertiesNames.ToArray();
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
