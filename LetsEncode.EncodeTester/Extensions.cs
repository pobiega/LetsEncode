using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsEncode.EncodeTester
{
    public static class Extensions
    {
        public static byte NextByte(this Random random)
        {
            byte[] buffer = new byte[1];
            random.NextBytes(buffer);

            return buffer[0];
        }
    }
}
