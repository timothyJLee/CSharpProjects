﻿namespace LeeTProgram6CandySales
{
    partial class ManagementTotalsForm
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
            this.totalsOutputLabel = new System.Windows.Forms.Label();
            this.clearTotalsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // totalsOutputLabel
            // 
            this.totalsOutputLabel.AutoSize = true;
            this.totalsOutputLabel.Location = new System.Drawing.Point(13, 13);
            this.totalsOutputLabel.Name = "totalsOutputLabel";
            this.totalsOutputLabel.Size = new System.Drawing.Size(35, 13);
            this.totalsOutputLabel.TabIndex = 0;
            this.totalsOutputLabel.Text = "label1";
            // 
            // clearTotalsButton
            // 
            this.clearTotalsButton.Location = new System.Drawing.Point(197, 227);
            this.clearTotalsButton.Name = "clearTotalsButton";
            this.clearTotalsButton.Size = new System.Drawing.Size(75, 23);
            this.clearTotalsButton.TabIndex = 1;
            this.clearTotalsButton.Text = "Clear Totals";
            this.clearTotalsButton.UseVisualStyleBackColor = true;
            this.clearTotalsButton.Click += new System.EventHandler(this.clearTotalsButton_Click);
            // 
            // ManagementTotalsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.clearTotalsButton);
            this.Controls.Add(this.totalsOutputLabel);
            this.Name = "ManagementTotalsForm";
            this.Text = "ManagementTotalsForm";
            this.Load += new System.EventHandler(this.ManagementTotalsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label totalsOutputLabel;
        private System.Windows.Forms.Button clearTotalsButton;
    }
}