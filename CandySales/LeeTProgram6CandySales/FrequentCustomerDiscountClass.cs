using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeTProgram6CandySales
{
    class FrequentCustomerDiscountClass : CalculateOrderClass
    {
        // Private backing fields

        private  decimal _discountAmountDecimal = 0m;
        private decimal _amountDueAfterDiscountDecimal;
        private decimal _extendedPriceDerivedDecimal;
        private int _quantityCalculateDerivedInteger;
        private string _prodUnitCalcluateDerivedString;
        private decimal _unitPriceCalculateDerivedDecimal;
        private const decimal _TAX_RATE_DERIVED_DECIMAL = .06m;
        private decimal _taxAmountDerivedDecimal;
        private decimal _totalTaxCalculateDerivedDecimal;
        private int _totalNumberofCandyUnitsDerivedInteger;
        


        // Parameterized Constructors
        public FrequentCustomerDiscountClass(SingleOrderObject singleSaleObject, bool customerAccumulate)
            : base(customerAccumulate)
        {
            ProductIDCalculate = singleSaleObject.ProductID;
            QuantityCalculate = singleSaleObject.Quantity;
            ProductDescriptionCalculate = singleSaleObject.ProductDescription;
            ProductUnitCalculate = singleSaleObject.ProductUnit;
            ProductUnitPriceCalculate = singleSaleObject.ProductUnitPrice;

            _extendedPriceDerivedDecimal = CalculateSale(_prodUnitCalcluateDerivedString, _unitPriceCalculateDerivedDecimal, _quantityCalculateDerivedInteger, _TAX_RATE_DERIVED_DECIMAL);
            DetermineDiscountAmount();
            CaculateDiscountFrequent();
            CalculateTaxDerived();
            _totalNumberofCandyUnitsDerivedInteger += _quantityCalculateDerivedInteger;
        }

        // Public Properties
        public decimal AmountDueAfterDiscount
        {
            get { return _amountDueAfterDiscountDecimal; }
            set { _amountDueAfterDiscountDecimal = value; }
        }

        public decimal DiscountAmount
        {
            get { return _discountAmountDecimal; }
            set { _discountAmountDecimal = value; }
        }
        
        public override int QuantityCalculate
        {
            get { return _quantityCalculateDerivedInteger; }
            set { _quantityCalculateDerivedInteger = value; }
        }
                
        public override string ProductUnitCalculate
        {
            get { return _prodUnitCalcluateDerivedString; }
            set { _prodUnitCalcluateDerivedString = value; }
        }

        public override decimal ProductUnitPriceCalculate
        {
            get { return _unitPriceCalculateDerivedDecimal; }
            set { _unitPriceCalculateDerivedDecimal = value; }
        }

        public override decimal ExtendedPrice
        {
            get { return _extendedPriceDerivedDecimal; }
            set { _extendedPriceDerivedDecimal = value; }
        }

        public override decimal TotalTaxAmount
        {
            get { return _totalTaxCalculateDerivedDecimal; }
            set { _totalTaxCalculateDerivedDecimal = value; }
        }

        public override int TotalNumberOfCandyUnits
        {
            get { return _totalNumberofCandyUnitsDerivedInteger; }
            set { _totalNumberofCandyUnitsDerivedInteger = value; }
        }        

        public override decimal TAX_RATE
        {
            get { return _TAX_RATE_DERIVED_DECIMAL; }
        }
  
        // Private Methods
        private decimal CalculateSale(string units, decimal priceperunit, int quantity, decimal TAX_RATE)
        {
            decimal returnValue = 0m;

            returnValue = (priceperunit * quantity);  // add in discount amount...

            return returnValue;
        }

        public override void CaculateDiscountFrequent()
        {
            _amountDueAfterDiscountDecimal = _extendedPriceDerivedDecimal - _discountAmountDecimal;
        }

        public override void CalculateTaxDerived()
        {
            _taxAmountDerivedDecimal = _amountDueAfterDiscountDecimal * _TAX_RATE_DERIVED_DECIMAL;
            _amountDueAfterDiscountDecimal = _amountDueAfterDiscountDecimal - _taxAmountDerivedDecimal;

            _totalTaxCalculateDerivedDecimal += _taxAmountDerivedDecimal;
            _taxAmountDerivedDecimal = 0m;
        }

        public override void DetermineDiscountAmount()
        {
            decimal discountRateDecimal;
            int switchDeciderInteger;
            switchDeciderInteger = (int)(_unitPriceCalculateDerivedDecimal / 10);

            switch (switchDeciderInteger)
            {
                case 0:
                    discountRateDecimal = .1m;
                    break;
                case 1:
                    discountRateDecimal = .1m;
                    break;
                case 2:
                    discountRateDecimal = .2m;
                    break;
                default:
                    discountRateDecimal = .2m;
                    break;
            }
            _discountAmountDecimal = _unitPriceCalculateDerivedDecimal * discountRateDecimal;                
        }
    }
}
