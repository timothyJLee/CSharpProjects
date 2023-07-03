using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserInputItemAssignment0TLee
{
    public partial class ItemInputForm : Form
    {
        public ItemInputForm()
        {
            InitializeComponent();
        }

        //Presentation Class Variables
        private bool headerBool;
        private string headerString = "Item Input Reciept for User:" + Environment.NewLine + "By: Timothy Lee" + Environment.NewLine + Environment.NewLine +
                "Name:                  Quantity:             Price:             Total: " + Environment.NewLine +
                "______________________________________________" + Environment.NewLine;

        private string itemNameString;
        private int itemQuantityInteger;
        private double itemPriceDouble;

        private int numberItemsInputedInteger = 0;

        private Item[] userInputItems = new Item[9];

        private void ItemInputForm_Load(object sender, EventArgs e)
        {
            outputLabel.Text = string.Empty;
            headerBool = true;
        }

        private void totalButton_Click(object sender, EventArgs e)
        {
            if (headerBool)
            {
                outputLabel.Text = headerString;
                headerBool = false;
            }

            if (ValidateInputs())
            {
                ProcessOneItem();
                numberItemsInputedInteger++;
            }

            if (numberItemsInputedInteger >= 9)
            {
                //printArrayButton.Enabled = false;
                totalButton.Enabled = false;
                userTotalButton_Click(sender, e);
            }
            ClearForNewItem();
        }

        private void userTotalButton_Click(object sender, EventArgs e)
        {
            if (headerBool)
            {
                outputLabel.Text = headerString;
                headerBool = false;
            }

            if (ValidateInputs() && totalButton.Enabled == true)
            {
                ProcessOneItem();
                numberItemsInputedInteger++;
            }

            outputLabel.Text += Environment.NewLine + "Final Total:  " + Item.TotalDueAllItems.ToString("c");  // COME BACK AND PUT IN FINAL TOTALS!

            totalButton.Enabled = false;
            userTotalButton.Enabled = false;
            headerBool = true;
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            headerBool = true;
            Item.TotalDueAllItems = 0;
            numberItemsInputedInteger = 0;
            ClearForNewUser();
        }

        private void ClearForNewItem()
        {
            nameTextBox.Text = string.Empty;
            nameTextBox.Focus();
            nameTextBox.SelectAll();
            quantityTextBox.Text = string.Empty;
            priceTextBox.Text = string.Empty;
        }

        private void ClearForNewUser()
        {
            ClearForNewItem();
            totalButton.Enabled = true;
            userTotalButton.Enabled = true;
            printArrayButton.Enabled = true;
            outputLabel.Text = "";
        }

        private bool ValidateInputs()
        {
            bool returnBool = false;

            nameTextBoxErrorProvider.SetError(nameTextBox, "");
            quantityTextBoxErrorProvider.SetError(quantityTextBox, "");
            priceTextBoxErrorProvider.SetError(priceTextBox, "");

            if (nameTextBox.Text.Trim().Length > 0)
            {
                if (quantityTextBox.Text.Trim().Length > 0)
                {
                    if (priceTextBox.Text.Trim().Length > 0)
                    {
                        try
                        {
                            itemQuantityInteger = int.Parse(quantityTextBox.Text);
                            try
                            {
                                itemPriceDouble = double.Parse(priceTextBox.Text);
                                itemNameString = nameTextBox.Text;
                                returnBool = true;
                            }
                            catch
                            {
                                priceTextBoxErrorProvider.SetError(priceTextBox, "Please enter a proper numerical value for the Price in the Text Box!");
                                returnBool = false;
                            }    
                        }
                        catch
                        {
                            quantityTextBoxErrorProvider.SetError(quantityTextBox, "Please enter an integer value quantity in the Text Box!");
                            returnBool = false;
                        }              
                    }
                    else
                    {
                        priceTextBoxErrorProvider.SetError(priceTextBox, "Please enter a price for the Item!");
                        returnBool = false;
                    }
                }
                else
                {
                    quantityTextBoxErrorProvider.SetError(quantityTextBox, "Please enter the amount of Items to purchase!");
                    returnBool = false;
                }
            }
            else
            {
                nameTextBoxErrorProvider.SetError(nameTextBox, "Please enter a name for the Item!");
                returnBool = false;
            }

            return returnBool;
        }

        private void ProcessOneItem()
        {
            userInputItems[numberItemsInputedInteger] = new Item(itemNameString, itemQuantityInteger, itemPriceDouble);
            outputLabel.Text += userInputItems[numberItemsInputedInteger].OutputLabel;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "SHINY BLK LRG rod";
            quantityTextBox.Text = "11";
            priceTextBox.Text = "13.99";
        }

        private void printArrayButton_Click(object sender, EventArgs e)
        {
            // To meet the requirements for the assignment to have at least one loop
            outputLabel.Text += Environment.NewLine + Environment.NewLine;
            for (int i = 0; i <= numberItemsInputedInteger - 1; i++)
            {
                userInputItems[i] = new Item(itemNameString, itemQuantityInteger, itemPriceDouble);
                outputLabel.Text += userInputItems[i].Name + Environment.NewLine;
            }
        }        
    }
}
