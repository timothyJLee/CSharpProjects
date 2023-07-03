// Random is a built-in class in the FCL Framework Class Library (FCL)  in System namespace,    50
//		somewhat similar to Console, Convert and Math classes.
//
// But Console, Convert and Math classes only:
//      "provide services" (i.e., static methods);
//      they do NOT "store data" (i.e., in instance variables).
// So:  1) any user of the class does NOT declare an object of the class type
//      2) calls a method of that class specifying:  className.Method
//
// Random class, however, also "stores data" besides "providing services".
// So:  1) any user of the class must DECLARE AN OBJECT OF THE CLASS
//          prior to using any of its methods,
//      2) call a method of that class specifying:  objectName.Method
//          (vs. ClassName.Method, like Console)
// --------------------------------------------------------------------------
// Two Methods in Random class that you'll use are:
//		Next        (which returns the "next" random INTEGER) and
//		NextDouble  (which returns the "next" random DOUBLE).
//
// These methods actually produce PSEUDO-RANDOM numbers
//		vs. true random numbers.
// --------------------------------------------------------------------------
// NOTE:  This is POOR PROGRAMMING STYLE.  It should be MODULARLIZED by
//      - declaring individual static methods
//      - having Main CALL those methods (rather than doing "any work") itself.
// --------------------------------------------------------------------------

using System;

namespace RandomNum
{
    class Program
    {
        static void Main()
        {
            Random ranNum = new Random();
            // NOTE: no parameters in call to constructor  (Random() is a 'constructor')
            double dNum;
            int iNum;

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
            // NextDouble() returns the next random DOUBLE between 0.0 and 1.0

            Console.WriteLine("Random DOUBLES between 0.0 and 1.0");

            for (int i = 1; i <= 10; i++)
            {
                dNum = ranNum.NextDouble();     //var = object .  next and next double mostly used
                                                //   no range so DEFAULT RANGE is 0.0 - 1.0
                Console.WriteLine(dNum);        // POSITIVE values
            }
            Console.WriteLine();

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
            // Next() returns the next random INTEGER between 0 and int.MaxValue

            Console.WriteLine("Random INTEGERS between 0 and MaxValueForAnInt" +
                " (which is {0})", int.MaxValue);

            for (int i = 1; i <= 15; i++)
            {                    // next is an overloaded method (look at it!) 0, 1, 2 parms avail.
                iNum = ranNum.Next();         
                Console.WriteLine("{0,10}", iNum);  // #'s between 0 thru 9 (not 10!!!)KNOW THIS!
            }
            Console.WriteLine();

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
            // Next(10) returns the next random integer BETWEEN 0 AND 10-1
            //      [Just USE the number, don't STORE it].

            Console.WriteLine("Random INTEGERS between 0 and 9");

            for (int i = 1; i <= 20; i++)
                Console.Write("{0}  ", ranNum.Next(10));

            Console.WriteLine('\n');

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
            // Next(20,28) returns the next random integer BETWEEN 20 AND 28-1
            //      [Just USE the number, don't STORE it].

            Console.WriteLine("Random INTEGERS between 20 and 27");

            for (int i = 1; i <= 15; i++)
                Console.Write("{0}  ", ranNum.Next(20, 28));

            Console.WriteLine("\n");

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
            // Next(1,4) returns the next random integer between 1 and 4-1
            //				then that number is mapped to a CHAR.

            Console.WriteLine("Random LETTERS between 'A' and 'C'");

            for (int i = 1; i <= 20; i++)
            {
                iNum = ranNum.Next(1, 4);           // 3 values (1, 2, 3)

                switch (iNum)
                {
                    case 1:
                        Console.Write("{0}  ", 'A');
                        break;
                    case 2:
                        Console.Write("{0}  ", 'B');
                        break;
                    case 3:
                        Console.Write("{0}  ", 'C');
                        break;
                }
            }
            Console.WriteLine('\n');

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
            // Next(1,4) returns the next random double between 0.0 and 1.0
            //				then that number is mapped to a BOOL.

            Console.WriteLine("Random BOOLEANS between false and true");

            for (int i = 1; i <= 10; i++)
            {
                dNum = ranNum.NextDouble();

                if (dNum < 0.5)
                    Console.Write("{0}  ", true);
                else
                    Console.Write("{0}  ", false);
            }
            Console.WriteLine("\n");

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
            // NextDouble() returns the next random double between 0.0 and 1.0
            //              Then it's multiplied by 1.5 and .25 is added.
            //				So the result is between 0.25 and 1.75.

            Console.WriteLine("Random DOUBLEs between 0.25 and 1.75");

            for (int i = 1; i <= 10; i++)
            {
                dNum = 1.5 * ranNum.NextDouble() + 0.25;
                Console.Write("{0:F2}  ", dNum);
            }
            Console.WriteLine("\n");

            // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        }
    }
}
/*
Random DOUBLES between 0.0 and 1.0
0.964692264778862
0.63909801684278
0.648165259346443
0.648050852887356
0.340719853220843
0.820292537482592
0.0403120755405687
0.8581224958683
0.375273479323496
0.31412819601322

Random INTEGERS between 0 and MaxValueForAnInt (which is 2147483647)
1753471860
1582793904
1210776265
1102433464
 737032146
 815129745
1991416937
 769904161
1809861140
1442849640
1233404867
 587333321
 485073235
1522402175
 846387100

Random INTEGERS between 0 and 9
5  4  8  2  9  9  9  3  0  3  4  4  0  2  4  0  3  8  0  7

Random INTEGERS between 20 and 27
25  22  24  23  21  23  27  26  20  22  25  23  27  22  26

Random LETTERS between 'A' and 'C'
A  A  B  B  B  C  B  B  A  C  C  C  A  B  B  A  B  A  C  B

Random BOOLEANS between false and true
True  False  True  True  True  True  True  True  False  False

Random DOUBLEs between 0.25 and 1.75
0.27  1.08  1.43  0.89  0.51  1.50  1.42  0.77  1.31  1.56

Press any key to continue . . .
*/