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
                Console.WriteLine("\n-help - список команд;\t-end - конец работы");
                switch (Console.ReadLine().ToLower().Replace(" ", ""))
                {
                    case "-ins":
                        lib.Insert(CreateNewObjectViaTheConsole());
                        Console.WriteLine("Объект создан.");
                        break;
                    case "-help":
                        PrintAvailableCommands();
                        break;
                    case "-end":
                        Exit();
                        break;
                    case "-del":
                        ElementToDelete(lib);
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
                        Console.Write("Введите Id нужного объекта: ");
                        var idToFind = GetIntegerExpressionFromConsole();
                        if(idToFind == -1)
                        {
                            break;
                        }
                        var resId = lib.Find(idToFind);
                        while (resId == null)
                        {
                            Console.Write("Не найдено эл-ов с таким id.\nВведите id еще раз: ");
                            resId = lib.Find(GetIntegerExpressionFromConsole());
                        }
                        Console.WriteLine(resId.GetInfo());
                        break;

                    case "-findn":
                        Console.Write("Введите название нужного объекта: ");
                        var title = Console.ReadLine();
                        if(title.ToLower() == "-end")
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
        /// Просит ввести id, после чего выводит список свойств объекта с этим id
        /// После получения id делает проверку на наличие объекта в библиотеке, если такого не нашлось - сообщает об этом
        /// Далее принимает значения:
        ///     1. Номер изменяемого св-ва по выведенному списку
        ///     2. Если св-во по номеру это св-во "Год", то происходит проверка корректности ввода
        ///     3. Новое значение св-ва
        /// После вызывает метод библиотеки по изменению и передает полученные значения
        /// В случае неудачи сообщает об этом и просит првоерить введенные значения
        /// </summary>
        /// <param name="lib"></param>
        public static void Change(Library lib)
        {
            Console.Write("\nВведите id эл-та: ");
            var objId = GetIntegerExpressionFromConsole();
            if(objId == -1)
            {
                return;
            }

            var propertiesNames = lib.GetElementPropertiesInfo(objId);
            if (propertiesNames[0] == "notFound")
            {
                Console.WriteLine("\nЭлементов с таким id не было найдено");
                return;
            }

            Console.WriteLine("\nВыберите номер св-ва, которое вы хотите изменить: \n\tId генерируется автоматически при создании, изменить его невозможно");

            for (int i = 0; i < propertiesNames.Length; i++)
            {
                Console.WriteLine($"{i+1}. {propertiesNames[i]} ");
            }

            Console.WriteLine("\nНомер: ");
            var propertyNumber = GetLimitedIntegerExpressionFromConsole(propertiesNames.Length);
            if(propertyNumber == -1)
            {
                return;
            }

            var propertyNewValue = GetStringExpressionFromConsole(); 

            Console.Write("\nВведите новое значение св-ва: ");

            if (propertyNewValue == "" || propertyNewValue == "-1")
            {
                return;
            }


            if (lib.ChangeElementProperty(objId, propertyNumber - 1, propertyNewValue))
            {
                Console.WriteLine($"\nСв-во {propertiesNames[propertyNumber - 1]} было успешно изменено\n");
            }
            else
            {
                Console.WriteLine($"\nНе удалось применить изменения, проверьте введные данные {objId} : {propertyNewValue}\n\nВозможно, вы выбрали id, помните, " +
                    $"id генерируется автоматически при создании, изменить его невозможно\n\nТак же важно понимать, что св-ву год нельзя присвоить значение до 1 г. н.э. или больше нынешнего года");
            }

        }
        /// <summary>
        /// Просит ввести id элемента, после проверет, существует ли такой элемент, если нет
        /// то просит ввести id еще раз
        /// В случае если библиотека содержит такой эл-т, то передает его id библиотеке на удаление
        /// </summary>
        /// <param name="lib">Библиотка</param>
        public static void ElementToDelete(Library lib)
        {

            Console.Write("Введите id удаляемого объекта: ");

            var idToDelete = GetIntegerExpressionFromConsole();

            if (idToDelete == -1)
            {
                return;
            }

            if (!lib.Delete(idToDelete))
            {
                Console.WriteLine("\nНе удалось удалить объект (не найдено эл-ов с таким id)");
                return;
            }
            Console.WriteLine("\nОбъект удален.");
        }
        /// <summary>
        /// Осуществляет контроль за корректностью ввода праметров, если ввод неверный, предлагает исправить
        /// Дает выбор между существующими типами (журнал, книга)
        /// Создает экземпляр выбранного класса
        /// </summary>
        /// <param name="lib">Библиотека</param>
        /// <returns>Созданный экземпляр выбранного класса</returns>
        public static IBook CreateNewObjectViaTheConsole()
        {
            Console.WriteLine("Укажите тип создаваемого объекта. Прервать создание невозможно.\n Выберите один из вариантов, указав его номер\n\t1. Книга\n\t2. Журнал");
            var typeToCreate = GetLimitedIntegerExpressionFromConsole(2);

            Console.Write("Введите название: ");
            var title = GetStringExpressionFromConsole();

            Console.Write("Введите количество: ");
            var quantity = GetIntegerExpressionFromConsole();

            Console.Write("Введите год издания: ");
            var date = GetYearExpressionFromConsole();

            Console.Write("Введите издательство: ");
            var edition = GetStringExpressionFromConsole();

            if (typeToCreate == 1)
            {

                Console.Write("Введите имя автора книги: ");
                var author = GetStringExpressionFromConsole();

                Console.Write("Введите название жанра книги: ");
                var genre = GetStringExpressionFromConsole();

                return new Book(title, quantity, author, genre, date, edition);

            }
            else
            {

                Console.Write("Введите периодичность журнала: ");
                var periodicity = GetStringExpressionFromConsole();

                Console.Write("Введите номер журнала: ");
                var number = GetIntegerExpressionFromConsole();

                return new Magazine(title, quantity, date, edition, periodicity, number);

            }
        }
        /// <summary>
        /// Выводит список доступных для ввода команд
        /// </summary>
        public static void PrintAvailableCommands()
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
        /// Осуществляет контроль ввода строки, не позволяет ввести пустую
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Введенная строка</returns>
        private static string GetStringExpressionFromConsole()
        {
            var str = Console.ReadLine();
            if (str.ToLower() == "-end")
            {
                return "";
            }
            var check = str.Replace(" ", "");
            while (check.Length == 0)
            {
                Console.Write("\nВы ввели пустую строку, повторите ввод: ");
                str = Console.ReadLine();
                check = str.Replace(" ", "");
            }
            return str;
        }
        /// <summary>
        /// Осуществляет контроль ввода, не позволяет ввести год НЕ в диапазоне [1 н.э. , Нынешний год]
        /// </summary>
        /// <returns>Введенный год</returns>
        private static int GetYearExpressionFromConsole()
        {
            int year;

            bool success;

            do
            {
                var value = Console.ReadLine();

                if (value.ToLower() == "-end")
                {
                    return -1;
                }

                success = int.TryParse(value, out year) && year > 0 && year <= DateTime.Now.Year;
                if (!success)
                {
                    Console.Write("\nВведите год от 1 г. н.э. до текущего: ");
                }

            } while (!success);

            return year;
        }
        /// <summary>
        /// Осуществляет контроль ввода, не позволяет ввести отрицательное, не целое, равное 0 и/или число больше переданного
        /// При вводе "-end" возвращает -1
        /// </summary>
        /// <param name="limit">Максимальное досутпное для ввода число</param>
        /// <returns>Введенное число</returns>
        private static int GetLimitedIntegerExpressionFromConsole(int limit)
        {
            int number;

            bool success;

            do
            {
                var value = Console.ReadLine();

                if (value.ToLower() == "-end")
                {
                    return -1;
                }

                success = int.TryParse(value, out number) && number <= limit && number > 0;
                if (!success)
                {
                    Console.Write($"\nВведите целое положительное число, не больше {limit}: ");
                }

            } while (!success);

            return number;

        }
        /// <summary>
        /// Осуществляет контроль ввода, не позволяет ввести отрицательно, не целое и/или равное 0 число
        /// При вводе "-end" возвращает -1
        /// </summary>
        /// <returns>Введенное число</returns>
        private static int GetIntegerExpressionFromConsole()
        {

            int number;

            bool success;

            do
            {
                var value = Console.ReadLine();

                if (value.ToLower() == "-end")
                {
                    return -1;
                }

                success = int.TryParse(value, out number) && number > 0;
                if (!success)
                {
                    Console.Write($"\nВведите целое положительное число: ");
                }

            } while (!success);

            return number;
        }
        #endregion

    }
}
