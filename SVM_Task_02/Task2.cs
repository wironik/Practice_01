using System;

namespace SVM_Task_02
{
    class Task2
    {
        static void Main(string[] args)
        {
            string exit=" ";
            Console.WriteLine("Данная программа будет выполняться до тех пор, пока не будет введено слово exit");
            while (exit!="exit")
            {
                exit = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Вы ввели: " + exit);
            }
        }
    }
}
