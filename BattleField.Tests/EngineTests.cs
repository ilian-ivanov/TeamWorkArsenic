using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Tests
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void IsEndOfGame_False()
        {
            var field = new string[,]
            { 
                {"X","-","-"},
                {"X","X","-"},
                {"-","-","1"}
            };

            var expected = false;
            var actual = Engine.IsEndOfGame(field);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsEndOfGame_True()
        {
            var field = new string[,]
            { 
                {"X","-","-"},
                {"X","X","-"},
                {"-","-","X"}
            };

            var expected = true;
            var actual = Engine.IsEndOfGame(field);
            Assert.AreEqual(expected, actual);
        }
    }
}
