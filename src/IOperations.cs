using System;

namespace BitwiseStorN 
{
    /// <summary>
    /// Interface for Bitwise Stor .NET operations
    /// </summary>
    public interface IOperations
    {
        /// <summary>
        /// Packs array of values (bool[] or int[]) into a signed integer
        /// </summary>
        /// <param name="bits">Binary digits represented in the array</param>
        /// <typeparam name="T">The supported types are T = bool[] or T = int[]</typeparam>
        /// <returns>Integer representing bits turned on/off (when T = bool[], it returns 5 when array of bool[] = {true, false, true})</returns>
        int PackArrayOf<T>(T bits);
        /// <summary>
        /// Unpacks an integer number into an array of values representing bits (binary digits)
        /// </summary>
        /// <param name="packedBits">An integer value that encodes a sequence of bits</param>
        /// <typeparam name="T">The supported types are T = bool[] or T = int[]</typeparam>
        /// <returns>An array of binary digits of type bool or int (when T = bool[], it returns bool[] = {true, false, true} when packedBits = 5</returns>
        T UnpackArrayOf<T>(int packedBits);
        /// <summary>
        /// Converts a string of zeroes and ones to an integer representation of the string of bits base 2
        /// </summary>
        /// <param name="binaryDigitString">A string of binary digits where each character in the string is either a zero ("0") or a one ("1")</param>
        /// <returns>Integer representation of the string of bits base 2</returns>
        int Pack(string binaryDigitString);
        /// <summary>
        /// Converts an integer into a string of zeroes or ones.
        /// </summary>
        /// <param name="packedBits">An integer whose binary representation forms the basis for the returned string of bits</param>
        /// <returns>A string of binary digits where each character in the string is either a zero ("0") or a one ("1")</returns>
        string Unpack(int packedBits);
    }
}