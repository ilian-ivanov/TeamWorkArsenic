using System;
using System.Linq;

namespace BattleField
{
    public static class GameState
    {        
        public static void vremeEIgrachaDaDeistva(int n, int rows, int cols, String[,] workField, int countPlayed)
        {
            countPlayed++;
            Console.WriteLine("Please enter coordinates: ");
            String xy = Console.ReadLine();
            int x = int.Parse(xy.Substring(0, 1));
            int y = int.Parse(xy.Substring(2, 1));

            while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
            {
                Console.WriteLine("Invalid move !");
                Console.WriteLine("Please enter coordinates: ");
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));
            }

            x += 2;
            y = 2 * y + 2;

            while (workField[x, y] == "-" || workField[x, y] == "X")
            {
                Console.WriteLine("Invalid move! ");
                Console.WriteLine("Please enter coordinates: ");
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));

                while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
                {
                    Console.WriteLine("Invalid move !");
                    Console.WriteLine("Please enter coordinates: ");
                    xy = Console.ReadLine();
                    x = int.Parse(xy.Substring(0, 1));
                    y = int.Parse(xy.Substring(2, 1));

                }

                x += 2;
                y = 2 * y + 2;
            }

            int hitCoordinate = Convert.ToInt32(workField[x, y]);
            switch (hitCoordinate)
            {
                case 1: Explosion.HitOne(x, y, rows, cols, workField); break;
                case 2: Explosion.PrasniDvama(x, y, rows, cols, workField); break;
                case 3: Explosion.HitThree(x, y, rows, cols, workField); break;
                case 4: Explosion.HitFour(x, y, rows, cols, workField); break;
                case 5: Explosion.HitFive(x, y, rows, cols, workField); break;
            }

            Renderer.VisualizeBattleField(rows, cols, workField);
            if (!IsEndOfGame(rows, cols, workField))
            {
                vremeEIgrachaDaDeistva(n, rows, cols, workField, countPlayed);
            }
            else
            {
                Console.WriteLine("Game over. Detonated mines: " + countPlayed);
            }
        }

        public static bool IsEndOfGame(int rows, int cols, String[,] Полето)
        {
            bool isEndOfGame = true;
            for (int i = 2; i < rows; i++)
            {
                for (int j = 2; j < cols; j++)
                {
                    if (Полето[i, j] == "1" || Полето[i, j] == "2" || Полето[i, j] == "3" || Полето[i, j] == "4" || Полето[i, j] == "5")
                    {
                        isEndOfGame = false;
                        break;
                    }
                }
            }
            return isEndOfGame;
        }
    }
}