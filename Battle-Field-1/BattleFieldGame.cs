using System;
using System.Linq;

namespace BattleField
{
    class BattleFieldGame
    { 
        static void Main()
        { 
            int n = Renderer.TakeDataForGame();
            int rows = n + 2;
            int cols = n * 2 + 2;
            string[,] field = new string[rows, cols];

            Renderer.PrepareBattleField(n, rows, cols, field);
            Renderer.FillBattleField(n, rows, cols, field);
            Renderer.VisualizeBattleField(rows, cols, field);

            int countPlayed = 0;
            GameState.vremeEIgrachaDaDeistva(n, rows, cols, field, countPlayed);
        }       
    }
}