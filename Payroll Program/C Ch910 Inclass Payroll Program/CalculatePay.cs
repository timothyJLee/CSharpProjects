// THIS IS YOUR TYPICAL DOCUMENTATION....
// THIS IS THE BUSINESS TIER CLASS TO CALCULATE PAY FOR AN EMPLOYEE


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// using System.Windows.Forms;

namespace C_Ch910_Inclass_Payroll_Program
{
    class CalculatePay
    {
        // PART 1:  PRIVATE INSTANCE VARIABLES: *(AKA:  Backing Fields)

        protected int  _hoursInteger;          // set from form/ 'protected Access Modifier to both
        protected decimal _rateDecimal;         // base class & inherited class can use backing field

        protected decimal _grossPayDecimal;   // calculated here when NO HAZARD PAY
        private decimal _taxesDecimal;
        private decimal _netPayDecimal;

        private const decimal _TAX_RATE_DECIMAL = .06m;

        // ACCUMULATORS:                    ' static' retains values w/ @ instantiation
        private static int _totalNoEmployeesInteger;
        private static decimal _totalTaxesDecimal;

        // PART 2:  CONSTRUCTOR

        // What's the constructor do:    
        //      a) accept data from Pres. tier (form)
        //      b) assigns data(parameters) to the Properties via the SET accessor
        //      c) calls processes (methods)

        // PARAMETERIZED CONSTRUCTOR:
        public CalculatePay(int passedHours, decimal passedRate)  // (a)
        {
            Hours = passedHours;                                    // (b) assigning parameter value to Property
            Rate = passedRate;

            //                                                      (c)
            CalculateGross();               // when NO HAZARD PAY
            CalculatePayroll();
            Accumulations();
          
        }

        // EMPTY  CONSTRUCTOR:

        public CalculatePay() { }           // overloaded constructor

    ////    public CalculatePay(bool clear)
    //    {
    //        if (clear)
    //            ClearAccumulators();
    //    }

        //public CalculatePay(DialogResult clear)       // passing in dialog result (need using at top)
        //{
        //    if (clear == DialogResult.Yes)
        //        ClearAccumulators();
        //}

        //public CalculatePay(string clear)
        //{
        //    if (clear == "Yes")
        //        ClearAccumulators();
        //}

        // PART 3: PROPERTIES
        // ******* INPUT properties
        public int Hours
        {
            set                     // SETting the parm passed into backing field/Priv instance Var's
            {   _hoursInteger = value;  }
        }

        public decimal Rate
        {
            set  
            {
                _rateDecimal = value;
            }
        }
// ******* OUTPUT properties
        public decimal GrossPay         // calculated values that will be 'returned' to the form
        {                               // for display purposes (OUTPUT)
            get  { return _grossPayDecimal; }
        }

        public decimal Taxes
        {                                
            get
            {
                return _taxesDecimal;
            }
        }

        public decimal NetPay
        {
            get
            {
                return _netPayDecimal;
            }
        }

  // *******  ACCUMULATOR PROPERTIES ***

        public static int TotalEmployees
        {
            get { return _totalNoEmployeesInteger; }
            set { _totalNoEmployeesInteger = value; }
        }

        public static decimal TotalTaxes
        {
            get { return _totalTaxesDecimal; }
            set { _totalTaxesDecimal = value; }
        }

 // PART 4: METHODS TO DO THE PROCESSING:

        protected virtual void CalculateGross()         // virtual 'ALLOWS" method to be overridden
        {                               // Calculation of GROSS PAY w/o HAZARD PAY
            _grossPayDecimal = _hoursInteger * _rateDecimal;
        }

        private void CalculatePayroll()     // Calcs of Taxes & Net pay's (whether hazard pay or not)
        {
            _taxesDecimal = Math.Round( _grossPayDecimal * _TAX_RATE_DECIMAL, 2);  // round to 2 dec.
            _netPayDecimal = _grossPayDecimal - _taxesDecimal;
        }

        private void Accumulations()      // accum # employees processed and total Taxes Paid
        {
            _totalNoEmployeesInteger += 1;
            _totalTaxesDecimal += _taxesDecimal;
        }

        //private void ClearAccumulators()
        //{
        //    _totalNoEmployeesInteger = 0;
        //    _totalTaxesDecimal = 0;
        //}


    }
}
