using System;

namespace SVM_Task_03
{
    class Task3
    {
        static void Main(string[] args)
        {
            string password = "пароль такой";
            string enter_password = " ";
            string poslanie = "'Вы молодец! пароль успешно разгадан, за это вам полагается награда в виде 150 золота.'";
            Console.WriteLine("Данная программа содержит секретное послание. Чтобы его увидеть, Вам нужно угадать пароль. У вас есть 3 попытки.");
            for (int i=1; i<4; i++)
            {
                Console.WriteLine("Введите пароль. Попытка " + i);
                enter_password = Convert.ToString(Console.ReadLine());
                if (enter_password == password)
                {
                    Console.WriteLine("Вы угадали пароль. Секретное послание: \n" + poslanie);
                    break;
                }
                Console.WriteLine("Неправильный пароль.");
            }
        }
    }
}
