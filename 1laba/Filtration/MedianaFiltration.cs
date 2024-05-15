using _1laba.Helper.ClassHelper;
using _1laba.Pixel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1laba.Filtration
{
    internal class MedianaFiltration : Filtr
    {
        public MedianaFiltration(MyPixel[,] Pixels, double[,] Maska) : base(Pixels, Maska)
        {
        }

        public static MyPixel MedianaFiltr(MyPixel[,] Pixels, double[,] maska, Koordinata start, Koordinata end)
        {
            int N = Pixels.GetLength(0); int M = Pixels.GetLength(1);
            MyPixel[] newPixels = new MyPixel[maska.GetLength(0)*maska.GetLength(1)];
            
            int i_new=0;
            for(int i = start.i; i <= end.i; i++)
            {
                for(int j = start.j; j<= end.j; j++)
                {
                    var pixik = Pixels[i, j];
                    int r = pixik.r; int g = pixik.g; int b = pixik.b;
                    newPixels[i_new] = new MyPixel() { r = r, g = g, b = b };
                    i_new++;
                }
            }
           
            MyPixel pix = Sortirovka(newPixels);


            return pix;
        }

        public static MyPixel MedianaFiltr(MyPixel[,] Pixels)
        {
          
            int N = Pixels.GetLength(0); int M = Pixels.GetLength(1);
            MyPixel[] newPixels = new MyPixel[N * M];
           

            int i_new = 0;
            for (int i = 0; i < Pixels.GetLength(0); i++)
            {
                for (int j = 0; j < Pixels.GetLength(1); j++)
                {
                    var pixik = Pixels[i,j];
                    int r = pixik.r ; int g = pixik.g; int b = pixik.b;
                    newPixels[i_new] = new MyPixel() { r = r, g = g, b = b };
                    i_new++;
                }
            }
           

            MyPixel pix = Sortirovka(newPixels);


            return pix;

        }

        private static MyPixel Sortirovka(MyPixel[] pixels)
        {
            var arr = new PixelHelper[pixels.Length];
           // Console.WriteLine($"размерность равна {pixels.Length}");
            for (int i = 0; i < pixels.Length; i++)
            {
                if (pixels[i] == null)
                {
                    Console.WriteLine($"Пиксель равен нулл на {i} итерации");
                    // Пропускаем нулевые элементы и продолжаем цикл
                    continue;
                }
                int r = pixels[i].r; int g = pixels[i].g; int b = pixels[i].b;
                arr[i] = new PixelHelper(r + g + b, i);
            }

            // Удаляем нулевые элементы из массива arr
            arr = arr.Where(x => x != null).ToArray();

            Array.Sort(arr, (a, b) => a.sum.CompareTo(b.sum));

            int nomer = arr.Length / 2;

            return pixels[arr[nomer].nomer];
        }
    }
}
