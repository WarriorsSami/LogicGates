using System.Collections;
using System.IO;

namespace BitwiseOperations
{
    internal static class Program
    {
        private const string FileIn = "C:\\Users\\barbu\\RiderProjects\\BitArraySln\\bit.in";
        private const string FileOut = "C:\\Users\\barbu\\RiderProjects\\BitArraySln\\bit.out";

        private static void Main(string[] args)
        {
            using var fin = new FileStream(FileIn, FileMode.Open, FileAccess.Read);
            using var fout = new FileStream(FileOut, FileMode.Truncate, FileAccess.Write);

            using var reader = new StreamReader(fin);
            using var writer = new StreamWriter(fout);
            
            var bit1 = reader.ReadArray();
            var bit2 = reader.ReadArray();
            var bit = new bool[bit1.Length];
            var aux = new bool[bit2.Length];

            // NOT B1
            writer.WriteArray(bit1, "= B1");
            bit1.CopyTo(bit, 0);
            writer.WriteArray(bit1.Not(), "= NOT B1");
            bit1 = new BitArray(bit);
            writer.WriteLine();

            // NOT B2
            writer.WriteArray(bit2, "= B2");
            bit2.CopyTo(bit, 0);
            writer.WriteArray(bit2.Not(), "= NOT B2");
            bit2 = new BitArray(bit);
            writer.WriteLine();
            
            // AND
            bit1.CopyTo(bit, 0);
            var bitAnd = bit1.And(bit2);
            bit1 = new BitArray(bit);
            writer.WriteOperation(bit1, bit2, bitAnd, "= B1 AND B2");

            // OR
            bit1.CopyTo(bit, 0);
            var bitOr = bit1.Or(bit2);
            bit1 = new BitArray(bit);
            writer.WriteOperation(bit1, bit2, bitOr, "= B1 OR B2");
            
            // XOR
            bit1.CopyTo(bit, 0);
            var bitXor = bit1.Xor(bit2);
            bit1 = new BitArray(bit);
            writer.WriteOperation(bit1, bit2, bitXor, "= B1 XOR B2");
            
            // NAND
            bit1.CopyTo(bit, 0);
            var bitNand = bit1.Nand(bit2); 
            bit1 = new BitArray(bit); 
            writer.WriteOperation(bit1, bit2, bitNand, "= B1 NAND B2");
            
            // NOR
            bit1.CopyTo(bit, 0); 
            var bitNor = bit1.Nor(bit2); 
            bit1 = new BitArray(bit); 
            writer.WriteOperation(bit1, bit2, bitNor, "= B1 NOR B2");
            
            // P -> Q (yield) (not P or Q)
            bit1.CopyTo(bit, 0);
            var bitYield = bit1.Yield(bit2); 
            bit1 = new BitArray(bit); 
            writer.WriteOperation(bit1, bit2, bitYield, "= B1 -> B2");

            // Q -> P (mutual)
            bit1.CopyTo(bit, 0);
            bit2.CopyTo(aux, 0);
            var bitMutual = bit1.Mutual(bit2); 
            bit1 = new BitArray(bit);
            bit2 = new BitArray(aux);
            writer.WriteOperation(bit1, bit2, bitMutual, "= B2 -> B1");
            
            // not Q -> not P (counter-positive)
            bit1.CopyTo(bit, 0); 
            bit2.CopyTo(aux, 0);
            var bitCp = bit1.CounterPositive(bit2); 
            bit1 = new BitArray(bit);
            bit2 = new BitArray(aux);
            writer.WriteOperation(bit1, bit2, bitCp, "= NOT B2 -> NOT B1");
            
            // not P -> not Q (inverse)
            bit1.CopyTo(bit, 0); 
            bit2.CopyTo(aux, 0);
            var bitInverse = bit1.Inverse(bit2); 
            bit1 = new BitArray(bit);
            bit2 = new BitArray(aux);
            writer.WriteOperation(bit1, bit2, bitInverse, "= NOT B1 -> NOT B2");
            
            // P <-> Q (iff)
            bit1.CopyTo(bit, 0); 
            var bitIff = bit1.Xnor(bit2); 
            bit1 = new BitArray(bit); 
            writer.WriteOperation(bit1, bit2, bitIff, "= B1 <-> B2");
        }
    }
}
