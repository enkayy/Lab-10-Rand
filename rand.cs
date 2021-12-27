using System;
using System.Collections.Generic;

namespace RandomBarrels
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            List<int> Inside = new List<int>();
            List<int> Outside = new List<int>();
            int ReadFromConsole(string message)//Метод чтения числа с консоли
            {
                int a = 0;//Сюда пишем значение
                while (a == 0)//Пока оно ноль продолжаем требовать ввод
                {
                    Console.Write(message);//Пишем, что мы хотим от юзера
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());//Берём ввод с клавиатуры и пытаемся сделать цифрой
                        if (a < 1)//Нужно положительное число
                        {
                            Console.Write("Некорректный ввод.\n");//Выводим просьбу
                            a = 0;//Чтобы цикл продолжился
                        }
                    }
                    catch (Exception e)//Сделать цифрой не получилось
                    {
                        Console.Write("Некорректный ввод.\n");//Выводим просьбу
                        a = 0;//Чтобы цикл продолжился
                    }

                }
                return a;//Возвращаем
            }
            void FillInside(int z)//Заполняем массив бочками
            {
                int value;
                Random rnd = new Random();

                for (int i = 0; i < z;)//Цикл для N бочек
                {
                    if (!Inside.Contains(value = rnd.Next(1, z + 1)))
                    {
                        Inside.Add(value);
                        i++;
                    }
                }
            }
            void PrintList(List<int> L)//Выводим на экран список
            {
                int[] array = L.ToArray();//Делаем массив в целях оптимизации
                foreach (int z in array) Console.Write(" " + z.ToString());//Все элементы выводим через пробел
            }
            void NextBarrel() // Выпадение следующей бочки
            {
                Console.Write("Выпало число " + Inside[0]);//Уведомляем о том, какое число выпало
                Inside.Remove(Inside[0]);//Вычёркиваем из списка бочек в мешке
            }
            N = ReadFromConsole("Введите N: ");//ввод N
            FillInside(N);//Заполняем список бочек в мешке
            Console.Write("В мешке бочки с номерами:");//Выводим
            PrintList(Inside);
            while (Inside.Count != 0)//Пока бочки в мешке есть
            {
                Console.ReadLine();//Ждём когда пользователь нажмёт Enter
                NextBarrel();
            }
            Console.WriteLine("\nНажмите на любую клавишу...");
            Console.ReadKey();
        }
    }
}
