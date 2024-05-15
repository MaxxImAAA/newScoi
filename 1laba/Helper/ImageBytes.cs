using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _1laba.Helper
{
    internal static class ImageBytes
    {
        public static byte[] GetImageBytes(int w, int h, Bitmap img)
        {
            using Bitmap _tmp = new Bitmap(w, h, PixelFormat.Format24bppRgb);

            _tmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using var g = Graphics.FromImage(_tmp);

            g.DrawImageUnscaled(img, 0, 0);

            return getImgBytes(_tmp);

        }

        public static Bitmap ImageBytesToBitmap(int w, int h, Bitmap img, byte[] output_bytes)
        {
            var img_ret = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            img_ret.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            writeImageBytes(img_ret, output_bytes);

            return img_ret;
        }




        private static byte[] getImgBytes(Bitmap img)
        {
            byte[] bytes = new byte[img.Width * img.Height * 3];  //выделяем память под массив байтов
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.ReadOnly,
                img.PixelFormat);
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);  //копируем байты изображения в массив
            img.UnlockBits(data);   //разблокируем изображение
            return bytes; //возвращаем байты
        }

        private static void writeImageBytes(Bitmap img, byte[] bytes)
        {
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.WriteOnly,
                img.PixelFormat);
            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length); //копируем байты массива в изображение

            img.UnlockBits(data);  //разблокируем изображение
        }
    }
}
