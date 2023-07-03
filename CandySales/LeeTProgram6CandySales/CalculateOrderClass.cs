using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeTProgram6CandySales
{
    class CalculateOrderClass
    {
        // Private Backing Fields
        private int _prodIDCalculateInteger;
        private int _quantityCalculateInteger;
        private string _prodDescriptionCalculateString;
        private string _prodUnitCalcluateString;
        private decimal _unitPriceCalculateDecimal;
        private decimal _totalTaxCalculateDecimal;
        private decimal _extendedPriceDecimal;
        //private virtual decimal _discountAmountDecimal;
        //private virtual decimal _amountDueAfterDiscountDecimal;
        private decimal _taxAmountDecimal;
        private const decimal _TAX_RATE = .06m;
        private int _totalNumberofCandyUnitsInteger;


        private static int _totalNumberofCustomersInteger;

        // Parameterized Constructors
        public CalculateOrderClass(bool customerAccumulate) 
        {
            if (customerAccumulate)
                _totalNumberofCustomersInteger += _totalNumberofCustomersInteger;
        }  // overloaded constructor for Derived methods

        public CalculateOrderClass(SingleOrderObject singleSaleObject, bool customerAccumulate)
        {
            ProductIDCalculate = singleSaleObject.ProductID;
            QuantityCalculate = singleSaleObject.Quantity;
            ProductDescriptionCalculate = singleSaleObject.ProductDescription;
            ProductUnitCalculate = singleSaleObject.ProductUnit;
            ProductUnitPriceCalculate = singleSaleObject.ProductUnitPrice;

            _extendedPriceDecimal = CalculateSale(_prodUnitCalcluateString, _unitPriceCalculateDecimal, _quantityCalculateInteger, _TAX_RATE);
            //_amountDueAfterDiscountDecimal = _extendedPriceDecimal - _discountAmountDecimal;
            _taxAmountDecimal = _extendedPriceDecimal * _TAX_RATE;
            //_amountDueAfterDiscountDecimal = _amountDueAfterDiscountDecimal - _taxAmountDecimal;
            _totalTaxCalculateDecimal += _taxAmountDecimal;
            _taxAmountDecimal = 0m;
            _totalNumberofCandyUnitsInteger += _quantityCalculateInteger;

            if (customerAccumulate)
                _totalNumberofCustomersInteger += _totalNumberofCustomersInteger;
        }

        // Public Properties
        public int ProductIDCalculate
        {
            get { return _prodIDCalculateInteger; }
            set { _prodIDCalculateInteger = value; }
        }

        public virtual int QuantityCalculate
        {
            get { return _quantityCalculateInteger; }
            set { _quantityCalculateInteger = value; }
        }

        public string ProductDescriptionCalculate
        {
            get { return _prodDescriptionCalculateString; }
            set { _prodDescriptionCalculateString = value; }
        }

        public virtual string ProductUnitCalculate
        {
            get { return _prodUnitCalcluateString; }
            set { _prodUnitCalcluateString = value; }
        }

        public virtual decimal ProductUnitPriceCalculate
        {
            get { return _unitPriceCalculateDecimal; }
            set { _unitPriceCalculateDecimal = value; }
        }

        public virtual decimal ExtendedPrice
        {
            get { return _extendedPriceDecimal; }
            set { _extendedPriceDecimal = value; }
        }

        public virtual decimal TotalTaxAmount
        {
            get { return _totalTaxCalculateDecimal; }
            set { _totalTaxCalculateDecimal = value; }
        }

        public virtual int TotalNumberOfCandyUnits
        {
            get { return _totalNumberofCandyUnitsInteger; }
            set { _totalNumberofCandyUnitsInteger = value; }
        }

        public int TotalNumberOfCustomers
        {
            get { return _totalNumberofCustomersInteger; }
            set { _totalNumberofCustomersInteger = value; }
        }

        public virtual decimal TAX_RATE
        {
            get { return _TAX_RATE; }
        }

        // Private Methods
        private decimal CalculateSale(string units, decimal priceperunit, int quantity, decimal TAX_RATE)
        {
            // TAX_RATE passing is left over from another idea..  Quicker to comment here than sort through lots of code...
            //decimal taxAmountDecimal;
            decimal returnValue = 0m;

            returnValue = (priceperunit * quantity);

            return returnValue;
        }

        private void CalculateTaxBase()
        {

        }

        public virtual void CaculateDiscountFrequent()
        {
           // _amountDueAfterDiscountDecimal = _extendedPriceDecimal - _discountAmountDecimal;
        }

        public virtual void CalculateDiscountCorporate()
        {
            //_amountDueAfterDiscountDecimal = _extendedPriceDecimal - _discountAmountDecimal;
        }

        public virtual void CalculateTaxDerived()
        {
            //_taxAmountDecimal = _amountDueAfterDiscountDecimal * _TAX_RATE;
            //_amountDueAfterDiscountDecimal = _amountDueAfterDiscountDecimal - _taxAmountDecimal;
            
        }

        public virtual void DetermineDiscountAmount() { }

    }
}
