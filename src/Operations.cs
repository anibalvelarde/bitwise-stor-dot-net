using System;
using System.Collections.Generic;
using System.Linq;

namespace BitwiseStorN
{
    public class Operations : IOperations
    {
        int IOperations.Pack(string binaryDigitString)
        {
            if (String.IsNullOrEmpty(binaryDigitString)) return 0;
            return Convert.ToInt32(binaryDigitString, 2);
        }

        string IOperations.Unpack(int packedBits)
        {
            if (packedBits < 0) throw new ArgumentOutOfRangeException(nameof(packedBits));
            if (packedBits == 0) return "0000000000000000000000000000000";
            return Convert.ToString(packedBits, 2);
        }

        int IOperations.PackArrayOf<T>(T bits) {
            if (bits is null) throw new ArgumentNullException(nameof(bits));
            
            return bits switch
            {
                bool[] arrayOfBooleans => this.PackArrayOfBooleans(arrayOfBooleans),
                int[] arrayOfBits => this.PackArrayOfBits(arrayOfBits),
                _ => throw new NotSupportedException($"Unsupported type of [{typeof(T)}]")
            };
        }
        T IOperations.UnpackArrayOf<T>(int packedBits)
        {
            var @switch = new Dictionary<Type, Func<int, object>>() {
                { typeof(bool[]), this.UnpackArrayOfBooleans},
                { typeof(int[]), this.UnpackArrayOfBits}
            };

            if (!@switch.ContainsKey(typeof(T))) throw new TypeLoadException($"Unsupported type [{typeof(T)}].");

            object val = @switch[typeof(T)](packedBits);
            return (T) Convert.ChangeType(val, typeof(T));
        }

        private int PackArrayOfBooleans(bool[] bits)
        {
           var booleanArray = bits ?? throw new ArgumentNullException(nameof(bits));
           var bds = booleanArray.Aggregate(
               seed: "",
               func: (current, next) => current + (next ? "1" : "0")
           );
           return ((IOperations)this).Pack(bds);
        }

        private bool[] UnpackArrayOfBooleans(int packedBits)
        {
            return ((IOperations)this)
                .Unpack(packedBits)
                .ToCharArray()
                .Select(item => (item == '1') ? true : false)
                .ToArray();
        }

        private int PackArrayOfBits(int[] bits)
        {
           var intArray = bits ?? throw new ArgumentNullException(nameof(bits));
           var bds = intArray.Aggregate(
               seed: "",
               func: (current, next) => {
                   if (next > 1 || next < 0) throw new ArgumentOutOfRangeException($"[{nameof(bits)}]: Only '0' or '1' is allowed.");

                   return current + (next == 1 ? "1" : "0");
               }
           );
           return ((IOperations)this).Pack(bds);
        }

        private int[] UnpackArrayOfBits(int packedBits)
        {
            return ((IOperations)this)
                .Unpack(packedBits)
                .ToCharArray()
                .Select(item => (item == '1') ? 1 : 0)
                .ToArray();
        }
    }
}
