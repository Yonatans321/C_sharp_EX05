using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05_01
{
    public partial class GameForm : Form
    {
        private ReverseTicTacToeLogic m_GameLogic;
        private Button[,] m_BoardButtons;
        private Label m_LabelPlayer1Score;
        private Label m_LabelPlayer2Score;
        private string m_Player1Name;
        private string m_Player2Name;
        private int m_Rows;
        private int m_Cols;

        public GameForm(int i_Rows, int i_Cols, string i_Player1Name, string i_Player2Name)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "TicTacToeMisere";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            m_Player1Name = i_Player1Name;
            m_Player2Name = i_Player2Name;
            m_Rows = i_Rows;
            m_Cols = i_Cols;

            bool isComputer = m_Player2Name == "[Computer]";

            if (isComputer)
            {
                m_Player2Name = "Computer";
            }

            m_GameLogic = new ReverseTicTacToeLogic(i_Rows, isComputer);
            m_GameLogic.CellChanged += m_GameLogic_CellChanged;
            m_BoardButtons = new Button[m_Rows, m_Cols];

            int buttonSize = 75;
            int margin = 10;
            int scoreAreaHeight = 40;
            int windowWidth = (i_Cols * buttonSize) + (margin * 2);
            int windowHeight = (i_Rows * buttonSize) + (margin * 2) + scoreAreaHeight;

            this.ClientSize = new Size(windowWidth, windowHeight);

            createBoard(i_Rows, i_Cols, buttonSize, margin);
            createScoreLabel();
        }

        private void createBoard(int i_Rows, int i_Cols, int i_ButtonSize, int i_Margin)
        {
            for (int row = 0; row < i_Rows; ++row)
            {
                for (int col = 0; col < i_Cols; ++col)
                {
                    Button boardButton = new Button();

                    boardButton.Size = new Size(i_ButtonSize, i_ButtonSize);
                    boardButton.Location = new Point(i_Margin + (col * i_ButtonSize), i_Margin + (row * i_ButtonSize));
                    boardButton.Font = new Font("Arial", 20, FontStyle.Bold);
                    boardButton.Click += boardButton_Click;
                    this.Controls.Add(boardButton);

                    m_BoardButtons[row, col] = boardButton;
                }
            }
        }

        private void createScoreLabel()
        {
            m_LabelPlayer1Score = new Label();
            m_LabelPlayer2Score = new Label();

            m_LabelPlayer1Score.AutoSize = true;
            m_LabelPlayer2Score.AutoSize = true;

            this.Controls.Add(m_LabelPlayer1Score);
            this.Controls.Add(m_LabelPlayer2Score);

            updateScoreLabel();
        }

        private void updateScoreLabel()
        {
            m_LabelPlayer1Score.Text = string.Format("{0}: {1}", m_Player1Name, m_GameLogic.Player1Score);
            m_LabelPlayer2Score.Text = string.Format("{0}: {1}", m_Player2Name, m_GameLogic.Player2Score);

            if (m_GameLogic.CurrentPlayerState == eCellState.Player1)
            {
                m_LabelPlayer1Score.Font = new Font(m_LabelPlayer1Score.Font, FontStyle.Bold);
                m_LabelPlayer2Score.Font = new Font(m_LabelPlayer2Score.Font, FontStyle.Regular);
            }
            else
            {
                m_LabelPlayer1Score.Font = new Font(m_LabelPlayer1Score.Font, FontStyle.Regular);
                m_LabelPlayer2Score.Font = new Font(m_LabelPlayer2Score.Font, FontStyle.Bold);
            }

            int spacing = 20;
            int totalWidth = m_LabelPlayer1Score.Width + spacing + m_LabelPlayer2Score.Width;
            int xLocation = (this.ClientSize.Width - totalWidth) / 2;
            int yLocation = this.ClientSize.Height - 30;

            m_LabelPlayer1Score.Location = new Point(xLocation, yLocation);
            m_LabelPlayer2Score.Location = new Point(xLocation + m_LabelPlayer1Score.Width + spacing, yLocation);
        }

        private void m_GameLogic_CellChanged(int i_Row, int i_Col, eCellState i_NewState)
        {
            Button changedButton = m_BoardButtons[i_Row, i_Col];

            if (i_NewState == eCellState.Player1)
            {
                changedButton.Text = "X";
                changedButton.Enabled = false;
            }
            else if (i_NewState == eCellState.Player2)
            {
                changedButton.Text = "O";
                changedButton.Enabled = false;
            }
            else
            {
                changedButton.Text = "";
                changedButton.Enabled = true;
            }
        }

        private void boardButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int rowToPlay = -1;
            int colToPlay = -1;

            for (int r = 0; r < m_Rows; ++r)
            {
                for (int c = 0; c < m_Cols; ++c)
                {
                    if (m_BoardButtons[r, c] == clickedButton)
                    {
                        rowToPlay = r;
                        colToPlay = c;
                    }
                }
            }

            if (rowToPlay != -1 && colToPlay != -1)
            {
                m_GameLogic.MakeMove(rowToPlay, colToPlay);
                updateScoreLabel();

                if (!checkGameOver())
                {
                    if (m_GameLogic.IsComputerTurn())
                    {
                        m_GameLogic.MakeComputerMove();
                        updateScoreLabel();
                        checkGameOver();
                    }
                }
            }
        }

        private bool checkGameOver()
        {
            bool isGameOver = false;
            eCellState winner;

            if (m_GameLogic.IsGameOver(out winner))
            {
                isGameOver = true;
                updateScoreLabel();
                string resultMessage;
                string resultTitle;

                if (winner == eCellState.Player1)
                {
                    resultTitle = "A Win!";
                    resultMessage = string.Format("The winner is {0}!", m_Player1Name);
                }
                else if (winner == eCellState.Player2)
                {
                    resultTitle = "A Win!";
                    resultMessage = string.Format("The winner is {0}!", m_Player2Name);
                }
                else
                {
                    resultTitle = "A Tie!";
                    resultMessage = "Tie!";
                }

                string fullMessage = string.Format("{0}\nWould you like to play another round?", resultMessage);
                DialogResult result = MessageBox.Show(this, fullMessage, resultTitle, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    m_GameLogic.ResetBoard();
                    updateScoreLabel();

                    if (m_GameLogic.IsComputerTurn())
                    {
                        m_GameLogic.MakeComputerMove();
                    }
                }
                else
                {
                    this.Close();
                }
            }

            return isGameOver;
        }
    }
}
