using System;

namespace SVM_Task_06
{
    class Task6
    {
        static void Main(string[] args)
        {
            string[] name = new string[20];
            string[] post = new string[20];
            int size = 0;
            while (true)
            {
                Console.WriteLine("Выберите действие (нажмите нужную букву): ");
                Console.WriteLine("A: Добавить досье");
                Console.WriteLine("B: Вывести все досье");
                Console.WriteLine("C: Удалить досье");
                Console.WriteLine("D: Поиск по фамилии");
                Console.WriteLine("E: Выход");
                ConsoleKeyInfo choise = Console.ReadKey();
                while (choise.Key != ConsoleKey.A && choise.Key != ConsoleKey.B && choise.Key != ConsoleKey.C && choise.Key != ConsoleKey.D && choise.Key != ConsoleKey.E)
                {
                    Console.WriteLine("Такого действия не существует. Повторите попытку: ");
                    choise = Console.ReadKey();
                }
                if (choise.Key == ConsoleKey.A)
                {
                    AddLink(ref name, ref post, ref size);
                }
                else if (choise.Key == ConsoleKey.B)
                {
                    GetInfo(name, post, size);
                }
                else if (choise.Key == ConsoleKey.C)
                {
                    DeleteLink(ref name, ref post, ref size);
                }
                else if (choise.Key == ConsoleKey.D)
                {
                    SearchLink(name, post, size);
                }
                else if (choise.Key == ConsoleKey.E)
                    ExitProgram();
            }
        }
        static void ExitProgram()
        {
            Console.WriteLine("\nЗавершение программы\n\n\n\n");
            System.Environment.Exit(1);
        }
        static void SearchLink(string[] name, string[] post, int size)
        {
            string surname;
            int amount = 0;
            Console.WriteLine("\nВведите фамилию, которую необходимо найти: ");
            surname = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                if (name[i].IndexOf(surname, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine(i + 1 + ". " + name[i] + ", " + post[i]);
                    amount++;
                }
            }
            Console.WriteLine("\n");
            if (amount == 0)
                Console.WriteLine("Такая фамилия не была найдена. \n");
        }
        static void DeleteLink(ref string[] name, ref string[] post, ref int size)
        {
            if (size == 0)
                Console.WriteLine("\nЧтобы удалить досье, необходима хотя бы одна запись в нем.");
            else
            {
                int pos;
                Console.WriteLine("\nВведите количество позиций, которые хотите удалить: ");
                int amount = Convert.ToInt32(Console.ReadLine());
                while (amount <= 0)
                {
                    Console.WriteLine("Количество не может быть отрицательным или равно нулю.");
                    Console.WriteLine("Введите количество позиций, которые хотите удалить: ");
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                while (amount > 0)
                {
                    Console.WriteLine("\nВведите номер позиции: ");
                    pos = Convert.ToInt32(Console.ReadLine());
                    while ((pos <= 0) || (pos > size))
                    {
                        Console.WriteLine("Некорректное значение. Всего позиций: " + size);
                        Console.WriteLine("Введите номер позиции: ");
                        pos = Convert.ToInt32(Console.ReadLine());
                    }
                    pos--;
                    for (int i = pos; i < size; i++)
                    {
                        name[i] = name[i + 1];
                        post[i] = post[i + 1];
                    }
                    Console.WriteLine("\nТекущая позиция успешно удалена. \n");
                    GetInfo(name, post, size);
                    size--;
                    amount--;
                }
                Console.WriteLine("\nПозиции успешно удалены. \n");
            }
        }
        static void GetInfo(string[] name, string[] post, int size)
        {
            if (size==0)
                Console.WriteLine("\nДосье отсутствуют. ");
            else
            {
                Console.WriteLine("\nДосье всех сотрудников: ");
                Console.WriteLine("Фамилия Имя Должность\n");
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine(i + 1 +". "+ name[i] +", "+ post[i]);
                }
            }
            Console.WriteLine("\n");
        }
        static void AddLink(ref string[] name, ref string[] post, ref int size) 
        {
            int oldsize = size;
            Console.WriteLine("\nВведите количество позиций, которое хотите добавить: ");
            int newsize = Convert.ToInt32(Console.ReadLine());
            while (newsize <= 0)
            {
                Console.WriteLine("Неправильный размер массива.");
                Console.WriteLine("Введите количество позиций, которое хотите добавить: ");
                newsize = Convert.ToInt32(Console.ReadLine());
            }
            size = size + newsize;

            for (int i=oldsize; i<size; i++)
            {
                Console.WriteLine("Введите фамилию и имя: ");
                name[i] = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите должность: ");
                post[i] = Convert.ToString(Console.ReadLine());
            }
            Console.WriteLine("\nНовые позиции успешно добавлены. \n");
        }
    }
}
