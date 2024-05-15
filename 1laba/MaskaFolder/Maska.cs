using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1laba.MaskaFolder
{
    internal class Maska
    {
        public static double[,] GetMaska()
        {
            Console.WriteLine("Введите нечетный N маски");
            int N = Convert.ToInt32(Console.ReadLine());
            while(N % 2 == 0)
            {
                Console.WriteLine("Нечетный!!!");
                N = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите нечетный M маски");
            int M = Convert.ToInt32(Console.ReadLine());
            while (M % 2 == 0)
            {
                Console.WriteLine("Нечетный!!!");
                M = Convert.ToInt32(Console.ReadLine());
            }

            double[,] maskaArr = new double[N,M];

            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1.Заполнить одним числом весь массив");
            Console.WriteLine("2.Заполнить массив вручную");
            int number = Convert.ToInt32(Console.ReadLine());

            

            /* for(int i = 0; i < maskaArr.GetLength(0); i ++)
             {
                 for(int j = 0; j<maskaArr.GetLength(1); j++)
                 {
                     maskaArr[i, j] = num;
 ;                }
             }*/

            switch (number)
            {
                case 1:
                    {
                        Console.WriteLine("Введите число которое будет содержаться в маске");
                        double num = Convert.ToDouble(Console.ReadLine());
                        for (int i = 0; i < maskaArr.GetLength(0); i++)
                        {
                            for (int j = 0; j < maskaArr.GetLength(1); j++)
                            {
                                maskaArr[i, j] = num;
                                
                            }
                        }
                        break;
                    }

                case 2:
                    {
                        int f = 0;
                        for (int i = 0; i < maskaArr.GetLength(0); i++)
                        {
                            if (f == 1)
                            {
                                PrintMaska(maskaArr, i-1);
                            }
                            
                            for (int j = 0; j < maskaArr.GetLength(1); j++)
                            {
                                f = 1;
                                Console.WriteLine($"Введите [{i},{j}]");
                                maskaArr[i, j] = Convert.ToDouble(Console.ReadLine());

                            }
                            Console.Clear();
                        }
                        break;

                    }
                        
            }

            return maskaArr;
        }

       private static void PrintMaska(double[,] maska, int newi)
        {
            Console.WriteLine("Маска:");
            for(int i = 0; i <= newi; i++)
            {
                for(int j = 0; j < maska.GetLength(1); j++)
                {
                    Console.Write($"{maska[i, j]} ");

                }
                Console.WriteLine();
            }
        }

       

    }
}
