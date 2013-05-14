using System;
using System.Linq;

namespace BattleField
{
    public class ExplosionGenerator
    {
        public const string DetonatedCell = "X";
        private int x;
        private int y;
        private int rows;
        private int cols;
        private String[,] workField;

        public ExplosionGenerator(int x, int y, int rows, int cols, String[,] workField)
        {
            this.x = x;
            this.y = y;
            this.rows = rows;
            this.cols = cols;
            this.workField = workField;
        }

        public void Detonate(int mineSize)
        {
            switch (mineSize)
            {
                case 1: this.DetonateTinyMine(); break;
                case 2: this.DetonateSmallMine(); break;
                case 3: this.DetonateMediumMine(); break;
                case 4: this.DetonateBigMine(); break;
                case 5: this.DetonateHugeMine(); break;
                    //TODO: Throw exception when default
            }
        }

        private void DetonateTinyMine()
        {
            workField[x, y] = ExplosionGenerator.DetonatedCell;
            if (x - 1 > 1 && y - 2 > 1)
            {
                workField[x - 1, y - 2] = ExplosionGenerator.DetonatedCell;
            }
            if (x - 1 > 1 && y < cols - 2)
            {
                workField[x - 1, y + 2] = ExplosionGenerator.DetonatedCell;
            }
            if (x < rows - 1 && y < cols - 2)
            {
                workField[x + 1, y + 2] = ExplosionGenerator.DetonatedCell;
            }
            if (x < rows - 1 && y - 2 > 1)
            {
                workField[x + 1, y - 2] = ExplosionGenerator.DetonatedCell;
            }
        }

        private void DetonateSmallMine()
        {
            workField[x, y] = ExplosionGenerator.DetonatedCell;
            DetonateTinyMine();
            if (y - 2 > 1)
            {
                workField[x, y - 2] = ExplosionGenerator.DetonatedCell;
            }
            if (y < cols - 2)
            {
                workField[x, y + 2] = ExplosionGenerator.DetonatedCell;
            }
            if (x - 1 > 1)
            {
                workField[x - 1, y] = ExplosionGenerator.DetonatedCell;
            }
            if (x < rows - 1)
            {
                workField[x + 1, y] = ExplosionGenerator.DetonatedCell;
            }
        }

        private void DetonateMediumMine()
        {
            DetonateSmallMine();
            if (x - 2 > 1)
            {
                workField[x - 2, y] = ExplosionGenerator.DetonatedCell;
            }
            if (x < rows - 2)
            {
                workField[x + 2, y] = ExplosionGenerator.DetonatedCell;
            }
            if (y - 4 > 1)
            {
                workField[x, y - 4] = ExplosionGenerator.DetonatedCell;
            }
            if (y == 18)
            {
                workField[x, y + 2] = ExplosionGenerator.DetonatedCell;

            }
            else if (y == 20)
            {
                workField[x, y] = ExplosionGenerator.DetonatedCell;
            }
            else
            {
                if (y < cols - 3)
                {
                    workField[x, y + 4] = ExplosionGenerator.DetonatedCell;
                }
            }
        }

        private void DetonateBigMine()
        {
            DetonateMediumMine();
            if (x - 2 > 1 && y - 2 > 1)
            {
                workField[x - 2, y - 2] = ExplosionGenerator.DetonatedCell;
            }
            if (x - 1 > 1 && y - 4 > 1)
            {
                workField[x - 1, y - 4] = ExplosionGenerator.DetonatedCell;
            }
            if (x - 2 > 1 && y < cols - 2)
            {
                workField[x - 2, y + 2] = ExplosionGenerator.DetonatedCell;
            }


            if (x < rows - 1 && y - 4 > 1)
            {
                workField[x + 1, y - 4] = ExplosionGenerator.DetonatedCell;
            }
            if (x < rows - 2 && y - 2 > 1)
            {
                workField[x + 2, y - 2] = ExplosionGenerator.DetonatedCell;
            }

            if (x < rows - 2 && y < cols - 2)
            {
                workField[x + 2, y + 2] = ExplosionGenerator.DetonatedCell;
            }

            if (y == 18)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y + 2] = ExplosionGenerator.DetonatedCell;
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y + 2] = ExplosionGenerator.DetonatedCell;
                }
            }

            else if (y == 20)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y] = ExplosionGenerator.DetonatedCell;
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y] = ExplosionGenerator.DetonatedCell;
                }
            }
            else
            {
                if (x - 1 > 1 && y < cols - 3)
                {
                    workField[x - 1, y + 4] = ExplosionGenerator.DetonatedCell;
                }

                if (x < rows - 1 && y < cols - 3)
                {
                    workField[x + 1, y + 4] = ExplosionGenerator.DetonatedCell;
                }
            }
        }

        private void DetonateHugeMine()
        {
            DetonateBigMine();
            if (x - 2 > 1 && y - 4 > 1)
            {
                workField[x - 2, y - 4] = ExplosionGenerator.DetonatedCell;
            }

            if (x < rows - 2 && y - 4 > 1)
            {
                workField[x + 2, y - 4] = ExplosionGenerator.DetonatedCell;
            }

            if (y == 18)
            {
                if (x < rows - 2)
                {
                    workField[x + 2, y + 2] = ExplosionGenerator.DetonatedCell;
                }
                if (x - 2 > 1)
                {
                    workField[x - 2, y + 2] = ExplosionGenerator.DetonatedCell;
                }
            }
            else if (y == 20)
            {
                if (x < rows - 2)
                {
                    workField[x + 2, y] = ExplosionGenerator.DetonatedCell;
                }
                if (x - 2 > 1)
                {
                    workField[x - 2, y] = ExplosionGenerator.DetonatedCell;
                }

            }
            else
            {
                if (x < rows - 2 && y < cols - 3)
                {
                    workField[x + 2, y + 4] = ExplosionGenerator.DetonatedCell;
                }
                if (x - 2 > 1 && y < cols - 3)
                {
                    workField[x - 2, y + 4] = ExplosionGenerator.DetonatedCell;
                }
            }
        }
    }
}
