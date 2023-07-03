using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// ADD THIS TO USE FILES:
using System.IO;

namespace LeeTProgram6CandySales
{
    public partial class CandySalesForm : Form
    {
        public CandySalesForm()
        {
            InitializeComponent();
        }
        
        private bool headerBool;
        private int switchRadioButtonInteger = 0;
        private SingleOrderObject singleLineItemObject;
        private CalculateOrderClass aSingleSaleCalculateOrderClass;
        private FrequentCustomerDiscountClass aSingleSaleFrequentCustomerDiscountClass;
        private CorporateDiscountClass aSingleSaleCorporateDiscountClass;
        private StreamReader candyTXTFileStreamReader;
        private ListBox productListBox;
        private RadioButton discountRadioButton;
        
        private void CandySalesForm_Load(object sender, EventArgs e)
        {
            headerBool = true;
            singleLineItemObject = new SingleOrderObject();

            discountGroupBox.Enabled = false;
            outputLabel.Text = "";

            ListBoxFill();

            frequentCustomerRadioButton.Tag = 1;
            corporateRadioButton.Tag = 2;
        }

        private void addToOrderButton_Click(object sender, EventArgs e)
        {            
            if (ValidateInputs())
            {
                if (discountCheckBox.Checked)
                {
                    switch (switchRadioButtonInteger.ToString())
                    {
                        case "1":
                            aSingleSaleFrequentCustomerDiscountClass = new FrequentCustomerDiscountClass(singleLineItemObject, false); // Derived parameterized constructor call FrequentCustomerClass
                            break;
                        case "2":
                            aSingleSaleCorporateDiscountClass = new CorporateDiscountClass(singleLineItemObject, false); // Derived parameterized constructor call CorporateClass
                            break;
                        default:
                            MessageBox.Show("Please select at least one Discount Rate...", "SELECT A RATE!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                }
                else
                {
                    aSingleSaleCalculateOrderClass = new CalculateOrderClass(singleLineItemObject, false);  // parameterized constructor call CalculateClass
                }
                OutputOrder();
                corporateRadioButton.Checked = true;
                corporateRadioButton.Checked = false;
                discountCheckBox.Checked = false;
            }
        }

        private void endOrderButton_Click(object sender, EventArgs e)
        {            
            addToOrderButton.Enabled = false;

            if (ValidateInputs())
            {
                if (discountCheckBox.Checked)
                {
                    switch (switchRadioButtonInteger.ToString())
                    {
                        case "1":
                            aSingleSaleFrequentCustomerDiscountClass = new FrequentCustomerDiscountClass(singleLineItemObject, true); // Derived parameterized constructor call FrequentCustomerClass
                            break;
                        case "2":
                            aSingleSaleCorporateDiscountClass = new CorporateDiscountClass(singleLineItemObject, true); // Derived parameterized constructor call CorporateClass
                            break;
                        default:
                            MessageBox.Show("Please select at least one Discount Rate...", "SELECT A RATE!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                }
                else
                {
                    aSingleSaleCalculateOrderClass = new CalculateOrderClass(singleLineItemObject, true);  // parameterized constructor call CalculateClass
                }

                OutputOrder();


                if (corporateRadioButton.Checked != true && frequentCustomerRadioButton.Checked != true)
                {
                    decimal tempTaxDecimal = aSingleSaleCalculateOrderClass.ExtendedPrice * aSingleSaleCalculateOrderClass.TAX_RATE;
                    decimal tempTotalBeforeTaxDecimal = aSingleSaleCalculateOrderClass.ExtendedPrice - (aSingleSaleCalculateOrderClass.ExtendedPrice * aSingleSaleCalculateOrderClass.TAX_RATE);
                    outputLabel.Text += Environment.NewLine + "Total Units of Candy: " + aSingleSaleCalculateOrderClass.TotalNumberOfCandyUnits.ToString() + Environment.NewLine +
                                        "Total Due: " + tempTotalBeforeTaxDecimal.ToString("c") + Environment.NewLine +
                                        "Tax Amount: " + tempTaxDecimal.ToString("c") + Environment.NewLine +
                                        "Final Total: " + aSingleSaleCalculateOrderClass.ExtendedPrice + Environment.NewLine;
                }
                else
                {
                    if (corporateRadioButton.Checked)
                    {
                        decimal tempTaxDecimal = aSingleSaleFrequentCustomerDiscountClass.ExtendedPrice * aSingleSaleFrequentCustomerDiscountClass.TAX_RATE;
                        decimal tempTotalBeforeTaxDecimal = aSingleSaleFrequentCustomerDiscountClass.ExtendedPrice - (aSingleSaleFrequentCustomerDiscountClass.ExtendedPrice * aSingleSaleFrequentCustomerDiscountClass.TAX_RATE);
                        outputLabel.Text += Environment.NewLine + "Total Units of Candy: " + aSingleSaleFrequentCustomerDiscountClass.TotalNumberOfCandyUnits.ToString() + Environment.NewLine +
                                            "Total Due: " + tempTotalBeforeTaxDecimal.ToString("c") + Environment.NewLine +
                                            "Tax Amount: " + tempTaxDecimal.ToString("c") + Environment.NewLine +
                                            "Final Total: " + aSingleSaleFrequentCustomerDiscountClass.ExtendedPrice + Environment.NewLine;

                    }
                    else
                    {
                        if (frequentCustomerRadioButton.Checked)
                        {                            
                            decimal tempTaxDecimal = aSingleSaleCorporateDiscountClass.ExtendedPrice * aSingleSaleCorporateDiscountClass.TAX_RATE;
                            decimal tempTotalBeforeTaxDecimal = aSingleSaleCorporateDiscountClass.ExtendedPrice - (aSingleSaleCorporateDiscountClass.ExtendedPrice * aSingleSaleCorporateDiscountClass.TAX_RATE);
                            outputLabel.Text += Environment.NewLine + "Total Units of Candy: " + aSingleSaleCorporateDiscountClass.TotalNumberOfCandyUnits.ToString() + Environment.NewLine +
                                                "Total Due: " + tempTotalBeforeTaxDecimal.ToString("c") + Environment.NewLine +
                                                "Tax Amount: " + tempTaxDecimal.ToString("c") + Environment.NewLine +
                                                "Final Total: " + aSingleSaleCorporateDiscountClass.ExtendedPrice + Environment.NewLine;
                        }
                    }

                    outputLabel.Text += Environment.NewLine + "          THANK YOU FOR CHOOSING TIM'S CANDY SALES!!!!!!";

                    corporateRadioButton.Checked = true;
                    corporateRadioButton.Checked = false;
                    discountCheckBox.Checked = false;
                    headerBool = true;
                }
            }
        }

        private void OutputOrder()
        {
            if (headerBool == true)
            {
                outputLabel.Text += "Tim's Candy Sales        Timothy Lee" + Environment.NewLine +
                                    "Date: " + DateTime.Today.ToString("dd/MM/yyyy") + "     Time: " + DateTime.Now.ToShortTimeString() + Environment.NewLine +// todo: finish header
                                    Environment.NewLine + "___________________________________" + Environment.NewLine + Environment.NewLine +
                                    "ItemID:  Name:     UnitPrice:    Number: ExtendedPrice:    Discount:   DueAfterDiscount:" + Environment.NewLine + Environment.NewLine;
                headerBool = false;
            }

            if (corporateRadioButton.Checked != true && frequentCustomerRadioButton.Checked != true)
            {
                outputLabel.Text += singleLineItemObject.ProductID.ToString() + "     " +
                                    singleLineItemObject.ProductDescription + "     " +
                                    singleLineItemObject.ProductUnitPrice.ToString("c") + "/" + singleLineItemObject.ProductUnit + "   " +
                                    quantityMaskedTextBox.Text + "        " + aSingleSaleCalculateOrderClass.ExtendedPrice.ToString("c") + "               ";
                outputLabel.Text += "$0.00" + "          " + "0.00" + Environment.NewLine;
            }
            else
            {
                if (corporateRadioButton.Checked)
                {
                    outputLabel.Text += singleLineItemObject.ProductID.ToString() + "     " +
                                    singleLineItemObject.ProductDescription + "     " +
                                    singleLineItemObject.ProductUnitPrice.ToString("c") + "/" + singleLineItemObject.ProductUnit + "   " +
                                    quantityMaskedTextBox.Text + "        " + aSingleSaleCorporateDiscountClass.ExtendedPrice.ToString("c") + "               ";
                    outputLabel.Text += aSingleSaleCorporateDiscountClass.DiscountAmount.ToString("c") + "       " + aSingleSaleCorporateDiscountClass.AmountDueAfterDiscount.ToString("c") + Environment.NewLine;
                }
                else
                {
                    if (frequentCustomerRadioButton.Checked)
                    {
                        outputLabel.Text += singleLineItemObject.ProductID.ToString() + "     " +
                                    singleLineItemObject.ProductDescription + "     " +
                                    singleLineItemObject.ProductUnitPrice.ToString("c") + "/" + singleLineItemObject.ProductUnit + "   " +
                                    quantityMaskedTextBox.Text + "        " + aSingleSaleFrequentCustomerDiscountClass.ExtendedPrice.ToString("c") + "               ";
                        outputLabel.Text += aSingleSaleFrequentCustomerDiscountClass.DiscountAmount.ToString("c") + "       " + aSingleSaleFrequentCustomerDiscountClass.AmountDueAfterDiscount.ToString("c") + Environment.NewLine;
                    }                    
                }
            }           
        }

        private void mgmtTotalsButton_Click(object sender, EventArgs e)
        {
            ManagementTotalsForm ManagmentTotalsLoadForm = new ManagementTotalsForm(aSingleSaleCalculateOrderClass.TotalNumberOfCustomers);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            prodIDListBox.SelectedIndex = -1;
            quantityMaskedTextBox.Text = "";
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            cityTextBox.Text = "";
            stateTextBox.Text = "";
            zipCodeMaskedTextBox.Text = "";
            phoneMaskedTextBox.Text = "";
            prodIDMaskedTextBox.Text = "";
            frequentCustomerRadioButton.Checked = true;
            frequentCustomerRadioButton.Checked = false;
            discountCheckBox.Checked = false;
            outputLabel.Text = "";
            headerBool = true;
            addToOrderButton.Enabled = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void discountCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (discountCheckBox.Checked)
            {
                discountGroupBox.Enabled = true;
            }
            else
            {
                discountGroupBox.Enabled = false;
            }
        }

        private void discountRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            discountRadioButton = (RadioButton)sender;
            switchRadioButtonInteger = (int)discountRadioButton.Tag;    
        }

        private void productListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productListBox = (ListBox)sender;

            prodIDListBox.SelectedIndex = productListBox.SelectedIndex;
            prodDescriptionListBox.SelectedIndex = productListBox.SelectedIndex;
            prodUnitListBox.SelectedIndex = productListBox.SelectedIndex;
            prodUnitPriceListBox.SelectedIndex = productListBox.SelectedIndex;

            if (productListBox.SelectedIndex != -1)
            prodIDMaskedTextBox.Text = productListBox.SelectedItem.ToString();
        }

        private void ListBoxFill()
        {
            string lineString;
            string prodIDFillString;
            string prodDescriptionFillString;
            string prodUnitFillString;
            string prodUnitPriceFillString;

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                candyTXTFileStreamReader = File.OpenText(openFileDialog1.FileName);

                while (!candyTXTFileStreamReader.EndOfStream)       // while NOT EOF
                {                       // input first record
                    lineString = candyTXTFileStreamReader.ReadLine();

                    var field1 = lineString.Split(',');

                    prodIDFillString = field1[0].Trim();

                    //      var field2 = lineString.Split(',');
                    prodDescriptionFillString = field1[1].Trim();

                    prodUnitFillString = field1[2].Trim();

                    prodUnitPriceFillString = field1[3].Trim();

                    prodIDListBox.Items.Add(prodIDFillString);
                    prodDescriptionListBox.Items.Add(prodDescriptionFillString);
                    prodUnitListBox.Items.Add(prodUnitFillString);
                    prodUnitPriceListBox.Items.Add("$" + prodUnitPriceFillString);
                }
                candyTXTFileStreamReader.Close();
            }
            else
            {
                MessageBox.Show("File Open was Cancelled");
            }
        }

        private bool ValidateInputs()
        {
            bool validateBool = true;
            errorProviderName.SetError(nameTextBox, "");
            errorProviderProdID.SetError(prodIDMaskedTextBox, "");
            errorProviderAddress.SetError(addressTextBox, "");
            errorProviderCity.SetError(cityTextBox, "");
            errorProviderState.SetError(stateTextBox, "");
            errorProviderZipCode.SetError(zipCodeMaskedTextBox, "");
            errorProviderPhone.SetError(phoneMaskedTextBox, "");
            errorProviderDiscount.SetError(discountGroupBox, "");
            errorProviderQuantity.SetError(quantityMaskedTextBox, "");

            if (discountCheckBox.Checked && frequentCustomerRadioButton.Checked != true && corporateRadioButton.Checked != true)
            {
                validateBool = false;
                errorProviderDiscount.SetError(discountGroupBox, "Please select a Discount Amount or uncheck box!");
            }
            else
            {               
                    if (nameTextBox.Text.Trim().Length > 0)
                    {
                        if (addressTextBox.Text.Trim().Length > 0)
                        {
                            if (cityTextBox.Text.Trim().Length > 0)
                            {
                                if (stateTextBox.Text.Trim().Length > 0)
                                {
                                    if (zipCodeMaskedTextBox.Text.Length == 5)
                                    {
                                        if (phoneMaskedTextBox.Text.Length == 14)
                                        {                                            
                                            try
                                            {
                                                if (prodIDMaskedTextBox.Text.Length != 3)
                                                {
                                                    validateBool = false;
                                                    errorProviderProdID.SetError(prodIDMaskedTextBox, "Please enter a three digit product ID!");
                                                }
                                                else
                                                {
                                                    if (prodIDListBox.Items.Contains(prodIDMaskedTextBox.Text) | prodIDListBox.SelectedIndex > -1)
                                                    {
                                                        validateBool = true;
                                                        prodIDListBox.SelectedItem = prodIDMaskedTextBox.Text;                                                        
                                                        singleLineItemObject.ProductID = int.Parse(prodIDListBox.SelectedItem.ToString());
                                                        try
                                                        {
                                                            singleLineItemObject.Quantity = int.Parse(quantityMaskedTextBox.Text);
                                                        }
                                                        catch
                                                        {
                                                            errorProviderQuantity.SetError(quantityMaskedTextBox, "Please enter a quantity in the Text Box!");
                                                        }                                                        
                                                        singleLineItemObject.ProductDescription = prodDescriptionListBox.SelectedItem.ToString();
                                                        singleLineItemObject.ProductUnit = prodUnitListBox.SelectedItem.ToString();
                                                        singleLineItemObject.ProductUnitPrice = decimal.Parse((prodUnitPriceListBox.SelectedItem.ToString()).TrimStart('$'));
                                                    }
                                                    else
                                                    {
                                                        errorProviderProdID.SetError(prodIDMaskedTextBox, "Please enter a valid Product ID!");
                                                    }
                                                }
                                            }                    
                                            catch
                                            {
                                                validateBool = false;
                                                errorProviderProdID.SetError(prodIDMaskedTextBox, "Please enter valid integer values for Product ID!");
                                            }
                                        }
                                        else
                                        {
                                            validateBool = false;
                                            errorProviderPhone.SetError(phoneMaskedTextBox, "Please enter a valid 10-digit phone number!");
                                        }
                                    }
                                    else
                                    {
                                        validateBool = false;
                                        errorProviderZipCode.SetError(zipCodeMaskedTextBox, "Please enter a valid 5-digit zip code!");
                                    }
                                }
                                else
                                {
                                    validateBool = false;
                                    errorProviderState.SetError(stateTextBox, "Enter a State into the State Text Box!");
                                }
                            }
                            else
                            {
                                validateBool = false;
                                errorProviderCity.SetError(cityTextBox, "Enter a City into the City Text Box!");
                            }
                        }
                        else
                        {
                            validateBool = false;
                            errorProviderAddress.SetError(addressTextBox, "Enter an Address into the Address Text Box!");
                        }
                    }
                    else
                    {
                        validateBool = false;
                        errorProviderName.SetError(nameTextBox, "Enter a Name into the Name Text Box!");
                    }
            }
            return validateBool;
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            prodIDListBox.SelectedIndex = 3;
            nameTextBox.Text = "Tim";
            addressTextBox.Text = "345 Merry Ln.";
            cityTextBox.Text = "Kalamazoo";
            stateTextBox.Text = "MI";
            zipCodeMaskedTextBox.Text = "55555";
            phoneMaskedTextBox.Text = "5555555555";
            prodIDMaskedTextBox.Text = "123";
            quantityMaskedTextBox.Text = "3";
        }

 
    }
}
