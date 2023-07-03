using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C_Methods_Program
{
    public partial class MethodsForm : Form
    {
        // INPUT:
        int quantityInteger;
        decimal unitPriceDecimal;

        bool validBoolean;

        public MethodsForm()
        {
            InitializeComponent();
        }

        private void MehtodsForm_Load(object sender, EventArgs e)
        { }

        private void voidButton_Click(object sender, EventArgs e)
        {
            ValidateInput();
            if (validBoolean)               // BOTTOM METHOD! USES tryParse( ) METHOD
            {
                outputLabel.Text = "";

                CalculateWithPassedValues(quantityInteger, unitPriceDecimal);       // call method to determine product & output it to label
       
            }
        }

  private void CalculateWithPassedValues(int qty, decimal price)
  {
      outputLabel.Text = (qty * price).ToString("C");
  }

        
 


// ***************************************************************************************************************
                // ************** NAMED ARGUMENTS *********************************

        private void namedArgumentsButton_Click(object sender, EventArgs e)
        {
            ValidateInput();
            if (validBoolean)               // BOTTOM METHOD! USES tryParse( ) METHOD
            {
                outputLabel.Text = "";
                                                             // pass parameter out of order using Named Arguments
                CalculateWithNamedArguments( secondVar: quantityInteger, firstVar: unitPriceDecimal);
            }
        }

        private void CalculateWithNamedArguments(decimal firstVar, int secondVar)   //CALLED FROM namedArgumentsButton_Click
        {
            outputLabel.Text = (secondVar * firstVar).ToString("C");
        }
// ************************************************************************************************************************
        
        // *******  USING DEFAULT VALUES ********************
        private void defaultArgumentsButton_Click(object sender, EventArgs e)
        {
            ValidateInput();
            if (validBoolean)               // BOTTOM METHOD! USES tryParse( ) METHOD
            {
                outputLabel.Text = "";

             //    CalcTaxToo(quantityInteger,unitPriceDecimal);      // uses default value

                CalcTaxToo(quantityInteger, unitPriceDecimal, .0m);            // passed new tax rate
            }
        }

        private void CalcTaxToo(int qty, decimal unitPrice, decimal taxRate = .06m)
        {
            outputLabel.Text += (qty * unitPrice * (1 + taxRate)).ToString("C") + Environment.NewLine;
        }


//*********************************************************************************************************


// ********** PASS USING BY VALUE *******************************
        private void byValueButton_Click(object sender, EventArgs e)    // CALLS CalculateByValue JUST OUTPUTTING 
        {                                                               // VALUE OF taxRate USING BY VALUE (THE DEFAULT)
            ValidateInput();
            if (validBoolean)               // BOTTOM METHOD! USES tryParse( ) METHOD
            {
                outputLabel.Text = "";
                decimal taxRate = .10m;

                      CalculateByValue(quantityInteger, unitPriceDecimal, taxRate);            // passed new tax rate

               outputLabel.Text += taxRate.ToString("P");
            }
        }


        private void CalculateByValue(int quantityInteger, decimal unitPriceDecimal, decimal taxRate)
        {
            taxRate = .55m;
            outputLabel.Text = taxRate.ToString("P");   
        }

//******************************************************************************************************** 

        // ***** USING BY REFERENCE **********************         MUST PASS INITIALIZED VALUE

        private void referenceButton_Click(object sender, EventArgs e)    // CALLS CalculateByReference JUST OUTPUTTING 
        {                                                                 // VALUE OF taxRate USING REFERENCE

            ValidateInput();
            if (validBoolean)               // BOTTOM METHOD! USES tryParse( ) METHOD
            {
                outputLabel.Text = "";
                decimal taxRate = .10m;

               CalculateByReference(quantityInteger, unitPriceDecimal, ref   taxRate);            // passed new tax rate

                outputLabel.Text += taxRate.ToString("P");
            }
        }

        private void CalculateByReference(int qty, decimal price, ref decimal taxRate)
        {
            taxRate = .55m;
            outputLabel.Text = taxRate.ToString("P");   
        }
// ***********************************************************************************************************

        // USING OUT VARIABLE (vs REFERENCE) *******************************************  CAN PASS UN-INITIALIZED VALUE
        private void outButton_Click(object sender, EventArgs e)                  // BUT MUST HAVE A VALUE BEFORE PASSED BK
        {

            ValidateInput();
            if (validBoolean)               // BOTTOM METHOD! USES tryParse( ) METHOD
            {
                outputLabel.Text = "";
                 decimal taxRate;                       // UNINITIALIZED   TK O/ = .10m;

                CalculateWithOUT( quantityInteger,unitPriceDecimal, out taxRate);                                           // passed NO VALUE, use OUT!
 
                outputLabel.Text += taxRate.ToString("P");
            }
        }

        private void CalculateWithOUT(int qty, decimal unitPrice, out decimal taxRate)          // use OUT
        {                                                                           // taxRate MUST BE ASSIGNED A VALUE
            taxRate = .55m;
            outputLabel.Text = taxRate.ToString("P");
        }
// ***************************************************************************************************************


        //   ***** RETURN VALUES! ***************************************

        private void returnValueButton_Click(object sender, EventArgs e)
        {
            ValidateInput();
            if (validBoolean)               // BOTTOM METHOD! USES tryParse( ) METHOD
            {
                outputLabel.Text = "";
                decimal taxRate;                       // UNINITIALIZED   TK O/ = .10m;
                decimal amtDueDecimal;

                //amtDueDecimal = ReturnAValue(quantityInteger, unitPriceDecimal);            // passed NO VALUE, use OUT!
                //outputLabel.Text = amtDueDecimal.ToString("c");
            
                // another way...
                outputLabel.Text = (ReturnAValue(quantityInteger, unitPriceDecimal)).ToString("C");
            }
        }

        // METHOD w/ DATA TYPE!!!
        private decimal ReturnAValue(int qty, decimal unitPrice, decimal taxRate = .06m)
        {
            return qty * unitPrice * (1 + taxRate);
        // another way... 
            //decimal amtDueDecimal = qty * unitPrice * (1 + taxRate);
            //return amtDueDecimal;
        }                                                                             //  
             
// ***************************************************************************************************************
       
  // BOOLEAN USE OF METHODS:      
        
        private void booleanButton_Click(object sender, EventArgs e)
        {
            quantityInteger = 0;          // ARGUMENTS PASSED MUST HAVE A VALUE
            unitPriceDecimal = 0;

            if (ValidateInputMethod(ref quantityInteger, ref unitPriceDecimal))   // PASS BY REFERENCE W/IN TEST
            {
                decimal extentedPriceDecimal = quantityInteger * unitPriceDecimal;
                outputLabel.Text = extentedPriceDecimal.ToString("C");
            }
            else
            {
                outputLabel.Text = "test not passed";
            }
        }

        private bool ValidateInputMethod(ref int qty, ref decimal unitPrice)         // REF PARMS; BOOLEAN METHOD SO BOOLEAN RETURNED
        {

       //     validBoolean = false;

            if (int.TryParse(qtyTextBox.Text, out qty ))
            {
                if (decimal.TryParse(unitPricesTextBox.Text, out unitPrice))  // METHOD ACTUALLY PASSES A T/F 
                {                                                       // 
                   // validBoolean = true;                                // 
                    return true;
                }                                                       //  
                else
                {
                    MessageBox.Show("Enter a Unit Price", "PRICE INPUT ERROR");
                    unitPricesTextBox.Focus();
                    unitPricesTextBox.SelectAll();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Enter Quantity as an Whole Number", "QTY INPUT ERROR");
                qtyTextBox.Focus();
                qtyTextBox.SelectAll();
                return false;
            }
         //   return validBoolean;
        }

 // ***************************************************************************************************************
 // ***********************************************************************************************************

        // ********** VALIDATION METHOD ********

        private void ValidateInput()         // USING TRY PARSE (W/IN AN IF, not TRY)  Pg 230-
        {

            validBoolean = false;

            if (int.TryParse(qtyTextBox.Text, out quantityInteger))
            {
                if (decimal.TryParse(unitPricesTextBox.Text, out unitPriceDecimal))  // method actually passes a T/F 
                {                                                       // no exception is thrown..so ..put in an IF
                    validBoolean = true;                        // 'out' keyword w/output var after...the var is pasesd as arg. to
                }                                               //  the method (tryParse), when finished..assign value to var
                else
                {
                    MessageBox.Show("Enter a Unit Price", "PRICE INPUT ERROR");
                    unitPricesTextBox.Focus();
                    unitPricesTextBox.SelectAll();
                }
            }
            else
            {

                MessageBox.Show("Enter Quantity as an Whole Number", "QTY INPUT ERROR");
                qtyTextBox.Focus();
                qtyTextBox.SelectAll();
            }

        }

       
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
