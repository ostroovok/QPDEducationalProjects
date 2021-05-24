using System;
using LibrarianLogic;
using System.Reflection;

namespace TestApp.Theme3
{
    public static class Librarian
    {
        public static void Start()
        {
            Console.Clear();
            bool exit = true;
            Library lib = new();
            while (exit)
            {
                Console.WriteLine("-help - список команд;\t-end - конец работы");
                switch (Console.ReadLine())
                {
                    case "-ins":
                        lib.Insert(CreateNew(lib));
                        Console.WriteLine("Объект создан.");
                        break;
                    case "-help":
                        PrintCommands();
                        break;
                    case "-end":
                        Exit(out exit);
                        break;
                    case "-del":
                        ElementToDelete(lib);
                        Console.WriteLine("Объект удален.");
                        break;
                    case "-change":
                        Change(lib);
                        break;
                    case "-printall":
                        if(lib.Count == 0)
                            Console.WriteLine("Элементов не найдено!");
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
                        var resId = lib.Find(CheckInputValue());
                        while (resId == null)
                        {
                            Console.Write("Не найдено эл-ов с таким id!\nВведите id еще раз: ");
                            resId = lib.Find(CheckInputValue());
                        }
                        Console.WriteLine(resId.GetInfo());
                        break;
                    case "-findn":
                        Console.Write("Введите название нужного экземпляра: ");
                        var title = Console.ReadLine();
                        var resTitle = lib.Find(title);
                        while (resTitle.Length == 0)
                        {
                            Console.Write("Не найдено эл-ов с таким названием!\nВведите название еще раз: ");
                            resTitle = lib.Find(Console.ReadLine());
                        }
                        foreach (var v in resTitle)
                            Console.WriteLine($"\n{v.GetInfo()}\n");
                        break;
                    default:
                        Console.WriteLine("Строка пустая или вы ввели команду, которой не существует,\n\t либо она сейчас недоступна");
                        break;
                }
            }
        }
        public static void Exit(out bool exit)
        {
            exit = false;
        }
        public static void Change(Library lib)
        {

            Console.WriteLine("Введите id элемента, который вы хотите изменить: ");

            var temp = lib.Find(CheckInputValue());

            while (temp == null)
            {
                Console.Write("Не найдено эл-ов с таким id!\nВведите id еще раз: ");
                temp = lib.Find(CheckInputValue());
            }

            PropertyInfo[] properties = temp.GetType().GetTypeInfo().GetProperties();

            for (int i = 0; i < properties.Length; i++)
                Console.WriteLine($"{i + 1}. Св-во объекта:\n \tТип: {properties[i].PropertyType.Name} \tНазвание: {properties[i].Name} \tЗначение: {properties[i].GetValue(temp)}");

            bool changeIsOver = false;
            
            while (!changeIsOver)
            {
                Console.WriteLine("Что вы хотите изменить?");

                var propertyToChange = properties[CheckInputValue(properties.Length) - 1];

                Console.WriteLine($"Вы выбрали {propertyToChange.Name}, введите новое значение, " +
                    $"учитывая тип {propertyToChange.PropertyType.Name}: ");

                if(propertyToChange.PropertyType == typeof(int))
                {

                    if (propertyToChange.Name == "Id")
                    {

                        Console.WriteLine("Вы не можете изменить id\n");

                        Console.WriteLine($"Нажмите Enter чтобы продолжить или введите -close для выхода из меню изменения");

                        if (Console.ReadLine() == "-close")
                            changeIsOver = true;

                        continue;
                    }
                    else
                    {
                        propertyToChange.SetValue(temp, CheckInputValue());
                    }
                }
                else if (propertyToChange.PropertyType == typeof(Date))
                {
                    propertyToChange.SetValue(temp, CheckInputDate());
                }  
                else
                {
                    var value = Console.ReadLine();
                    propertyToChange.SetValue(temp, Convert.ChangeType(value, propertyToChange.PropertyType));
                }

                Console.WriteLine($"Вы успешно изменили св-во {propertyToChange.Name}, нажмите Enter чтобы продолжить или введите -close для выхода из меню изменения\n");

                if (Console.ReadLine() == "-close")
                    changeIsOver = true;
                
            }
        }
        public static void ElementToDelete(Library lib)
        {
            Console.WriteLine("Как вы хотите удалить экземпляр? Выберите один из вариантов, указав его номер\n1. id\n2. Название");

            var value = CheckInputValue(2);

            if(value == 1)
            {

                Console.Write("Введите id удаляемого экземпляра: ");

                var temp = lib.Find(CheckInputValue());

                while(temp == null)
                {

                    Console.Write("Не найдено эл-ов с таким id!\nВведите id еще раз: ");
                    temp = lib.Find(CheckInputValue());

                }

                lib.Delete(temp);
                Console.WriteLine("Вы успешно удалили экземпляр");
            }
            else if (value == 2)
            {
                Console.WriteLine("Введите название удаляемого экземпляра: ");

                IBook[] temp = lib.Find(Console.ReadLine());

                while (temp.Length == 0)
                {

                    Console.Write("Не найдено эл-ов с таким названием!\nВведите название еще раз: "); 
                    temp = lib.Find(Console.ReadLine());
                }

                if (temp.Length > 1)
                {

                    Console.WriteLine("Какой именно из эл-ов вы хотеите удалить?");

                    for (int i = 0; i < temp.Length; i++)
                    {

                        Console.WriteLine($"{i}.{temp[i].GetInfo()}\n");

                    }
                    Console.Write("Введите его номер: ");

                    int number = CheckInputValue();

                    lib.Delete(temp[number]);
                }
                else
                    lib.Delete(temp[0]);
            }
        }
        public static IBook CreateNew(Library lib)
        {
                Console.WriteLine("Укажите тип создаваемого объекта.  Выберите один из вариантов, указав его номер\n1. Книга\n2. Журнал");
            var n = CheckInputValue(2);

                Console.Write("Введите id: ");
            var id = CheckInputValue();

            while(lib.Find(id) != null)
            {

                Console.WriteLine("Экземпляр с таким id уже есть, введите новый id: ");
                id = CheckInputValue();

            }
                Console.Write("Введите название: ");
            var title = Console.ReadLine();

                Console.Write("Введите количество: ");
            var quantity = CheckInputValue();

                Console.WriteLine("Введите дату издания: ");
            var date = CheckInputDate();

                Console.Write("Введите издательство: ");
            var edition = Console.ReadLine();

            if (n == 1)
            {

                Console.Write("Введите имя автора книги: ");
                var author = Console.ReadLine();

                Console.Write("Введите название жанра книги: ");
                var genre = Console.ReadLine();
                
                return new Book(id, title, quantity, author, genre, date, edition);

            }
            else
            {

                Console.Write("Введите периодичность журнала: ");
                var periodicity = CheckInputValue();

                Console.Write("Введите номер журнала: ");
                var number = CheckInputValue();

                return new Magazine(id, title, quantity, date, edition, periodicity, number);

            }
            
        }

