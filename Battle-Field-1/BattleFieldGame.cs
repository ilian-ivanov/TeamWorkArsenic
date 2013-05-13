using System;
using System.Linq;

namespace BattleField
{
    class BattleFieldGame
    { 
        static void Main(string[] argumenti)
        { 
            Console.Write("Welcome to \"Battle Field game.\" Enter battle field size: n = ");         
            int n = int.Parse(Console.ReadLine());
            while (n < 1 || n > 10)
            {
                Console.WriteLine("Enter a number between 1 and 10!");
                n = int.Parse(Console.ReadLine());
            }

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