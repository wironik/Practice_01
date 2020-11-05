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
                Console.WriteLine("\nВведите количество золота, которое у вас есть (введите целое число): ");
                int zoloto = Convert.ToInt32(Console.ReadLine());
                while(zoloto<=0)
                {
                    Console.WriteLine("Количество золота не может быть меньше нуля.");
                    Console.WriteLine("\nВведите количество золота, которое у вас есть (введите целое число): ");
                    zoloto = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Введите количество кристаллов, которые есть в магазине (введите целое число): ");
                int crystal_all = Convert.ToInt32(Console.ReadLine());
                while (crystal_all <= 0)
                {
                    Console.WriteLine("Количество кристаллов не может быть меньше нуля.");
                    Console.WriteLine("Введите количество кристаллов, которые есть в магазине (введите целое число): ");
                    crystal_all = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Введите цену за один кристалл (введите целое число): ");
                int crystal_price = Convert.ToInt32(Console.ReadLine());
                while (crystal_price <= 0)
                {
                    Console.WriteLine("Цена за один кристалл не может быть меньше нуля.");
                    Console.WriteLine("Введите цену за один кристалл (введите целое число): ");
                    crystal_price = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("\nколичество золота у вас: " + zoloto);
                Console.WriteLine("количество кристаллов в магазине: " + crystal_all);
                Console.WriteLine("Цена за 1 кристалл: " + crystal_price);

                Console.WriteLine("Приступить к покупке?");
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить, чтобы вернуться назад, нажмите q:");
                ConsoleKeyInfo choise1 = Console.ReadKey();
                int crystal_none = zoloto/crystal_price;
                while (choise1.Key != ConsoleKey.Q)
                {
                    while ((crystal_all > 0)&&(crystal_none!=0))
                    {
                        Console.WriteLine("\nВведите количество кристаллов, которое хотите купить (введите целое число): ");
                        int crystal_kolvo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("количество кристаллов, которое хотите приобрести: " + crystal_kolvo);
                        while (crystal_kolvo > crystal_all)
                        {
                            Console.WriteLine("\nВы ввели количество кристаллов, которое превышает количество всех кристаллов в магазине.");
                            Console.WriteLine("количество кристаллов в магазине: " + crystal_all);
                            Console.WriteLine("Введите количество кристаллов, которое хотите купить (введите целое число): ");
                            crystal_kolvo = Convert.ToInt32(Console.ReadLine());
                        }
                        int price = crystal_kolvo * crystal_price;
                        Console.WriteLine("Цена к оплате: " + price);
                        int zoloto_none = price - zoloto;
                        while (price > zoloto)
                        {
                            Console.WriteLine("\nУ вас недостаточно средств, чтобы совершить покупку.");
                            Console.WriteLine("Вам не хватает " + zoloto_none + " золота.");
                            Console.WriteLine("Вы можете купить только " + crystal_none + " кристаллов.");
                            Console.WriteLine("\nВведите количество кристаллов, которое хотите купить (введите целое число): ");
                            crystal_kolvo = Convert.ToInt32(Console.ReadLine());
                            while (crystal_kolvo > crystal_all)
                            {
                                Console.WriteLine("\nВы ввели количество кристаллов, которое превышает количество всех кристаллов в магазине.");
                                Console.WriteLine("количество кристаллов в магазине: " + crystal_all);
                                Console.WriteLine("Введите количество кристаллов, которое хотите купить (введите целое число): ");
                                crystal_kolvo = Convert.ToInt32(Console.ReadLine());
                            }
                            price = crystal_kolvo * crystal_price;
                        }
                        zoloto = zoloto - price;
                        crystal = crystal + crystal_kolvo;
                        crystal_all = crystal_all - crystal_kolvo;
                        crystal_none = zoloto / crystal_price;
                        Console.WriteLine("\nПокупка совершена успешно!");
                        Console.WriteLine("количество золота осталось: " + zoloto);
                        Console.WriteLine("количество кристаллов получено: " + crystal);
                        Console.WriteLine("количество кристаллов в магазине: " + crystal_all);
                        Console.WriteLine("количество кристаллов, которое можно купить с учетом средств: " + crystal_none);
                        break;
                    }
                    Console.WriteLine("\nХотите купить еще кристаллов?");
                    Console.WriteLine("количество кристаллов в магазине: " + crystal_all);
                    Console.WriteLine("Ваши средства: " + zoloto);
                    Console.WriteLine("количество кристаллов, которое можно купить с учетом средств: " + crystal_none);
                    Console.WriteLine("Введите любую клавишу, для выхода нажмите Q:");
                    Console.WriteLine("Вы не сможете купить еще кристаллов, если у вас недостаточно средств для покупки хотя бы одного кристалла, или кристаллы закончились.");
                    choise1 = Console.ReadKey();
                }
                Console.WriteLine("\nСпасибо за покупку, приходите еще!");
                Console.WriteLine("Для того, чтобы начать заново, нажмите любую клавишу, для выхода нажмите q:");
                choise = Console.ReadKey();
            }
            Console.WriteLine("\nСпасибо за покупку, приходите еще!\n\n\n");
        }

    }
}
