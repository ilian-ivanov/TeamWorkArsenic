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
            // The current cell.
            if (this.IsCellInTheGameField(this.x, this.y))
            {
                this.DetonateCell(this.x, this.y);
            }

            // The top left cell.
            if (this.IsCellInTheGameField(this.x - 1, this.y - 1))
            {
                this.DetonateCell(this.x - 1, this.y - 1);
            }

            // Top right cell.
            if (this.IsCellInTheGameField(this.x - 1, this.y + 1))
            {
                this.DetonateCell(this.x - 1, this.y + 1);
            }

            // Bottom left cell.
            if (this.IsCellInTheGameField(this.x + 1, this.y - 1))
            {
                this.DetonateCell(this.x + 1, this.y - 1);
            }

            // Bottom right cell.
            if (this.IsCellInTheGameField(this.x + 1, this.y + 1))
            {
                this.DetonateCell(this.x + 1, this.y + 1);
            }
        }

        private void DetonateSmallMine()
        {
            this.DetonateTinyMine();

            // Top cell.
            if (this.IsCellInTheGameField(this.x - 1, this.y))
            {
                this.DetonateCell(this.x - 1, this.y);
            }

            // Right cell.
            if (this.IsCellInTheGameField(this.x, this.y + 1))
            {
                this.DetonateCell(this.x, this.y + 1);
            }

            // Bottom cell.
            if (this.IsCellInTheGameField(this.x + 1, this.y))
            {
                this.DetonateCell(this.x + 1, this.y);
            }

            // Left cell.
            if (this.IsCellInTheGameField(this.x, this.y - 1))
            {
                this.DetonateCell(this.x, this.y - 1);
            }
        }

        private void DetonateMediumMine()
        {
            this.DetonateSmallMine();

            // Top of the small mine.
            if (this.IsCellInTheGameField(this.x - 2, this.y))
            {
                this.DetonateCell(this.x - 2, this.y);
            }

            // Right of the small mine.
            if (this.IsCellInTheGameField(this.x, this.y + 2))
            {
                this.DetonateCell(this.x, this.y + 2);
            }

            // Bottom of the small mine.
            if (this.IsCellInTheGameField(this.x + 2, this.y))
            {
                this.DetonateCell(this.x + 2, this.y);
            }

            // Left of the small mine.
            if (this.IsCellInTheGameField(this.x, this.y - 2))
            {
                this.DetonateCell(this.x, this.y - 2);
            }
        }

        private void DetonateBigMine()
        {
            this.DetonateMediumMine();

            // Top left of the medium mine.
            if (this.IsCellInTheGameField(this.x - 2, this.y - 1))
            {
                this.DetonateCell(this.x - 2, this.y - 1);
            }

            // Top right of the medium mine.
            if (this.IsCellInTheGameField(this.x - 2, this.y + 1))
            {
                this.DetonateCell(this.x - 2, this.y + 1);
            }

            // Right top of the medium mine.
            if (this.IsCellInTheGameField(this.x - 1, this.y + 2))
            {
                this.DetonateCell(this.x - 1, this.y + 2);
            }

            // Right bottom of the medium mine.
            if (this.IsCellInTheGameField(this.x + 1, this.y + 2))
            {
                this.DetonateCell(this.x + 1, this.y + 2);
            }

            // Bottom right of the medium mine.
            if (this.IsCellInTheGameField(this.x + 2, this.y + 1))
            {
                this.DetonateCell(this.x + 2, this.y + 1);
            }

            // Bottom left of the medium mine.
            if (this.IsCellInTheGameField(this.x + 2, this.y - 1))
            {
                this.DetonateCell(this.x + 2, this.y - 1);
            }

            // Left bottom of the medium mine.
            if (this.IsCellInTheGameField(this.x + 1, this.y - 2))
            {
                this.DetonateCell(this.x + 1, this.y - 2);
            }

            // Left top of the medium mine.
            if (this.IsCellInTheGameField(this.x - 1, this.y - 2))
            {
                this.DetonateCell(this.x - 1, this.y - 2);
            }
        }

        private void DetonateHugeMine()
        {
            this.DetonateBigMine();

            // Top left of the big mine.
            if (this.IsCellInTheGameField(this.x - 2, this.y - 2))
            {
                this.DetonateCell(this.x - 2, this.y - 2);
            }

            // Top right of the big mine.
            if (this.IsCellInTheGameField(this.x - 2, this.y + 2))
            {
                this.DetonateCell(this.x - 2, this.y + 2);
            }

            // Bottom left of the big mine.
            if (this.IsCellInTheGameField(this.x + 2, this.y - 2))
            {
                this.DetonateCell(this.x + 2, this.y - 2);
            }

            // Bottom right of the big mine.
            if (this.IsCellInTheGameField(this.x + 2, this.y + 2))
            {
                this.DetonateCell(this.x + 2, this.y + 2);
            }
        }

        private bool IsCellInTheGameField(int row, int col)
        {
            if (row < 0)
            {
                return false;
            }

            if (row >= this.rows)
            {
                return false;
            }

            if (col < 0)
            {
                return false;
            }

            if (col >= this.cols)
            {
                return false;
            }

            return true;
        }

        private void DetonateCell(int row, int col)
        {
            if (this.IsCellInTheGameField(row, col) == false)
            {
                throw new InvalidOperationException("The coordinates are out of the fields!");
            }

            this.workField[row, col] = ExplosionGenerator.DetonatedCell;
        }
    }
}
