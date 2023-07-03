/* THIS SHOWS THE DIFFERENCE BETWEEN PASSING VARIABLES USING REF VS VAL
 *   VAL - MAKES NEW VARIABLES/LOCATIONS
 *   REF - POINTS (C TYPE LANGUAGES OFTEN USE 'POINTERS') TO 1 LOCATION FOR THE VALUE
 *          PASSED SO CHANGES WHERE EVER IT IS
 */
  

using System;

namespace Swap
{
    class Program
    {
        static void Main()                  
        {
            int a = 1;
            int b = 2;
            int c = 3;
            int d = 4;

            Console.WriteLine("a={0}, b={1}", a, b);

            Swap(ref a, ref b);		    // CALL BY REFERENCE - 1 storage location for each var

            Console.WriteLine("AFTER Swap: a={0}, b={1}\n", a, b);

            Console.WriteLine("c={0}, d={1}", c, d);

            BadSwap(c,d);		        // CALL BY VALUE - values are copied from one area to next

            Console.WriteLine("AFTER BadSwap: c={0}, d={1}\n", c, d);
        }
        // ******************************************************************
        public static void Swap(ref int x, ref int y)   // pass by reference
        {
            int temp;

            temp = x;
            x = y;
            y = temp;
        }
        // *****************************************************************
        public static void BadSwap(int x, int y)        // pass by value
        {
            int temp;

            temp = x;
            x = y;
            y = temp;
        }
        // *****************************************************************
    }
}

/* output:
a=1, b=2
AFTER Swap: a=2, b=1

c=3, d=4
AFTER BadSwap: c=3, d=4

Press any key to continue . . .*/