// This program is the same as RandomNum except that it's MODULARIZED
// by declaring static methods, and having Main just CALL those methods.
// ------------------------------------------------------------------------
// NOTE:  Several changes were needed besides this modularizing:
//      1) the 2 declarations:  double dNum and int iNum
//          were declared in Main,
//          so they are thus not accessible from within the other methods.
//          THE FIX:  make the appropriate declaration LOCALLY in any
//                      method which needs such a variable.
//      2) Random ranNum = new Random();
//          is declared in Main,
//          so this object in not accessible from within the other methods.
//          THE FIX:  pass the ranNum object from Main to the methods as a PARAMETER.
// ------------------------------------------------------------------------

using System;

namespace RandomNumSM
{
    class Program
    {
        static void Main()
        {
            Random ranNum = new Random();
                            // NOTE: no parameters in call to constructor

            ShowRandomDoubles(ranNum);
            ShowRandomIntegers(ranNum);
            ShowRandomInt1To9(ranNum);
            ShowRandomInt20To27(ranNum);
            ShowRandomLetters(ranNum);
            ShowRandomBools(ranNum);
            ShowRandomDoublesWithOffset(ranNum);
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        // NextDouble() returns the next random DOUBLE between 0.0 and 1.0

        static void ShowRandomDoubles(Random ranNum)
        {
            Console.WriteLine("Random DOUBLES between 0.0 and 1.0");

            double dNum;

            for (int i = 1; i <= 10; i++)
            {
                dNum = ranNum.NextDouble();
                Console.WriteLine(dNum);
            }
            Console.WriteLine();
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        // Next() returns the next random INTEGER between 0 and int.MaxValue

        static void ShowRandomIntegers(Random ranNum)
        {
            Console.WriteLine("Random INTEGERS between 0 and MaxValueForAnInt" +
                " (which is {0})", int.MaxValue);

            int iNum;

            for (int i = 1; i <= 15; i++)
            {
                iNum = ranNum.Next();
                Console.WriteLine("{0,10}", iNum);
            }
            Console.WriteLine();
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        // Next(10) returns the next random integer BETWEEN 0 AND 10-1
        //      [Just USE the number, don't STORE it].

        static void ShowRandomInt1To9(Random ranNum)
        {
            Console.WriteLine("Random INTEGERS between 0 and 9");
    
            for (int i = 1; i <= 20; i++)
                Console.Write("{0}  ", ranNum.Next(10));

            Console.WriteLine('\n');
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        // Next(20,28) returns the next random integer BETWEEN 20 AND 28-1
        //      [Just USE the number, don't STORE it].

        static void ShowRandomInt20To27(Random ranNum)
        {
            Console.WriteLine("Random INTEGERS between 20 and 27");

            for (int i = 1; i <= 15; i++)
                Console.Write("{0}  ", ranNum.Next(20, 28));

            Console.WriteLine("\n");
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        // Next(1,4) returns the next random integer between 1 and 4-1
        //				then that number is mapped to a CHAR.

        static void ShowRandomLetters(Random ranNum)
        {
            Console.WriteLine("Random LETTERS between 'A' and 'C'");

            int iNum;

            for (int i = 1; i <= 20; i++)
            {
                iNum = ranNum.Next(1, 4);

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
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        // Next(1,4) returns the next random double between 0.0 and 1.0
        //				then that number is mapped to a BOOL.

        static void ShowRandomBools(Random ranNum)
        {
            Console.WriteLine("Random BOOLEANS between false and true");

            double dNum;

            for (int i = 1; i <= 10; i++)
            {
                dNum = ranNum.NextDouble();

                if (dNum < 0.5)
                    Console.Write("{0}  ", true);
                else
                    Console.Write("{0}  ", false);
            }
            Console.WriteLine("\n");
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        // NextDouble() returns the next random double between 0.0 and 1.0
        //              Then it's multiplied by 1.5 and .25 is added.
        //				So the result is between 0.25 and 1.75.

        static void ShowRandomDoublesWithOffset(Random ranNum)
        {
            Console.WriteLine("Random DOUBLEs between 0.25 and 1.75");

            double dNum;

            for (int i = 1; i <= 10; i++)
            {
                dNum = 1.5 * ranNum.NextDouble() + 0.25;
                Console.Write("{0:F2}  ", dNum);
            }
            Console.WriteLine("\n");
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
    }
}