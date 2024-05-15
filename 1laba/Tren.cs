using _1laba.Binarization;
using _1laba.Filtration;
using _1laba.Helper;
using _1laba.Helper.ClassHelper;
using _1laba.MaskaFolder;
using _1laba.Pixel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _1laba
{
    public class Tren
    {
        private static string pathImg1;
        private static string pathImg2;

        public Tren(string _pathImg1)
        {
            pathImg1 = _pathImg1;
        }
        public Tren(string _pathImg1, string _pathImg2)
        {
            pathImg1 = _pathImg1;
            pathImg2 = _pathImg2;
        }

        public  void first()
        {
            using var img1 = new Bitmap(pathImg1);
            using var img2 = new Bitmap(pathImg2);

            var w = img1.Width;
            var h = img1.Height;

            using var img_out = new Bitmap(w, h);

            var start = DateTime.UtcNow;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    var pix1 = img1.GetPixel(j, i);
                    var pix2 = img2.GetPixel(j, i);

                    int r1 = pix1.R;
                    int r2 = pix2.R;
                    int newr = r1 + r2;

                    int g1 = pix1.G;
                    int g2 = pix2.G;
                    int newg = g1 + g2;

                    int b1 = pix1.B;
                    int b2 = pix2.B;
                    int newb = b1 + b2;

                    newr = (int)HelperClass.Clamp(newr * 1.4, 0, 255);
                    newg = (int)HelperClass.Clamp(newg * 1.4, 0, 255);
                    newb = (int)HelperClass.Clamp(newb * 1.4, 0, 255);

                    var newpix = Color.FromArgb(newr, newg, newb);

                    img_out.SetPixel(j, i, newpix);

                }
            }

            /*Parallel.For(0, h, i =>
            {
                for (int j = 0; j < w; j++)
                {
                    Color pix1, pix2;
                    lock (img1)
                    {
                        pix1 = img1.GetPixel(j, i);
                    }
                    lock (img2)
                    {
                        pix2 = img2.GetPixel(j, i);
                    }

                    int newr = Clamp(pix1.R + pix2.R, 0, 255);
                    int newg = Clamp(pix1.G + pix2.G, 0, 255);
                    int newb = Clamp(pix1.B + pix2.B, 0, 255);

                    newr = (int)(newr * 1.4);
                    newg = (int)(newg * 1.4);
                    newb = (int)(newb * 1.4);

                    newr = Clamp(newr, 0, 255);
                    newg = Clamp(newg, 0, 255);
                    newb = Clamp(newb, 0, 255);

                    Color newpix = Color.FromArgb(newr, newg, newb);

                    lock (img_out)
                    {
                        img_out.SetPixel(j, i, newpix);
                    }
                }
            });*/

            var end = DateTime.UtcNow;
            var res = end - start;
            Console.WriteLine($"Результат занял {res.Milliseconds} миллисекунд");
            SaveImg(img_out);
            //img_out.Save("..\\..\\..\\out1.jpg");
        }

        public  void two()
        {
            using var img1 = new Bitmap(pathImg1);
            using var img2 = new Bitmap(pathImg2);

            var w = img1.Width;
            var h = img1.Height;

            using var img_out = new Bitmap(w, h);

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    var pix1 = img1.GetPixel(j, i);
                    var pix2 = img2.GetPixel(j, i);

                    int r1 = pix1.R;
                    int r2 = pix2.R;
                    int newr = (r1 + r2)/2;

                    int g1 = pix1.G;
                    int g2 = pix2.G;
                    int newg = (g1 + g2)/2;

                    int b1 = pix1.B;
                    int b2 = pix2.B;
                    int newb = (b1 + b2)/2;

                    newr = (int)HelperClass.Clamp(newr * 1.4, 0, 255);
                    newg = (int)HelperClass.Clamp(newg * 1.4, 0, 255);
                    newb = (int)HelperClass.Clamp(newb * 1.4, 0, 255);

                    var newpix = Color.FromArgb(newr, newg, newb);

                    img_out.SetPixel(j, i, newpix);



                }
            }
            SaveImg(img_out);
            //img_out.Save("..\\..\\..\\out2.jpg");

        }

        public  void three()
        {
            using var img1 = new Bitmap(pathImg1);
            using var img2 = new Bitmap(pathImg2);

            var w = img1.Width;
            var h = img1.Height;

            using var img_out = new Bitmap(w, h);

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    var pix1 = img1.GetPixel(j, i);
                    var pix2 = img2.GetPixel(j, i);

                    int r1 = pix1.R;
                    int r2 = pix2.R;
                    int newr = int.Max(r1, r2);

                    int g1 = pix1.G;
                    int g2 = pix2.G;
                    int newg = int.Max(g1, g2); 

                    
                    int b1 = pix1.B;
                    int b2 = pix2.B;
                    int newb = int.Max(b1,b2);

                    newr = (int)HelperClass.Clamp(newr * 1.4, 0, 255);
                    newg = (int)HelperClass.Clamp(newg * 1.4, 0, 255);
                    newb = (int)HelperClass.Clamp(newb * 1.4, 0, 255);

                    var newpix = Color.FromArgb(newr, newg, newb);

                    img_out.SetPixel(j, i, newpix);



                }
            }
            SaveImg(img_out);
            //img_out.Save("..\\..\\..\\out3.jpg");

        }

        public void Gradation()
        {
            using var img = new Bitmap(pathImg1);

            var w = img.Width;
            var h = img.Height;

            using var img_out = new Bitmap(w, h);

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    var pix = img.GetPixel(j, i);

                    int r = pix.R;
                    int g = pix.G;
                    int b = pix.B;

                    int new_r = (int)(255.0 * ((r / 255.0) * (r / 255.0)));
                    int new_g = (int)(255.0 * ((g / 255.0) * (g / 255.0))); // формула
                    int new_b = (int)(255.0 * ((b / 255.0) * (b / 255.0)));

                    new_r = (int)HelperClass.Clamp(new_r * 1.4, 0, 255);
                    new_g = (int)HelperClass.Clamp(new_g * 1.4, 0, 255);
                    new_b = (int)HelperClass.Clamp(new_b * 1.4, 0, 255);
                    
                    var newpix = Color.FromArgb(new_r, new_g, new_b);

                    img_out.SetPixel(j, i, newpix);


                }
            }
            SaveImg(img_out);
        }

        /*public void GradationParallel()
        {
            using var img = new Bitmap(pathImg1);

            var w = img.Width;
            var h = img.Height;

            using var img_out = new Bitmap(w, h);

            int countPotok;
            int razmernost;

            HelperClass.RachetPotokov(img.Height, out countPotok, out razmernost);

            Task[] Tasks = new Task[countPotok];

            int start = 0;
            int razmernostKlon = razmernost;

            for (int i = 0; i < Tasks.Length; i++)
            {
               
                int startCopy = start;
                int razmernostKlonCopy = razmernostKlon;

                Tasks[i] = Task.Run(() => HelperClass.MethodFor2Mer(startCopy, razmernostKlonCopy, img, img_out));
                start += razmernost;
                razmernostKlon += razmernost;
            }

            Task.WaitAll(Tasks);

            SaveImg(img_out);
        }
        */


        public void GradationParallel()
        {
            using var img = new Bitmap(pathImg1);
            var w = img.Width;
            var h = img.Height;


            byte[] input_bytes = ImageBytes.GetImageBytes(w, h, img);
            byte[] output_bytes = new byte[input_bytes.Length];

            string f1 = Path.GetFileName(pathImg1);
            Gistogramma.GetGistogramm(input_bytes, f1+"IN");
           

            int razmernost = input_bytes.Length / 3;
            int start = 0;
            
            Task[] Tasks = new Task[3];
            for(int i = 0; i< Tasks.Length; i++)
            {
                int startcopy = start;
                
                Tasks[i] = Task.Run(() => HelperClass.MethodFor1Mer(startcopy, startcopy+razmernost, input_bytes, output_bytes));
                start += razmernost;

            }

            Task.WaitAll(Tasks);

            Gistogramma.GetGistogramm(output_bytes, f1 + "OUT");
            using var img_ret = ImageBytes.ImageBytesToBitmap(w, h, img, output_bytes);

            SaveImg(img_ret);

        }

        public void LinFiltr()
        {
            using var img = new Bitmap(pathImg1);
            var w = img.Width;
            var h = img.Height;

            // получаем байты
            var input_bytes = ImageBytes.GetImageBytes(w, h, img);

            MyPixel[,] Pixels = new MyPixel[h, w];

           // Из байты в Двумерный массив MyPixel
            
            MyPixel.BytesToPixel(input_bytes, Pixels);
            
            // создание маски
            double[,] maskaArr = Maska.GetMaska();

            // вычисляем координаты центра маски 
            var centrMaska = new 
            {
                i = (maskaArr.GetLength(0) - 1) / 2,
                j = (maskaArr.GetLength(1) - 1) / 2

            };

            // создание двумерного массива состоящего из MyPixel размером с размер маски, для озеркаливания и последующей работы с ним
            var newPixels = new MyPixel[maskaArr.GetLength(0), maskaArr.GetLength(1)];

            // Создание Массива выходного 
            var outPixel = new MyPixel[Pixels.GetLength(0), Pixels.GetLength(1)];

            for(int i = 0; i < Pixels.GetLength(0); i++)
            {
                for(int j = 0; j < Pixels.GetLength(1); j++)
                {
                    var kletka = new Koordinata(i, j);
                    var start = new Koordinata { i = i - centrMaska.i, j = j - centrMaska.j };
                    var end = new Koordinata { i = i + centrMaska.i, j = j + centrMaska.j };

                    // если матрица вмещается в изо
                    /* if ((start.i >=0 && start.j>=0)&&(end.i<=Pixels.GetLength(0)-1 && end.j <= Pixels.GetLength(1)-1)) 
                     {
                         outPixel[i,j] =  LinalFiltration.Filtr(Pixels, maskaArr, start, end);

                     }*/
                    if (start.IsNorm() && end.IsNorm(Pixels.GetLength(0),Pixels.GetLength(1)))
                    {
                        outPixel[i, j] = LinalFiltration.Filtr(Pixels, maskaArr, start, end);

                    }
                    else
                    {
                        var newMask = LinalFiltration.Otzerkal(Pixels, maskaArr.GetLength(0), maskaArr.GetLength(1), kletka);
                        outPixel[i, j] = LinalFiltration.Filtr(newMask, maskaArr);
                    }
                    // если центр матрицы на границах или она не вмещается в изо


                    
                    

                }
            }

            var outbytes = MyPixel.PixelsToByte(outPixel);


            using var img_ret = ImageBytes.ImageBytesToBitmap(w, h, img, outbytes);


            /*for(int i = 0; i< Pixels.GetLength(0); i++)
            {
                for(int j = 0; j < Pixels.GetLength(1); j++)
                {
                    Console.WriteLine($"{Pixels[i, j].r} {Pixels[i, j].r} {Pixels[i, j].r}");
                }
            }*/
            SaveImg(img_ret);

        }

        public void MedianaFiltr()
        {
            using var img = new Bitmap(pathImg1);
            var w = img.Width;
            var h = img.Height;

            // получаем байты
            var input_bytes = ImageBytes.GetImageBytes(w, h, img);

            MyPixel[,] Pixels = new MyPixel[h, w];

            // Из байты в Двумерный массив MyPixel

            MyPixel.BytesToPixel(input_bytes, Pixels);

            // создание маски
            double[,] maskaArr = Maska.GetMaska();

            // вычисляем координаты центра маски 
            var centrMaska = new
            {
                i = (maskaArr.GetLength(0) - 1) / 2,
                j = (maskaArr.GetLength(1) - 1) / 2

            };

            // создание двумерного массива состоящего из MyPixel размером с размер маски, для озеркаливания и последующей работы с ним
            var newPixels = new MyPixel[maskaArr.GetLength(0), maskaArr.GetLength(1)];

            // Создание Массива выходного 
            var outPixel = new MyPixel[Pixels.GetLength(0), Pixels.GetLength(1)];

            for (int i = 0; i < Pixels.GetLength(0); i++)
            {
                for (int j = 0; j < Pixels.GetLength(1); j++)
                {
                    var kletka = new Koordinata(i, j);
                    var start = new Koordinata { i = i - centrMaska.i, j = j - centrMaska.j };
                    var end = new Koordinata { i = i + centrMaska.i, j = j + centrMaska.j };

                    // если матрица вмещается в изо
                    /* if ((start.i >=0 && start.j>=0)&&(end.i<=Pixels.GetLength(0)-1 && end.j <= Pixels.GetLength(1)-1)) 
                     {
                         outPixel[i,j] =  LinalFiltration.Filtr(Pixels, maskaArr, start, end);

                     }*/
                    if (start.IsNorm() && end.IsNorm(Pixels.GetLength(0), Pixels.GetLength(1)))
                    {
                        outPixel[i, j] = MedianaFiltration.MedianaFiltr(Pixels, maskaArr, start, end);

                    }
                    else
                    {
                        var newMask = LinalFiltration.Otzerkal(Pixels, maskaArr.GetLength(0), maskaArr.GetLength(1), kletka);
                        outPixel[i, j] = MedianaFiltration.MedianaFiltr(newMask);
                    }
                    // если центр матрицы на границах или она не вмещается в изо





                }
            }

            var outbytes = MyPixel.PixelsToByte(outPixel);


            using var img_ret = ImageBytes.ImageBytesToBitmap(w, h, img, outbytes);


            /*for(int i = 0; i< Pixels.GetLength(0); i++)
            {
                for(int j = 0; j < Pixels.GetLength(1); j++)
                {
                    Console.WriteLine($"{Pixels[i, j].r} {Pixels[i, j].r} {Pixels[i, j].r}");
                }
            }*/
            SaveImg(img_ret);
        }

        public void KriteriyGavrilova()
        {
            using var img = new Bitmap(pathImg1);
            var w = img.Width;
            var h = img.Height;

            // получаем байты
            var input_bytes = ImageBytes.GetImageBytes(w, h, img);
            var output = new byte[input_bytes.Length];
            var srednee = Binariz.GetAVG(input_bytes);

            Task[] tasks = new Task[3];
            int start = 0;
            int razmernost = input_bytes.Length / 3;
            for(int i = 0; i < 3; i++)
            {
                int startcopy = start;
                

                tasks[i] =  Task.Run(() => Binariz.KritGavrilova(input_bytes, output, startcopy, startcopy+razmernost, srednee));

                start += razmernost;
                
            }


            Task.WaitAll(tasks);

            using var img_ret = ImageBytes.ImageBytesToBitmap(w, h, img, output);

            SaveImg(img_ret);



        }

        public void ChastotFiltrByte()
        {
            using var img = new Bitmap(pathImg1);
            var w = img.Width;
            var h = img.Height;



            Complex[,] complexImage = new Complex[h, w];
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    complexImage[y, x] = new Complex(img.GetPixel(x, y).R, 0); // Только действительная часть
                }
            }

            Complex[,] fourierImage = Chastot.FourierTransform(complexImage);

            // Визуализация Фурье-образа
            Bitmap magnitudeImage = Chastot.VisualizeFourier(fourierImage);

            SaveImg(magnitudeImage);
        }

        public void ChastotFilt()
        {

        }

        private  void SaveImg(Bitmap img)
        {
            Console.WriteLine("Введите название изображения для сохранения");
            string pathsave = Console.ReadLine();
            Console.Clear();
            img.Save($"..\\..\\..\\{pathsave}.jpg");

        }

        
    }
}
