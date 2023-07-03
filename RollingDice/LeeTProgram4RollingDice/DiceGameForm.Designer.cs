namespace LeeTProgram4RollingDice
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
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.player1NameTextBox = new System.Windows.Forms.TextBox();
            this.player2NameTextBox = new System.Windows.Forms.TextBox();
            this.accumulatedGamePointsLabel = new System.Windows.Forms.Label();
            this.gameDisplayListBox = new System.Windows.Forms.ListBox();
            this.die1DisplayLabel = new System.Windows.Forms.Label();
            this.die2DisplayLabel = new System.Windows.Forms.Label();
            this.rollDiceButton = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            this.holdButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.numberOfDiceGroupBox = new System.Windows.Forms.GroupBox();
            this.twoDiceRadioButton = new System.Windows.Forms.RadioButton();
            this.oneDieRadioButton = new System.Windows.Forms.RadioButton();
            this.testButton = new System.Windows.Forms.Button();
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.gameLogsButton = new System.Windows.Forms.Button();
            this.numberOfDiceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Location = new System.Drawing.Point(55, 53);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(66, 13);
            this.playerNameLabel.TabIndex = 1;
            this.playerNameLabel.Text = "Enter Name:";
            // 
            // player1NameTextBox
            // 
            this.player1NameTextBox.Location = new System.Drawing.Point(183, 50);
            this.player1NameTextBox.Name = "player1NameTextBox";
            this.player1NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.player1NameTextBox.TabIndex = 3;
            // 
            // player2NameTextBox
            // 
            this.player2NameTextBox.Location = new System.Drawing.Point(183, 73);
            this.player2NameTextBox.Name = "player2NameTextBox";
            this.player2NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.player2NameTextBox.TabIndex = 6;
            // 
            // accumulatedGamePointsLabel
            // 
            this.accumulatedGamePointsLabel.AutoSize = true;
            this.accumulatedGamePointsLabel.Location = new System.Drawing.Point(55, 80);
            this.accumulatedGamePointsLabel.Name = "accumulatedGamePointsLabel";
            this.accumulatedGamePointsLabel.Size = new System.Drawing.Size(41, 13);
            this.accumulatedGamePointsLabel.TabIndex = 4;
            this.accumulatedGamePointsLabel.Text = "Score: ";
            // 
            // gameDisplayListBox
            // 
            this.gameDisplayListBox.FormattingEnabled = true;
            this.gameDisplayListBox.Location = new System.Drawing.Point(38, 114);
            this.gameDisplayListBox.Name = "gameDisplayListBox";
            this.gameDisplayListBox.Size = new System.Drawing.Size(265, 277);
            this.gameDisplayListBox.TabIndex = 7;
            // 
            // die1DisplayLabel
            // 
            this.die1DisplayLabel.AutoSize = true;
            this.die1DisplayLabel.Location = new System.Drawing.Point(102, 394);
            this.die1DisplayLabel.Name = "die1DisplayLabel";
            this.die1DisplayLabel.Size = new System.Drawing.Size(35, 13);
            this.die1DisplayLabel.TabIndex = 8;
            this.die1DisplayLabel.Text = "label1";
            // 
            // die2DisplayLabel
            // 
            this.die2DisplayLabel.AutoSize = true;
            this.die2DisplayLabel.Location = new System.Drawing.Point(183, 394);
            this.die2DisplayLabel.Name = "die2DisplayLabel";
            this.die2DisplayLabel.Size = new System.Drawing.Size(35, 13);
            this.die2DisplayLabel.TabIndex = 9;
            this.die2DisplayLabel.Text = "label1";
            // 
            // rollDiceButton
            // 
            this.rollDiceButton.Location = new System.Drawing.Point(21, 463);
            this.rollDiceButton.Name = "rollDiceButton";
            this.rollDiceButton.Size = new System.Drawing.Size(75, 23);
            this.rollDiceButton.TabIndex = 10;
            this.rollDiceButton.Text = "&Roll Dice";
            this.rollDiceButton.UseVisualStyleBackColor = true;
            this.rollDiceButton.Click += new System.EventHandler(this.rollDiceButton_Click);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(120, 463);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(75, 23);
            this.newGameButton.TabIndex = 12;
            this.newGameButton.Text = "&New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // holdButton
            // 
            this.holdButton.Location = new System.Drawing.Point(21, 492);
            this.holdButton.Name = "holdButton";
            this.holdButton.Size = new System.Drawing.Size(75, 23);
            this.holdButton.TabIndex = 11;
            this.holdButton.Text = "&Hold";
            this.holdButton.UseVisualStyleBackColor = true;
            this.holdButton.Click += new System.EventHandler(this.holdButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(120, 492);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // numberOfDiceGroupBox
            // 
            this.numberOfDiceGroupBox.Controls.Add(this.twoDiceRadioButton);
            this.numberOfDiceGroupBox.Controls.Add(this.oneDieRadioButton);
            this.numberOfDiceGroupBox.Location = new System.Drawing.Point(71, 4);
            this.numberOfDiceGroupBox.Name = "numberOfDiceGroupBox";
            this.numberOfDiceGroupBox.Size = new System.Drawing.Size(199, 37);
            this.numberOfDiceGroupBox.TabIndex = 0;
            this.numberOfDiceGroupBox.TabStop = false;
            this.numberOfDiceGroupBox.Text = "One or Two Dice:";
            // 
            // twoDiceRadioButton
            // 
            this.twoDiceRadioButton.AutoSize = true;
            this.twoDiceRadioButton.Location = new System.Drawing.Point(113, 14);
            this.twoDiceRadioButton.Name = "twoDiceRadioButton";
            this.twoDiceRadioButton.Size = new System.Drawing.Size(42, 17);
            this.twoDiceRadioButton.TabIndex = 1;
            this.twoDiceRadioButton.TabStop = true;
            this.twoDiceRadioButton.Text = "&two";
            this.twoDiceRadioButton.UseVisualStyleBackColor = true;
            // 
            // oneDieRadioButton
            // 
            this.oneDieRadioButton.AutoSize = true;
            this.oneDieRadioButton.Location = new System.Drawing.Point(23, 14);
            this.oneDieRadioButton.Name = "oneDieRadioButton";
            this.oneDieRadioButton.Size = new System.Drawing.Size(43, 17);
            this.oneDieRadioButton.TabIndex = 0;
            this.oneDieRadioButton.TabStop = true;
            this.oneDieRadioButton.Text = "&one";
            this.oneDieRadioButton.UseVisualStyleBackColor = true;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(230, 463);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(73, 23);
            this.testButton.TabIndex = 14;
            this.testButton.Text = "T&EST";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Location = new System.Drawing.Point(140, 57);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(45, 13);
            this.player1Label.TabIndex = 2;
            this.player1Label.Text = "Player&1:";
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Location = new System.Drawing.Point(140, 80);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(45, 13);
            this.player2Label.TabIndex = 5;
            this.player2Label.Text = "Player&2:";
            // 
            // gameLogsButton
            // 
            this.gameLogsButton.Location = new System.Drawing.Point(228, 493);
            this.gameLogsButton.Name = "gameLogsButton";
            this.gameLogsButton.Size = new System.Drawing.Size(75, 23);
            this.gameLogsButton.TabIndex = 15;
            this.gameLogsButton.Text = "&Game Logs";
            this.gameLogsButton.UseVisualStyleBackColor = true;
            this.gameLogsButton.Click += new System.EventHandler(this.gameLogsButton_Click);
            // 
            // DiceGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 528);
            this.Controls.Add(this.gameLogsButton);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.numberOfDiceGroupBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.holdButton);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.rollDiceButton);
            this.Controls.Add(this.die2DisplayLabel);
            this.Controls.Add(this.die1DisplayLabel);
            this.Controls.Add(this.gameDisplayListBox);
            this.Controls.Add(this.accumulatedGamePointsLabel);
            this.Controls.Add(this.player2NameTextBox);
            this.Controls.Add(this.player1NameTextBox);
            this.Controls.Add(this.playerNameLabel);
            this.Name = "DiceGameForm";
            this.Text = "Tim\'s Street Gambling     LeeTProgram4RollingDice";
            this.Load += new System.EventHandler(this.DiceGameForm_Load);
            this.numberOfDiceGroupBox.ResumeLayout(false);
            this.numberOfDiceGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.TextBox player1NameTextBox;
        private System.Windows.Forms.TextBox player2NameTextBox;
        private System.Windows.Forms.Label accumulatedGamePointsLabel;
        private System.Windows.Forms.ListBox gameDisplayListBox;
        private System.Windows.Forms.Label die1DisplayLabel;
        private System.Windows.Forms.Label die2DisplayLabel;
        private System.Windows.Forms.Button rollDiceButton;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button holdButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.GroupBox numberOfDiceGroupBox;
        private System.Windows.Forms.RadioButton twoDiceRadioButton;
        private System.Windows.Forms.RadioButton oneDieRadioButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.Button gameLogsButton;
    }
}

