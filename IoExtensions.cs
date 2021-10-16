using System.Collections;
using System.IO;

namespace BitwiseOperations
{
    public static class IoExtensions
    {
        public static BitArray ReadArray(this StreamReader reader)
        {
            var n = int.Parse(reader.ReadLine() ?? string.Empty);
            var arr = new bool[n];
            
            var s = reader.ReadLine() ?? string.Empty;
            for (var i = 0; i < n; ++i)
                arr[i] = s[i] - '0' != 0;

            var bit = new BitArray(arr);
            return bit;
        }
        
        public static void WriteArray(this StreamWriter writer, BitArray arr, string msg)
        {
            foreach (var item in arr)
                writer.Write((item.Equals(true) ? 1 : 0) + " ");
            writer.Write(msg);
            writer.WriteLine();
        }

        public static void WriteOperation(this StreamWriter writer, 
            BitArray b1, BitArray b2, BitArray res, 
            string msg)
        {
            writer.WriteArray(b1, "= B1");
            writer.WriteArray(b2, "= B2");
            writer.WriteArray(res, msg);
            writer.WriteLine();
        }
    }
}