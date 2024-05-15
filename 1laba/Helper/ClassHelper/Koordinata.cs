using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1laba.Helper.ClassHelper
{
    internal class Koordinata
    {
        public int i { get; set; }
        public int j { get; set; }

        public Koordinata()
        {
            
        }

        public Koordinata(int i, int j)
        {
            this.i = i;
            this.j = j;

            if (i < 0)
                this.i = 0;
            if (j < 0)
                this.j = 0;

        }

        public Koordinata(int i, int j, int N, int M)
        {
            this.i = i;
            this.j = j;
            N = N - 1;
            M = M - 1;
            if (i > N)
                this.i = N;
            if (j > M)
                this.j = M;

        }

        public bool IsNorm()
        {
            if ((i < 0) || (j < 0))
                return false;
            return true;
        }

        public bool IsNorm(int N, int M)
        {
            if ((i > N - 1) || (j > N - 1))
                return false;
            return true;
        }

        public static Koordinata operator -(Koordinata one, Koordinata two)
        {
            var res = new Koordinata
            {
                i = one.i - two.i,
                j = one.j - two.j,
            };
            return res;
        }
    }
}
