using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserInputItemAssignment0TLee
{
    class Item
    {
        // Private Backing fields/variables
        private string _nameString;
        private string _outputLabelString;
        private int _quantityInteger;
        private double _priceDouble;
        private double _totalDueDouble;

        private static double _totalAmountDueTotalDouble;

        // Default and Parameterized Constructors
        public Item() { }

        public Item(string passedString, int passedQuantity, double passedPrice)
        {
            Name = passedString;
            Quantity = passedQuantity;
            Price = passedPrice;

            _totalDueDouble = CalculateTotal(_quantityInteger, _priceDouble);
            _outputLabelString = DisplayInformation(_nameString, _quantityInteger, _priceDouble, _totalDueDouble);

            _totalAmountDueTotalDouble += _totalDueDouble;
            _totalDueDouble = 0;
        }

        // Public Properties
        public string Name
        {
            get { return _nameString; }
            set { _nameString = value; }
        }
        public string OutputLabel
        {
            get { return _outputLabelString; }
            set { _outputLabelString = value; }
        }
        public int Quantity
        {
            get { return _quantityInteger; }
            set { _quantityInteger = value; }
        }
        public double Price
        {
            get { return _priceDouble; }
            set { _priceDouble = value; }
        }

        public double TotalDue
        {
            get { return _totalDueDouble; }
            set { _totalDueDouble = value; }
        }

        public static double TotalDueAllItems
        {
            get { return _totalAmountDueTotalDouble; }
            set { _totalAmountDueTotalDouble = value; }
        }

        // Methods to be called by the constructor BE SURE TO MAKE METHODS THAT MAKE SENSE!
        private double CalculateTotal(int pQuantityInteger, double pPriceDouble)
        {
            double totalReturnValueDouble = 0;

            totalReturnValueDouble = pQuantityInteger * pPriceDouble;

            return totalReturnValueDouble;
        }

        private string DisplayInformation(string pNameString, int pQuantityInteger, double pPriceDouble, double pTotalDouble)
        {
            string outputLabelReturnString = string.Empty;

            outputLabelReturnString = pNameString + "        " + pQuantityInteger + "        " + pPriceDouble.ToString("c") + "        " + pTotalDouble.ToString("c") + Environment.NewLine;

            return outputLabelReturnString;
        }
    }
}