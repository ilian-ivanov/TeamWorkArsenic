﻿using System;
using System.Linq;

namespace BattleField
{
    public static class Engine
    {
        public static void Run()
        {
            int sizeOfBattleField = ConsoleInput.TakeSizeOfBattleField();
            int rows = sizeOfBattleField;
            int cols = sizeOfBattleField;
            string[,] battleField = new string[rows, cols];

            Renderer.PrepareBattleField(rows, cols, battleField);
            Renderer.FillBattleField(sizeOfBattleField, battleField);
            Renderer.VisualizeBattleField(rows, cols, battleField);

            int score = 0;
            do
            {
                score++;
                int xCoord;
                int yCoord;
                ConsoleInput.ReadPlayerMove(sizeOfBattleField, battleField, out xCoord, out yCoord);

                int hitCoordinate = int.Parse(battleField[xCoord, yCoord]);

                ExplosionGenerator explosionGenerator = new ExplosionGenerator(xCoord, yCoord, rows, cols, battleField);
                explosionGenerator.Detonate((MineType)hitCoordinate);

                Renderer.VisualizeBattleField(rows, cols, battleField);
            }
            while(!IsEndOfGame(rows, cols, battleField));
            
            Console.WriteLine("Game over. Detonated mines: " + score);
        }

        private static bool IsEndOfGame(int rows, int cols, string[,] battleField)
        {
            bool isEndOfGame = true;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (battleField[i, j] == "1" || battleField[i, j] == "2" || 
                        battleField[i, j] == "3" || battleField[i, j] == "4" || 
                        battleField[i, j] == "5")
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
