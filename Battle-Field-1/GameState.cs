using System;
using System.Linq;

namespace BattleField
{
    public static class GameState
    {
        public const int GameFieldScaleOffset = 2;

        public static void Run()
        {
            int sizeOfBattleField = Renderer.TakeDataForGame();
            int rows = sizeOfBattleField + 2;
            int cols = sizeOfBattleField * 2 + 2;
            string[,] field = new string[rows, cols];

            Renderer.PrepareBattleField(sizeOfBattleField, rows, cols, field);
            Renderer.FillBattleField(sizeOfBattleField, rows, cols, field);
            Renderer.VisualizeBattleField(rows, cols, field);

            int countPlayed = 0;
            do{
                
                countPlayed++;
                int x;
                int y;
                ReadPlayerMove(sizeOfBattleField, field, out x, out y);

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
               
            }while(!IsEndOfGame(rows, cols, field));
            
            Console.WriteLine("Game over. Detonated mines: " + countPlayed);
        }

        private static void ReadPlayerMove(int n, string[,] workField, out int x, out int y)
        {
            bool isCorrectUserMove = false;
            int row;
            int col;

            do
            {
                Console.WriteLine("Please enter coordinates: ");
                String userInput = Console.ReadLine();
                
                bool isValidUserInput = TryParseValidUserInput(userInput, out row, out col);
                bool areCoordinates = IsInputValidCoordinate(n, row, col);
                bool isValidMove = false;

                if (isValidUserInput && areCoordinates)
                {
                    isValidMove = IsPlayerValidMove(workField, row, col);
                }

                if (isValidUserInput && areCoordinates && isValidMove)
                {
                    isCorrectUserMove = true;
                }
                else
                {
                    Console.WriteLine("Invalid move! ");
                }
            }
            while (!isCorrectUserMove);

            x = row + GameFieldScaleOffset;
            y = col * 2 + GameFieldScaleOffset;
        }

        private static bool TryParseValidUserInput(string userInput, out int row, out int col)
        {
            bool isValidRow = false;
            bool isValidCol = false;
            string rowCol = userInput;
            try
            {
                isValidRow = int.TryParse(rowCol.Substring(0, 1), out row);
                isValidCol = int.TryParse(rowCol.Substring(2, 1), out col);
            }
            catch
            {
                // we dont care why the input is not parsed
                // that's why no specific exception is catched
                // we only need correct input
                // row and col must have some int value after the method is called
                row = -1;
                col = -1;
            }

            if (isValidRow && isValidCol)
            {
                return true;
            }

            return false;
        }

        private static bool IsPlayerValidMove(string[,] workField, int row, int col)
        {
            int gameFieldRow = row + GameFieldScaleOffset;
            int gameFieldCol = col * 2 + GameFieldScaleOffset;
            if (workField[gameFieldRow, gameFieldCol] == "-" ||
                workField[gameFieldRow, gameFieldCol] == "X")
            {
                return false;
            }
            return true;
        }

        private static bool IsInputValidCoordinate(int n, int row, int col)
        {
            if ((row < 0 || row > (n - 1)) && (col < 0 || col > (n - 1)))
            {
                return false;
            }

            return true;
        }



        public static bool IsEndOfGame(int rows, int cols, String[,] gameField)
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