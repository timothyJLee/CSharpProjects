


///  Timothy lee
///  10/12/12
///  ClassRoomPointOfView:
///   - Learn to input data for processing with validation of inputs, calculations, accumulations,
///     outputs, decisions, etc..
///  BusinessPointOfView:
///   - Determine the charge and create a receipt for a group or individual attending a water park,
///     which includes a parking fee
///     
///  DECISIONS: case, if, If-else, try-catch, nested decisions, single line if
///  METHODS: MessageBox.Show(), CalculateFee(), ExtraEventCharge(), ParkingCharge(), AccumulateCustomerTotals(),
///           OutputReceipt(), EventCheckedProcess(), ManagementTotalsCalculate(), ClearCustomerTotals()
///  EVENTS: Button_Click, RadioButton_CheckedChanged, Form_Load


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeeTProgram2WaterPark
{
    public partial class CustomerOrderForm : Form
    {
        public CustomerOrderForm()
        {
            InitializeComponent();
        }

        // input field declarations:
        private string groupNameString;       // nameTexBox.Text
        private string discountAmountString;  // discountDouble.ToString("p")
        private int numberInGroupInteger;     // int.Parse(numberInGroupTextBox.Text)
        private int minutesParkedInteger;     // int.Parse(enterTimeMaskedTextBox.Text)
               
        // calculated fields
        private decimal extraEventChargeDecimal = 0m;  // Case Structure
        private decimal parkingChargeDecimal = 0m;    // ((decimal)numberOfHoursParkedDouble * 2.00m) + (minuteChargeDecimal)
        private decimal minuteChargeDecimal = 0m;     // if 1-30 then .5 if 31-59 then 1 hour
        private decimal numberOfMinutesParkedDecimal;
        private double numberOfHoursParkedDouble = 0; // minutesParkedInteger / 60
        private decimal discountDecimal = 0;            // = DISCOUNT_PERCENT_DECIMAL
        private decimal numberOfHoursParkedOutputDecimal = 0;

        private decimal individualFeeDecimal = 0;     // baseFeeDecimal + extraEventChargeDecimal
        private decimal totalParkFeeDecimal = 0m;     // (decimal)numberInGroupInteger * individualFeeDecimal
        private decimal totalChargeBeforeDiscountDecimal = 0m; // totalParkFeeDecimal + parkingChargeDecimal
        private decimal finalTotalDueDecimal = 0m;             // totalChargeBeforeDiscountDecimal + (totalChargeBeforeDiscountDecimal * discountDouble)
        
        // accumulated fields
        private int totalNumberOfGroupsInteger = 0;        // totalNumberOfGroupsInteger++
        private int totalNumberOfIndividualsInteger = 0;   // totalNumberOfIndividualsInteger + numberInGroupInteger
        private double averageNumberOfPeoplePerGroupDouble = 0;
        // customer totals
        private int totalNumberOfEventsInteger = 0;
        private string eventListString;

        // management totals

        private int mgmtTotalNumberOfGroupsInteger = 0;
        private int mgmtTotalNumberOfIndividualsInteger = 0;
        private double mgmtAverageNumberOfPeoplePerGroupDouble = 0;

        // constant variables:
        private decimal BASE_FEE_DECIMAL = 20.00m;          // = 20.00 but may be subject to change by company
        private const decimal NONE_PERCENT_DECIMAL = .0m;
        private const decimal FIVE_PERCENT_DECIMAL = .05m;
        private const decimal TEN_PERCENT_DECIMAL = .1m;
        private const decimal TWENTY_PERCENT_DECIMAL = .2m;

        // working fields
        private bool headerBoolean = true;       // display the header when true
        private RadioButton discountRadioButton;

        private void CustomerOrderForm_Load(object sender, EventArgs e)
        {
            noneRadioButton.Text += NONE_PERCENT_DECIMAL.ToString("p");
            fivePercentRadioButton.Text += FIVE_PERCENT_DECIMAL.ToString("p");
            tenPercentRadioButton.Text += TEN_PERCENT_DECIMAL.ToString("p");
            twentyPercentRadioButton.Text += TWENTY_PERCENT_DECIMAL.ToString("p");

            noneRadioButton.Tag = NONE_PERCENT_DECIMAL;
            fivePercentRadioButton.Tag = FIVE_PERCENT_DECIMAL;
            tenPercentRadioButton.Tag = TEN_PERCENT_DECIMAL;
            twentyPercentRadioButton.Tag = TWENTY_PERCENT_DECIMAL;
        }

        private void totalbutton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim() != string.Empty)
            {
                groupNameString = nameTextBox.Text;
                try
                {
                    numberInGroupInteger = int.Parse(numberInGroupTextBox.Text);
                    if (numberInGroupInteger > 0)
                    {
                        try
                        {
                            minutesParkedInteger = int.Parse(enterTimeMaskedTextBox.Text);
                            if (minutesParkedInteger > 0)
                            {
                                if (noneRadioButton.Checked || fivePercentRadioButton.Checked ||
                                    tenPercentRadioButton.Checked || twentyPercentRadioButton.Checked)
                                {
                                    try
                                    {
                                        EventCheckedProcess();
                                        ExtraEventCharge();
                                        ParkingCharge();
                                        if (snowconeVolcanoCheckBox.Checked || redBarronCheckBox.Checked ||
                                            crustyCanyonCheckBox.Checked || californiaCarWashCheckBox.Checked ||
                                            goldenWaterfallCheckBox.Checked)
                                        {
                                            CalculateFee();
                                            AccumulateCustomerTotals();
                                            OutputReceipt();
                                            totalbutton.Enabled = false;
                                            customerTotalButton.Enabled = false;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("THERE WAS A PROBLEM: " + ex, "ERROR",
                                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Select a discount amount...", "INPUT ERROR - INCOMPLETE FORM!",
                                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    discountGroupBox.BackColor = Color.Crimson;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Enter minutes parked as a positive integer...", "INPUT ERROR - INVALID INPUT FOR MINUTES PARKED!",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                enterTimeMaskedTextBox.Focus();
                                enterTimeMaskedTextBox.SelectAll();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Enter minutes parked as a positive integer...", "INPUT ERROR - INVALID INPUT FOR MINUTES PARKED!",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            enterTimeMaskedTextBox.Focus();
                            enterTimeMaskedTextBox.SelectAll();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter number of people in group as a positive integer...", "INPUT ERROR - INVALID INPUT FOR NO IN GROUP!",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        numberInGroupTextBox.Focus();
                        numberInGroupTextBox.SelectAll();
                    }
                }
                catch
                {
                    MessageBox.Show("Enter number of people in group as a positive integer...", "INPUT ERROR - INVALID INPUT FOR NO IN GROUP!",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numberInGroupTextBox.Focus();
                    numberInGroupTextBox.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Enter a group name in the box...", "INPUT ERROR - INVALID INPUT FOR GROUP NAME!",
                                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Focus();
                nameTextBox.SelectAll();
            }
        }

        private void CalculateFee()
        {
            individualFeeDecimal = BASE_FEE_DECIMAL + extraEventChargeDecimal;
            totalParkFeeDecimal = (decimal)numberInGroupInteger * individualFeeDecimal;
            totalChargeBeforeDiscountDecimal = totalParkFeeDecimal + parkingChargeDecimal;
            finalTotalDueDecimal = totalChargeBeforeDiscountDecimal - (totalChargeBeforeDiscountDecimal * discountDecimal);
        }

        private void ExtraEventCharge()
        {
            switch (totalNumberOfEventsInteger.ToString())
            {
                case "1":
                    extraEventChargeDecimal = 0.00m;             
                    break;
                case "2":
                    extraEventChargeDecimal = 3.00m; 
                    break;
                case "3":
                    extraEventChargeDecimal = 5.00m;
                    break;
                case "4":
                    extraEventChargeDecimal = 6.00m;
                    break;
                case "5":
                    extraEventChargeDecimal = 7.00m;
                    break;
                default:
                    MessageBox.Show("Please select at least one event...", "SELECT AN EVENT!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void ParkingCharge()
        {
            numberOfHoursParkedDouble = (double)(minutesParkedInteger / 60);
            numberOfHoursParkedOutputDecimal = (decimal)numberOfHoursParkedDouble;
            numberOfMinutesParkedDecimal = (decimal)minutesParkedInteger % 60;

            if (numberOfMinutesParkedDecimal > 30)
            {
                minuteChargeDecimal = 2.00m;
                numberOfHoursParkedOutputDecimal += 1.0m;
            }
            if (numberOfMinutesParkedDecimal < 31)
            {
                minuteChargeDecimal = 1.00m;
                numberOfHoursParkedOutputDecimal += 0.5m;
            }
            if (numberOfMinutesParkedDecimal == 0)
                minuteChargeDecimal = 0.00m;
            
           parkingChargeDecimal = ((decimal)numberOfHoursParkedDouble * 2) + minuteChargeDecimal;
        }

        private void AccumulateCustomerTotals()
        {
            totalNumberOfGroupsInteger++;
            totalNumberOfIndividualsInteger += numberInGroupInteger;
            averageNumberOfPeoplePerGroupDouble = (double)totalNumberOfIndividualsInteger / (double)totalNumberOfGroupsInteger;
        }

        private void OutputReceipt()
        {
            if (headerBoolean)
            {
                receiptLabel.Text += "Lee's Wet and Wild WaterPark!" + Environment.NewLine +
                                    "Date: " + DateTime.Now.ToString() + Environment.NewLine +
                                    "Owner: Timothy Lee" + Environment.NewLine;
                headerBoolean = false;
            }

            receiptLabel.Text += Environment.NewLine +
                                 "Name: " + groupNameString + Environment.NewLine +
                                 "No. in group: " + numberInGroupInteger.ToString() + Environment.NewLine +
                                 "Hours Parked: " + numberOfHoursParkedOutputDecimal.ToString() + Environment.NewLine +
                                 "Parking Fee: " + parkingChargeDecimal.ToString("c") + Environment.NewLine + Environment.NewLine +
                                 "***EVENTS***" + Environment.NewLine +
                                 eventListString + Environment.NewLine + Environment.NewLine +
                                 "Extra Event Charge: " + extraEventChargeDecimal.ToString("c") + Environment.NewLine +
                                 "Fee for Individual: " + BASE_FEE_DECIMAL.ToString("c") + Environment.NewLine +
                                 "Total Group Fee: " + totalParkFeeDecimal.ToString() + Environment.NewLine +
                                 "Total Charge: " + totalChargeBeforeDiscountDecimal.ToString() + Environment.NewLine;
            if (fivePercentRadioButton.Checked || tenPercentRadioButton.Checked || twentyPercentRadioButton.Checked)
            {
                receiptLabel.Text += Environment.NewLine +
                                    discountDecimal.ToString("p") + " discount = " + (totalChargeBeforeDiscountDecimal * discountDecimal).ToString("c") +
                                    Environment.NewLine + Environment.NewLine;
            }
            receiptLabel.Text += "FINAL TOTAL: " + finalTotalDueDecimal.ToString("c") + Environment.NewLine;                               
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            noneRadioButton.Checked = true;
            noneRadioButton.Checked = false;
            noneRadioButton.TabStop = true;

            numberInGroupTextBox.Clear();
            nameTextBox.Clear();
            nameTextBox.Focus();
            enterTimeMaskedTextBox.Clear();

            snowconeVolcanoCheckBox.Checked = false;
            redBarronCheckBox.Checked = false;
            crustyCanyonCheckBox.Checked = false;
            californiaCarWashCheckBox.Checked = false;
            goldenWaterfallCheckBox.Checked = false;

            eventListString = "";
        }

        private void customerTotalButton_Click(object sender, EventArgs e)
        {
            totalbutton_Click(sender, e);
        }

        private void EventCheckedProcess()
        {
            if (snowconeVolcanoCheckBox.Checked)   // boolean so auto test for TRUE
            {
                eventListString += snowconeVolcanoCheckBox.Text + Environment.NewLine;
                totalNumberOfEventsInteger++;
            }
            if (redBarronCheckBox.Checked)   // boolean so auto test for TRUE
            {
                eventListString += redBarronCheckBox.Text + Environment.NewLine;
                totalNumberOfEventsInteger++;
            }
            if (crustyCanyonCheckBox.Checked)   // boolean so auto test for TRUE
            {
                eventListString += crustyCanyonCheckBox.Text + Environment.NewLine;
                totalNumberOfEventsInteger++;
            }
            if (californiaCarWashCheckBox.Checked)   // boolean so auto test for TRUE
            {
                eventListString += californiaCarWashCheckBox.Text + Environment.NewLine;
                totalNumberOfEventsInteger++;
            }
            if (goldenWaterfallCheckBox.Checked)   // boolean so auto test for TRUE
            {
                eventListString += goldenWaterfallCheckBox.Text + Environment.NewLine;
                totalNumberOfEventsInteger++;
            }
            }

        private void managementTotalButton_Click(object sender, EventArgs e)
        {
            ManagementTotalsCalculate();

            string msgString;
            DialogResult clearTotalsDialogResult;

            msgString = " TOTALS " + Environment.NewLine +
                        "_____________________________" +
                        Environment.NewLine +
                        "Total number of individuals: " + mgmtTotalNumberOfIndividualsInteger +
                        Environment.NewLine +
                        "Total number of groups: " + mgmtTotalNumberOfGroupsInteger +
                        Environment.NewLine +
                        "Average number of people per group: " + mgmtAverageNumberOfPeoplePerGroupDouble +
                        Environment.NewLine + Environment.NewLine +
                            "Click yes to Clear Totals";

            clearTotalsDialogResult = MessageBox.Show(msgString, "TOTALS", MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Information,
                                                 MessageBoxDefaultButton.Button2);
            if (clearTotalsDialogResult == DialogResult.Yes)
            {
                mgmtTotalNumberOfIndividualsInteger = 0;
                mgmtTotalNumberOfGroupsInteger = 0;
                mgmtAverageNumberOfPeoplePerGroupDouble = 0;

                totalNumberOfGroupsInteger = 0;
                totalNumberOfIndividualsInteger = 0;
                averageNumberOfPeoplePerGroupDouble = 0;
            }
        }

        private void ManagementTotalsCalculate()
        {
            mgmtTotalNumberOfIndividualsInteger = totalNumberOfIndividualsInteger;
            mgmtTotalNumberOfGroupsInteger = totalNumberOfGroupsInteger;
            mgmtAverageNumberOfPeoplePerGroupDouble = averageNumberOfPeoplePerGroupDouble;
        }

        private void newCustomerButton_Click(object sender, EventArgs e)
        {
            clearButton_Click(sender, e);
            receiptLabel.Text = "";
            headerBoolean = true;

            nameTextBox.Clear();
            nameTextBox.Focus();

            totalbutton.Enabled = true;
            customerTotalButton.Enabled = true;

            ClearCustomerTotals();
            headerBoolean = true;
        }

        private void ClearCustomerTotals()
        {
            extraEventChargeDecimal = 0m;
            parkingChargeDecimal = 0m;
            minuteChargeDecimal = 0m;
            numberOfHoursParkedDouble = 0;
            discountDecimal = 0;
            individualFeeDecimal = 0;
            totalParkFeeDecimal = 0m;
            totalChargeBeforeDiscountDecimal = 0m;
            finalTotalDueDecimal = 0m;
            totalNumberOfEventsInteger = 0;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "Dawn";
            numberInGroupTextBox.Text = "5";
            enterTimeMaskedTextBox.Text = "75";
            tenPercentRadioButton.Checked = true;
            snowconeVolcanoCheckBox.Checked = true;
            redBarronCheckBox.Checked = true;
            goldenWaterfallCheckBox.Checked = true;
        }

        private void discountRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            discountRadioButton = (RadioButton)sender;
            discountGroupBox.BackColor = Color.Transparent; // shows orig color of background of group box in case changed with error
            discountAmountString = discountRadioButton.Text;

            discountDecimal = (decimal)discountRadioButton.Tag;     // ASSIGNS THE VALUE IN THE TAG PROP TO VAR (CAST 1ST!)
        }
    }
}
