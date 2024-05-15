using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1laba.Binarization
{
    internal static class Binariz
    {

        public static void KritGavrilova(byte[] bytes, byte[] output, int start, int end, int sred)
        {

            for(int i = start; i < end; i++)
            {
                output[i] = bytes[i] <= sred ? (byte)0 : (byte)255;
            }

        }

        public static int GetAVG(byte[] bytes)
        {
            int res = 0;

            res = (int)bytes.Sum(x => x);
            //int ress = bytes.Select(x => (int)x).Sum();
            return res / bytes.Length/3;
        }


    }
}
