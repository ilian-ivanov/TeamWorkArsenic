using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Tests
{
    [TestClass]
    public class ConsoleInputTests
    {
        [TestMethod]
        //public void TakeSizeOfBattleFiel_ValidTest1()
        //{
        //    ConsoleInput target = new ConsoleInput();
        //    PrivateObject obj = new PrivateObject(target);
        //    var retVal = obj.Invoke("PrivateMethod");
        //    int size = 5;
        //    Assert.AreEqual(size, retVal);
        //}

        [TestMethod]
        public void TakeSizeOfBattleFiel_ValidTestWithOne()
        {
            ConsoleInput target = new ConsoleInput();
            PrivateObject obj = new PrivateObject(target);
            var observed = obj.Invoke("PrivateMethod");
            const int expected = 1;
            Assert.AreEqual(expected, observed);
        }

        public void TakeSizeOfBattleFiel_ValidTestWithTen()
        {
            ConsoleInput target = new ConsoleInput();
            PrivateObject obj = new PrivateObject(target);
            var observed = obj.Invoke("PrivateMethod");
            const int expected = 10;
            Assert.AreEqual(expected, observed);
        }


    }
}
