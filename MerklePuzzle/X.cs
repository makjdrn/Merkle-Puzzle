using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerklePuzzle
{
    class X
    {
        List<List<UInt64>> AllPuzzles = new List<List<UInt64>>();


        public List<List<UInt64>> GeneratePuzzles(UInt64 Pattern)
        {
            List<List<UInt64>> CAllPuzzles = new List<List<UInt64>>();
            List<UInt64> IDs = new List<UInt64>();
            List<UInt64> Keys = new List<UInt64>();

            Random r = new Random();

            for (int i = 0; i < Program.PuzzleNr; i++)
            {
                UInt64 Key1 = MyRandom.NextMyInt(r);
                UInt64 ID, Key;
                ID = MyRandom.NextMyInt(r) + (UInt64)i;
                Key = MyRandom.NextMyInt(r) + (UInt64)i;

                AllPuzzles.Add(new List<UInt64>() { Pattern, ID, Key });

                UInt64 CPattern = Encryption.Encrypt(Pattern, Key1);
                UInt64 C_ID = Encryption.Encrypt(ID, Key1);
                UInt64 C_Key = Encryption.Encrypt(Key, Key1);
                CAllPuzzles.Add(new List<UInt64>() { CPattern, C_ID, C_Key });
            }

            return CAllPuzzles;
        }

        public UInt64 Decrypt(UInt64 Ciphertext, UInt64 ID)
        {
            UInt64 Key = AllPuzzles.Find(puzzle => puzzle[1] == ID)[2];
            return Encryption.Decrypt(Ciphertext, Key);
        }
    }
}
