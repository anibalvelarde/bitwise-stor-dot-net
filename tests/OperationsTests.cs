using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitwiseStor;
using System;

namespace BitwiseStor.Tests
{
    [TestClass]
    public class OperationsTests
    {
        [DataRow(null)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_When_ArrayIsNull_Boolean_Values(bool[] bits)
        {
            // arrange..
            var bitOps = new Operations();

            // act...
            var result = bitOps.PackArrayOfBool(bits);

            // assert - expects exception
        }

        [DataRow(null)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_When_ArrayIsNull_Bit_Values(int[] bits)
        {
            // arrange..
            var bitOps = new Operations();

            // act...
            var result = bitOps.PackArrayOfBits(bits);

            // assert - expects exception
        }

        [DataRow(new int[] {1, 0, 2, 1, 1})]
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_When_Array_Has_NonBit_Values(int[] bits)
        {
            // arrange..
            var bitOps = new Operations();

            // act...
            var result = bitOps.PackArrayOfBits(bits);

            // assert - expects exception
        }

        [TestMethod]
        [DataRow(new bool[] {}, 0)]
        [DataRow(new bool[] {true, false, true}, 5)]
        [DataRow(new bool[] {true, false, false, false, true}, 17)]
        public void Should_pack_correct_value_from_array_of_boolean_values(bool[] bits, int expectedValue) 
        {
            // arrange...
            var bitOps = new Operations();

            // act...
            var result = bitOps.PackArrayOfBool(bits);

            // assert...
            Assert.AreEqual(expectedValue, result);
            Assert.IsInstanceOfType(result, typeof(int));
        }

        [TestMethod]
        [DataRow(new int[] {}, 0)]
        [DataRow(new int[] {1, 0, 1}, 5)]
        [DataRow(new int[] {1, 0, 0, 0, 1}, 17)]
        public void Should_pack_correct_value_from_array_of_integer_values(int[] bits, int expectedValue) 
        {
            // arrange...
            var bitOps = new Operations();

            // act...
            var result = bitOps.PackArrayOfBits(bits);

            // assert...
            Assert.AreEqual(expectedValue, result);
            Assert.IsInstanceOfType(result, typeof(int));
        }

        [TestMethod]
        [DataRow("0")]
        [DataRow("0000")]
        [DataRow("0000000")]
        [DataRow("0000000000000")]
        public void Should_pack_correct_value_when_all_bits_are_off(string stringOfBits)
        {
            // arrange...
            var bitOps = new Operations();

            // act...
            var result = bitOps.Pack(stringOfBits);

            // assert...
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow("1", 1)]
        [DataRow("11", 3)]
        [DataRow("11111", 31)]
        [DataRow("1111111111", 1023)]
        [DataRow("111111111111111111111111", 16777215)]
        public void Should_pack_correct_value_when_all_bits_are_on(string stringOfBits, int expectedResult)
        {
            // arrange...
            var bitOps = new Operations();

            // act...
            var result = bitOps.Pack(stringOfBits);
            
            // assert...
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("101010101010101010101011", 11184811)]
        public void Should_pack_correct_value_when_some_bits_are_on(string stringOfBits, int expectedResult)
        {
            // arrange...
            var bitOps = new Operations();

            // act...
            var result = bitOps.Pack(stringOfBits);
            
            // assert...
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("101010101010101010101011", 11184811)]
        [DataRow("101110101110100110101000",  12249512)]
        [DataRow("101",5)]
        [DataRow("10000000", 128)]
        [DataRow("10000001", 129)]
        [DataRow("101010101010101011", 174763)]
        public void Should_unpack_correct_value_when_some_bits_are_on(string expectedResult, int packedBits)
        {
            // arrange...
            var bitOps = new Operations();

            // act...
            var result = bitOps.Unpack(packedBits);
            
            // assert...
            Assert.AreEqual(expectedResult, result);
        }

    }
}
