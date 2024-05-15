using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1laba
{
    public class Menu
    {
        private static  string MyPath = "..\\..\\..\\";
       

        public static List<string> VyborImage(int actionNumber)
        {
            string[] FileNamesArray = GetFilesName();
            int[] numbers = new int[] { 4, 5, 6,7, 8 };
            if (numbers.Contains(actionNumber))
            {
                Console.WriteLine("Выберите изображение с которым хотите провести операцию");
                int img = Convert.ToInt32 (Console.ReadLine());
                Console.Clear();
                return new List<string>()
                {
                    FileNamesArray[img-1]
                };

            }

            Console.WriteLine("Выберите 2 изображения с которыми хотите провести операцию");
            Console.WriteLine("1 изображение :");
            int img1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("2 изображение :");
            int img2 = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            return new List<string>()
            {
                FileNamesArray[img1-1],
                FileNamesArray[img2-1]
            };

        }

        public static int ChoosingAnAction()
        {
            Console.WriteLine("Выберите действие из перечисленных");
            Console.WriteLine("1.Вычислить попиксельно сумму");
            Console.WriteLine("2.Вычислить попиксельно среднее арифметическое");
            Console.WriteLine("3.Вычислить попиксельно максимум");
            Console.WriteLine("4.Вычислить градационные преобразования");
            Console.WriteLine("5.Вычислить линейную фильтрацию");
            Console.WriteLine("6.Вычислить медианую фильтрацию");
            Console.WriteLine("7.бинаризация(Критерий Гаврилова)");
            Console.WriteLine("8.5 лаба");

            int actionNumber = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            return actionNumber;

        }

        private static string[] GetFilesName()
        {
            string[] FileNamesArray = Directory.GetFiles(MyPath)
               .Where(x => x.Contains(".jpg"))
               .ToArray();

            for (int i = 0; i < FileNamesArray.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Path.GetFileName(FileNamesArray[i])}");
            }
            return FileNamesArray;
        }

    
        public static void Processing(List<string> ImagesPath, int actionNumber)
        {
            Tren tren = ImagesPath.Count == 1 ?
                      new Tren(ImagesPath[0]) :
                      new Tren(ImagesPath[0], ImagesPath[1]);
            
            switch (actionNumber)
            {
                case 1:
                    {
                        tren.first();
                        break;
                    }
                case 2:
                    {
                        tren.two();
                        break;
                    }
                case 3:
                    {
                        tren.three();
                        break;
                    }
                case 4:
                    {
                        tren.GradationParallel();
                        break;
                    }
                    case 5:
                    {
                        tren.LinFiltr();
                        break;
                    }
                    case 6:
                    {
                        tren.MedianaFiltr();
                        break;
                    }
                    case 7:
                    {
                        tren.KriteriyGavrilova();
                        break;
                    }
                case 8:
                    {
                        tren.ChastotFiltrByte();
                        break;
                    }


            }
        }




    }
}
