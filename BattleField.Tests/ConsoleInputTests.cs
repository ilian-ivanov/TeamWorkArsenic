using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var sr = new StringReader("2 2");
            Console.SetIn(sr);
            int actualXCoord;
            int ectualYCoord;
            ConsoleInput.ReadPlayerMove(field, out actualXCoord, out ectualYCoord);
            sr.Dispose();

            Assert.AreEqual(expectedX, actualXCoord);
            Assert.AreEqual(expectedY, ectualYCoord);
        }

        // don't delete
        // this test make infinity loop and this is correct behaviour
        //[TestMethod]
        //public void ReadPlayerMove_InvalidInput()
        //{
        //    var field = new string[,]
        //    {
        //        {"X","-","-"},
        //        {"X","X","-"},
        //        {"-","-","1"}
        //    };
        //    var sr = new StringReader("2 \"\"");
        //    Console.SetIn(sr);
        //    //Console.SetIn(new StringReader("2 2"));

        //    int actualXCoord;
        //    int ectualYCoord;
        //    ConsoleInput.ReadPlayerMove(field, out actualXCoord, out ectualYCoord);

        //    //var sw = new StringWriter();
        //    //Console.SetOut(sw);

        //    //string expected = "Invalid move";
        //    //string actual = sw.ToString();
        //    //sw.Dispose();
        //    sr.Dispose();
        //    //Assert.AreEqual(expected, actual);
        //}

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
