using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerklePuzzle
{
    static class Encryption
    {
        static public UInt64 Encrypt(UInt64 Plaintext, UInt64 Key)
        {
            return Plaintext ^ Key;
        }

        static public UInt64 Decrypt(UInt64 Ciphertext, UInt64 Key)
        {
            return Ciphertext ^ Key;
        }
    }
}
