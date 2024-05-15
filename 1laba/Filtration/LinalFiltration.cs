using _1laba.Helper;
using _1laba.Helper.ClassHelper;
using _1laba.MaskaFolder;
using _1laba.Pixel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1laba.Filtration
{
    internal  class LinalFiltration : Filtr
    {
        public LinalFiltration(MyPixel[,] Pixels, double[,] Maska) : base(Pixels, Maska)
        {
            
        }
        public static  MyPixel Filtr(MyPixel[,] Pixels, double[,] maska, Koordinata start, Koordinata end)
        {
            int imaska = 0;
            int jmaska;

            double resR = 0;
            double resG = 0;
            double resB = 0;
            for(int i = start.i; i <= end.i; i++)
            {
                jmaska = 0;
                for(int j = start.j; j <= end.j; j++)
                {
                    resR += Pixels[i, j].r * maska[imaska, jmaska];
                    resG += Pixels[i, j].g * maska[imaska, jmaska];
                    resB += Pixels[i, j].b * maska[imaska, jmaska];
                    jmaska++;

                }
                imaska++;
            }

            resR = (int)HelperClass.Clamp(resR * 1.4, 0, 255);
            resG = (int)HelperClass.Clamp(resG * 1.4, 0, 255);
            resB = (int)HelperClass.Clamp(resB * 1.4, 0, 255);

            return new MyPixel(resR, resG, resB);
            
        }

        public static MyPixel Filtr(MyPixel[,] Pixels, double[,] maska)
        {
            int N = Pixels.GetLength(0); int M = Pixels.GetLength(1);

            int imaska = 0;
            int jmaska;

            double resR = 0;
            double resG = 0;
            double resB = 0;
            for (int i = 0; i < N ; i++)
            {
                jmaska = 0;
                for (int j = 0; j < M; j++)
                {
                    resR += Pixels[i, j].r * maska[i, j];
                    resG += Pixels[i, j].g * maska[i, j];
                    resB += Pixels[i, j].b * maska[i, j];
                    jmaska++;

                }
                imaska++;
            }

            resR = (int)HelperClass.Clamp(resR * 1.4, 0, 255);
            resG = (int)HelperClass.Clamp(resG * 1.4, 0, 255);
            resB = (int)HelperClass.Clamp(resB * 1.4, 0, 255);

            return new MyPixel(resR, resG, resB);

        }




    }
}
