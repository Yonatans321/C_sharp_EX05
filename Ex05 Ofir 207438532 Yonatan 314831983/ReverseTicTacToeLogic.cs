using System;


namespace Ex05_01
{
    public delegate void CellChangedDelegate(int i_Row, int i_Col, eCellState i_NewState);

    public class ReverseTicTacToeLogic
    {
        private readonly Board r_Board;
        private readonly bool r_IsVsComputer;
        private readonly Random r_RandomGeneratorForComputer;

        private bool m_Player1Turn;
        private int m_Player1Score;
        private int m_Player2Score;
        private int m_FilledCellsCount;

        public event CellChangedDelegate CellChanged;

        public int Player1Score
        {
            get { return m_Player1Score; }
            set { m_Player1Score = value; }
        }

        public int Player2Score
        {
            get { return m_Player2Score; }
            set { m_Player2Score = value; }
        }

        public eCellState CurrentPlayerState
        {
            get { return m_Player1Turn ? eCellState.Player1 : eCellState.Player2; }
        }

        public ReverseTicTacToeLogic(int i_BoardSize, bool i_IsVsComputer)
        {
            r_IsVsComputer = i_IsVsComputer;
            r_Board = new Board(i_BoardSize);
            r_RandomGeneratorForComputer = new Random();
            m_Player1Score = 0;
            m_Player2Score = 0;
            m_Player1Turn = true;
            m_FilledCellsCount = 0;

            ResetBoard();
        }

        public void ResetBoard()
        {
            r_Board.InitializeEmptyBoard();
            m_Player1Turn = true;
            m_FilledCellsCount = 0;

            for (int r = 0; r < r_Board.Size; ++r)
            {
                for (int c = 0; c < r_Board.Size; ++c)
                {
                    OnCellChanged(r, c, eCellState.Empty);
                }
            }
        }

        public bool IsCellEmpty(int i_Row, int i_Col)
        {
            return r_Board.IsCellEmpty(i_Row, i_Col);
        }

        public bool IsComputerTurn()
        {
            return r_IsVsComputer && !m_Player1Turn;
        }

        public void MakeMove(int i_Row, int i_Col)
        {
            eCellState currentPlayerState = m_Player1Turn ? eCellState.Player1 : eCellState.Player2;

            r_Board.UpdateCell(i_Row, i_Col, currentPlayerState);

            OnCellChanged(i_Row, i_Col, currentPlayerState);

            m_FilledCellsCount++;
            m_Player1Turn = !m_Player1Turn;
        }

        protected virtual void OnCellChanged(int i_Row, int i_Col, eCellState i_NewState)
        {
            if (CellChanged != null)
            {
                CellChanged.Invoke(i_Row, i_Col, i_NewState);
            }
        }

        public void MakeComputerMove()
        {
            int totalCells = r_Board.Size * r_Board.Size;
            int emptyCellsCount = totalCells - m_FilledCellsCount;
            int rowToMove = -1;
            int colToMove = -1;
            bool moveFound = false;

            if (emptyCellsCount > 0)
            {
                int randomEmptyCellIndex = r_RandomGeneratorForComputer.Next(emptyCellsCount);
                int currentEmptyCount = 0;

                for (int row = 0; row < r_Board.Size && !moveFound; ++row)
                {
                    for (int col = 0; col < r_Board.Size && !moveFound; ++col)
                    {
                        if (IsCellEmpty(row, col))
                        {
                            if (currentEmptyCount == randomEmptyCellIndex)
                            {
                                rowToMove = row;
                                colToMove = col;
                                moveFound = true;
                            }
                            else
                            {
                                currentEmptyCount++;
                            }
                        }
                    }
                }
            }

            if (moveFound)
            {
                MakeMove(rowToMove, colToMove);
            }
        }

        public bool IsGameOver(out eCellState o_Winner)
        {
            bool isGameOver = false;
            eCellState lastPlayerState = m_Player1Turn ? eCellState.Player2 : eCellState.Player1;
            bool hasSequence = checkSequence(lastPlayerState);

            o_Winner = eCellState.Empty;

            if (hasSequence)
            {
                isGameOver = true;

                if (lastPlayerState == eCellState.Player1)
                {
                    o_Winner = eCellState.Player2;
                    m_Player2Score++;
                }
                else
                {
                    o_Winner = eCellState.Player1;
                    m_Player1Score++;
                }
            }
            else if (m_FilledCellsCount == (r_Board.Size * r_Board.Size))
            {
                o_Winner = eCellState.Empty;
                isGameOver = true;
            }

            return isGameOver;
        }

        private bool checkSequence(eCellState i_State)
        {
            return checkRows(i_State) || checkCols(i_State) || checkDiagonals(i_State);
        }

        private bool checkRows(eCellState i_State)
        {
            bool foundSequence = false;
            bool isCurrentRowFull = false;

            for (int r = 0; r < r_Board.Size; ++r)
            {
                if (!foundSequence)
                {
                    isCurrentRowFull = true;

                    for (int c = 0; c < r_Board.Size; ++c)
                    {
                        if (r_Board.GetCellState(r, c) != i_State)
                        {
                            isCurrentRowFull = false;
                        }
                    }
                }

                foundSequence = isCurrentRowFull || foundSequence;
            }

            return foundSequence;
        }

        private bool checkCols(eCellState i_State)
        {
            bool foundSequence = false;
            bool isCurrentColFull = false;

            for (int c = 0; c < r_Board.Size; ++c)
            {
                if (!foundSequence)
                {
                    isCurrentColFull = true;

                    for (int r = 0; r < r_Board.Size; ++r)
                    {
                        if (r_Board.GetCellState(r, c) != i_State)
                        {
                            isCurrentColFull = false;
                        }
                    }
                }

                foundSequence = isCurrentColFull || foundSequence;
            }

            return foundSequence;
        }

        private bool checkDiagonals(eCellState i_State)
        {
            bool isMainDiagonalFull = true;
            bool isSecondDiagonalFull = true;

            for (int i = 0; i < r_Board.Size; ++i)
            {
                if (r_Board.GetCellState(i, i) != i_State)
                {
                    isMainDiagonalFull = false;
                }

                if (r_Board.GetCellState(i, r_Board.Size - 1 - i) != i_State)
                {
                    isSecondDiagonalFull = false;
                }
            }

            return isMainDiagonalFull || isSecondDiagonalFull;
        }
    }
}
