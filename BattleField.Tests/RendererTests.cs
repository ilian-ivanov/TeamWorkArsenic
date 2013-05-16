using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using System.Text;

namespace BattleField.Tests
{
    [TestClass]
    public class RendererTests
    {
        [TestMethod]
        public void PrepareBattleField_Size1()
        {
            string[,] expectedBattleField = new string[1, 1]
            {
                {"-"}
            };
            string[,] actualBattleField = new string[1, 1];
            Renderer.PrepareBattleField(actualBattleField);

            CollectionAssert.AreEqual(expectedBattleField, actualBattleField);
        }

        [TestMethod]
        public void PrepareBattleField_Size5()
        {
            string[,] expectedBattleField = new string[5, 5]
            {
                {"-","-","-","-","-"},
                {"-","-","-","-","-"},
                {"-","-","-","-","-"},
                {"-","-","-","-","-"},
                {"-","-","-","-","-"},
            };
            string[,] actualBattleField = new string[5, 5];
            Renderer.PrepareBattleField(actualBattleField);

            CollectionAssert.AreEqual(expectedBattleField, actualBattleField);
        }

        [TestMethod]
        public void PrepareBattleField_Size10()
        {
            string[,] expectedBattleField = new string[10, 10]
            {
                {"-","-","-","-","-","-","-","-","-","-"},
                {"-","-","-","-","-","-","-","-","-","-"},
                {"-","-","-","-","-","-","-","-","-","-"},
                {"-","-","-","-","-","-","-","-","-","-"},
                {"-","-","-","-","-","-","-","-","-","-"},
                {"-","-","-","-","-","-","-","-","-","-"},
                {"-","-","-","-","-","-","-","-","-","-"},
                {"-","-","-","-","-","-","-","-","-","-"},
                {"-","-","-","-","-","-","-","-","-","-"},
                {"-","-","-","-","-","-","-","-","-","-"},
            };
            string[,] actualBattleField = new string[10, 10];
            Renderer.PrepareBattleField(actualBattleField);

            CollectionAssert.AreEqual(expectedBattleField, actualBattleField);
        }

        [TestMethod]
        public void FillBattleField()
        {


            string[,] expectedBattleField = new string[1, 1]
            {
                {"-"}
            };
            string[,] actualBattleField = new string[1, 1];
            Renderer.PrepareBattleField(actualBattleField);

            CollectionAssert.AreEqual(expectedBattleField, actualBattleField);
        }

        [TestMethod]
        public void VisualizeBattleField()
        {
            var field = new string[,]
            {
                {" "," ","0"," ","1"," ","2"},
                {" "," ","-","-","-","-","-"},
                {"0","|","-"," ","-"," ","-"},
                {"1","|","-"," ","-"," ","-"},
                {"2","|","-"," ","-"," ","-"},
            };
            StringBuilder expected = new StringBuilder();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    expected.Append(field[i, k]);
                }
                expected.AppendLine();
            }
            Renderer.VisualizeBattleField(field);

            var input = new StringReader(Console.ReadLine());
            Console.SetIn(input);

            string result = Console.SetIn(input);
            result += Console.SetIn(input);
            result += Console.SetIn(input);
            result += Console.SetIn(input);
            result += Console.SetIn(input);
            //var actual = new StringWriter(result);
            //Console.SetOut(actual);
            //actual.Dispose();
            Assert.AreEqual(expected.ToString(), result);
        }
    }
}
