namespace LeeTProgram5RollingDice2
{
    partial class DiceGameForm
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
            this.twoDiceCheckBox = new System.Windows.Forms.CheckBox();
            this.enterNameLabel = new System.Windows.Forms.Label();
            this.Player1NameTextBox = new System.Windows.Forms.TextBox();
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.Player2NameTextBox = new System.Windows.Forms.TextBox();
            this.player1ScoreLabel = new System.Windows.Forms.Label();
            this.player2ScoreLabel = new System.Windows.Forms.Label();
            this.GameHistoryListBox = new System.Windows.Forms.ListBox();
            this.CurrentGameListBox = new System.Windows.Forms.ListBox();
            this.Die1Label = new System.Windows.Forms.Label();
            this.Die2Label = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.saveGameLogButton = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            this.switchPlayerButton = new System.Windows.Forms.Button();
            this.Player1Button = new System.Windows.Forms.Button();
            this.Player2Button = new System.Windows.Forms.Button();
            this.pointsToWinTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // twoDiceCheckBox
            // 
            this.twoDiceCheckBox.AutoSize = true;
            this.twoDiceCheckBox.Location = new System.Drawing.Point(60, 25);
            this.twoDiceCheckBox.Name = "twoDiceCheckBox";
            this.twoDiceCheckBox.Size = new System.Drawing.Size(159, 17);
            this.twoDiceCheckBox.TabIndex = 0;
            this.twoDiceCheckBox.Text = "Check to play with two dice.";
            this.twoDiceCheckBox.UseVisualStyleBackColor = true;
            // 
            // enterNameLabel
            // 
            this.enterNameLabel.AutoSize = true;
            this.enterNameLabel.Location = new System.Drawing.Point(60, 70);
            this.enterNameLabel.Name = "enterNameLabel";
            this.enterNameLabel.Size = new System.Drawing.Size(66, 13);
            this.enterNameLabel.TabIndex = 2;
            this.enterNameLabel.Text = "Enter Name:";
            // 
            // Player1NameTextBox
            // 
            this.Player1NameTextBox.Location = new System.Drawing.Point(200, 67);
            this.Player1NameTextBox.Name = "Player1NameTextBox";
            this.Player1NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.Player1NameTextBox.TabIndex = 3;
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Location = new System.Drawing.Point(140, 70);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(48, 13);
            this.player1Label.TabIndex = 5;
            this.player1Label.Text = "Player1: ";
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Location = new System.Drawing.Point(140, 98);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(45, 13);
            this.player2Label.TabIndex = 7;
            this.player2Label.Text = "Player2:";
            // 
            // Player2NameTextBox
            // 
            this.Player2NameTextBox.Location = new System.Drawing.Point(200, 95);
            this.Player2NameTextBox.Name = "Player2NameTextBox";
            this.Player2NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.Player2NameTextBox.TabIndex = 6;
            // 
            // player1ScoreLabel
            // 
            this.player1ScoreLabel.AutoSize = true;
            this.player1ScoreLabel.Location = new System.Drawing.Point(316, 67);
            this.player1ScoreLabel.Name = "player1ScoreLabel";
            this.player1ScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.player1ScoreLabel.TabIndex = 8;
            this.player1ScoreLabel.Text = "Score";
            // 
            // player2ScoreLabel
            // 
            this.player2ScoreLabel.AutoSize = true;
            this.player2ScoreLabel.Location = new System.Drawing.Point(316, 95);
            this.player2ScoreLabel.Name = "player2ScoreLabel";
            this.player2ScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.player2ScoreLabel.TabIndex = 9;
            this.player2ScoreLabel.Text = "Score";
            // 
            // GameHistoryListBox
            // 
            this.GameHistoryListBox.FormattingEnabled = true;
            this.GameHistoryListBox.Location = new System.Drawing.Point(40, 127);
            this.GameHistoryListBox.Name = "GameHistoryListBox";
            this.GameHistoryListBox.Size = new System.Drawing.Size(112, 290);
            this.GameHistoryListBox.TabIndex = 10;
            // 
            // CurrentGameListBox
            // 
            this.CurrentGameListBox.FormattingEnabled = true;
            this.CurrentGameListBox.Location = new System.Drawing.Point(173, 127);
            this.CurrentGameListBox.Name = "CurrentGameListBox";
            this.CurrentGameListBox.Size = new System.Drawing.Size(151, 290);
            this.CurrentGameListBox.TabIndex = 11;
            // 
            // Die1Label
            // 
            this.Die1Label.AutoSize = true;
            this.Die1Label.Location = new System.Drawing.Point(141, 454);
            this.Die1Label.Name = "Die1Label";
            this.Die1Label.Size = new System.Drawing.Size(35, 13);
            this.Die1Label.TabIndex = 12;
            this.Die1Label.Text = "label7";
            // 
            // Die2Label
            // 
            this.Die2Label.AutoSize = true;
            this.Die2Label.Location = new System.Drawing.Point(228, 454);
            this.Die2Label.Name = "Die2Label";
            this.Die2Label.Size = new System.Drawing.Size(35, 13);
            this.Die2Label.TabIndex = 13;
            this.Die2Label.Text = "label8";
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(330, 169);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 14;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(330, 332);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 15;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // saveGameLogButton
            // 
            this.saveGameLogButton.Location = new System.Drawing.Point(330, 289);
            this.saveGameLogButton.Name = "saveGameLogButton";
            this.saveGameLogButton.Size = new System.Drawing.Size(75, 23);
            this.saveGameLogButton.TabIndex = 16;
            this.saveGameLogButton.Text = "SaveAll";
            this.saveGameLogButton.UseVisualStyleBackColor = true;
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(330, 249);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(75, 23);
            this.newGameButton.TabIndex = 17;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            // 
            // switchPlayerButton
            // 
            this.switchPlayerButton.Location = new System.Drawing.Point(330, 209);
            this.switchPlayerButton.Name = "switchPlayerButton";
            this.switchPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.switchPlayerButton.TabIndex = 18;
            this.switchPlayerButton.Text = "Switch";
            this.switchPlayerButton.UseVisualStyleBackColor = true;
            // 
            // Player1Button
            // 
            this.Player1Button.Location = new System.Drawing.Point(28, 429);
            this.Player1Button.Name = "Player1Button";
            this.Player1Button.Size = new System.Drawing.Size(86, 23);
            this.Player1Button.TabIndex = 19;
            this.Player1Button.Text = "Make Player 1";
            this.Player1Button.UseVisualStyleBackColor = true;
            // 
            // Player2Button
            // 
            this.Player2Button.Location = new System.Drawing.Point(28, 459);
            this.Player2Button.Name = "Player2Button";
            this.Player2Button.Size = new System.Drawing.Size(86, 23);
            this.Player2Button.TabIndex = 20;
            this.Player2Button.Text = "Make Player 2";
            this.Player2Button.UseVisualStyleBackColor = true;
            // 
            // pointsToWinTextBox
            // 
            this.pointsToWinTextBox.Location = new System.Drawing.Point(354, 454);
            this.pointsToWinTextBox.Name = "pointsToWinTextBox";
            this.pointsToWinTextBox.Size = new System.Drawing.Size(59, 20);
            this.pointsToWinTextBox.TabIndex = 21;
            this.pointsToWinTextBox.Text = "50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Enter amount of points to win.";
            // 
            // DiceGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 529);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pointsToWinTextBox);
            this.Controls.Add(this.Player2Button);
            this.Controls.Add(this.Player1Button);
            this.Controls.Add(this.switchPlayerButton);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.saveGameLogButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.Die2Label);
            this.Controls.Add(this.Die1Label);
            this.Controls.Add(this.CurrentGameListBox);
            this.Controls.Add(this.GameHistoryListBox);
            this.Controls.Add(this.player2ScoreLabel);
            this.Controls.Add(this.player1ScoreLabel);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.Player2NameTextBox);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.Player1NameTextBox);
            this.Controls.Add(this.enterNameLabel);
            this.Controls.Add(this.twoDiceCheckBox);
            this.Name = "DiceGameForm";
            this.Text = "Tim\'s Street Gambling     LeeTProgram5RollingDice2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox twoDiceCheckBox;
        private System.Windows.Forms.Label enterNameLabel;
        private System.Windows.Forms.TextBox Player1NameTextBox;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.TextBox Player2NameTextBox;
        private System.Windows.Forms.Label player1ScoreLabel;
        private System.Windows.Forms.Label player2ScoreLabel;
        private System.Windows.Forms.ListBox GameHistoryListBox;
        private System.Windows.Forms.ListBox CurrentGameListBox;
        private System.Windows.Forms.Label Die1Label;
        private System.Windows.Forms.Label Die2Label;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button saveGameLogButton;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button switchPlayerButton;
        private System.Windows.Forms.Button Player1Button;
        private System.Windows.Forms.Button Player2Button;
        private System.Windows.Forms.TextBox pointsToWinTextBox;
        private System.Windows.Forms.Label label1;
    }
}

