using System.Collections;

namespace BitwiseOperations
{
    public static class BitArrayExtensions
    {
        public static BitArray Nand(this BitArray bit, BitArray other)
        {
            bit.And(other);
            return bit.Not();
        }

        public static BitArray Nor(this BitArray bit, BitArray other)
        {
            bit.Or(other);
            return bit.Not();
        }

        public static BitArray Yield(this BitArray bit, BitArray other)
        {
            bit.Not();
            return bit.Or(other);
        }

        public static BitArray Mutual(this BitArray bit, BitArray other)
        {
            return other.Yield(bit);
        }

        public static BitArray CounterPositive(this BitArray bit, BitArray other)
        {
            other.Not();
            return other.Yield(bit.Not());
        }

        public static BitArray Inverse(this BitArray bit, BitArray other)
        {
            bit.Not();
            return bit.Yield(other.Not());
        }

        public static BitArray Xnor(this BitArray bit, BitArray other)
        {
            bit.Xor(other);
            return bit.Not();
        }
    }
}