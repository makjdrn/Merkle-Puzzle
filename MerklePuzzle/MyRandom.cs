using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerklePuzzle
{
    static class MyRandom
    {
        public static UInt64 NextMyInt(this Random rnd)
        {
            var buffer = new byte[sizeof(Int64)];
            rnd.NextBytes(buffer);
            return BitConverter.ToUInt64(buffer, 0) % Program.lenght;
        }
    }
}
