namespace LeeTProgram1CellPhones
{
    partial class displayForm
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
            this.summaryLabel = new System.Windows.Forms.Label();
            this.printPreviewButton = new System.Windows.Forms.Button();
            this.phoneSummaryLabel = new System.Windows.Forms.Label();
            this.deliveryDisplayFormLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.Location = new System.Drawing.Point(12, 25);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(53, 13);
            this.summaryLabel.TabIndex = 1;
            this.summaryLabel.Text = "Summary:";
            // 
            // printPreviewButton
            // 
            this.printPreviewButton.Location = new System.Drawing.Point(215, 351);
            this.printPreviewButton.Name = "printPreviewButton";
            this.printPreviewButton.Size = new System.Drawing.Size(92, 23);
            this.printPreviewButton.TabIndex = 0;
            this.printPreviewButton.Text = "&Print Preview";
            this.toolTip1.SetToolTip(this.printPreviewButton, "Click to see a print preview of order...");
            this.printPreviewButton.UseVisualStyleBackColor = true;
            this.printPreviewButton.Click += new System.EventHandler(this.printPreviewButton_Click);
            // 
            // phoneSummaryLabel
            // 
            this.phoneSummaryLabel.AutoSize = true;
            this.phoneSummaryLabel.Location = new System.Drawing.Point(15, 166);
            this.phoneSummaryLabel.Name = "phoneSummaryLabel";
            this.phoneSummaryLabel.Size = new System.Drawing.Size(35, 13);
            this.phoneSummaryLabel.TabIndex = 2;
            this.phoneSummaryLabel.Text = "label1";
            // 
            // deliveryDisplayFormLabel
            // 
            this.deliveryDisplayFormLabel.AutoSize = true;
            this.deliveryDisplayFormLabel.Enabled = false;
            this.deliveryDisplayFormLabel.Location = new System.Drawing.Point(18, 250);
            this.deliveryDisplayFormLabel.Name = "deliveryDisplayFormLabel";
            this.deliveryDisplayFormLabel.Size = new System.Drawing.Size(45, 13);
            this.deliveryDisplayFormLabel.TabIndex = 3;
            this.deliveryDisplayFormLabel.Text = "Delivery";
            // 
            // displayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 386);
            this.Controls.Add(this.deliveryDisplayFormLabel);
            this.Controls.Add(this.phoneSummaryLabel);
            this.Controls.Add(this.printPreviewButton);
            this.Controls.Add(this.summaryLabel);
            this.Name = "displayForm";
            this.Text = "displayForm";
            this.Load += new System.EventHandler(this.displayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label summaryLabel;
        private System.Windows.Forms.Button printPreviewButton;
        private System.Windows.Forms.Label phoneSummaryLabel;
        private System.Windows.Forms.Label deliveryDisplayFormLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}