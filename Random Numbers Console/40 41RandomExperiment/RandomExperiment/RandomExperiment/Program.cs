// Objects r1 through r5 are all declared at ABOUT the same TIME when the
//      program runs.  So the constructor (which executes 5 times) seeds each
//      of the objects (stores a value it the object's instance variable),
//      all at ABOUT the SAME time with a number based on the computer's clock.
//		So their seeds are likely to all be the same.
// Object r6 is defined "much later", so it's seed is likely to be DIFFERENT
//		than the others.

using System;

namespace RandomExperiment
{
    class Program
    {
        static void Main()
        {

            Random r1 = new Random();           // NOW is the time when these
            Random r2 = new Random();           // are all seeded.
            Random r3 = new Random();
            Random r4 = new Random();
            Random r5 = new Random();

            Console.Write("\nr1:  ");
            for (int i = 1; i <= 37; i++)               // how long does this tk to run? (do 
                                                    // the 3 things 37 x's but - b/c declared
                                                    // all at the top - ends up same #


                                                    // to mk @ different - 'waste' some computer time
                Console.Write("{0} ", r1.Next(10)); // which is why r6 is different - time has passed

            Console.Write("\nr2:  ");
            for (int i = 1; i <= 37; i++)
                Console.Write("{0} ", r2.Next(10));

            Console.Write("\nr3:  ");
            for (int i = 1; i <= 37; i++)
                Console.Write("{0} ", r3.Next(10));

            Console.Write("\nr4:  ");
            for (int i = 1; i <= 37; i++)
                Console.Write("{0} ", r4.Next(10));

            Console.Write("\nr5:  ");
            for (int i = 1; i <= 37; i++)
                Console.Write("{0} ", r5.Next(10));

            int count = 0;
            for (int i = 1; i <= 10000; i++)    // a "time-waster"
                count++;

            // ************************************************************

            Random r6 = new Random();           // r6 is seeded here, much later

            Console.Write("\n\nJUST NOW DEFINED r6");

            Console.Write("\nr6:  ");
            for (int i = 1; i <= 37; i++)

                Console.Write("{0} ", r6.Next(10));

            Console.WriteLine();
        }
    }
}
/*   So note that #'s virtually same b/c of when start (seed time).  Excepts for object: r6
 * 
 * 
 * OUTPUT:

r1:  9 0 8 5 1 8 5 3 9 2 4 5 1 7 4 1 7 9 5 8 8 6 5 2 6 6 0 8 0 2 3 8 2 7 4 4 0
r2:  9 0 8 5 1 8 5 3 9 2 4 5 1 7 4 1 7 9 5 8 8 6 5 2 6 6 0 8 0 2 3 8 2 7 4 4 0
r3:  9 0 8 5 1 8 5 3 9 2 4 5 1 7 4 1 7 9 5 8 8 6 5 2 6 6 0 8 0 2 3 8 2 7 4 4 0
r4:  9 0 8 5 1 8 5 3 9 2 4 5 1 7 4 1 7 9 5 8 8 6 5 2 6 6 0 8 0 2 3 8 2 7 4 4 0
r5:  9 0 8 5 1 8 5 3 9 2 4 5 1 7 4 1 7 9 5 8 8 6 5 2 6 6 0 8 0 2 3 8 2 7 4 4 0

JUST NOW DEFINED r6
r6:  1 1 5 1 1 9 3 9 7 6 3 7 4 8 1 5 7 1 4 9 9 2 8 0 6 5 7 0 6 1 8 9 7 5 3 7 7
Press any key to continue . . .
*/