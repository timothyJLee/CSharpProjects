namespace LeeTProgram2WaterPark
{
    partial class CustomerOrderForm
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
            this.receiptPanel = new System.Windows.Forms.Panel();
            this.receiptLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eventGroupBox = new System.Windows.Forms.GroupBox();
            this.goldenWaterfallCheckBox = new System.Windows.Forms.CheckBox();
            this.californiaCarWashCheckBox = new System.Windows.Forms.CheckBox();
            this.crustyCanyonCheckBox = new System.Windows.Forms.CheckBox();
            this.redBarronCheckBox = new System.Windows.Forms.CheckBox();
            this.snowconeVolcanoCheckBox = new System.Windows.Forms.CheckBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.numberInGroupTextBox = new System.Windows.Forms.TextBox();
            this.enterTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.discountGroupBox = new System.Windows.Forms.GroupBox();
            this.twentyPercentRadioButton = new System.Windows.Forms.RadioButton();
            this.tenPercentRadioButton = new System.Windows.Forms.RadioButton();
            this.fivePercentRadioButton = new System.Windows.Forms.RadioButton();
            this.noneRadioButton = new System.Windows.Forms.RadioButton();
            this.managementTotalButton = new System.Windows.Forms.Button();
            this.totalbutton = new System.Windows.Forms.Button();
            this.newCustomerButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.customerTotalButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.receiptPanel.SuspendLayout();
            this.eventGroupBox.SuspendLayout();
            this.discountGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // receiptPanel
            // 
            this.receiptPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.receiptPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.receiptPanel.Controls.Add(this.receiptLabel);
            this.receiptPanel.Location = new System.Drawing.Point(270, 24);
            this.receiptPanel.Name = "receiptPanel";
            this.receiptPanel.Size = new System.Drawing.Size(238, 356);
            this.receiptPanel.TabIndex = 9;
            // 
            // receiptLabel
            // 
            this.receiptLabel.AutoSize = true;
            this.receiptLabel.Location = new System.Drawing.Point(13, 15);
            this.receiptLabel.Name = "receiptLabel";
            this.receiptLabel.Size = new System.Drawing.Size(0, 13);
            this.receiptLabel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "N&o. In Group:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter Minutes &Parked:";
            // 
            // eventGroupBox
            // 
            this.eventGroupBox.Controls.Add(this.goldenWaterfallCheckBox);
            this.eventGroupBox.Controls.Add(this.californiaCarWashCheckBox);
            this.eventGroupBox.Controls.Add(this.crustyCanyonCheckBox);
            this.eventGroupBox.Controls.Add(this.redBarronCheckBox);
            this.eventGroupBox.Controls.Add(this.snowconeVolcanoCheckBox);
            this.eventGroupBox.Location = new System.Drawing.Point(15, 239);
            this.eventGroupBox.Name = "eventGroupBox";
            this.eventGroupBox.Size = new System.Drawing.Size(226, 154);
            this.eventGroupBox.TabIndex = 7;
            this.eventGroupBox.TabStop = false;
            this.eventGroupBox.Text = "C&heck events for group.  One event for free.";
            // 
            // goldenWaterfallCheckBox
            // 
            this.goldenWaterfallCheckBox.AutoSize = true;
            this.goldenWaterfallCheckBox.Location = new System.Drawing.Point(17, 126);
            this.goldenWaterfallCheckBox.Name = "goldenWaterfallCheckBox";
            this.goldenWaterfallCheckBox.Size = new System.Drawing.Size(105, 17);
            this.goldenWaterfallCheckBox.TabIndex = 4;
            this.goldenWaterfallCheckBox.Text = "Golden &Waterfall";
            this.goldenWaterfallCheckBox.UseVisualStyleBackColor = true;
            // 
            // californiaCarWashCheckBox
            // 
            this.californiaCarWashCheckBox.AutoSize = true;
            this.californiaCarWashCheckBox.Location = new System.Drawing.Point(17, 103);
            this.californiaCarWashCheckBox.Name = "californiaCarWashCheckBox";
            this.californiaCarWashCheckBox.Size = new System.Drawing.Size(119, 17);
            this.californiaCarWashCheckBox.TabIndex = 3;
            this.californiaCarWashCheckBox.Text = "Cali&fornia Car Wash";
            this.californiaCarWashCheckBox.UseVisualStyleBackColor = true;
            // 
            // crustyCanyonCheckBox
            // 
            this.crustyCanyonCheckBox.AutoSize = true;
            this.crustyCanyonCheckBox.Location = new System.Drawing.Point(17, 80);
            this.crustyCanyonCheckBox.Name = "crustyCanyonCheckBox";
            this.crustyCanyonCheckBox.Size = new System.Drawing.Size(94, 17);
            this.crustyCanyonCheckBox.TabIndex = 2;
            this.crustyCanyonCheckBox.Text = "Crust&y Canyon";
            this.crustyCanyonCheckBox.UseVisualStyleBackColor = true;
            // 
            // redBarronCheckBox
            // 
            this.redBarronCheckBox.AutoSize = true;
            this.redBarronCheckBox.Location = new System.Drawing.Point(17, 57);
            this.redBarronCheckBox.Name = "redBarronCheckBox";
            this.redBarronCheckBox.Size = new System.Drawing.Size(80, 17);
            this.redBarronCheckBox.TabIndex = 1;
            this.redBarronCheckBox.Text = "&Red Barron";
            this.redBarronCheckBox.UseVisualStyleBackColor = true;
            // 
            // snowconeVolcanoCheckBox
            // 
            this.snowconeVolcanoCheckBox.AutoSize = true;
            this.snowconeVolcanoCheckBox.Location = new System.Drawing.Point(17, 34);
            this.snowconeVolcanoCheckBox.Name = "snowconeVolcanoCheckBox";
            this.snowconeVolcanoCheckBox.Size = new System.Drawing.Size(123, 17);
            this.snowconeVolcanoCheckBox.TabIndex = 0;
            this.snowconeVolcanoCheckBox.Text = "&Snow Cone Volcano";
            this.snowconeVolcanoCheckBox.UseVisualStyleBackColor = true;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(68, 43);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // numberInGroupTextBox
            // 
            this.numberInGroupTextBox.Location = new System.Drawing.Point(116, 86);
            this.numberInGroupTextBox.Name = "numberInGroupTextBox";
            this.numberInGroupTextBox.Size = new System.Drawing.Size(52, 20);
            this.numberInGroupTextBox.TabIndex = 3;
            // 
            // enterTimeMaskedTextBox
            // 
            this.enterTimeMaskedTextBox.Location = new System.Drawing.Point(130, 122);
            this.enterTimeMaskedTextBox.Mask = "00000";
            this.enterTimeMaskedTextBox.Name = "enterTimeMaskedTextBox";
            this.enterTimeMaskedTextBox.Size = new System.Drawing.Size(38, 20);
            this.enterTimeMaskedTextBox.TabIndex = 5;
            this.enterTimeMaskedTextBox.ValidatingType = typeof(int);
            // 
            // discountGroupBox
            // 
            this.discountGroupBox.Controls.Add(this.twentyPercentRadioButton);
            this.discountGroupBox.Controls.Add(this.tenPercentRadioButton);
            this.discountGroupBox.Controls.Add(this.fivePercentRadioButton);
            this.discountGroupBox.Controls.Add(this.noneRadioButton);
            this.discountGroupBox.Location = new System.Drawing.Point(15, 175);
            this.discountGroupBox.Name = "discountGroupBox";
            this.discountGroupBox.Size = new System.Drawing.Size(249, 46);
            this.discountGroupBox.TabIndex = 6;
            this.discountGroupBox.TabStop = false;
            this.discountGroupBox.Text = "&Discounts:";
            // 
            // twentyPercentRadioButton
            // 
            this.twentyPercentRadioButton.AutoSize = true;
            this.twentyPercentRadioButton.Location = new System.Drawing.Point(180, 20);
            this.twentyPercentRadioButton.Name = "twentyPercentRadioButton";
            this.twentyPercentRadioButton.Size = new System.Drawing.Size(14, 13);
            this.twentyPercentRadioButton.TabIndex = 3;
            this.twentyPercentRadioButton.TabStop = true;
            this.twentyPercentRadioButton.UseVisualStyleBackColor = true;
            this.twentyPercentRadioButton.CheckedChanged += new System.EventHandler(this.discountRadioButton_CheckedChanged);
            // 
            // tenPercentRadioButton
            // 
            this.tenPercentRadioButton.AutoSize = true;
            this.tenPercentRadioButton.Location = new System.Drawing.Point(122, 19);
            this.tenPercentRadioButton.Name = "tenPercentRadioButton";
            this.tenPercentRadioButton.Size = new System.Drawing.Size(14, 13);
            this.tenPercentRadioButton.TabIndex = 2;
            this.tenPercentRadioButton.TabStop = true;
            this.tenPercentRadioButton.UseVisualStyleBackColor = true;
            this.tenPercentRadioButton.CheckedChanged += new System.EventHandler(this.discountRadioButton_CheckedChanged);
            // 
            // fivePercentRadioButton
            // 
            this.fivePercentRadioButton.AutoSize = true;
            this.fivePercentRadioButton.Location = new System.Drawing.Point(63, 20);
            this.fivePercentRadioButton.Name = "fivePercentRadioButton";
            this.fivePercentRadioButton.Size = new System.Drawing.Size(14, 13);
            this.fivePercentRadioButton.TabIndex = 1;
            this.fivePercentRadioButton.TabStop = true;
            this.fivePercentRadioButton.UseVisualStyleBackColor = true;
            this.fivePercentRadioButton.CheckedChanged += new System.EventHandler(this.discountRadioButton_CheckedChanged);
            // 
            // noneRadioButton
            // 
            this.noneRadioButton.AutoSize = true;
            this.noneRadioButton.Location = new System.Drawing.Point(7, 20);
            this.noneRadioButton.Name = "noneRadioButton";
            this.noneRadioButton.Size = new System.Drawing.Size(14, 13);
            this.noneRadioButton.TabIndex = 0;
            this.noneRadioButton.TabStop = true;
            this.noneRadioButton.UseVisualStyleBackColor = true;
            this.noneRadioButton.CheckedChanged += new System.EventHandler(this.discountRadioButton_CheckedChanged);
            // 
            // managementTotalButton
            // 
            this.managementTotalButton.Location = new System.Drawing.Point(392, 415);
            this.managementTotalButton.Name = "managementTotalButton";
            this.managementTotalButton.Size = new System.Drawing.Size(116, 23);
            this.managementTotalButton.TabIndex = 13;
            this.managementTotalButton.Text = "&Management Total";
            this.managementTotalButton.UseVisualStyleBackColor = true;
            this.managementTotalButton.Click += new System.EventHandler(this.managementTotalButton_Click);
            // 
            // totalbutton
            // 
            this.totalbutton.Location = new System.Drawing.Point(270, 386);
            this.totalbutton.Name = "totalbutton";
            this.totalbutton.Size = new System.Drawing.Size(116, 23);
            this.totalbutton.TabIndex = 10;
            this.totalbutton.Text = "&Total Receipt";
            this.totalbutton.UseVisualStyleBackColor = true;
            this.totalbutton.Click += new System.EventHandler(this.totalbutton_Click);
            // 
            // newCustomerButton
            // 
            this.newCustomerButton.Location = new System.Drawing.Point(270, 444);
            this.newCustomerButton.Name = "newCustomerButton";
            this.newCustomerButton.Size = new System.Drawing.Size(116, 23);
            this.newCustomerButton.TabIndex = 14;
            this.newCustomerButton.Text = "N&ew Customer";
            this.newCustomerButton.UseVisualStyleBackColor = true;
            this.newCustomerButton.Click += new System.EventHandler(this.newCustomerButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(392, 444);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(116, 23);
            this.exitButton.TabIndex = 15;
            this.exitButton.Text = "E&xit Program";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(392, 386);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(116, 23);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "&Clear Form";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // customerTotalButton
            // 
            this.customerTotalButton.Location = new System.Drawing.Point(270, 415);
            this.customerTotalButton.Name = "customerTotalButton";
            this.customerTotalButton.Size = new System.Drawing.Size(116, 23);
            this.customerTotalButton.TabIndex = 12;
            this.customerTotalButton.Text = "C&ustomer Total";
            this.customerTotalButton.UseVisualStyleBackColor = true;
            this.customerTotalButton.Click += new System.EventHandler(this.customerTotalButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(13, 404);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(47, 23);
            this.testButton.TabIndex = 8;
            this.testButton.Text = "&Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // CustomerOrderForm
            // 
            this.AcceptButton = this.customerTotalButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(520, 470);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.customerTotalButton);
            this.Controls.Add(this.newCustomerButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.totalbutton);
            this.Controls.Add(this.managementTotalButton);
            this.Controls.Add(this.discountGroupBox);
            this.Controls.Add(this.enterTimeMaskedTextBox);
            this.Controls.Add(this.numberInGroupTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.eventGroupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.receiptPanel);
            this.Name = "CustomerOrderForm";
            this.Text = "Timothy\'s Water Park Orders           LeeTProgram2WaterPark";
            this.Load += new System.EventHandler(this.CustomerOrderForm_Load);
            this.receiptPanel.ResumeLayout(false);
            this.receiptPanel.PerformLayout();
            this.eventGroupBox.ResumeLayout(false);
            this.eventGroupBox.PerformLayout();
            this.discountGroupBox.ResumeLayout(false);
            this.discountGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel receiptPanel;
        private System.Windows.Forms.Label receiptLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox eventGroupBox;
        private System.Windows.Forms.CheckBox goldenWaterfallCheckBox;
        private System.Windows.Forms.CheckBox californiaCarWashCheckBox;
        private System.Windows.Forms.CheckBox crustyCanyonCheckBox;
        private System.Windows.Forms.CheckBox redBarronCheckBox;
        private System.Windows.Forms.CheckBox snowconeVolcanoCheckBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox numberInGroupTextBox;
        private System.Windows.Forms.MaskedTextBox enterTimeMaskedTextBox;
        private System.Windows.Forms.GroupBox discountGroupBox;
        private System.Windows.Forms.RadioButton twentyPercentRadioButton;
        private System.Windows.Forms.RadioButton tenPercentRadioButton;
        private System.Windows.Forms.RadioButton fivePercentRadioButton;
        private System.Windows.Forms.RadioButton noneRadioButton;
        private System.Windows.Forms.Button managementTotalButton;
        private System.Windows.Forms.Button totalbutton;
        private System.Windows.Forms.Button newCustomerButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button customerTotalButton;
        private System.Windows.Forms.Button testButton;
    }
}

