﻿using System;
using System.Linq;

namespace BattleField
{
    public static class Engine
    {
        public static void Run()
        {
            int sizeOfBattleField = ConsoleInput.TakeSizeOfBattleField();
            string[,] battleField = new string[sizeOfBattleField, sizeOfBattleField];

            Renderer.PrepareBattleField(battleField);
            Renderer.FillBattleField(battleField);
            Renderer.VisualizeBattleField(battleField);

            int score = 0;
            do
            {
                score++;
                int xCoord;
                int yCoord;
                ConsoleInput.ReadPlayerMove(battleField, out xCoord, out yCoord);

                ExplosionGenerator explosionGenerator = new ExplosionGenerator(xCoord, yCoord, battleField);
                int hitCoordinate = int.Parse(battleField[xCoord, yCoord]);
                explosionGenerator.Detonate((MineType)hitCoordinate);

                Renderer.VisualizeBattleField(battleField);
            }
            while (!IsEndOfGame(battleField));

            Console.WriteLine("Game over. Detonated mines: " + score);
        }

        public static bool IsEndOfGame(string[,] battleField)
        {
            bool isEndOfGame = true;
            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                for (int j = 0; j < battleField.GetLength(1); j++)
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
