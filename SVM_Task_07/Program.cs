using System;

namespace SVM_Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            int[] NewArr = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++) arr[i] = rnd.Next(0, 100);

            Console.WriteLine("\nИсходный массив:");
            PrintArr(arr, size);
            Console.WriteLine("\nИтоговый массив:");
            Shuffle(arr, size);
            PrintArr(arr, size);
        }
        static void PrintArr(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
                Console.Write(arr[i]+" ");
            Console.Write("\n");
        }
        static void Shuffle(int[] arr, int size)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                int j = rnd.Next(0, i+1);
                int temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }
        }
    }
}
