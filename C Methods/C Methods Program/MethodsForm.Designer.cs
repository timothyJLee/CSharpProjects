namespace C_Methods_Program
{
    partial class MethodsForm
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
            this.outputLabel = new System.Windows.Forms.Label();
            this.namedArgumentsButton = new System.Windows.Forms.Button();
            this.defaultArgumentsButton = new System.Windows.Forms.Button();
            this.voidButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.unitPricesTextBox = new System.Windows.Forms.TextBox();
            this.qtyTextBox = new System.Windows.Forms.TextBox();
            this.byValueButton = new System.Windows.Forms.Button();
            this.referenceButton = new System.Windows.Forms.Button();
            this.outButton = new System.Windows.Forms.Button();
            this.returnValueButton = new System.Windows.Forms.Button();
            this.booleanButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(133, 142);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(63, 13);
            this.outputLabel.TabIndex = 0;
            this.outputLabel.Text = "outputLabel";
            // 
            // namedArgumentsButton
            // 
            this.namedArgumentsButton.Location = new System.Drawing.Point(352, 65);
            this.namedArgumentsButton.Name = "namedArgumentsButton";
            this.namedArgumentsButton.Size = new System.Drawing.Size(173, 23);
            this.namedArgumentsButton.TabIndex = 5;
            this.namedArgumentsButton.Text = "Calculate with Names Arguments";
            this.namedArgumentsButton.UseVisualStyleBackColor = true;
            this.namedArgumentsButton.Click += new System.EventHandler(this.namedArgumentsButton_Click);
            // 
            // defaultArgumentsButton
            // 
            this.defaultArgumentsButton.Location = new System.Drawing.Point(352, 94);
            this.defaultArgumentsButton.Name = "defaultArgumentsButton";
            this.defaultArgumentsButton.Size = new System.Drawing.Size(173, 23);
            this.defaultArgumentsButton.TabIndex = 6;
            this.defaultArgumentsButton.Text = "Calculate with Default Arguments ";
            this.defaultArgumentsButton.UseVisualStyleBackColor = true;
            this.defaultArgumentsButton.Click += new System.EventHandler(this.defaultArgumentsButton_Click);
            // 
            // voidButton
            // 
            this.voidButton.Location = new System.Drawing.Point(352, 36);
            this.voidButton.Name = "voidButton";
            this.voidButton.Size = new System.Drawing.Size(173, 23);
            this.voidButton.TabIndex = 4;
            this.voidButton.Text = "Calculate with Void Method";
            this.voidButton.UseVisualStyleBackColor = true;
            this.voidButton.Click += new System.EventHandler(this.voidButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unit Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Qty:";
            // 
            // unitPricesTextBox
            // 
            this.unitPricesTextBox.Location = new System.Drawing.Point(187, 85);
            this.unitPricesTextBox.Name = "unitPricesTextBox";
            this.unitPricesTextBox.Size = new System.Drawing.Size(100, 20);
            this.unitPricesTextBox.TabIndex = 3;
            this.unitPricesTextBox.Text = "2.99";
            // 
            // qtyTextBox
            // 
            this.qtyTextBox.Location = new System.Drawing.Point(187, 59);
            this.qtyTextBox.Name = "qtyTextBox";
            this.qtyTextBox.Size = new System.Drawing.Size(100, 20);
            this.qtyTextBox.TabIndex = 1;
            this.qtyTextBox.Text = "10";
            // 
            // byValueButton
            // 
            this.byValueButton.Location = new System.Drawing.Point(352, 123);
            this.byValueButton.Name = "byValueButton";
            this.byValueButton.Size = new System.Drawing.Size(173, 23);
            this.byValueButton.TabIndex = 7;
            this.byValueButton.Text = "Calculate with ByValue ";
            this.byValueButton.UseVisualStyleBackColor = true;
            this.byValueButton.Click += new System.EventHandler(this.byValueButton_Click);
            // 
            // referenceButton
            // 
            this.referenceButton.Location = new System.Drawing.Point(352, 156);
            this.referenceButton.Name = "referenceButton";
            this.referenceButton.Size = new System.Drawing.Size(173, 23);
            this.referenceButton.TabIndex = 8;
            this.referenceButton.Text = "Calculate with Reference ";
            this.referenceButton.UseVisualStyleBackColor = true;
            this.referenceButton.Click += new System.EventHandler(this.referenceButton_Click);
            // 
            // outButton
            // 
            this.outButton.Location = new System.Drawing.Point(352, 185);
            this.outButton.Name = "outButton";
            this.outButton.Size = new System.Drawing.Size(173, 23);
            this.outButton.TabIndex = 9;
            this.outButton.Text = "Calculate with Out ";
            this.outButton.UseVisualStyleBackColor = true;
            this.outButton.Click += new System.EventHandler(this.outButton_Click);
            // 
            // returnValueButton
            // 
            this.returnValueButton.Location = new System.Drawing.Point(352, 214);
            this.returnValueButton.Name = "returnValueButton";
            this.returnValueButton.Size = new System.Drawing.Size(173, 23);
            this.returnValueButton.TabIndex = 10;
            this.returnValueButton.Text = "Calculate with Return Values ";
            this.returnValueButton.UseVisualStyleBackColor = true;
            this.returnValueButton.Click += new System.EventHandler(this.returnValueButton_Click);
            // 
            // booleanButton
            // 
            this.booleanButton.Location = new System.Drawing.Point(352, 243);
            this.booleanButton.Name = "booleanButton";
            this.booleanButton.Size = new System.Drawing.Size(173, 23);
            this.booleanButton.TabIndex = 11;
            this.booleanButton.Text = "Boolean Return Value";
            this.booleanButton.UseVisualStyleBackColor = true;
            this.booleanButton.Click += new System.EventHandler(this.booleanButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(567, 306);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 12;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MethodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(717, 425);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.booleanButton);
            this.Controls.Add(this.returnValueButton);
            this.Controls.Add(this.outButton);
            this.Controls.Add(this.referenceButton);
            this.Controls.Add(this.byValueButton);
            this.Controls.Add(this.qtyTextBox);
            this.Controls.Add(this.unitPricesTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.voidButton);
            this.Controls.Add(this.defaultArgumentsButton);
            this.Controls.Add(this.namedArgumentsButton);
            this.Controls.Add(this.outputLabel);
            this.Name = "MethodsForm";
            this.Text = "C#  Methods Usage Program";
            this.Load += new System.EventHandler(this.MehtodsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button namedArgumentsButton;
        private System.Windows.Forms.Button defaultArgumentsButton;
        private System.Windows.Forms.Button voidButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox unitPricesTextBox;
        private System.Windows.Forms.TextBox qtyTextBox;
        private System.Windows.Forms.Button byValueButton;
        private System.Windows.Forms.Button referenceButton;
        private System.Windows.Forms.Button outButton;
        private System.Windows.Forms.Button returnValueButton;
        private System.Windows.Forms.Button booleanButton;
        private System.Windows.Forms.Button exitButton;
    }
}

