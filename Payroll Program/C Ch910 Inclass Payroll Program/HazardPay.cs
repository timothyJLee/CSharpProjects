
// DERIVED FROM CalculatePay to CALCULATE THE HAZARD PAY FOR AN EMPLOYEE:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_Ch910_Inclass_Payroll_Program
{

    class HazardPay : CalculatePay          // line the 'inherits' CalculatePay
    {
        const decimal HAZARD_PAY_Decimal = 3m;      // $3.00 is current per hour hazard rate

        public HazardPay(int passedHours, decimal passedRate) : base(passedHours, passedRate)
        {

        }

      protected override void  CalculateGross()     // overrides CalculateGross in Base Class
    {                                               //                           (CalculatePay)
         _grossPayDecimal = _hoursInteger * (_rateDecimal + HAZARD_PAY_Decimal)  ;
    }

    }
}
