// DOCUMENT ME TOO!!!

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
    public partial class PayrollClassesForm : Form
    {
        public PayrollClassesForm()
        {
            InitializeComponent();
        }

        private int hoursInteger;
        private decimal rateDecimal;

        private DialogResult clearTotalsDialogResult;

        CalculatePay anEmployee = new CalculatePay();       // requires overload/empty constructor
      //  CalculatePay anEmployee;            // = new CalculatePay();
        
        private void PayrollClassesForm_Load(object sender, EventArgs e)
        {
            outputLabel.Text = "";
            totalsLabel.Text = "";
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            //  string name;

            nameTextBox.Text = "Fred";
            hoursTextBox.Text = "50";
            rateTextBox.Text = "9.50";

             
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim() != string.Empty)
            {
                if (int.TryParse(hoursTextBox.Text, out hoursInteger))
                {
                    try
                    {
                        rateDecimal = decimal.Parse(rateTextBox.Text);
                        try
                        {
                            // process
                            ProcessData();
                            OutputData();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        } 
                    }
                    catch
                    {
                      MessageBox.Show("enter rate");
                      rateTextBox.Focus();
                      rateTextBox.SelectAll();
                    }
                 }
                 else
                 {
                    MessageBox.Show("enter hours");
                    hoursTextBox.Focus();
                    hoursTextBox.SelectAll();
                 }
            }
            else
            {
                MessageBox.Show("enter name");
                nameTextBox.Focus();
                nameTextBox.SelectAll();
            }
        }
        private void ProcessData()
        {       // instantiate and instance of our CalculatePay class & pass rate, hours as arguments:

            // this creates an instance of the class and passes 2 arguments to the class:
          //  CalculatePay anEmployee = new CalculatePay(hoursInteger, rateDecimal);

            // using already created instance variable/object (anEmployee) this line:
            //   instantiates a new instance of the CalculatePay Class:
            //   and passes arguments to it....

            if (hazardPayCheckBox.Checked)
            {                   // instantiate HazardPay class when Emp receives HAZARD PAY
                anEmployee = new HazardPay(hoursInteger, rateDecimal);
            }
            else
            {                   // instantiate CalculatePay class when Emp receives NO HAZARD PAY
                anEmployee = new CalculatePay(hoursInteger, rateDecimal);
            }
             

        }
        private void OutputData()
        {
            outputLabel.Text = "Pay for " + nameTextBox.Text + Environment.NewLine +
                                " Hours: " + hoursInteger.ToString() + Environment.NewLine +
                                " Rate: " + rateDecimal.ToString() + Environment.NewLine +
                                Environment.NewLine +
                                "Gross Pay: " + anEmployee.GrossPay.ToString("C") + Environment.NewLine +
                                "Taxes:     " + anEmployee.Taxes.ToString() + Environment.NewLine +
                                "Net Pay:   " + anEmployee.NetPay.ToString("C");
        }

        private void totalsButton_Click(object sender, EventArgs e)
        {           // OUTPUT TOTALS ACCUMULATED IN THE BUSINESS TIER (CalculatePay)
                    //   totals are 'static' and for ALL Employees so ref. property thru the CLASS NAME
          
            totalsLabel.Text = "Totals" + Environment.NewLine +
                               "Total # Employees is " + CalculatePay.TotalEmployees.ToString() +
                               Environment.NewLine +
                               "Total Taxes Paid is  " + CalculatePay.TotalTaxes.ToString("c");
        }

        private void clearTotalsButton_Click(object sender, EventArgs e)
        {           // CLEAR TOTALS IN THE BUS TIER AFTER CONFIRMATION USING A DIALOG BOX:
            clearTotalsDialogResult = MessageBox.Show("Click Yes to Clear Totals",
                                                    "CLEAR CONFIRMATION", MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question, 
                                                    MessageBoxDefaultButton.Button2);

            if (clearTotalsDialogResult == DialogResult.Yes)
            {
            //  //  anEmployee = new CalculatePay(true);
            //    string clearString = clearTotalsDialogResult.ToString();
            ////    anEmployee = new CalculatePay(clearTotalsDialogResult);
            //    anEmployee = new CalculatePay(clearString);

                CalculatePay.TotalEmployees = 0;            // clear totals via properties 
                CalculatePay.TotalTaxes = 0;                // which are public and use the
                                                            // SET accessor
            }
        }

        private void exitButton_Click(object sender, EventArgs e)       // close this form
        {
            this.Close();
        }

        private void getDataButton_Click(object sender, EventArgs e)  // DISPLAYS FORM FOR INPUT OF DATA TO THIS 'MAIN FORM'
        {
            // CREATE AND INSTANTIATE AN INSTANCE OF THE GetDataForm
            GetDataForm inputData = new GetDataForm();
            // THEN SHOW THE FORM
            inputData.ShowDialog();                 // display instance of form w/ ShowDialog() method

        // ACCEPT THE DATA FROM THE FORM INTO THE CLASS LEVEL VARIABLES OF THIS FORM
            nameTextBox.Text = inputData.EmployeeName;          // 'getting' name from instance (inputData) of GetDataForm
            hoursInteger = inputData.Hours;         // takes property from inputData instance and 
            rateDecimal = inputData.Rate;           //   assigns it to variable from this class

            // SO WE CAN JUST CALL THE PROCESSES THAT WE HAVE USED BEFORE
            // process
            ProcessData();
            OutputData();
        }

        private void outputDataButton_Click(object sender, EventArgs e)
        {            // CREATE STRING OF DATA TO OUTPUT
            string outputString;
            outputString = "Pay for " + nameTextBox.Text + Environment.NewLine +
                                " Hours: " + hoursInteger.ToString() + Environment.NewLine +
                                " Rate: " + rateDecimal.ToString() + Environment.NewLine +
                                Environment.NewLine +
                                "Gross Pay: " + anEmployee.GrossPay.ToString("C") + Environment.NewLine +
                                "Taxes:     " + anEmployee.Taxes.ToString() + Environment.NewLine +
                                "Net Pay:   " + anEmployee.NetPay.ToString("C");
            //CREATE INSTANCE OF OutputForm:

            OutputForm oneEmployeeData = new OutputForm(); 

            // CAN I TAKE A VARIABLE FROM THIS FORM AND ASSIGN IT TO THE PROPERTY OF OUTPUT FORM?
            oneEmployeeData.OneEmployeesPay = outputString;
            oneEmployeeData.ShowDialog();
        }
    }
}
