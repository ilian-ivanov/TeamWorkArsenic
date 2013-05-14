using System;
using System.Linq;

namespace BattleField
{
    public static class Engine
    {
        public const int GameFieldScaleOffset = 2;

        public static void Run()
        {
            int sizeOfBattleField = Renderer.TakeDataForGame();
            int rows = sizeOfBattleField + GameFieldScaleOffset;
            int cols = sizeOfBattleField * 2 + GameFieldScaleOffset;
            string[,] field = new string[rows, cols];

            Renderer.PrepareBattleField(sizeOfBattleField, rows, cols, field);
            Renderer.FillBattleField(sizeOfBattleField, rows, cols, field);
            Renderer.VisualizeBattleField(rows, cols, field);

            int score = 0;
            do
            {
                score++;
                int x, y;
                ConsoleInput.ReadPlayerMove(sizeOfBattleField, field, out x, out y);

                int hitCoordinate = Convert.ToInt32(field[x, y]);
                switch (hitCoordinate)
                {
                    case 1: Explosion.HitOne(x, y, rows, cols, field); break;
                    case 2: Explosion.PrasniDvama(x, y, rows, cols, field); break;
                    case 3: Explosion.HitThree(x, y, rows, cols, field); break;
                    case 4: Explosion.HitFour(x, y, rows, cols, field); break;
                    case 5: Explosion.HitFive(x, y, rows, cols, field); break;
                }

                Renderer.VisualizeBattleField(rows, cols, field);
            }
            while(!IsEndOfGame(rows, cols, field));
            
            Console.WriteLine("Game over. Detonated mines: " + score);
        }

        private static bool IsEndOfGame(int rows, int cols, String[,] gameField)
        {
            bool isEndOfGame = true;
            for (int i = 2; i < rows; i++)
            {
                for (int j = 2; j < cols; j++)
                {
                    if (gameField[i, j] == "1" || gameField[i, j] == "2" || gameField[i, j] == "3" || gameField[i, j] == "4" || gameField[i, j] == "5")
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