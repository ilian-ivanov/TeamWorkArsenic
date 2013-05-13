using System;
using System.Linq;

namespace BattleField
{
    public static class Renderer
    {
        public static int TakeDataForGame()
        {
            Console.Write("Welcome to \"Battle Field game.\" Enter battle field size: n = ");
            int n = int.Parse(Console.ReadLine());
            while (n < 1 || n > 10)
            {
                Console.WriteLine("Enter a number between 1 and 10!");
                n = int.Parse(Console.ReadLine());
            }
            return n;
        }

        public static void PrepareBattleField(int n, int rows, int cols, string[,] field)
        {
            field[0, 0] = " ";
            field[0, 1] = " ";
            field[1, 0] = " ";
            field[1, 1] = " ";

            for (int row = 2; row < rows; row++)
            {
                for (int col = 2; col < cols; col++)
                {
                    if (col % 2 == 0)
                    {
                        if (col == 2)
                        {
                            field[0, col] = "0";
                        }
                        else
                        {
                            field[0, col] = ((col - 2) / 2).ToString();
                        }
                    }
                    else
                    {
                        field[0, col] = " ";
                    }

                    if (col < cols - 1)
                    {
                        field[1, col] = "-";
                    }

                    field[row, 0] = (row - 2).ToString();
                    field[row, 1] = "|";
                    if (col % 2 == 0)
                    {
                        field[row, col] = "-";
                    }
                    else
                    {
                        field[row, col] = " ";
                    }
                }
            }
        }

        public static void FillBattleField(int n, int rows, int cols, String[,] workField)
        {
            Random randomNumber = new Random();
            int minPercent = (int)(0.15 * (n * n));
            int maxPercent = (int)(0.30 * (n * n));
            int countMines = randomNumber.Next(minPercent, maxPercent);
            int count = 0;

            while (count <= countMines)
            {
                int randomPlaceRow = randomNumber.Next(0, n) + 2;
                int randomPlaceCol = randomNumber.Next(0, n) * 2 + 2;

                do
                {
                    randomPlaceRow = randomNumber.Next(0, n) + 2;
                    randomPlaceCol = randomNumber.Next(0, n) * 2 + 2;
                } while (workField[randomPlaceRow, randomPlaceCol] != " " &&
                    workField[randomPlaceRow, randomPlaceCol] != "-");

                string randomValueOfCell = randomNumber.Next(1, 6).ToString();
                workField[randomPlaceRow, randomPlaceCol] = randomValueOfCell;
                workField[randomPlaceRow, randomPlaceCol + 1] = " ";
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
