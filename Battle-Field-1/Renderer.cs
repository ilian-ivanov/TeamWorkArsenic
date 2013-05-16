using System;
using System.Linq;

namespace BattleField
{
    public static class Renderer
    {
        public static void PrepareBattleField(int rows, int cols, string[,] battleField)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    battleField[row, col] = "-";
                }
            }
        }

        public static void FillBattleField(int battleFieldSize, string[,] battleField)
        {
            Random randomGenerator = new Random();
            int minPercent = (int)(0.15 * (battleFieldSize * battleFieldSize));
            int maxPercent = (int)(0.30 * (battleFieldSize * battleFieldSize));
            int countMines = randomGenerator.Next(minPercent, maxPercent);
            int count = 0;

            while (count <= countMines)
            {
                int randomPlaceRow;
                int randomPlaceCol;

                do
                {
                    randomPlaceRow = randomGenerator.Next(0, battleFieldSize);
                    randomPlaceCol = randomGenerator.Next(0, battleFieldSize);
                } while (battleField[randomPlaceRow, randomPlaceCol] != " " &&
                    battleField[randomPlaceRow, randomPlaceCol] != "-");

                string randomValueOfCell = randomGenerator.Next(1, 6).ToString();
                battleField[randomPlaceRow, randomPlaceCol] = randomValueOfCell;
                count++;
            }
        }

        public static void RenderBattleField(int rows, int cols, string[,] battleField)
        {
            Console.Write(" ");
            for (int i = 0; i < cols; i++)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();

            Console.Write("  ");
            for (int i = 0; i < cols * 2 - 1; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            for (int row = 0; row < rows; row++)
            {
                Console.Write(row + "|");
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(battleField[row, col]);
                    if (col < cols)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}