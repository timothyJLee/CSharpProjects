using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeeTProgram6CandySales
{
    public partial class ManagementTotalsForm : Form
    {
        private int _totCustomersInteger;

        public ManagementTotalsForm(int totalCustomersInt)
        {
            TotalCustomers = totalCustomersInt;
            InitializeComponent();
        }

        // Properties

        public int TotalCustomers
        {
            get { return _totCustomersInteger; }
            set { _totCustomersInteger = value; }
        }

        private void ManagementTotalsForm_Load(object sender, EventArgs e)
        {

            totalsOutputLabel.Text = "TOTAL NUMBER OF CUSTOMERS: " + _totCustomersInteger.ToString();

        }

        private void clearTotalsButton_Click(object sender, EventArgs e)
        {
             // CLEAR TOTALS IN THE BUS TIER AFTER CONFIRMATION USING A DIALOG BOX:
            //clearTotalsDialogResult = MessageBox.Show("Click Yes to Clear Totals",
            //                                        "CLEAR CONFIRMATION", MessageBoxButtons.YesNo,
            //                                        MessageBoxIcon.Question, 
            //                                        MessageBoxDefaultButton.Button2);

            //if (clearTotalsDialogResult == DialogResult.Yes)
            {

            }
        }
    }
}
