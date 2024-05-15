using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1laba.Helper
{
    internal static class HelperClass
    {
        public static void RachetPotokov(int Height, out int countPotok, out int razmernost)
        {
            countPotok = 0;
            razmernost = 0;
            for (int i = 2; i <= 8; i += 2)
            {
                if (Height % i == 0)
                {
                    countPotok = i;
                    razmernost = Height / i;

                }

            }


        }


      /*  public static void MethodFor2Mer(int start, int end, Bitmap img, Bitmap outimg)
        {
            // Console.WriteLine($"Метод запустился в потоке {Task.CurrentId}");
            for (int i = start; i < end; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    var pix = img.GetPixel(j, i);

                    int r = pix.R;
                    int g = pix.G;
                    int b = pix.B;

                    int new_r = (int)(255.0 * ((r / 255.0) * (r / 255.0)));
                    int new_g = (int)(255.0 * ((g / 255.0) * (g / 255.0))); // формула
                    int new_b = (int)(255.0 * ((b / 255.0) * (b / 255.0)));

                    new_r = (int)Clamp(new_r * 1.4, 0, 255);
                    new_g = (int)Clamp(new_g * 1.4, 0, 255);
                    new_b = (int)Clamp(new_b * 1.4, 0, 255);

                    var newpix = Color.FromArgb(new_r, new_g, new_b);

                    outimg.SetPixel(j, i, newpix);

                }

            }

        }*/

        public static void MethodFor1Mer(int start, int end, byte[] img, byte[] outimg)
        {
            Console.WriteLine($"Метод начал работу в потоке{Task.CurrentId}");
            for(int i = start; i < end-3; i=i+3)
            {
                int b = Convert.ToInt32(img[i]);
                int g = Convert.ToInt32(img[i+1]);
                int r = Convert.ToInt32(img[i+2]);

                int new_r = (int)(255.0 * ((r / 255.0) * (r / 255.0)));
                int new_g = (int)(255.0 * ((g / 255.0) * (g / 255.0))); // формула
                int new_b = (int)(255.0 * ((b / 255.0) * (b / 255.0)));

               /* new_r = (int)Clamp(new_r * 1.4, 0, 255);
                new_g = (int)Clamp(new_g * 1.4, 0, 255);
                new_b = (int)Clamp(new_b * 1.4, 0, 255);*/

                outimg[i] = Convert.ToByte(new_b);
                outimg[i+1] = Convert.ToByte(new_g);
                outimg[i+2] = Convert.ToByte(new_r);
            }

        }

       
      



        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

    }
}
