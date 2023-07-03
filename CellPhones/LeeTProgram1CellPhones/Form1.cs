/// Timothy Lee
/// 9/23/12
/// ClassPointofView:
/// - The point of this assignment is to make sure that we know the basics of using Visual Studio.  We need to
///   make sure we know how to use forms, tools, properties of objects, variables, various controls and methods.
/// BusinessPointofView:
/// - Create a simple to use form for inputting information so a customer can have a record of their purchase.
/// 



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
    public partial class phoneForm : Form
    {        
        public phoneForm()
        {
            InitializeComponent();
        }

        private void phoneForm_Load(object sender, EventArgs e)
        {
            richTextBox.LoadFile("RichTextHeader.rtf");  // Load rich text file into rich text box...

            nameTextBox.Text = "hello";
            nameTextBox.SelectionStart = 0;
            nameTextBox.SelectionLength = nameTextBox.Text.Length;

        }

        private void displayHeaderCheckBox_CheckedChanged(object sender, EventArgs e)  // Event signaling the 
                                                                     //  display header checkbox was changed...
        {
            richTextBox.Visible = displayHeaderCheckBox.Checked;  //  connecting the visible state of the rich
                                        // text box with the checked state of the display header.
        }

        private void galaxyRadioButton_CheckedChanged(object sender, EventArgs e) //  Radio Button event...
        {
            descriptionLabel.Text = "Samsung Galaxy S3";  // Adding a description...
        }

        private void iPhoneRadioButton_CheckedChanged(object sender, EventArgs e)  //  Radio Button event...
        {
            descriptionLabel.Text = "Apple iPhone 5";    // Adding a description...
        }

        private void lumiaRadioButton_CheckedChanged(object sender, EventArgs e)  //  Radio Button event...
        {
            descriptionLabel.Text = "Nokia Lumia 900";   // Adding a description...
        }

        private void optimusRadioButton_CheckedChanged(object sender, EventArgs e)  //  Radio Button event...
        {
            descriptionLabel.Text = "LG Optimus G";   // Adding a description...
        }

        private void deliveryCheckBox_CheckedChanged(object sender, EventArgs e)  //  Radio Button event...
        {
            deliveryLabel.Enabled = deliveryCheckBox.Checked;
        }

        private void displayButton_Click(object sender, EventArgs e)  // Button Click Event...
        {
            displayForm displayForm = new displayForm();   // Instantiating a displayForm Form
            displayForm.nameString = nameTextBox.Text;       // Passing value to displayForm var
            displayForm.addressString = addressTextBox.Text;   // Passing value to displayForm var
            displayForm.cityString = cityTextBox.Text;   // Passing value to displayForm var
            displayForm.stateString = stateComboBox.Text;   // Passing value to displayForm var
            displayForm.zipCodeString = zipCodeTextBox.Text;   // Passing value to displayForm var
            displayForm.dateString = dateMaskedTextBox.Text;   // Passing value to displayForm var
            displayForm.itemAmountString = itemAmountTextBox.Text;   // Passing value to displayForm var
            displayForm.phoneTypeString = descriptionLabel.Text;   // Passing value to displayForm var
            displayForm.phoneColorString = descriptionLabel.ForeColor.Name;   // Passing value to displayForm var
            displayForm.deliveryMessageDisplay = deliveryCheckBox.Checked;   // Passing value to displayForm var
            displayForm.ShowDialog();  // Showing instantiated form
        }
                    

        //private void printPreviewButton_Click(object sender, EventArgs e)  // Button Click Event...
        //{

        //}

        private void clearButton_Click(object sender, EventArgs e)  // Button Click Event...
        {
            nameTextBox.Clear();  // Clearing
            nameTextBox.Focus();  // putting focus on textbox for easy input

            addressTextBox.Clear();  // Clearing
            stateComboBox.Text = "";  // Clearing
            zipCodeTextBox.Clear();  // Clearing
            dateMaskedTextBox.Clear();  // Clearing

            galaxyRadioButton.Checked = true;  // Resetting Radio Buttons
            galaxyRadioButton.Checked = false;   // Resetting Radio Buttons
            blackRadioButton.Checked = true;  // Resetting Radio Buttons
            blackRadioButton.Checked = false;  // Resetting Radio Buttons
            phonePictureBox.Image = null;     // Resetting picturebox
            galaxyRadioButton.TabStop = true;  // Reset Tabs

            displayHeaderCheckBox.Checked = false;  // Reset Checkbox
            deliveryCheckBox.Checked = false;  // Reset Checkbox

            descriptionLabel.Text = "Description:";  // Reset Label

        }

        private void exitButton_Click(object sender, EventArgs e)  // Button Click Event...
        {
            this.Close();  // Closes the form and terminates the program...
        }

        private void blackRadioButton_CheckedChanged(object sender, EventArgs e) // Color Pick Radio Button Event.
        {
            if (galaxyRadioButton.Checked)          // Decision deciding which RadioButton was previously clicked.
            {
                phonePictureBox.Image = Properties.Resources.GalaxyBlack;  // Assigning a colorpicture to picturebox.
            }
            else if (iPhoneRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.iPhoneBlack;  // Assigning a color...
            }
            else if (lumiaRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.LumiaBlack;  // Assigning a color...
            }
            else if (optimusRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.OptimusBlack;  // Assigning a color...
            }

            descriptionLabel.ForeColor = Color.Black;   // Changing the text color...
        }

        private void whiteRadioButton_CheckedChanged(object sender, EventArgs e)  // Color Pick Radio Button Event.
        {
            if (galaxyRadioButton.Checked)  // Decision deciding which RadioButton was previously clicked.
            {
                phonePictureBox.Image = Properties.Resources.GalaxyWhite;  // Assigning a color...
            }
            else if (iPhoneRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.iPhoneWhite;  // Assigning a color...
            }
            else if (lumiaRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.LumiaWhite;  // Assigning a color...
            }
            else if (optimusRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.OptimusWhite;  // Assigning a color...
            }

            descriptionLabel.ForeColor = Color.White;  // Changing the text color...
        }

        private void redRadioButton_CheckedChanged(object sender, EventArgs e)  // Color Pick Radio Button Event.
        {
            if (galaxyRadioButton.Checked)  // Decision deciding which RadioButton was previously clicked.
            {
                phonePictureBox.Image = Properties.Resources.GalaxyRed;  // Assigning a color...
            }
            else if (iPhoneRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.iPhoneRed;  // Assigning a color...
            }
            else if (lumiaRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.LumiaRed;  // Assigning a color...
            }
            else if (optimusRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.OptimusRed;  // Assigning a color...
            }

            descriptionLabel.ForeColor = Color.Red;  // Changing the text color...
        }

        private void blueRadioButton_CheckedChanged(object sender, EventArgs e)  // Color Pick Radio Button Event.
        {
            if (galaxyRadioButton.Checked)  // Decision deciding which RadioButton was previously clicked.
            {
                phonePictureBox.Image = Properties.Resources.GalaxyBlue;  // Assigning a color...
            }
            else if (iPhoneRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.iPhoneBlue;  // Assigning a color...
            }
            else if (lumiaRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.LumiaBlue;  // Assigning a color...
            }
            else if (optimusRadioButton.Checked)
            {
                phonePictureBox.Image = Properties.Resources.OptimusBlue;  // Assigning a color...
            }

            descriptionLabel.ForeColor = Color.Blue;  // Changing the text color...
        }

        

       

    }
}
