using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeeTProgram1CellPhones
{
    public partial class displayForm : Form
    {
        // Variable declarations for passed values
        public string nameString;
        public string addressString;
        public string cityString;
        public string stateString;
        public string zipCodeString;
        public string dateString;
        public string itemAmountString;
        public string phoneTypeString;
        public string phoneColorString;
        public bool deliveryMessageDisplay;

        public displayForm()
        {
            InitializeComponent();
        }

        private void displayForm_Load(object sender, EventArgs e)
        {
            // Passing strings to summary labels...
            summaryLabel.Text =
                "Date: " + dateString +
                "\nName: " + nameString + 
                "\nAddress: " + addressString +
                "\n" + cityString + ", " + stateString + ", " + zipCodeString +
                "\n" + "\n";

            phoneSummaryLabel.Text =
                "Customer ordered " + itemAmountString + " " + phoneColorString + phoneTypeString + "(s).";

            deliveryDisplayFormLabel.Enabled = deliveryMessageDisplay;

        }

        private void printPreviewButton_Click(object sender, EventArgs e)
        {
            // making a print preview...
            //printForm.Print();  // Set printform to print preview

            //printForm.PrintAction = System.Drawing.Printing.PrintAction.PrintToPreview;            
        }
    }
}
