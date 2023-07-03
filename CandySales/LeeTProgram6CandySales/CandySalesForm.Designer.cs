namespace LeeTProgram6CandySales
{
    partial class CandySalesForm
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
            this.prodIDListBox = new System.Windows.Forms.ListBox();
            this.prodDescriptionListBox = new System.Windows.Forms.ListBox();
            this.prodUnitListBox = new System.Windows.Forms.ListBox();
            this.prodUnitPriceListBox = new System.Windows.Forms.ListBox();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.zipCodeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.phoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.prodIDMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.discountGroupBox = new System.Windows.Forms.GroupBox();
            this.corporateRadioButton = new System.Windows.Forms.RadioButton();
            this.frequentCustomerRadioButton = new System.Windows.Forms.RadioButton();
            this.discountCheckBox = new System.Windows.Forms.CheckBox();
            this.addToOrderButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.endOrderButton = new System.Windows.Forms.Button();
            this.mgmtTotalsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.orderViewPanel = new System.Windows.Forms.Panel();
            this.outputLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProviderName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderProdID = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderCity = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderState = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderZipCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.testButton = new System.Windows.Forms.Button();
            this.errorProviderDiscount = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderQuantity = new System.Windows.Forms.ErrorProvider(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.quantityMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.discountGroupBox.SuspendLayout();
            this.orderViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProdID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderZipCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // prodIDListBox
            // 
            this.prodIDListBox.FormattingEnabled = true;
            this.prodIDListBox.Location = new System.Drawing.Point(23, 108);
            this.prodIDListBox.Name = "prodIDListBox";
            this.prodIDListBox.Size = new System.Drawing.Size(43, 186);
            this.prodIDListBox.TabIndex = 0;
            this.prodIDListBox.SelectedIndexChanged += new System.EventHandler(this.productListBox_SelectedIndexChanged);
            // 
            // prodDescriptionListBox
            // 
            this.prodDescriptionListBox.FormattingEnabled = true;
            this.prodDescriptionListBox.Location = new System.Drawing.Point(87, 108);
            this.prodDescriptionListBox.Name = "prodDescriptionListBox";
            this.prodDescriptionListBox.Size = new System.Drawing.Size(85, 186);
            this.prodDescriptionListBox.TabIndex = 1;
            this.prodDescriptionListBox.SelectedIndexChanged += new System.EventHandler(this.productListBox_SelectedIndexChanged);
            // 
            // prodUnitListBox
            // 
            this.prodUnitListBox.FormattingEnabled = true;
            this.prodUnitListBox.Location = new System.Drawing.Point(190, 108);
            this.prodUnitListBox.Name = "prodUnitListBox";
            this.prodUnitListBox.Size = new System.Drawing.Size(60, 186);
            this.prodUnitListBox.TabIndex = 2;
            this.prodUnitListBox.SelectedIndexChanged += new System.EventHandler(this.productListBox_SelectedIndexChanged);
            // 
            // prodUnitPriceListBox
            // 
            this.prodUnitPriceListBox.FormattingEnabled = true;
            this.prodUnitPriceListBox.Location = new System.Drawing.Point(256, 108);
            this.prodUnitPriceListBox.Name = "prodUnitPriceListBox";
            this.prodUnitPriceListBox.Size = new System.Drawing.Size(53, 186);
            this.prodUnitPriceListBox.TabIndex = 3;
            this.prodUnitPriceListBox.SelectedIndexChanged += new System.EventHandler(this.productListBox_SelectedIndexChanged);
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Location = new System.Drawing.Point(13, 331);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(41, 13);
            this.customerNameLabel.TabIndex = 4;
            this.customerNameLabel.Text = "Name: ";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(13, 365);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(48, 13);
            this.addressLabel.TabIndex = 5;
            this.addressLabel.Text = "Address:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(68, 365);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(145, 20);
            this.addressTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "City: ";
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(68, 396);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(100, 20);
            this.cityTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "State:";
            // 
            // stateTextBox
            // 
            this.stateTextBox.Location = new System.Drawing.Point(68, 421);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(38, 20);
            this.stateTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Zip:";
            // 
            // zipCodeMaskedTextBox
            // 
            this.zipCodeMaskedTextBox.Location = new System.Drawing.Point(143, 425);
            this.zipCodeMaskedTextBox.Mask = "00000";
            this.zipCodeMaskedTextBox.Name = "zipCodeMaskedTextBox";
            this.zipCodeMaskedTextBox.Size = new System.Drawing.Size(38, 20);
            this.zipCodeMaskedTextBox.TabIndex = 12;
            this.zipCodeMaskedTextBox.ValidatingType = typeof(int);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(60, 324);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Phone:";
            // 
            // phoneMaskedTextBox
            // 
            this.phoneMaskedTextBox.Location = new System.Drawing.Point(230, 328);
            this.phoneMaskedTextBox.Mask = "(999) 000-0000";
            this.phoneMaskedTextBox.Name = "phoneMaskedTextBox";
            this.phoneMaskedTextBox.Size = new System.Drawing.Size(88, 20);
            this.phoneMaskedTextBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Enter Product ID:";
            // 
            // prodIDMaskedTextBox
            // 
            this.prodIDMaskedTextBox.Location = new System.Drawing.Point(112, 472);
            this.prodIDMaskedTextBox.Mask = "000";
            this.prodIDMaskedTextBox.Name = "prodIDMaskedTextBox";
            this.prodIDMaskedTextBox.Size = new System.Drawing.Size(29, 20);
            this.prodIDMaskedTextBox.TabIndex = 17;
            // 
            // discountGroupBox
            // 
            this.discountGroupBox.Controls.Add(this.corporateRadioButton);
            this.discountGroupBox.Controls.Add(this.frequentCustomerRadioButton);
            this.discountGroupBox.Location = new System.Drawing.Point(16, 545);
            this.discountGroupBox.Name = "discountGroupBox";
            this.discountGroupBox.Size = new System.Drawing.Size(226, 47);
            this.discountGroupBox.TabIndex = 18;
            this.discountGroupBox.TabStop = false;
            this.discountGroupBox.Text = "Discount";
            // 
            // corporateRadioButton
            // 
            this.corporateRadioButton.AutoSize = true;
            this.corporateRadioButton.Location = new System.Drawing.Point(126, 19);
            this.corporateRadioButton.Name = "corporateRadioButton";
            this.corporateRadioButton.Size = new System.Drawing.Size(71, 17);
            this.corporateRadioButton.TabIndex = 1;
            this.corporateRadioButton.TabStop = true;
            this.corporateRadioButton.Text = "Corporate";
            this.corporateRadioButton.UseVisualStyleBackColor = true;
            this.corporateRadioButton.CheckedChanged += new System.EventHandler(this.discountRadioButton_CheckedChanged);
            // 
            // frequentCustomerRadioButton
            // 
            this.frequentCustomerRadioButton.AutoSize = true;
            this.frequentCustomerRadioButton.Location = new System.Drawing.Point(7, 20);
            this.frequentCustomerRadioButton.Name = "frequentCustomerRadioButton";
            this.frequentCustomerRadioButton.Size = new System.Drawing.Size(114, 17);
            this.frequentCustomerRadioButton.TabIndex = 0;
            this.frequentCustomerRadioButton.TabStop = true;
            this.frequentCustomerRadioButton.Text = "Frequent Customer";
            this.frequentCustomerRadioButton.UseVisualStyleBackColor = true;
            this.frequentCustomerRadioButton.CheckedChanged += new System.EventHandler(this.discountRadioButton_CheckedChanged);
            // 
            // discountCheckBox
            // 
            this.discountCheckBox.AutoSize = true;
            this.discountCheckBox.Location = new System.Drawing.Point(16, 522);
            this.discountCheckBox.Name = "discountCheckBox";
            this.discountCheckBox.Size = new System.Drawing.Size(117, 17);
            this.discountCheckBox.TabIndex = 19;
            this.discountCheckBox.Text = "Check for Discount";
            this.discountCheckBox.UseVisualStyleBackColor = true;
            this.discountCheckBox.CheckedChanged += new System.EventHandler(this.discountCheckBox_CheckedChanged);
            // 
            // addToOrderButton
            // 
            this.addToOrderButton.Location = new System.Drawing.Point(243, 386);
            this.addToOrderButton.Name = "addToOrderButton";
            this.addToOrderButton.Size = new System.Drawing.Size(75, 23);
            this.addToOrderButton.TabIndex = 20;
            this.addToOrderButton.Text = "Add to Order";
            this.addToOrderButton.UseVisualStyleBackColor = true;
            this.addToOrderButton.Click += new System.EventHandler(this.addToOrderButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(243, 418);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 21;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // endOrderButton
            // 
            this.endOrderButton.Location = new System.Drawing.Point(243, 447);
            this.endOrderButton.Name = "endOrderButton";
            this.endOrderButton.Size = new System.Drawing.Size(75, 23);
            this.endOrderButton.TabIndex = 22;
            this.endOrderButton.Text = "End Order";
            this.endOrderButton.UseVisualStyleBackColor = true;
            this.endOrderButton.Click += new System.EventHandler(this.endOrderButton_Click);
            // 
            // mgmtTotalsButton
            // 
            this.mgmtTotalsButton.Location = new System.Drawing.Point(243, 476);
            this.mgmtTotalsButton.Name = "mgmtTotalsButton";
            this.mgmtTotalsButton.Size = new System.Drawing.Size(75, 23);
            this.mgmtTotalsButton.TabIndex = 23;
            this.mgmtTotalsButton.Text = "mgmtTotals";
            this.mgmtTotalsButton.UseVisualStyleBackColor = true;
            this.mgmtTotalsButton.Click += new System.EventHandler(this.mgmtTotalsButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(243, 505);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 24;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // orderViewPanel
            // 
            this.orderViewPanel.BackColor = System.Drawing.SystemColors.Window;
            this.orderViewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.orderViewPanel.Controls.Add(this.outputLabel);
            this.orderViewPanel.Location = new System.Drawing.Point(346, 63);
            this.orderViewPanel.Name = "orderViewPanel";
            this.orderViewPanel.Size = new System.Drawing.Size(432, 493);
            this.orderViewPanel.TabIndex = 25;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(4, 10);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(68, 13);
            this.outputLabel.TabIndex = 0;
            this.outputLabel.Text = "Output Label";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "ProductID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(84, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(189, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Units:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(253, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Price/Unit:";
            // 
            // errorProviderName
            // 
            this.errorProviderName.ContainerControl = this;
            // 
            // errorProviderProdID
            // 
            this.errorProviderProdID.ContainerControl = this;
            // 
            // errorProviderAddress
            // 
            this.errorProviderAddress.ContainerControl = this;
            // 
            // errorProviderCity
            // 
            this.errorProviderCity.ContainerControl = this;
            // 
            // errorProviderState
            // 
            this.errorProviderState.ContainerControl = this;
            // 
            // errorProviderZipCode
            // 
            this.errorProviderZipCode.ContainerControl = this;
            // 
            // errorProviderPhone
            // 
            this.errorProviderPhone.ContainerControl = this;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(517, 569);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 30;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // errorProviderDiscount
            // 
            this.errorProviderDiscount.ContainerControl = this;
            // 
            // errorProviderQuantity
            // 
            this.errorProviderQuantity.ContainerControl = this;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(147, 475);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "X";
            // 
            // quantityMaskedTextBox
            // 
            this.quantityMaskedTextBox.Location = new System.Drawing.Point(168, 472);
            this.quantityMaskedTextBox.Mask = "0";
            this.quantityMaskedTextBox.Name = "quantityMaskedTextBox";
            this.quantityMaskedTextBox.Size = new System.Drawing.Size(21, 20);
            this.quantityMaskedTextBox.TabIndex = 32;
            // 
            // CandySalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 604);
            this.Controls.Add(this.quantityMaskedTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.orderViewPanel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.mgmtTotalsButton);
            this.Controls.Add(this.endOrderButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.addToOrderButton);
            this.Controls.Add(this.discountCheckBox);
            this.Controls.Add(this.discountGroupBox);
            this.Controls.Add(this.prodIDMaskedTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phoneMaskedTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.zipCodeMaskedTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stateTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.customerNameLabel);
            this.Controls.Add(this.prodUnitPriceListBox);
            this.Controls.Add(this.prodUnitListBox);
            this.Controls.Add(this.prodDescriptionListBox);
            this.Controls.Add(this.prodIDListBox);
            this.Name = "CandySalesForm";
            this.Text = "Timothy\'s Candy Sales     LeeTProgram5CandySales";
            this.Load += new System.EventHandler(this.CandySalesForm_Load);
            this.discountGroupBox.ResumeLayout(false);
            this.discountGroupBox.PerformLayout();
            this.orderViewPanel.ResumeLayout(false);
            this.orderViewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProdID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderZipCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox prodIDListBox;
        private System.Windows.Forms.ListBox prodDescriptionListBox;
        private System.Windows.Forms.ListBox prodUnitListBox;
        private System.Windows.Forms.ListBox prodUnitPriceListBox;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox zipCodeMaskedTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox phoneMaskedTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox prodIDMaskedTextBox;
        private System.Windows.Forms.GroupBox discountGroupBox;
        private System.Windows.Forms.RadioButton corporateRadioButton;
        private System.Windows.Forms.RadioButton frequentCustomerRadioButton;
        private System.Windows.Forms.CheckBox discountCheckBox;
        private System.Windows.Forms.Button addToOrderButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button endOrderButton;
        private System.Windows.Forms.Button mgmtTotalsButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Panel orderViewPanel;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProviderName;
        private System.Windows.Forms.ErrorProvider errorProviderProdID;
        private System.Windows.Forms.ErrorProvider errorProviderAddress;
        private System.Windows.Forms.ErrorProvider errorProviderCity;
        private System.Windows.Forms.ErrorProvider errorProviderState;
        private System.Windows.Forms.ErrorProvider errorProviderZipCode;
        private System.Windows.Forms.ErrorProvider errorProviderPhone;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.ErrorProvider errorProviderDiscount;
        private System.Windows.Forms.ErrorProvider errorProviderQuantity;
        private System.Windows.Forms.MaskedTextBox quantityMaskedTextBox;
        private System.Windows.Forms.Label label10;
    }
}

