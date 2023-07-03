// DATA WHICH CAN BE USED in a method
// 1) IN FROM CALLER - regular parameters (ONE OR MANY)
// 2) IN FROM USER - using ReadLine (& maybe converting), after prompting
// 3) OUT TO CALLER - a return value (JUST ONE)
// 4) OUT TO USER - using Write or WriteLine
// 5) "local" VARIABLES - can use or change:
//      a) private instance variables in THIS CLASS
//      b) local variables declared in THIS METHOD
//***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxParamReturn
{
    class Box
    {
        // ----------------- INSTANCE VARIABLES -------------------
        // These are always private
        //---------------------------------------------------------
        private int length;
        private int width;
        private int height;

        // -------------------- METHODS ---------------------------
        // These are public
        //---------------------------------------------------------

        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        // No input parameters - no return value
        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        public void GetData()
        {
            Console.Write("Enter length: ");
            length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter width: ");
            width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter height: ");
            height = Convert.ToInt32(Console.ReadLine());
        }
        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        // METHOD W/ NO INPUT PARAMETERS & 1 OUTPUT - AN INTEGER AS THE RETURN VALUE
        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        public int FindVolume()
        {
            int v;
            v = length * width * height;
            return v;
        }

        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        // ONE INPUT PARAMETER - no return value - VOLUME IS SENT FROM MAIN INTO V
        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        public void ShowVolume(int v)                       // A CONSTRUCTOR 
        {
            Console.WriteLine("\nVOLUME is {0}", v);
        }

        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        // No input parameters - no return value
        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        public void FindNShowFootprint()
        {
            Console.WriteLine("\nFOOTPRINT is {0}\n", length * width);
        }
    }
}
 