using System;
using System.Linq;

namespace BattleField
{
    public static class Explosion
    {
        public static void HitOne(int x, int y, int rows, int cols, String[,] workField)
        {
            workField[x, y] = "X";
            if (x - 1 > 1 && y - 2 > 1)
            {
                workField[x - 1, y - 2] = "X";
            }
            if (x - 1 > 1 && y < cols - 2)
            {
                workField[x - 1, y + 2] = "X";
            }
            if (x < rows - 1 && y < cols - 2)
            {
                workField[x + 1, y + 2] = "X";
            }
            if (x < rows - 1 && y - 2 > 1)
            {
                workField[x + 1, y - 2] = "X";
            }
        }

        public static void PrasniDvama(int x, int y, int rows, int cols, String[,] workField)
        {
            workField[x, y] = "X";
            HitOne(x, y, rows, cols, workField);
            if (y - 2 > 1)
            {
                workField[x, y - 2] = "X";
            }
            if (y < cols - 2)
            {
                workField[x, y + 2] = "X";
            }
            if (x - 1 > 1)
            {
                workField[x - 1, y] = "X";
            }
            if (x < rows - 1)
            {
                workField[x + 1, y] = "X";
            }
        }

        public static void HitThree(int x, int y, int rows, int cols, String[,] workField)
        {
            PrasniDvama(x, y, rows, cols, workField);
            if (x - 2 > 1)
            {
                workField[x - 2, y] = "X";
            }
            if (x < rows - 2)
            {
                workField[x + 2, y] = "X";
            }
            if (y - 4 > 1)
            {
                workField[x, y - 4] = "X";
            }
            if (y == 18)
            {
                workField[x, y + 2] = "X";

            }
            else if (y == 20)
            {
                workField[x, y] = "X";
            }
            else
            {
                if (y < cols - 3)
                {
                    workField[x, y + 4] = "X";
                }
            }
        }

        public static void HitFour(int x, int y, int rows, int cols, String[,] workField)
        {
            HitThree(x, y, rows, cols, workField);
            if (x - 2 > 1 && y - 2 > 1)
            {
                workField[x - 2, y - 2] = "X";
            }
            if (x - 1 > 1 && y - 4 > 1)
            {
                workField[x - 1, y - 4] = "X";
            }
            if (x - 2 > 1 && y < cols - 2)
            {
                workField[x - 2, y + 2] = "X";
            }


            if (x < rows - 1 && y - 4 > 1)
            {
                workField[x + 1, y - 4] = "X";
            }
            if (x < rows - 2 && y - 2 > 1)
            {
                workField[x + 2, y - 2] = "X";
            }

            if (x < rows - 2 && y < cols - 2)
            {
                workField[x + 2, y + 2] = "X";
            }

            if (y == 18)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y + 2] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y + 2] = "X";
                }
            }

            else if (y == 20)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y] = "X";
                }
            }
            else
            {
                if (x - 1 > 1 && y < cols - 3)
                {
                    workField[x - 1, y + 4] = "X";
                }

                if (x < rows - 1 && y < cols - 3)
                {
                    workField[x + 1, y + 4] = "X";
                }
            }
        }

        public static void HitFive(int x, int y, int rows, int cols, String[,] poleZaRabota)
        {
            HitFour(x, y, rows, cols, poleZaRabota);
            if (x - 2 > 1 && y - 4 > 1)
            {
                poleZaRabota[x - 2, y - 4] = "X";
            }

            if (x < rows - 2 && y - 4 > 1)
            {
                poleZaRabota[x + 2, y - 4] = "X";
            }

            if (y == 18)
            {
                if (x < rows - 2)
                {
                    poleZaRabota[x + 2, y + 2] = "X";
                }
                if (x - 2 > 1)
                {
                    poleZaRabota[x - 2, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x < rows - 2)
                {
                    poleZaRabota[x + 2, y] = "X";
                }
                if (x - 2 > 1)
                {
                    poleZaRabota[x - 2, y] = "X";
                }

            }
            else
            {
                if (x < rows - 2 && y < cols - 3)
                {
                    poleZaRabota[x + 2, y + 4] = "X";
                }
                if (x - 2 > 1 && y < cols - 3)
                {
                    poleZaRabota[x - 2, y + 4] = "X";
                }
            }
        }
    }
}
