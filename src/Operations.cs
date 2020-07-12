using System;
using System.Collections.Generic;
using System.Linq;

namespace BitwiseStor
{
    public class Operations : IOperations
    {
        public int PackArrayOfBool(bool[] bits)
        {
           var booleanArray = bits ?? throw new ArgumentNullException(nameof(bits));
           var bds = booleanArray.Aggregate(
               seed: "",
               func: (current, next) => current + (next ? "1" : "0")
           );
           return this.Pack(bds);
        }

        public bool[] UnpackArrayOfBool(int packedBits)
        {
            return this
                .Unpack(packedBits)
                .ToCharArray()
                .Select(item => (item == '1') ? true : false)
                .ToArray();
        }

        public int PackArrayOfBits(int[] bits)
        {
           var intArray = bits ?? throw new ArgumentNullException(nameof(bits));
           var bds = intArray.Aggregate(
               seed: "",
               func: (current, next) => {
                   if (next > 1 || next < 0) throw new ArgumentOutOfRangeException($"[{nameof(bits)}]: Only '0' or '1' is allowed.");

                   return current + (next == 1 ? "1" : "0");
               }
           );
           return this.Pack(bds);
        }

        public int Pack(string binaryDigitString)
        {
            if (String.IsNullOrEmpty(binaryDigitString)) return 0;
            return Convert.ToInt32(binaryDigitString, 2);
        }

        public string Unpack(int packedBits)
        {
            if (packedBits < 0) throw new ArgumentOutOfRangeException(nameof(packedBits));
            if (packedBits == 0) return "0000000000000000000000000000000";
            return Convert.ToString(packedBits, 2);
        }

        public int[] UnpackArrayOfBinaryDigits(int packedBits)
        {
            return this
                .Unpack(packedBits)
                .ToCharArray()
                .Select(item => (item == '1') ? 1 : 0)
                .ToArray();
        }
    }
}
