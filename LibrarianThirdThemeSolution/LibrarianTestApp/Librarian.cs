using LibrarianLogic;
using System;
using System.Reflection;

namespace TestApp.Theme3
{
    public static class Librarian
    {
        private static bool _exit = true;
        public static void Main(string[] args)
        {
            Start();
        }
        /// <summary>
        /// Основной метод с бесконечным циклом, прерывается после команды -end, которая меняет переменную _exit на false
        /// В методе свич, который перебрасывает по доступным методам с помощью входных команд
        /// </summary>
        public static void Start()
        {
            Console.Clear();
            Library lib = new();
            while (_exit)
            {
                Console.WriteLine("-help - список команд;\t-end - конец работы");
                switch (Console.ReadLine().ToLower())
                {
                    case "-ins":
                        lib.Insert(CreateNew());
                        Console.WriteLine("Объект создан.");
                        break;
                    case "-help":
                        PrintCommands();
                        break;
                    case "-end":
                        Exit();
                        break;
                    case "-del":
                        ElementToDelete(lib);
                        Console.WriteLine("Объект удален.");
                        break;
                    case "-change":
                        Change(lib);
                        break;

                    case "-printall":
                        if (lib.Count == 0)
                            Console.WriteLine("Элементов не найдено.");
                        else
                        {
                            foreach (var v in lib.LibraryFund)
                            {
                                Console.WriteLine($"\n{v.GetInfo()}\n");
                            }
                        }
                        break;

                    case "-findid":
                        Console.Write("Введите Id нужного экземпляра: ");
                        var idToFind = CheckInputValue();
                        if(idToFind == -1)
                        {
                            break;
                        }
                        var resId = lib.Find(idToFind);
                        while (resId == null)
                        {
                            Console.Write("Не найдено эл-ов с таким id.\nВведите id еще раз: ");
                            resId = lib.Find(CheckInputValue());
                        }
                        Console.WriteLine(resId.GetInfo());
                        break;

                    case "-findn":
                        Console.Write("Введите название нужного экземпляра: ");
                        var title = Console.ReadLine();
                        if(title.ToLower() == "-close")
                        {
                            break;
                        }
                        var resTitle = lib.Find(title);
                        while (resTitle.Length == 0)
                        {
                            Console.Write("Не найдено эл-ов с таким названием.\nВведите название еще раз: ");
                            resTitle = lib.Find(Console.ReadLine());
                        }
                        foreach (var v in resTitle)
                        {
                            Console.WriteLine($"\n{v.GetInfo()}\n");
                        }
                            
                        break;

                    default:
                        Console.WriteLine("Строка пустая или вы ввели команду, которой не существует,\n\t либо она сейчас недоступна");
                        break;
                }
            }
        }

        #region Public Methods
        public static void Exit()
        {
            _exit = false;
        }

