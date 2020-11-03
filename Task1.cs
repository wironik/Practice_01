using System;
using System.Collections.Generic;
using System.Text;

namespace SVM_Task_01
{
    class Task1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в магазин кристаллов.");
            Console.WriteLine("Хотите купить кристаллов?");
            Console.WriteLine("Введите любую клавишу, для выхода нажмите Q:");
            ConsoleKeyInfo choise = Console.ReadKey();
            while (choise.Key!=ConsoleKey.Q)
            {
                int crystal=0;
                Console.WriteLine("\nВведите количество золота, которое у вас есть: ");
                int zoloto = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите количество кристаллов, которые есть в магазине: ");
                int crystal_all = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите цену одного кристалла: ");
                int crystal_price = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nколичество золота у вас: " + zoloto);
                Console.WriteLine("количество кристаллов в магазине: " + crystal_all);
                Console.WriteLine("Цена за 1 кристалл: " + crystal_price);
                int crystal_none = crystal_all;
                Console.WriteLine("Приступить к покупке?");
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить, чтобы вернуться назад, нажмите q:");
                ConsoleKeyInfo choise1 = Console.ReadKey();
                while (choise1.Key != ConsoleKey.Q)
                {
                    while ((crystal_all > 0)&&(crystal_none!=0))
                    {
                        Console.WriteLine("Введите количество кристаллов, которое хотите купить: ");
                        int crystal_kolvo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("количество кристаллов, которое хотите приобрести: " + crystal_kolvo);
                        while (crystal_kolvo > crystal_all)
                        {
                            Console.WriteLine("\nВы ввели количество кристаллов, которое превышает количество всех кристаллов в магазине.");
                            Console.WriteLine("Введите количество кристаллов, которое хотите купить: ");
                            crystal_kolvo = Convert.ToInt32(Console.ReadLine());
                        }
                        int price = crystal_kolvo * crystal_price;
                        Console.WriteLine("Цена к оплате: " + price);
                        int zoloto_none = price - zoloto;
                        crystal_none = zoloto / crystal_price;
                        while (price > zoloto)
                        {
                            Console.WriteLine("\nУ вас недостаточно средств, чтобы совершить покупку.");
                            Console.WriteLine("Вам не хватает " + zoloto_none + " золота.");
                            Console.WriteLine("Вы можете купить только " + crystal_none + " кристаллов.");
                            Console.WriteLine("\nВведите количество кристаллов, которое хотите купить: ");
                            crystal_kolvo = Convert.ToInt32(Console.ReadLine());
                            while (crystal_kolvo > crystal_all)
                            {
                                Console.WriteLine("\nВы ввели количество кристаллов, которое превышает количество всех кристаллов в магазине.");
                                Console.WriteLine("Введите количество кристаллов, которое хотите купить: ");
                                crystal_kolvo = Convert.ToInt32(Console.ReadLine());
                            }
                            price = crystal_kolvo * crystal_price;
                        }
                        zoloto = zoloto - price;
                        crystal = crystal + crystal_kolvo;
                        crystal_all = crystal_all - crystal;
                        crystal_none = zoloto / crystal_price;
                        Console.WriteLine("\nПокупка совершена успешно!");
                        Console.WriteLine("количество золота осталось: " + zoloto);
                        Console.WriteLine("количество кристаллов получено: " + crystal);
                        Console.WriteLine("количество кристаллов в магазине: " + crystal_all);
                        Console.WriteLine("количество кристаллов, которое можно купить: " + crystal_none);
                        Console.WriteLine("\nХотите купить еще кристаллов?");
                        Console.WriteLine("Введите любую клавишу, для выхода нажмите Q:");
                    }
                    Console.WriteLine("количество кристаллов в магазине: " + crystal_all);
                    Console.WriteLine("Ваши средства: " + zoloto);
                    Console.WriteLine("Кристаллы закончились или вы не можете купить кристаллы. Для выхода нажмите q:");
                    choise1 = Console.ReadKey();
                }
                Console.WriteLine("\nСпасибо за покупку, приходите еще!");
                Console.WriteLine("Для того, чтобы начать заново, нажмите любую клавишу, для выхода нажмите q:");
                choise = Console.ReadKey();
            }

        }
    }
}
