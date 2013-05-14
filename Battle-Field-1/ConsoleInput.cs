using System;
using System.Linq;

namespace BattleField
{
    class ConsoleInput
    {
        public static void ReadPlayerMove(int n, string[,] workField, out int x, out int y)
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

            x = row + GameState.GameFieldScaleOffset;
            y = col * 2 + GameState.GameFieldScaleOffset;
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
            int gameFieldRow = row + GameState.GameFieldScaleOffset;
            int gameFieldCol = col * 2 + GameState.GameFieldScaleOffset;
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
    }
}