        /// <summary>
        /// Получает из библиотеки эл-т по Id, после получает его на св-ва и предлагает изменить одно из них
        /// Затем передает id, выбранное св-во и его новое значение библиотеке для изменения
        /// После успешного изменения дает выбор: продолжить или закончить
        /// Закончить - ввести "-close"; Продолжить - нажать Enter
        /// В случае выбора Id предпреждает о том, что изменить его невозможно, предлагает изменить выбор св-ва
        /// После каждого ввода стоят проверки на значение, если оно равно -1, то пользователь ввел -close, а значит нужно выйти
        /// </summary>
        /// <param name="lib">Библиотека</param>
        public static void Change(Library lib)
        {

            Console.WriteLine("Введите id элемента, который вы хотите изменить: ");

            var idToChange = CheckInputValue();
            if(idToChange == -1)
            {
                return;
            }
            while (!lib.Contains(idToChange))
            {
                Console.Write("Не найдено эл-ов с таким id\nВведите id еще раз: ");
                idToChange = CheckInputValue();
                if (idToChange == -1)
                {
                    return;
                }
            }

            PropertyInfo[] properties = lib.GetElementProperties(idToChange);

            for (int i = 0; i < properties.Length; i++)
            {
                Console.WriteLine($"{i + 1}. Св-во объекта:\n \tТип: {properties[i].PropertyType.Name} \tНазвание: {properties[i].Name}");
            }

            bool changeIsOver = false;

            while (!changeIsOver)
            {
                Console.WriteLine("Что вы хотите изменить?");

                var choice = CheckInputValue(properties.Length);
                if(choice == -1)
                {
                    break;
                }
                var propertyToChange = properties[choice - 1];

                Console.WriteLine($"Вы выбрали {propertyToChange.Name}, введите новое значение, " +
                    $"учитывая тип {propertyToChange.PropertyType.Name}: ");

                if(propertyToChange.PropertyType == typeof(int))
                {
                    if (propertyToChange.Name.ToLower() == "year")
                    {
                        int newValue = CheckInputYear();
                        if (newValue == -1)
                        {
                            break;
                        }
                        lib.ChangeElementProperty(idToChange, propertyToChange, newValue);
                        changeIsOver = ExitChangeMenu(propertyToChange.Name);
                    }
                    else if (propertyToChange.Name.ToLower() == "periodicity")
                    {
                        int newValue = CheckInputValue(31);
                        if (newValue == -1)
                        {
                            break;
                        }
                        lib.ChangeElementProperty(idToChange, propertyToChange, newValue);
                        changeIsOver = ExitChangeMenu(propertyToChange.Name);
                    }
                    else
                    {
                        int newValue = CheckInputValue();
                        if(newValue == -1)
                        {
                            break;
                        }
                        bool resultStatus = lib.ChangeElementProperty(idToChange, propertyToChange, newValue);
                        if (!resultStatus)
                        {
                            Console.WriteLine($"Не удалось изменить {propertyToChange.Name}, скорее всего, изменить его невозможно, выберите другое св-во");
                        }
                        else
                        {
                            changeIsOver = ExitChangeMenu(propertyToChange.Name);
                        }
                    }
                }
                else if(propertyToChange.PropertyType == typeof(string))
                {
                    var newValue = CheckInputString();
                    if(newValue == "")
                    {
                        break;
                    }
                    lib.ChangeElementProperty(idToChange, propertyToChange, CheckInputString());
                    changeIsOver = ExitChangeMenu(propertyToChange.Name);
                }
                else
                {
                    Console.WriteLine("Введенное вами значение соответсвует отличному от свойства типа\n\n" +
                        "Нажмите Enter чтобы продолжить или введите -close для выхода из меню изменения, " +
                    $"другие команды в данный момент недоступны\n");

                    if (Console.ReadLine().ToLower() == "-close")
                    {
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Просит ввести id элемента, после проверет, существует ли такой элемент, если нет
        /// то просит ввести id еще раз
        /// В случае если библиотека содержит такой эл-т, то передает его id библиотеке на удаление
        /// </summary>
        /// <param name="lib">Библиотке</param>
        public static void ElementToDelete(Library lib)
        {

            Console.Write("Введите id удаляемого экземпляра: ");

            var idToDelete = CheckInputValue();

            if (idToDelete == -1)
            {
                return;
            }

            while (!lib.Contains(idToDelete))
            {
                Console.Write("Не найдено эл-ов с таким id\nВведите id еще раз: ");
                idToDelete = CheckInputValue();
                if(idToDelete == -1)
                {
                    return;
                }
            }

            lib.Delete(idToDelete);
            Console.WriteLine("Вы успешно удалили экземпляр");
        }
        /// <summary>
        /// Осуществляет контроль за корректностью ввода праметров, если ввод неверный, предлагает исправить
        /// Дает выбор между существующими типами (журнал, книга)
        /// Создает экземпляр выбранного класса
        /// </summary>
        /// <param name="lib">Библиотека</param>
        /// <returns>Созданный экземпляр выбранного класса</returns>
        public static IBook CreateNew()
        {
            Console.WriteLine("Укажите тип создаваемого объекта. Прервать создание невозможно.\n Выберите один из вариантов, указав его номер\n\t1. Книга\n\t2. Журнал");
            var typeToCreate = CheckInputValue(2);

            Console.Write("Введите название: ");
            var title = CheckInputString();

            Console.Write("Введите количество: ");
            var quantity = CheckInputValue();

            Console.Write("Введите год издания: ");
            var date = CheckInputYear();

            Console.Write("Введите издательство: ");
            var edition = CheckInputString();

            if (typeToCreate == 1)
            {

                Console.Write("Введите имя автора книги: ");
                var author = CheckInputString();

                Console.Write("Введите название жанра книги: ");
                var genre = CheckInputString();

                return new Book(title, quantity, author, genre, date, edition);

            }
            else
            {

                Console.Write("Введите периодичность журнала: ");
                var periodicity = CheckInputValue(31);

                Console.Write("Введите номер журнала: ");
                var number = CheckInputValue();

                return new Magazine(title, quantity, date, edition, periodicity, number);

            }
        }
        /// <summary>
        /// Выводит список доступных для ввода команд
        /// </summary>
        public static void PrintCommands()
        {
            Console.WriteLine(
                $"-ins - добавить новый экземпляр\n" +
                $"-help - вывести список доступных команд\n" +
                $"-end - закончить работу\n" +
                $"-del - удалить экземпляр\n" +
                $"-change - изменить экземпляр\n" +
                $"-printall - вывести все имеющиеся экземпляры\n" +
                $"-findid - найти экземпляр по id\n" +
                $"-findn - найти экземпляр по имени\n"
                );
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Проверяет введенную команду, в случае "-close" возвращает false, 
        /// Если пользователь нажал Enter, то возвращает true
        /// </summary>
        /// <param name="propertyName">
        /// Т.к. метод вызывается после успешного изменения св-ва, он должен выводить название измененного св-ва, данный параметр им и является
        /// </param>
        /// <returns></returns>
        private static bool ExitChangeMenu(string propertyName)
        {
            Console.WriteLine($"Вы успешно изменили св-во {propertyName}, нажмите Enter чтобы продолжить или введите -close для выхода из меню изменения, " +
                    $"другие команды в данный момент недоступны\n");

            if (Console.ReadLine().ToLower() == "-close")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Осуществляет контроль ввода, не позволяет ввести пустую строку
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Введенная строка</returns>
        private static string CheckInputString()
        {
            var str = Console.ReadLine();
            if(str.ToLower() == "-close")
            {
                return "";
            }
            var check = str.Replace(" ", "");
            while (check.Length == 0)
            {
                Console.WriteLine("Вы ввели пустую строку");
                str = Console.ReadLine();
                check = str.Replace(" ", "");
            }
            return str;
        }
        /// <summary>
        /// Осуществляет контроль ввода, не позволяет ввести год НЕ в диапазоне [1 н.э. , Нынешний год]
        /// </summary>
        /// <returns>Введенный год</returns>
        private static int CheckInputYear()
        {
            int year;

            bool success;

            do
            {
                var value = Console.ReadLine();

                if (value.ToLower() == "-close")
                {
                    return -1;
                }

                success = int.TryParse(value, out year) && year > 0 && year < DateTime.Now.Year;
                if (!success)
                {
                    Console.WriteLine("\tВведите год от 1 г. н.э. до текущего");
                }

            } while (!success);

            return year;
        }
        /// <summary>
        /// Осуществляет контроль ввода, не позволяет ввести отрицательное, не целое, равное 0 и/или число больше переданного
        /// При вводе "-close" возвращает -1
        /// </summary>
        /// <param name="maxValue">Максимальное досутпное для ввода число</param>
        /// <returns>Введенное число</returns>
        private static int CheckInputValue(int maxValue)
        {
            int number;

            bool success;

            do
            {
                var value = Console.ReadLine();

                if (value.ToLower() == "-close")
                {
                    return -1;
                }

                success = int.TryParse(value, out number) && number <= maxValue && number > 0;
                if (!success)
                {
                    Console.WriteLine($"Введите целое положительное число, не больше {maxValue}: ");
                }

            } while (!success);

            return number;

        }
        /// <summary>
        /// Осуществляет контроль ввода, не позволяет ввести отрицательно, не целое и/или равное 0 число
        /// При вводе "-close" возвращает -1
        /// </summary>
        /// <returns>Введенное число</returns>
        private static int CheckInputValue()
        {

            int number;

            bool success;

            do
            {
                var value = Console.ReadLine();

                if (value.ToLower() == "-close")
                {
                    return -1;
                }

                success = int.TryParse(value, out number) && number > 0;
                if (!success)
                {
                    Console.WriteLine($"Введите целое положительное число: ");
                }

            } while (!success);

            return number;
        }
        #endregion

    }
}
