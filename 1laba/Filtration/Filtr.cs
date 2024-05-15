using _1laba.Helper.ClassHelper;
using _1laba.Pixel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1laba.Filtration
{
    internal abstract class Filtr
    {
        protected MyPixel[,] Pixels { get; set; }
        protected double[,] Maska { get; set; }

        public Filtr(MyPixel[,] Pixels, double[,] Maska)
        {
            this.Pixels = Pixels;
            this.Maska = Maska;
        }

        public static MyPixel[,] Otzerkal(MyPixel[,] Image, int K, int L, Koordinata kletka)
        {
            int N = Image.GetLength(0); int M = Image.GetLength(1);
            
            var MaskaCentr = new Koordinata
            {
                i = K / 2,
                j = L / 2

            };

            var start = new Koordinata(kletka.i, kletka.j);
            var end = new Koordinata(kletka.i, kletka.j, N, M);

            MyPixel[,] newMask = new MyPixel[K, L];

            List<Koordinata> mylist = new List<Koordinata>();

            for (int i = 0; i < K; i++)
            {
                for (int j = 0; j < L; j++)
                {
                    var koord = new Koordinata
                    {
                        i = i,
                        j = j
                    };

                    var provrasst = new Koordinata
                    {
                        i = Math.Abs(MaskaCentr.i - i),
                        j = Math.Abs(MaskaCentr.j - j)
                    };
                    var rast = new Koordinata
                    {
                        i = (MaskaCentr.i - i),
                        j = (MaskaCentr.j - j)
                    };

                    var otvet = kletka - rast;
                    var provotvet = kletka - provrasst;
                    /* if (provotvet.IsNorm() == true && provotvet.IsNorm(N, M) == true) // это вроде работает
                     {
                         newMask[i, j] = Image[provotvet.i, provotvet.j];
                     }*/

                    if (otvet.IsNorm() == true && otvet.IsNorm(N, M) == true) // это вроде работает
                    {
                        newMask[i, j] = Image[otvet.i, otvet.j];
                    }
                    else
                    {

                        //int newI = koord.i < MaskaCentr.i ? provrasst.i + kletka.i : provrasst.i - kletka.i;
                        //int newJ = koord.j < MaskaCentr.j ? provrasst.j + kletka.j : provrasst.j - kletka.j; // здесь какаято хрень

                        int newI = rast.i + kletka.i;
                        int newJ = rast.j + kletka.j;

                        if (newI < 0 || newJ < 0 || newI > N - 1 || newJ > M - 1)
                        {
                            mylist.Add(koord);
                           
                            continue;
                        }
                        newMask[i, j] = Image[newI, newJ];


                    }






                }
                var bebr = obnaruzhenie(mylist, K, L);
                MyPixel res = newMask[bebr.i, bebr.j];
                foreach (var item in mylist)
                {
                    newMask[item.i, item.j] = res;
                }
            }

            return newMask;

        }

        private static Koordinata obnaruzhenie(List<Koordinata> mylist, int K, int L)
        {
            var VL = new Koordinata(0, 0);
            var VP = new Koordinata(0, L - 1);
            var NL = new Koordinata(K - 1, 0);
            var NP = new Koordinata(K - 1, L - 1);


            var listkord = new List<Koordinata>() { VL, VP, NL, NP };


            foreach (var item1 in listkord)
            {
                int f = 0;
                foreach (var item2 in mylist)
                {
                    if ((item1.i == item2.i) && (item1.j == item2.j))
                    {
                        f = 1;
                    }

                }

                if (f == 0)
                {
                    return item1;
                }
            }

            return null;

        }
    }
}
