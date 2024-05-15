using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace _1laba.Helper
{
    internal static class Gistogramma
    {
       // private static int[] N { get; set; }
        public static void GetGistogramm(byte[] arr, string str)
        {
            var N = new int[256];
           
            for(int i = 0; i< arr.Length - 3; i += 3)
            {
                int c = ((Convert.ToInt32(arr[i]) + Convert.ToInt32(arr[i + 1]) + Convert.ToInt32(arr[i + 2])))/3;

                N[c]++;
            }

            int maxValue = N.Max();


            double scale = 100.0 / maxValue;
            int[] normalizedCounts = N.Select(c => (int)(c * scale)).ToArray();

          using  Bitmap histogram = new Bitmap(256, 100);
            using (Graphics g = Graphics.FromImage(histogram))
            {
                g.Clear(Color.White);
                Pen pen = new Pen(Color.Black);
                for (int i = 0; i < 256; i++)
                {
                    int height = normalizedCounts[i];
                    g.DrawLine(pen, i, 100, i, 100 - height);
                }
            }

            histogram.Save($"..\\..\\..\\{str}gistogramm.jpg");










        }

       

        
    }
}
