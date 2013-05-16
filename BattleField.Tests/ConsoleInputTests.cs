using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleField;

namespace BattleField.Tests
{
    [TestClass]
    public class ConsoleInputTests
    {
        [TestMethod]
        public void TakeSizeOfBattleFiel_IsEndOfGameFalse()
        {
            ConsoleInput target = new ConsoleInput();
            PrivateObject obj = new PrivateObject(target);
            string[,] field = new string[,] 
            {
                {"X","-","-"},
                {"X","X","-"},
                {"-","-","1"}
            };
            var expected = obj.Invoke("IsEndOfGame", new object[] { field });
            var actual = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TakeSizeOfBattleFiel_IsEndOfGameTrue()
        {
            ConsoleInput target = new ConsoleInput();
            PrivateObject obj = new PrivateObject(target);
            string[,] field = new string[,] 
            {
                {"X","-","-"},
                {"X","X","-"},
                {"-","-","X"}
            };
            var expected = obj.Invoke("IsEndOfGame", new object[] { field });
            var actual = false;
            Assert.AreEqual(expected, actual);
        }

        public void TakeSizeOfBattleFiel_ValidTestWithTen()
        {
            //ConsoleInput target = new ConsoleInput();
            //PrivateObject obj = new PrivateObject(target);
            //var observed = obj.Invoke("PrivateMethod");
            //const int expected = 10;
            //Assert.AreEqual(expected, observed);
        }


    }
}
