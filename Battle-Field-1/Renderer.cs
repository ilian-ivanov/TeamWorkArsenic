using System;
using System.Linq;

namespace BattleField
{
    public static class Renderer
    {
        public static void PrepareBattleField(int rows, int cols, string[,] battleField)
        {
            battleField[0, 0] = " ";
            battleField[0, 1] = " ";
            battleField[1, 0] = " ";
            battleField[1, 1] = " ";

            for (int row = 2; row < rows; row++)
            {
                for (int col = 2; col < cols; col++)
                {
                    if (col % 2 == 0)
                    {
                        if (col == 2)
                        {
                            battleField[0, col] = "0";
                        }
                        else
                        {
                            battleField[0, col] = ((col - 2) / 2).ToString();
                        }
                    }
                    else
                    {
                        battleField[0, col] = " ";
                    }

                    if (col < cols - 1)
                    {
                        battleField[1, col] = "-";
                    }

                    battleField[row, 0] = (row - 2).ToString();
                    battleField[row, 1] = "|";
                    if (col % 2 == 0)
                    {
                        battleField[row, col] = "-";
                    }
                    else
                    {
                        battleField[row, col] = " ";
                    }
                }
            }
        }

        public static void FillBattleField(int battleFieldSize, string[,] battleField)
        {
            Random randomNumber = new Random();
            int minPercent = (int)(0.15 * (battleFieldSize * battleFieldSize));
            int maxPercent = (int)(0.30 * (battleFieldSize * battleFieldSize));
            int countMines = randomNumber.Next(minPercent, maxPercent);
            int count = 0;

            while (count <= countMines)
            {
                int randomPlaceRow = randomNumber.Next(0, battleFieldSize) + 2;
                int randomPlaceCol = randomNumber.Next(0, battleFieldSize) * 2 + 2;

                do
                {
                    randomPlaceRow = randomNumber.Next(0, battleFieldSize) + 2;
                    randomPlaceCol = randomNumber.Next(0, battleFieldSize) * 2 + 2;
                } while (battleField[randomPlaceRow, randomPlaceCol] != " " &&
                    battleField[randomPlaceRow, randomPlaceCol] != "-");

                string randomValueOfCell = randomNumber.Next(1, 6).ToString();
                battleField[randomPlaceRow, randomPlaceCol] = randomValueOfCell;
                battleField[randomPlaceRow, randomPlaceCol + 1] = " ";
                count++;
            }
        }

        public static void VisualizeBattleField(int rows, int cols, string[,] battleField)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(battleField[row, col]);                    
                }
                Console.WriteLine();
            }
        }
    }
}