namespace Ex05_01
{
    partial class GameSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Palyer1Label = new System.Windows.Forms.Label();
            this.Player2Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PlayersTitle = new System.Windows.Forms.Label();
            this.player1TextBox = new System.Windows.Forms.TextBox();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            this.player2TextBox = new System.Windows.Forms.TextBox();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.rowLabel = new System.Windows.Forms.Label();
            this.colLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // Palyer1Label
            // 
            this.Palyer1Label.AutoSize = true;
            this.Palyer1Label.Location = new System.Drawing.Point(56, 49);
            this.Palyer1Label.Name = "Palyer1Label";
            this.Palyer1Label.Size = new System.Drawing.Size(75, 20);
            this.Palyer1Label.TabIndex = 0;
            this.Palyer1Label.Text = "Player 1:";
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Location = new System.Drawing.Point(89, 93);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(75, 20);
            this.Player2Label.TabIndex = 1;
            this.Player2Label.Text = "Player 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Board Size:";
            // 
            // PlayersTitle
            // 
            this.PlayersTitle.AutoSize = true;
            this.PlayersTitle.Location = new System.Drawing.Point(30, 11);
            this.PlayersTitle.Name = "PlayersTitle";
            this.PlayersTitle.Size = new System.Drawing.Size(70, 20);
            this.PlayersTitle.TabIndex = 3;
            this.PlayersTitle.Text = "Players:";
            // 
            // player1TextBox
            // 
            this.player1TextBox.Location = new System.Drawing.Point(170, 49);
            this.player1TextBox.Name = "player1TextBox";
            this.player1TextBox.Size = new System.Drawing.Size(153, 27);
            this.player1TextBox.TabIndex = 4;
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBoxPlayer2.Location = new System.Drawing.Point(59, 92);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(18, 17);
            this.checkBoxPlayer2.TabIndex = 8;
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(118, 221);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(52, 27);
            this.numericUpDownRows.TabIndex = 9;
            this.numericUpDownRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownRows.ValueChanged += new System.EventHandler(this.numericUpDownRows_ValueChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(92, 279);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(220, 49);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Play";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // player2TextBox
            // 
            this.player2TextBox.Enabled = false;
            this.player2TextBox.Location = new System.Drawing.Point(170, 93);
            this.player2TextBox.Name = "player2TextBox";
            this.player2TextBox.Size = new System.Drawing.Size(153, 27);
            this.player2TextBox.TabIndex = 12;
            this.player2TextBox.Text = "[Computer]";
            // 
            // numericUpDownCols
            // 
            this.numericUpDownCols.Location = new System.Drawing.Point(271, 221);
            this.numericUpDownCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(52, 27);
            this.numericUpDownCols.TabIndex = 13;
            this.numericUpDownCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownCols.ValueChanged += new System.EventHandler(this.numericUpDownCols_ValueChanged);
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Location = new System.Drawing.Point(56, 221);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(56, 20);
            this.rowLabel.TabIndex = 14;
            this.rowLabel.Text = "Rows:";
            // 
            // colLabel
            // 
            this.colLabel.AutoSize = true;
            this.colLabel.Location = new System.Drawing.Point(203, 223);
            this.colLabel.Name = "colLabel";
            this.colLabel.Size = new System.Drawing.Size(48, 20);
            this.colLabel.TabIndex = 15;
            this.colLabel.Text = "Cols:";
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 358);
            this.Controls.Add(this.colLabel);
            this.Controls.Add(this.rowLabel);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.player2TextBox);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.player1TextBox);
            this.Controls.Add(this.PlayersTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Palyer1Label);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameSettingsForm";
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Palyer1Label;
        private System.Windows.Forms.Label Player2Label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PlayersTitle;
        private System.Windows.Forms.TextBox player1TextBox;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox player2TextBox;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.Label colLabel;
    }
}