//   - generating random integers
// Uses shifting & scaling to force integers to be within a specified range.

using System;

namespace RandomIntegers
{
    class Program
    {
        static void Main()
        {
            Random randomNumbers = new Random();     // RANDOM NUMBER GENERATOR

            int num;            // STORES THE RANDOM INTEGER THAT'S GENERATED

            for (int counter = 1; counter <= 20; counter++)
            {
                        // Next METHOD GENERATES A RANDOM INTEGERS FROM 1 TO 6
                num = randomNumbers.Next(1, 7);   // always 1 less than ending/last value

                Console.Write("{0}  ", num);

                            // IF COUNTER IS DIVISIBLE BY 5, START A NEW LINE
                if (counter % 5 == 0)
                    Console.WriteLine();
            }
        }
    }
}
