using System;
using System.Windows.Forms;

namespace Ex05_01
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCols.Value = numericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Value = numericUpDownCols.Value;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int rows = (int)numericUpDownRows.Value;
            int cols = (int)numericUpDownCols.Value;
            string player1Name = player1TextBox.Text == "" ? "Player 1" : player1TextBox.Text;
            string player2Name = player2TextBox.Text == "" ? "Player 2" : player2TextBox.Text;
            GameForm gameBoard = new GameForm(rows, cols, player1Name, player2Name);

            this.Hide(); 
            gameBoard.ShowDialog(); 
            this.Close(); 
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            player2TextBox.Enabled = checkBoxPlayer2.Checked;

            if (checkBoxPlayer2.Checked)
            {
                player2TextBox.Text = string.Empty;
                player2TextBox.Focus();
            }
            else
            {
                player2TextBox.Text = "[Computer]";
            }
        }

        
    }
}
