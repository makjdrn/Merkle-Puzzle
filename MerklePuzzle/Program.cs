using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MerklePuzzle
{
    class Program
    {
        public static int bits = 16;
        public static UInt64 lenght = (UInt64)Math.Pow(2, bits);
        public static int PuzzleNr = (int)Math.Pow(2, 24);
        static void Main(string[] args)
        {
            X X = new X();
            Y Y = new Y();
            Random r = new Random();
            UInt64 Pattern = MyRandom.NextMyInt(r);

            Stopwatch stopwatch = Stopwatch.StartNew();
            List<List<UInt64>> AllPuzzles = X.GeneratePuzzles(Pattern);
            stopwatch.Stop();
            Console.WriteLine("Generating puzzles in ms: " + stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatch1 = Stopwatch.StartNew();
            Y.GetTheKey(AllPuzzles, Pattern);
            stopwatch1.Stop();
            Console.WriteLine("Geting key in ms: " + stopwatch1.ElapsedMilliseconds);

            UInt64 Message = 2222212322 % lenght;
            UInt64 Ciphertext;
            UInt64 ID;
            Console.WriteLine("Y wants to send the message: " + Message);

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            Ciphertext = Y.Encrypt(Message);
            Console.WriteLine("He sends ciphertext: " + Ciphertext);
            ID = Y.ID;
            Console.WriteLine("X understood: " + X.Decrypt(Ciphertext, ID));
            stopwatch2.Stop();
            Console.WriteLine("En- and Decryption in ms: " + stopwatch2.ElapsedMilliseconds);

            Console.ReadKey();

        }
    }
}
