namespace ItemRecursiveSortAssign1TLee
{
    partial class DisplayFileForm
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
            this.displayPanel = new System.Windows.Forms.Panel();
            this.outputLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.sortByGroupBox = new System.Windows.Forms.GroupBox();
            this.priceRadioButton = new System.Windows.Forms.RadioButton();
            this.nameRadioButton = new System.Windows.Forms.RadioButton();
            this.displayPanel.SuspendLayout();
            this.sortByGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayPanel
            // 
            this.displayPanel.AutoScroll = true;
            this.displayPanel.BackColor = System.Drawing.SystemColors.Window;
            this.displayPanel.Controls.Add(this.outputLabel);
            this.displayPanel.Location = new System.Drawing.Point(13, 163);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(324, 218);
            this.displayPanel.TabIndex = 0;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(12, 9);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(35, 13);
            this.outputLabel.TabIndex = 0;
            this.outputLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please select a file to display the sorted result...";
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(248, 22);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 2;
            this.openFileButton.Text = "Open";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(248, 52);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // sortByGroupBox
            // 
            this.sortByGroupBox.Controls.Add(this.priceRadioButton);
            this.sortByGroupBox.Controls.Add(this.nameRadioButton);
            this.sortByGroupBox.Location = new System.Drawing.Point(16, 52);
            this.sortByGroupBox.Name = "sortByGroupBox";
            this.sortByGroupBox.Size = new System.Drawing.Size(169, 52);
            this.sortByGroupBox.TabIndex = 4;
            this.sortByGroupBox.TabStop = false;
            this.sortByGroupBox.Text = "Sort by: ";
            // 
            // priceRadioButton
            // 
            this.priceRadioButton.AutoSize = true;
            this.priceRadioButton.Location = new System.Drawing.Point(83, 19);
            this.priceRadioButton.Name = "priceRadioButton";
            this.priceRadioButton.Size = new System.Drawing.Size(49, 17);
            this.priceRadioButton.TabIndex = 1;
            this.priceRadioButton.TabStop = true;
            this.priceRadioButton.Text = "Price";
            this.priceRadioButton.UseVisualStyleBackColor = true;
            this.priceRadioButton.CheckedChanged += new System.EventHandler(this.sortRadioButton_CheckedChanged);
            // 
            // nameRadioButton
            // 
            this.nameRadioButton.AutoSize = true;
            this.nameRadioButton.Location = new System.Drawing.Point(12, 19);
            this.nameRadioButton.Name = "nameRadioButton";
            this.nameRadioButton.Size = new System.Drawing.Size(53, 17);
            this.nameRadioButton.TabIndex = 0;
            this.nameRadioButton.TabStop = true;
            this.nameRadioButton.Text = "Name";
            this.nameRadioButton.UseVisualStyleBackColor = true;
            this.nameRadioButton.CheckedChanged += new System.EventHandler(this.sortRadioButton_CheckedChanged);
            // 
            // DisplayFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 393);
            this.Controls.Add(this.sortByGroupBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayPanel);
            this.Name = "DisplayFileForm";
            this.Text = "Display File          Timothy Lee";
            this.Load += new System.EventHandler(this.DisplayFileForm_Load);
            this.displayPanel.ResumeLayout(false);
            this.displayPanel.PerformLayout();
            this.sortByGroupBox.ResumeLayout(false);
            this.sortByGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel displayPanel;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox sortByGroupBox;
        private System.Windows.Forms.RadioButton priceRadioButton;
        private System.Windows.Forms.RadioButton nameRadioButton;
    }
}

