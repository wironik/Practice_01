using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace SVM_Task_05
{
    class Task5
    {
        static int PlayerHP = 100;
        static int x;
        static int y;
        static int coin;
        static public void GetInfo()
        {
            Console.SetCursorPosition(40, 1);
            Console.WriteLine("ИГРА 'СОБЕРИ ВСЕ МОНЕТЫ'");
            Console.SetCursorPosition(40, 2);
            Console.WriteLine("Управление: стрелки. Информация об игре: F1. Выход: ESC");
            Console.SetCursorPosition(40, 3);
            Console.WriteLine("Правила игры:\n");
            Console.SetCursorPosition(40, 4);
            Console.WriteLine("Ваша задача - собрать все монеты. Некоторые комнаты охраняются врагами, они\n");
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("отмечены буквой 'A'. Столкнувшись, вы должны будете сразиться с ними.\n");
            Console.SetCursorPosition(40, 6);
            Console.WriteLine("Чтобы восстановить здоровье, собирайте монеты, они добавляют +10 к здоровью.\n");
            Console.SetCursorPosition(40, 7);
            Console.WriteLine("Вы проиграете, если ваши жизни закончатся, поэтому будьте внимательнее.\n");
            Console.SetCursorPosition(40, 8);
            Console.WriteLine("После того как соберете все 50 монет, подойдите к букве 'E'.\n");
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("Удачи в игре!.\n");
        }
        static public char[,] ReadMap()
        {
            string[] newFile = File.ReadAllLines("..\\..\\..\\map.txt");
            char[,] array = new char[newFile.Length, newFile[0].Length];
            for (int j = 0; j < array.GetLength(0); j++)
            {
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    array[i, j] = newFile[j][i];

                    if (array[i, j] == '■')
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            return array;
        }
        static public void WriteMap(char[,] array)
        {
            Console.Clear();
            for (int j = 0; j < array.GetLength(0); j++)
            {
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }
        static public void MovePlayer(char[,] array, int x, int y)
        {
            int newVal;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow://лево
                    newVal = x - 1;
                    if (NotWall(array, newVal, y))
                        x = newVal;
                    break;
                case ConsoleKey.RightArrow://право
                    newVal = x + 1;
                    if (NotWall(array, newVal, y))
                        x = newVal;
                    break;
                case ConsoleKey.UpArrow://верх
                    newVal = y - 1;
                    if (NotWall(array, x, newVal))
                        y = newVal;
                    break;
                case ConsoleKey.DownArrow://низ
                    newVal = y + 1;
                    if (NotWall(array, x, newVal))
                        y = newVal;
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.WriteLine("\nВВы покинули игру!\n\n\n\n");
                    System.Environment.Exit(1);
                    break;
                case ConsoleKey.F1:
                    GetInfo();
                    break;
            }
            Console.SetCursorPosition(x, y);
            MovePlayer(array, x, y);
        }
        static public bool NotWall(char[,] array, int x, int y)
        {
            switch (array[x, y])
            {
                case ' ':
                    WritePlayerHP();
                    Console.SetCursorPosition(x, y);
                    return true;
                case '.':
                    coin += 1;
                    CoinCounter(array, x, y);
                    WritePlayerHP();
                    Console.SetCursorPosition(x, y);
                    if (PlayerHP < 100)
                        PlayerHP=PlayerHP+10;

                    return true;
                case 'A':
                    bool result=FightBoss();
                    if(result==true)
                    {
                        WriteMap(array);
                        Console.SetCursorPosition(x, y);
                        array[x, y] = ' ';
                        Console.Write(array[x, y]);
                        WritePlayerHP();
                        Console.SetCursorPosition(x, y);
                    }
                    else
                    {
                        Console.SetCursorPosition(40, 15);
                        Console.WriteLine("Сожалеем, вы умерли!");
                        System.Environment.Exit(1);
                    }
                    return result;
                case '■':
                    WritePlayerHP();
                    return true;
                case 'E':
                    if (coin == 50)
                    {
                        Console.Clear();
                        Console.WriteLine("ВВы прошли игру!\n\n\n\n");
                        System.Environment.Exit(1);
                        return true;
                    }
                    else return false;
                default:
                    return false;
            }
        }
        static void CoinCounter(char[,] array, int x, int y)
        {
            Console.SetCursorPosition(40, 13);
            if (coin > 0)
                Console.WriteLine("Вы собрали " +coin+ " монет!");
            Console.SetCursorPosition(x, y);
            array[x, y] = ' ';
            Console.Write(array[x, y]);
        }
        static void WritePlayerHP()
        {
            Console.SetCursorPosition(40, 12);
            if (PlayerHP <= 100)
                Console.WriteLine("Ваше здоровье: " + PlayerHP+"  ");
        }
        static bool FightBoss()
        {
            bool result = true;
            Random rnd = new Random();
            int BossHP = rnd.Next(20, 60);
            int damage;
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("Здоровье противника: " + BossHP+"  ");
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("Вы столкнулись с боссом. Победите его!");
            while(BossHP>0 && PlayerHP>0)
            {
                Console.SetCursorPosition(40, 16);
                Console.WriteLine("Для атаки нажмите любую клавишу:");
                Console.ReadKey();
                damage = rnd.Next(11, 16);
                Console.SetCursorPosition(40, 17);
                Console.WriteLine("Вы нанесли противнику "+damage+" урон");
                BossHP = BossHP - damage;
                damage = rnd.Next(15, 21);
                Console.SetCursorPosition(40, 18);
                Console.WriteLine("Противник нанес вам " + damage + " урон");
                PlayerHP = PlayerHP - damage;
                WritePlayerHP();
                Console.SetCursorPosition(40, 13);
                Console.WriteLine("Здоровье противника: " + BossHP+"  ");
            }
            if (PlayerHP <= 0)
            {
                result = false;
            }
            else if (BossHP<=0)
            {
                Console.SetCursorPosition(40, 20);
                Console.WriteLine("Вы победили босса!");
                Console.SetCursorPosition(40, 22);
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить:");
                Console.ReadKey();
                result = true;
            }
            Console.Clear();
            return result;
        }

        static void Main(string[] args)
        {
            char[,] mainArray=ReadMap();
            WriteMap(mainArray);
            GetInfo();
            CoinCounter(mainArray, x, y);
            Console.SetCursorPosition(x, y);
            MovePlayer(mainArray, x, y);
        }
    }
}
