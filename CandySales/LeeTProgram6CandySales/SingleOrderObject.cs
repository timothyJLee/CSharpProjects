using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeTProgram6CandySales
{
    class SingleOrderObject
    {
        // Private Backing Fields
        private int _prodIDInteger;
        private int _quantityInteger;
        private string _prodDescriptionString;
        private string _prodUnitString;
        private decimal _unitPriceDecimal;

        // Object Constructor
        public SingleOrderObject()
        {
            _prodIDInteger = 0;
            _quantityInteger = 0;
            _unitPriceDecimal = 0m;
            _prodDescriptionString = "";
            _prodUnitString = "";
        }


        // Public Properties
        public int ProductID
        {
            get { return _prodIDInteger; }
            set { _prodIDInteger = value; }
        }

        public int Quantity
        {
            get { return _quantityInteger; }
            set { _quantityInteger = value; }
        }

        public string ProductDescription
        {
            get { return _prodDescriptionString; }
            set { _prodDescriptionString = value; }
        }

        public string ProductUnit
        {
            get { return _prodUnitString; }
            set { _prodUnitString = value; }
        }

        public decimal ProductUnitPrice
        {
            get { return _unitPriceDecimal; }
            set { _unitPriceDecimal = value; }
        }
    }
}
