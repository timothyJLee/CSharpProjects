//Fig 7.8:  Roll a siz-sided die 6000 times
// (An experiment to see if this random number generator is "fair")

using System;

namespace RollDie
{
    class Program
    {
        static void Main()
        {
            Random randomNumbers = new Random();    // RANDOM NUMBER GENERATOR

            int frequency1 = 0;         // count of 1s rolled
            int frequency2 = 0;         // count of 2s rolled
            int frequency3 = 0;         // count of 3s rolled
            int frequency4 = 0;         // count of 4s rolled
            int frequency5 = 0;         // count of 5s rolled
            int frequency6 = 0;         // count of 6s rolled

            int face;           // STORES THE MOST RECENTLY GENERATED VALUE

            for (int roll = 1; roll <= 6000; roll++)
            {
                face = randomNumbers.Next(1, 7);     // A NUMBER FROM 1 TO 6

                switch (face)       // INCREMENT THE APPROPRIATE COUNTER 
                {
                    case 1:
                        frequency1++;
                        break;
                    case 2:
                        frequency2++;
                        break;
                    case 3:
                        frequency3++;
                        break;
                    case 4:
                        frequency4++;
                        break;
                    case 5:
                        frequency5++;
                        break;
                    case 6:
                        frequency6++;
                        break;
                } // end switch
            } // end for

            Console.WriteLine("Face\tFrequency");       // OUTPUT HEADERS

            Console.WriteLine("1\t{0}\n2\t{1}\n3\t{2}\n4\t{3}\n5\t{4}\n6\t{5}",
               frequency1, frequency2, frequency3, frequency4,
               frequency5, frequency6);
        } // end Main method
    } // end Program class
} // end RollDie namespace
