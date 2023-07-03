



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

namespace ItemRecursiveSortAssign1TLee
{
    public partial class DisplayFileForm : Form
    {
        public DisplayFileForm()
        {
            InitializeComponent();
        }

        private Item[] fileInputItemArray;

        private void DisplayFileForm_Load(object sender, EventArgs e)
        {
            outputLabel.Text = "";
            openFileButton.Enabled = false;
        }   

        private void openFileButton_Click(object sender, EventArgs e)
        {
            string lineString;

            string nameString;
            string quantityString;
            string priceString;            
            try
            {
                StreamReader inputFile;                
                openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFileDialog1.FileName);
                    Item[] fileInputItemArray = new Item[int.Parse(inputFile.ReadLine().Trim())];
                    int arrayIndexerInt = 0;

                    while (!inputFile.EndOfStream)       // while NOT EOF
                    {                       // input first record
                        lineString = inputFile.ReadLine();

                        var field1 = lineString.Split(';');
                        nameString = field1[0].Trim();
                        quantityString = field1[1].Trim();
                        priceString = field1[2].Trim();

                        fileInputItemArray[arrayIndexerInt] = new Item(nameString, int.Parse(quantityString), double.Parse(priceString));

                        outputLabel.Text += fileInputItemArray[arrayIndexerInt].Name + ": " + fileInputItemArray[arrayIndexerInt].Quantity.ToString() + ", " +
                                            fileInputItemArray[arrayIndexerInt].Price.ToString("c") + Environment.NewLine;

                        arrayIndexerInt++;                        
                    }
                    inputFile.Close();

                    if (nameRadioButton.Checked)
                    {
                        QuicksortByName(fileInputItemArray, 0, fileInputItemArray.Length - 1);
                    }
                    else
                    {
                        if (priceRadioButton.Checked)
                        {
                            QuicksortByPrice(fileInputItemArray, 0, fileInputItemArray.Length - 1);
                        }
                    }
                    outputLabel.Text += Environment.NewLine;
                    for (int i = 0; i < fileInputItemArray.Length; i++)
                    {
                        outputLabel.Text += fileInputItemArray[i].Name + ": " + fileInputItemArray[i].Quantity.ToString() + ", " +
                                                           fileInputItemArray[i].Price.ToString("c") + "  Total: " + fileInputItemArray[i].TotalPrice.ToString("c") + Environment.NewLine;
                    }
                }
                else
                {
                    MessageBox.Show("File Open was Cancelled");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("The error is " + err.Message);
            }
            outputLabel.Text += Environment.NewLine;           
        }

        private void QuicksortByName(Item[] fields, int leftPivot, int rightPivot)
        {
            int i = leftPivot, j = rightPivot;
            Item pivotValue = fields[(rightPivot - leftPivot) / 2];

            while (i <= j)
            {
                while (fields[i].Name.CompareTo(pivotValue.Name) < 0)
                {
                    i++;
                }

                while (fields[j].Name.CompareTo(pivotValue.Name) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    Item tempSwitchValue = fields[i];
                    fields[i] = fields[j];
                    fields[j] = tempSwitchValue;

                    i++;
                    j--;
                }
            }

            if (i != leftPivot)
            {
                if (leftPivot < j)
                {
                    QuicksortByName(fields, leftPivot, j);
                }

                if (i < rightPivot)
                {
                    QuicksortByName(fields, i, rightPivot);
                }
            }
        }
        private void QuicksortByPrice(Item[] fields, int leftPivot, int rightPivot)
        {
            int i = leftPivot, j = rightPivot;
            Item pivotValue = fields[(rightPivot - leftPivot) / 2];

            while (i <= j)
            {
                while (fields[i].TotalPrice < pivotValue.TotalPrice)
                {
                    i++;
                }

                while (fields[j].TotalPrice > pivotValue.TotalPrice)
                {
                    j--;
                }

                if (i <= j)
                {
                    Item tempSwitchValue = fields[i];
                    fields[i] = fields[j];
                    fields[j] = tempSwitchValue;

                    i++;
                    j--;
                }
            }

            if (i != leftPivot)
            {
                if (leftPivot < j)
                {
                    QuicksortByPrice(fields, leftPivot, j);
                }

                if (i < rightPivot)
                {
                    QuicksortByPrice(fields, i, rightPivot);
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sortRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            openFileButton.Enabled = true;
        }             
    }
}
