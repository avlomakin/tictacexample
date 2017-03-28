namespace GameLogic
{
    public class BigCell
    {
        public Cell[] Cells;

        public BigCell()
        {
            Cells = new Cell[9];
            for (int i = 0; i < 9; i++)
            {
                Cells[i] = Cell.Empty;
            }
        }

        public bool TrySet(int position, Cell cell)
        {
            if (Cells[position] == Cell.Empty)
            {
                Cells[position] = cell;
                return true;
            }
            return false;
        }

        public Cell Check()
        {
            if (Cells[0] == Cells[1] && Cells[0] == Cells[2] && Cells[0] != Cell.Empty) //horizontal
            {
                return Cells[0];
            }

            if (Cells[3] == Cells[4] && Cells[3] == Cells[5] && Cells[3] != Cell.Empty)
            {
                return Cells[3];
            }

            if (Cells[6] == Cells[7] && Cells[6] == Cells[8] && Cells[6] != Cell.Empty)
            {
                return Cells[6];
            }

            if (Cells[0] == Cells[3] && Cells[0] == Cells[6] && Cells[0] != Cell.Empty) //vertical
            {
                return Cells[0];
            }

            if (Cells[1] == Cells[4] && Cells[1] == Cells[7] && Cells[1] != Cell.Empty)
            {
                return Cells[1];
            }

            if (Cells[2] == Cells[5] && Cells[2] == Cells[8] && Cells[2] != Cell.Empty)
            {
                return Cells[2];
            }

            if (Cells[0] == Cells[4] && Cells[0] == Cells[8] && Cells[0] != Cell.Empty)  //diagonal
            {
                return Cells[0];
            }

            if (Cells[2] == Cells[4] && Cells[2] == Cells[6] && Cells[2] != Cell.Empty)
            {
                return Cells[2];
            }

            return Cell.Empty;
        }
    }
}