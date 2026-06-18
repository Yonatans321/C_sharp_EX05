
namespace Ex05_01
{
    public enum eCellState
    {
        Empty,
        Player1,
        Player2
    }
    public class Board
    {
        private readonly eCellState[,] r_BoardMat;
        private readonly int r_Size;

        public int Size
        {
            get { return r_Size; }
        }

        public Board(int i_Size)
        {
            r_Size = i_Size;
            r_BoardMat = new eCellState[r_Size, r_Size];
            InitializeEmptyBoard();
        }

        public void InitializeEmptyBoard()
        {
            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    r_BoardMat[i, j] = eCellState.Empty;
                }
            }
        }

        public eCellState GetCellState(int i_Row, int i_Col)
        {
            return r_BoardMat[i_Row, i_Col];
        }

        public void UpdateCell(int i_Row, int i_Col, eCellState i_NewState)
        {
            r_BoardMat[i_Row, i_Col] = i_NewState;
        }

        public bool IsCellEmpty(int i_Row, int i_Col)
        {
            return r_BoardMat[i_Row, i_Col] == eCellState.Empty;
        }
    }
}