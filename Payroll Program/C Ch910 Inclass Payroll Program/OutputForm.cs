using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C_Ch910_Inclass_Payroll_Program
{
    public partial class OutputForm : Form
    {
        private string outString;           // backing field (priv instance var) for label passed
                                            // to OneEmployeePay property
        public OutputForm()
        {
            InitializeComponent();
        }
      
        public string OneEmployeesPay               // property to hold text of one employees pay
        {
            set { outString = value; }
        }

        private void OutputForm_Load(object sender, EventArgs e)
        {
            outputLabel.Text = outString;                               // assign passed values to
        }                                                               //   output label on this form

        private void exitButton_Click(object sender, EventArgs e)       // exit form
        {
            this.Close();
        }
    }
}