        private static Date CheckInputDate()
        {

            Console.Write("\tВведите год: ");

            var y = CheckInputValue();

            while (y > DateTime.Now.Year || y < 0)
            {

                Console.WriteLine("\tНекорректные данные");
                y = CheckInputValue();

            }

            Console.Write("\tВведите месяц: ");

            var m = CheckInputValue();

            while(m > 12 || m < 1)
            {

                Console.WriteLine("\tНекорректные данные");
                m = CheckInputValue();

            }

            Console.Write("\tВведите день: ");

            var d = CheckInputValue();

            while (d > 31 || d < 1)
            {

                Console.WriteLine("\tНекорректные данные");
                d = CheckInputValue();

            }

            return new(y,m,d);

        }

        private static int CheckInputValue(int maxValue)
        {
            var value = Console.ReadLine();

            int number;

            bool success = int.TryParse(value, out number) && number <= maxValue && number > 0;

            while (!success)
            {

                Console.WriteLine("Такого варианта нет!");
                value = Console.ReadLine();
                if (value.ToLower() == "-end")
                    Start();
                success = int.TryParse(value, out number) && number <= maxValue && number > 0;

            }

            return number;

        }
        private static int CheckInputValue()
        {

            var value = Console.ReadLine();

            int number;

            bool success = int.TryParse(value, out number) && number > 0;

            while (!success)
            {

                Console.WriteLine("Не число или число отрицательное!");
                value = Console.ReadLine();
                if (value.ToLower() == "-end")
                    Start();
                success = int.TryParse(value, out number) && number > 0;

            }

            return number;

        }

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
    }
}
