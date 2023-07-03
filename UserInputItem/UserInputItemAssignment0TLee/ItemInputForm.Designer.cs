namespace UserInputItemAssignment0TLee
{
    partial class ItemInputForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.outputLabel = new System.Windows.Forms.Label();
            this.totalButton = new System.Windows.Forms.Button();
            this.userTotalButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.newUserButton = new System.Windows.Forms.Button();
            this.nameTextBoxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.quantityTextBoxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.priceTextBoxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.testButton = new System.Windows.Forms.Button();
            this.printArrayButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextBoxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityTextBoxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTextBoxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantity: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Please Enter Item Information Below...";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(103, 49);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 4;
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(103, 72);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(24, 20);
            this.quantityTextBox.TabIndex = 5;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(103, 93);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(51, 20);
            this.priceTextBox.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.outputLabel);
            this.panel1.Location = new System.Drawing.Point(24, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 276);
            this.panel1.TabIndex = 7;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(3, 11);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(35, 13);
            this.outputLabel.TabIndex = 0;
            this.outputLabel.Text = "label5";
            // 
            // totalButton
            // 
            this.totalButton.Location = new System.Drawing.Point(236, 39);
            this.totalButton.Name = "totalButton";
            this.totalButton.Size = new System.Drawing.Size(75, 23);
            this.totalButton.TabIndex = 8;
            this.totalButton.Text = "Item Total";
            this.totalButton.UseVisualStyleBackColor = true;
            this.totalButton.Click += new System.EventHandler(this.totalButton_Click);
            // 
            // userTotalButton
            // 
            this.userTotalButton.Location = new System.Drawing.Point(236, 64);
            this.userTotalButton.Name = "userTotalButton";
            this.userTotalButton.Size = new System.Drawing.Size(75, 23);
            this.userTotalButton.TabIndex = 9;
            this.userTotalButton.Text = "User Total";
            this.userTotalButton.UseVisualStyleBackColor = true;
            this.userTotalButton.Click += new System.EventHandler(this.userTotalButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(236, 119);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "MAX ITEMS: 10";
            // 
            // newUserButton
            // 
            this.newUserButton.Location = new System.Drawing.Point(236, 90);
            this.newUserButton.Name = "newUserButton";
            this.newUserButton.Size = new System.Drawing.Size(75, 23);
            this.newUserButton.TabIndex = 12;
            this.newUserButton.Text = "New User";
            this.newUserButton.UseVisualStyleBackColor = true;
            this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
            // 
            // nameTextBoxErrorProvider
            // 
            this.nameTextBoxErrorProvider.ContainerControl = this;
            // 
            // quantityTextBoxErrorProvider
            // 
            this.quantityTextBoxErrorProvider.ContainerControl = this;
            // 
            // priceTextBoxErrorProvider
            // 
            this.priceTextBoxErrorProvider.ContainerControl = this;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(249, 10);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(49, 23);
            this.testButton.TabIndex = 13;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // printArrayButton
            // 
            this.printArrayButton.Location = new System.Drawing.Point(223, 436);
            this.printArrayButton.Name = "printArrayButton";
            this.printArrayButton.Size = new System.Drawing.Size(97, 23);
            this.printArrayButton.TabIndex = 14;
            this.printArrayButton.Text = "Print Item Name\'s";
            this.printArrayButton.UseVisualStyleBackColor = true;
            this.printArrayButton.Click += new System.EventHandler(this.printArrayButton_Click);
            // 
            // ItemInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 464);
            this.Controls.Add(this.printArrayButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.newUserButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.userTotalButton);
            this.Controls.Add(this.totalButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ItemInputForm";
            this.Text = "Item Input           Timothy Lee";
            this.Load += new System.EventHandler(this.ItemInputForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextBoxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityTextBoxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTextBoxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button totalButton;
        private System.Windows.Forms.Button userTotalButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button newUserButton;
        private System.Windows.Forms.ErrorProvider nameTextBoxErrorProvider;
        private System.Windows.Forms.ErrorProvider quantityTextBoxErrorProvider;
        private System.Windows.Forms.ErrorProvider priceTextBoxErrorProvider;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button printArrayButton;
    }
}

