// 2 Random objects are declared in the CALLED METHOD which is REPEATEDLY CALLED.
// So the random number objects are set up and INITIALIZED (based on their seed)
//		EVERY TIME THE METHOD IS CALLED ! ! !
// This results in the SAME random number being generated (with .Next)
//      EVERY TIME THE METHOD IS CALLED.
// The problem is NOT that the random objects are declared in a called method.
//      The problem is that the method (and thus the initialization of the
//      object) is repeatedly called IN A LOOP.

using System;

namespace RandomInMethod
{
    class Program
    {
        static void Main()
        {
            for (int i = 1; i <= 20; i++)
                DoNextNumber();					// no parameters
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        public static void DoNextNumber()
        {
            Random r1 = new Random();				// DEFAULT SEED
            Random r2 = new Random(1234);			// HARDCODED SEED

            int int1, int2;

            int1 = r1.Next(10, 30);			// i.e., 10 to 30-1
            int2 = r2.Next(10, 30);			// i.e., 10 to 30-1

            Console.WriteLine("{0,4}   {1,4}", int1, int2);
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
    }
}
