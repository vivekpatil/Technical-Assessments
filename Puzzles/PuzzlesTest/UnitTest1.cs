using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzles;

namespace PuzzlesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Puzzle1_Pass()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int i = Puzzles_JohnHolland.fnReturnFifthElement(numbers);
            Assert.AreEqual(numbers[numbers.Length - 5], i);
        }

        [TestMethod]
        public void Puzzle1_Fail()
        {
            int[] numbers = new int[] { 1,2, 3, 4, 5 };
            int i = Puzzles_JohnHolland.fnReturnFifthElement(numbers);
            //Comparing with 4th element in array from tail
            Assert.AreNotEqual(numbers[numbers.Length - 4], i);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),"Array length was improper")]
        public void Puzzle1_Exception()
        {
            int[] numbers = new int[] {2, 3, 4, 5 };
            int i = Puzzles_JohnHolland.fnReturnFifthElement(numbers);
            
        }

        [TestMethod]
        public void Puzzle2_IsTriangle_Pass()
        {
            Double sideA = 10, sideB = 9, sideC = 10;
            bool isValid = Puzzles_JohnHolland.fnCheckIfTriangle(sideA, sideB, sideC);
            Assert.AreEqual(true, isValid);
        }

        [TestMethod]
        public void Puzzle2_IsTriangle_Fail()
        {
            Double sideA = 10, sideB = 9, sideC = 100;
            bool isValid = Puzzles_JohnHolland.fnCheckIfTriangle(sideA, sideB, sideC);
            Assert.AreEqual(false, isValid);
        }

        [TestMethod]
        public void Puzzle2_Equilateral_Pass()
        {
            Double sideA = 10, sideB = 10, sideC = 10;
            string strTriangleType = Puzzles_JohnHolland.fnReturnTriangleType(sideA, sideB, sideC);
            Assert.AreEqual("Equilateral", strTriangleType);
        }

        [TestMethod]
        public void Puzzle2_Isosceles_Pass()
        {
            Double sideA = 10, sideB = 10, sideC = 15;
            string strTriangleType = Puzzles_JohnHolland.fnReturnTriangleType(sideA, sideB, sideC);
            Assert.AreEqual("Isosceles", strTriangleType);
        }

        [TestMethod]
        public void Puzzle2_Scalene_Pass()
        {
            Double sideA = 10, sideB = 11, sideC = 12;
            string strTriangleType = Puzzles_JohnHolland.fnReturnTriangleType(sideA, sideB, sideC);
            Assert.AreEqual("Scalene", strTriangleType);
        }
    }
}
