namespace GameLogic
{
    public class Field
    {
        public BigCell CoarseField;

        public BigCell[] FineField;

        public Field()
        {
            CoarseField = new BigCell();
            FineField = new BigCell[9];
            for (int i = 0; i < 9; i++)
            {
                FineField[i] = new BigCell();
            }
        }

        public bool TrySet(int curCell, int position, Cell cell)
        {
            var result = FineField[curCell].TrySet(position, cell);
            if (!result) return false;
            if (FineField[curCell].Check() != Cell.Empty)
            {
                CoarseField.TrySet(curCell, cell);
            }

            return true;
        }



        public Cell Check()
        {
            return CoarseField.Check();
        }

    }
}