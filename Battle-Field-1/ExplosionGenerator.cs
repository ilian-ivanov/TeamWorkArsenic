using System;

namespace BattleField
{
    public class ExplosionGenerator
    {
        public const string DetonatedCell = "X";
        private int x;
        private int y;
        private readonly string[,] battleField;

        public ExplosionGenerator(int x, int y, string[,] battleField)
        {
            this.x = x;
            this.y = y;
            this.battleField = battleField;
        }

        public void Detonate(MineType mineSize)
        {
            string mineIndex = ((int)mineSize).ToString();
            if (this.battleField[this.x, this.y] != mineIndex)
            {
                throw new InvalidOperationException("The current mine type is different from the selected one");
            }

            switch (mineSize)
            {
                case MineType.TinyMine:
                    this.DetonateTinyMine();
                    break;
                case MineType.SmallMine:
                    this.DetonateSmallMine();
                    break;
                case MineType.MediumMine:
                    this.DetonateMediumMine();
                    break;
                case MineType.BigMine:
                    this.DetonateBigMine();
                    break;
                case MineType.HugeMine:
                    this.DetonateHugeMine();
                    break;
                default:
                    throw new ArgumentException("Unknown mine type.");
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

            if (row >= this.battleField.GetLength(0))
            {
                return false;
            }

            if (col < 0)
            {
                return false;
            }

            if (col >= this.battleField.GetLength(1))
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

            this.battleField[row, col] = ExplosionGenerator.DetonatedCell;
        }
    }
}
