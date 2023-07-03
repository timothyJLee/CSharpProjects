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
    public partial class GetDataForm : Form
    {
        public GetDataForm()
        {
            InitializeComponent();
        }

        private string nameString;
        private decimal rateDecimal;
        private int hourInteger;

        // will use the default constructor

        public string EmployeeName          // PUBLIC PROPERTIES TO SEND INPUT VALUES FROM THIS
        {                                   // FOR BACK TO THE 'MAIN FORM'
            get { return nameTextBox.Text; }    // or return nameString if assigned
        }

        public int Hours
        {
            get { return hourInteger; }
        }

        public decimal Rate
        {
            get { return rateDecimal; }
        }

        private void GetDataForm_Load(object sender, EventArgs e)
        {

        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(rateTextBox, string.Empty);         // removes icon
            errorProvider1.SetError(hoursTextBox, string.Empty);
            errorProvider1.SetError(nameTextBox, string.Empty);


            if (nameTextBox.Text.Trim() != string.Empty)
            {
                nameString = nameTextBox.Text;

                try
                {
                    hourInteger = int.Parse(hoursTextBox.Text);
                    try
                    {
                        rateDecimal = decimal.Parse(rateTextBox.Text);

                        this.Hide();            // hide keep form in memory/close recreates form
                    }                           // each time needed
                    catch
                    {
                        errorProvider1.SetError(rateTextBox, "ENTER RATE AS DECIMAL");
                        rateTextBox.Focus();
                        rateTextBox.SelectAll();
                    }
                }
                catch
                {
                    errorProvider1.SetError(hoursTextBox, "ENTER HOURS AS AN INTEGER");
                    hoursTextBox.Focus();
                    hoursTextBox.SelectAll();
                }
            }
            else
            {
                errorProvider1.SetError(nameTextBox, "ENTER A NAME");
                nameTextBox.Focus();
                nameTextBox.SelectAll();
            }
        }
    }
}
