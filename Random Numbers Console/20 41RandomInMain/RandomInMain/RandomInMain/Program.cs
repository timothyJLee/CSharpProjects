// Random objects are declared in Main so they are set up and
//		INITIALIZED TO THE "SEED" ONLY ONCE
//			(by the constructor using the parameter).
// NOTE:  The default seed is based on the computer's System Time.

using System;

namespace RandomInMain
{
    class Program
    {
        static void Main()
        {
            Random r1 = new Random();				// DEFAULT SEED
            Random r2 = new Random(1234);			// HARDCODED SEED

                            // The 2 objects are passed in (as parameters)
                            // to another method which USES the objects.

            for (int i = 1; i <= 20; i++)
                DoNextNumber(r1, r2);
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        public static void DoNextNumber(Random r1, Random r2)
                                        // NOTE THE PARAMETERS' DATA TYPES
        {
            int int1, int2;

            int1 = r1.Next(10, 30);			// i.e., 10 to 30-1      - different each run
            int2 = r2.Next(10, 30);			// i.e., 10 to 30-1      - same each run

            Console.WriteLine("{0,4}   {1,4}", int1, int2);
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
    }
}

