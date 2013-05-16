using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Tests
{
    [TestClass]
    public class ExplosionGeneratorTests
    {
        [TestMethod]
        public void TestDetonate_WithTinyMine()
        {
            string[,] battleField = new string[5, 5]
            {
                {"-","-","-","-","-"},
                {"-","1","-","1","-"},
                {"-","-","-","-","-"},
                {"1","-","1","-","-"},
                {"-","-","-","-","-"},
            };

            string[,] expectedBattleField = new string[5, 5]
            {
                {"X","-","X","-","-"},
                {"-","X","-","1","-"},
                {"X","-","X","-","-"},
                {"1","-","1","-","-"},
                {"-","-","-","-","-"},
            };

            Assert.AreEqual(battleField, expectedBattleField);
        }
    }
}
