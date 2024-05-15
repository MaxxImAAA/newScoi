using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _1laba.Filtration
{
    internal class Chastot
    {
        public static Complex[] BytesToComplexArray(byte[] bytes, int width, int height)
        {
            //Complex[,] complexArray = new Complex[height, width];
            var complexArray = new Complex[width * height];
            //int index = 0;
           /* for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Получение яркости пикселя из массива байтов
                    byte brightness = bytes[index++];
                    complexArray[y, x] = new Complex(brightness, 0); // Только действительная часть
                }
            }*/
            for(int i = 0; i <= bytes.Length; i += 3)
            {
                byte o = bytes[i];
                byte t = bytes[i+1];
                byte f = bytes[i+2];

                complexArray[i] = new Complex(o, 0);
                complexArray[i+1] = new Complex(t, 0);
                complexArray[i+2] = new Complex(f, 0);
            }
            return complexArray;
        }

        public static Complex[,] FourierTransform(Complex[,] image)
        {
            // Ваш код для преобразования Фурье
            // В этом примере будет использована простейшая реализация, которая просто копирует входной массив
            int height = image.GetLength(0);
            int width = image.GetLength(1);
            Complex[,] result = new Complex[height, width];
            Array.Copy(image, result, image.Length);
            return result;
        }

        public static Bitmap VisualizeFourier(Complex[,] fourierImage)
        {
            int height = fourierImage.GetLength(0);
            int width = fourierImage.GetLength(1);
            Bitmap magnitudeImage = new Bitmap(width, height);

            // Преобразование комплексных чисел в цвета пикселей
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int magnitude = (int)fourierImage[y, x].Real; // Действительная часть определяет яркость пикселя
                    magnitude = Math.Min(Math.Max(magnitude, 0), 255); // Ограничение значения в диапазоне 0-255
                    Color color = Color.FromArgb(magnitude, magnitude, magnitude); // Черно-белая градация
                    magnitudeImage.SetPixel(x, y, color);
                }
            }
            return magnitudeImage;
        }
    }
}
