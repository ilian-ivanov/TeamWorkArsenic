using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Tests
{
    [TestClass]
    public class ExplosionGeneratorTests
    {
        private string[,] battleField;

        [TestInitialize]
        public void TestInitialize()
        {
            this.battleField = new string[7, 7]
            {
                {"-","-","-","-","-","-","-"},
                {"-","1","-","1","-","-","-"},
                {"-","-","-","-","4","-","-"},
                {"1","-","-","-","-","3","-"},
                {"-","-","5","-","-","-","-"},
                {"-","-","-","-","-","2","-"},
                {"-","-","-","-","-","-","-"},
            };
        }

        [TestMethod]
        public void TestDetonate_WithTinyMine()
        {
            ExplosionGenerator explosionGenerator = new ExplosionGenerator(1, 1, this.battleField);
            explosionGenerator.Detonate(MineType.TinyMine);

            string[,] expectedBattleField = new string[7, 7]
            {
                {"X","-","X","-","-","-","-"},
                {"-","X","-","1","-","-","-"},
                {"X","-","X","-","4","-","-"},
                {"1","-","-","-","-","3","-"},
                {"-","-","5","-","-","-","-"},
                {"-","-","-","-","-","2","-"},
                {"-","-","-","-","-","-","-"},
            };

            AssertBattleFields(expectedBattleField, battleField);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDetonate_WithInvalidTinyMine()
        {
            ExplosionGenerator explosionGenerator = new ExplosionGenerator(0, 1, this.battleField);
            explosionGenerator.Detonate(MineType.TinyMine);
        }

        [TestMethod]
        public void TestDetonate_WithSmallMine()
        {
            ExplosionGenerator explosionGenerator = new ExplosionGenerator(5, 5, this.battleField);
            explosionGenerator.Detonate(MineType.SmallMine);

            string[,] expectedBattleField = new string[7, 7]
            {
                {"-","-","-","-","-","-","-"},
                {"-","1","-","1","-","-","-"},
                {"-","-","-","-","4","-","-"},
                {"1","-","-","-","-","3","-"},
                {"-","-","5","-","X","X","X"},
                {"-","-","-","-","X","X","X"},
                {"-","-","-","-","X","X","X"},
            };

            AssertBattleFields(expectedBattleField, battleField);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDetonate_WithInvalidSmallMine()
        {
            ExplosionGenerator explosionGenerator = new ExplosionGenerator(1, 1, this.battleField);
            explosionGenerator.Detonate(MineType.SmallMine);
        }

        [TestMethod]
        public void TestDetonate_WithMediumMine()
        {
            ExplosionGenerator explosionGenerator = new ExplosionGenerator(3, 5, this.battleField);
            explosionGenerator.Detonate(MineType.MediumMine);

            string[,] expectedBattleField = new string[7, 7]
            {
                {"-","-","-","-","-","-","-"},
                {"-","1","-","1","-","X","-"},
                {"-","-","-","-","X","X","X"},
                {"1","-","-","X","X","X","X"},
                {"-","-","5","-","X","X","X"},
                {"-","-","-","-","-","X","-"},
                {"-","-","-","-","-","-","-"},
            };

            AssertBattleFields(expectedBattleField, battleField);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDetonate_WithInvalidMediumMine()
        {
            ExplosionGenerator explosionGenerator = new ExplosionGenerator(5, 0, this.battleField);
            explosionGenerator.Detonate(MineType.MediumMine);
        }

        [TestMethod]
        public void TestDetonate_WithHugeMine()
        {
            ExplosionGenerator explosionGenerator = new ExplosionGenerator(4, 2, this.battleField);
            explosionGenerator.Detonate(MineType.HugeMine);

            string[,] expectedBattleField = new string[7, 7]
            {
                {"-","-","-","-","-","-","-"},
                {"-","1","-","1","-","-","-"},
                {"X","X","X","X","X","-","-"},
                {"X","X","X","X","X","3","-"},
                {"X","X","X","X","X","-","-"},
                {"X","X","X","X","X","2","-"},
                {"X","X","X","X","X","-","-"},
            };

            AssertBattleFields(expectedBattleField, battleField);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDetonate_WithInvalidHugeMine()
        {
            ExplosionGenerator explosionGenerator = new ExplosionGenerator(4, 1, this.battleField);
            explosionGenerator.Detonate(MineType.HugeMine);
        }

        private void AssertBattleFields(string[,] expected, string[,] actual)
        {
            Assert.AreEqual(expected.GetLength(0), actual.GetLength(0));
            Assert.AreEqual(expected.GetLength(1), actual.GetLength(1));

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }
    }
}