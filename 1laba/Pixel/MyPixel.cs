using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1laba.Pixel
{
    internal class MyPixel
    {
        
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }

        public MyPixel(byte r, byte g, byte b)
            {
               this.r = Convert.ToInt32(r);
               this.g = Convert.ToInt32(g);
               this.b = Convert.ToInt32(b);
            }

        public MyPixel()
        {
            
        }

        public MyPixel(double r, double g, double b)
        {
            this.r = Convert.ToInt32(r);
            this.g = Convert.ToInt32(g);
            this.b = Convert.ToInt32(b);
        }

        /// <summary>
        /// массив байтов переводит в двумерный массив MyPixel
        /// </summary>
        /// <param name="input_bytes"></param>
        /// <param name="Pixels"></param>
        public static void BytesToPixel(byte[] input_bytes, MyPixel[,] Pixels)
        {
            int iPixel = 0;
            int jPixel = 0;

            for (int i = 0; i <= input_bytes.Length - 3; i += 3)
            {

                Pixels[iPixel, jPixel] = new MyPixel(input_bytes[i + 2], input_bytes[i + 1], input_bytes[i]);

                jPixel++;
                if (jPixel == Pixels.GetLength(1))
                {
                    jPixel = 0;
                    iPixel++;

                }

            }
        } 

        public static byte[] PixelsToByte(MyPixel[,] Pixels)
        {
            int N = Pixels.GetLength(0); int M = Pixels.GetLength(1);
            MyPixel[] newPixels = new MyPixel[N * M];

            // превращаем двумерный в одномерный;
            int new_i = 0;
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    newPixels[new_i] = Pixels[i, j];
                    new_i++;


                }
            }

            byte[] bytes = new byte[N * M * 3];

            new_i = 0;
            for(int i = 0; i < bytes.Length - 3; i += 3)
            {
                bytes[i] = (byte)newPixels[new_i].b;
                bytes[i + 1] = (byte)newPixels[new_i].g;
                bytes[i + 2] = (byte)newPixels[new_i].r;
                new_i++;
            }

           

            return bytes;


        }

    }
}
