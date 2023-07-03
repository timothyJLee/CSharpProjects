namespace C_Ch910_Inclass_Payroll_Program
{
    partial class PayrollClassesForm
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
            this.totalsLabel = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rateTextBox = new System.Windows.Forms.TextBox();
            this.hoursTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.clearTotalsButton = new System.Windows.Forms.Button();
            this.totalsButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.hazardPayCheckBox = new System.Windows.Forms.CheckBox();
            this.getDataButton = new System.Windows.Forms.Button();
            this.outputDataButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // totalsLabel
            // 
            this.totalsLabel.AutoSize = true;
            this.totalsLabel.Location = new System.Drawing.Point(103, 190);
            this.totalsLabel.Name = "totalsLabel";
            this.totalsLabel.Size = new System.Drawing.Size(58, 13);
            this.totalsLabel.TabIndex = 11;
            this.totalsLabel.Text = "totalsLabel";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(763, 101);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(63, 13);
            this.outputLabel.TabIndex = 12;
            this.outputLabel.Text = "outputLabel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(575, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter Rate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(575, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Enter Hours:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(575, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Enter Name:";
            // 
            // rateTextBox
            // 
            this.rateTextBox.Location = new System.Drawing.Point(657, 110);
            this.rateTextBox.Name = "rateTextBox";
            this.rateTextBox.Size = new System.Drawing.Size(55, 20);
            this.rateTextBox.TabIndex = 5;
            // 
            // hoursTextBox
            // 
            this.hoursTextBox.Location = new System.Drawing.Point(657, 84);
            this.hoursTextBox.Name = "hoursTextBox";
            this.hoursTextBox.Size = new System.Drawing.Size(55, 20);
            this.hoursTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(647, 58);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(347, 307);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // clearTotalsButton
            // 
            this.clearTotalsButton.Location = new System.Drawing.Point(347, 276);
            this.clearTotalsButton.Name = "clearTotalsButton";
            this.clearTotalsButton.Size = new System.Drawing.Size(75, 23);
            this.clearTotalsButton.TabIndex = 9;
            this.clearTotalsButton.Text = "C&lear Totals";
            this.clearTotalsButton.UseVisualStyleBackColor = true;
            this.clearTotalsButton.Click += new System.EventHandler(this.clearTotalsButton_Click);
            // 
            // totalsButton
            // 
            this.totalsButton.Location = new System.Drawing.Point(347, 245);
            this.totalsButton.Name = "totalsButton";
            this.totalsButton.Size = new System.Drawing.Size(75, 23);
            this.totalsButton.TabIndex = 8;
            this.totalsButton.Text = "T&otals";
            this.totalsButton.UseVisualStyleBackColor = true;
            this.totalsButton.Click += new System.EventHandler(this.totalsButton_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(347, 214);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 7;
            this.calculateButton.Text = "C&alculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(766, 56);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 6;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // hazardPayCheckBox
            // 
            this.hazardPayCheckBox.AutoSize = true;
            this.hazardPayCheckBox.Location = new System.Drawing.Point(44, 146);
            this.hazardPayCheckBox.Name = "hazardPayCheckBox";
            this.hazardPayCheckBox.Size = new System.Drawing.Size(122, 17);
            this.hazardPayCheckBox.TabIndex = 13;
            this.hazardPayCheckBox.Text = "Click for Hazard Pay";
            this.hazardPayCheckBox.UseVisualStyleBackColor = true;
            // 
            // getDataButton
            // 
            this.getDataButton.Location = new System.Drawing.Point(86, 40);
            this.getDataButton.Name = "getDataButton";
            this.getDataButton.Size = new System.Drawing.Size(75, 79);
            this.getDataButton.TabIndex = 14;
            this.getDataButton.Text = "GET DATA (INPUT!)";
            this.getDataButton.UseVisualStyleBackColor = true;
            this.getDataButton.Click += new System.EventHandler(this.getDataButton_Click);
            // 
            // outputDataButton
            // 
            this.outputDataButton.Location = new System.Drawing.Point(187, 40);
            this.outputDataButton.Name = "outputDataButton";
            this.outputDataButton.Size = new System.Drawing.Size(75, 79);
            this.outputDataButton.TabIndex = 15;
            this.outputDataButton.Text = "Output Data";
            this.outputDataButton.UseVisualStyleBackColor = true;
            this.outputDataButton.Click += new System.EventHandler(this.outputDataButton_Click);
            // 
            // PayrollClassesForm
            // 
            this.AcceptButton = this.calculateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(813, 388);
            this.Controls.Add(this.outputDataButton);
            this.Controls.Add(this.getDataButton);
            this.Controls.Add(this.hazardPayCheckBox);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.totalsButton);
            this.Controls.Add(this.clearTotalsButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.hoursTextBox);
            this.Controls.Add(this.rateTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.totalsLabel);
            this.Name = "PayrollClassesForm";
            this.Text = "Chpt 9 & 10 Classes Inheritence Payroll Program";
            this.Load += new System.EventHandler(this.PayrollClassesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label totalsLabel;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rateTextBox;
        private System.Windows.Forms.TextBox hoursTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button clearTotalsButton;
        private System.Windows.Forms.Button totalsButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.CheckBox hazardPayCheckBox;
        private System.Windows.Forms.Button getDataButton;
        private System.Windows.Forms.Button outputDataButton;
    }
}

