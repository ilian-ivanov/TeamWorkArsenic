using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;
using System.IO;

namespace BattleField.Tests
{
    [TestClass]
    public class ConsoleInputTests
    {
        [TestMethod]
        public void ReadPlayerMove_ValidInput()
        {
            var field = new string[,]
            {
                {"X","-","-"},
                {"X","X","-"},
                {"-","-","1"}
            };
            var expectedX = 2;
            var expectedY = 2;
            Console.SetIn(new StringReader("2 2"));

            int actualXCoord;
            int ectualYCoord;
            ConsoleInput.ReadPlayerMove(field, out actualXCoord, out ectualYCoord);

            Assert.AreEqual(expectedX, actualXCoord);
            Assert.AreEqual(expectedY, ectualYCoord);
        }

        [TestMethod]
        public void TakeSizeOfBattleField_InvalidInputZero()
        {
            Console.SetIn(new StringReader("0")); //wrong input
            Console.SetIn(new StringReader("1")); //correct input
            var expected = 1;

            int actual = ConsoleInput.TakeSizeOfBattleField();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TakeSizeOfBattleField_InvalidInputEleven()
        {
            Console.SetIn(new StringReader("11")); //wrong input
            Console.SetIn(new StringReader("10")); //correct input
            var expected = 10;

            int actual = ConsoleInput.TakeSizeOfBattleField();

            Assert.AreEqual(expected, actual);
        }
    }
}
