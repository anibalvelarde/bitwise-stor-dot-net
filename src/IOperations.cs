using System;

namespace BitwiseStorN 
{
    public interface IOperations
    {
        int PackArrayOf<T>(T bits);
        T UnpackArrayOf<T>(int packedBits);
        int Pack(string binaryDigitString);
        string Unpack(int packedBits);
    }
}