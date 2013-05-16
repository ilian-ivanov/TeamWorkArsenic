using System;
using System.Linq;

namespace BattleField
{
    class ConsoleInput
    {
        public static int TakeSizeOfBattleField()
        {
            const int MaxBattleFieldSize = 10;
            const int MinBattleFieldSize = 1;

            Console.Write("Welcome to \"Battle Field game.\" Enter battle field size between[1 - 10]: size = ");
            string input = Console.ReadLine();
            int size = 0; // sets 0 to enter in loop if we cannot parse
            int.TryParse(input, out size);

            // enters in loop if entered number is not between 1 and 10 or input cannot be parsed
            while (size < MinBattleFieldSize || size > MaxBattleFieldSize)
            {
                Console.WriteLine("Enter a number between 1 and 10!");
                input = Console.ReadLine();
                int.TryParse(input, out size);
            }

            return size;
        }

        public static void ReadPlayerMove(string[,] battleField, out int xCoord, out int yCoord)
        {
            int sizeOfBattleField = battleField.GetLength(0);
            bool isCorrectUserMove = false;
            int x;
            int y;

            do
            {
                Console.WriteLine("Please enter coordinates: ");
                string userInput = Console.ReadLine();

                bool isValidUserInput = TryParseValidUserInput(userInput, out x, out y);
                bool areCoordinates = IsInputValidCoordinate(sizeOfBattleField, x, y);
                bool isValidMove = false;

                if (isValidUserInput && areCoordinates)
                {
                    isValidMove = IsPlayerValidMove(battleField, x, y);
                }

                if (isValidUserInput && areCoordinates && isValidMove)
                {
                    isCorrectUserMove = true;
                }
                else
                {
                    Console.WriteLine("Invalid move!");
                }
            }
            while (!isCorrectUserMove);

            xCoord = x;
            yCoord = y;
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
            catch (ArgumentOutOfRangeException aore)
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

        private static bool IsPlayerValidMove(string[,] battleField, int row, int col)
        {
            int gameFieldRow = row;
            int gameFieldCol = col;

            // TODO: index out of range if we make field with size 3 and give coordinates 0 3
            if (battleField[gameFieldRow, gameFieldCol] == "-" ||
                battleField[gameFieldRow, gameFieldCol] == ExplosionGenerator.DetonatedCell)
            {
                return false;
            }

            return true;
        }

        private static bool IsInputValidCoordinate(int battleFieldSize, int row, int col)
        {
            if ((row < 0 || row > (battleFieldSize - 1)) && (col < 0 || col > (battleFieldSize - 1)))
            {
                return false;
            }

            return true;
        }
    }
}