using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public static class Renderer
    {
        public static void NapylniMasiva(int n, int rows, int cols, String[,] workField)
        {
            int count = 0;
            Random randomNumber = new Random();
            int randomPlaceI;
            int randomPlaceJ;
            int minPercent = Convert.ToInt32(0.15 * (n * n));
            int maxPercent = Convert.ToInt32(0.30 * (n * n));
            int countMines = randomNumber.Next(minPercent, maxPercent);

            while (count <= countMines)
            {
                randomPlaceI = randomNumber.Next(0, n);
                randomPlaceJ = randomNumber.Next(0, n);
                randomPlaceI += 2;
                randomPlaceJ = 2 * randomPlaceJ + 2;

                while (workField[randomPlaceI, randomPlaceJ] != " " && workField[randomPlaceI, randomPlaceJ] != "-")
                {
                    randomPlaceI = randomNumber.Next(0, n);
                    randomPlaceJ = randomNumber.Next(0, n);
                    randomPlaceI += 2;
                    randomPlaceJ = 2 * randomPlaceJ + 2;
                }

                String randomDigit = Convert.ToString(randomNumber.Next(1, 6));
                workField[randomPlaceI, randomPlaceJ] = randomDigit;
                workField[randomPlaceI, randomPlaceJ + 1] = " ";
                count++;
            }
        }

        public static void PrintArray(int rows, int cols, String[,] workField)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(workField[i, j]);
                    Console.WriteLine();
                }
            }
        }
    }
}
