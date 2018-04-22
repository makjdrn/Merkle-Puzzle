using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerklePuzzle
{
    class Y
    {
        UInt64 Key;
        public UInt64 ID;

        public void GetTheKey(List<List<UInt64>> AllPuzzles, UInt64 Pattern)
        {
            Random r = new Random();
            int nr = r.Next(AllPuzzles.Count);
            for (UInt64 i = 0; i <= Program.lenght; i++)
            {
                if (Encryption.Decrypt(AllPuzzles[nr][0], i) == Pattern)
                {
                    ID = Encryption.Decrypt(AllPuzzles[nr][1], i);
                    Key = Encryption.Decrypt(AllPuzzles[nr][2], i);
                    break;
                }

            }
        }

        public UInt64 Encrypt(UInt64 Message)
        {
            return Encryption.Encrypt(Message, Key);
        }
    }
}
