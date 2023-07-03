//   8   Program gets 3 dimensions of a FedEx box,
//   then calculates the volume & footprint of the box.

// FORMAT:  Program has only ONE class, like earlier examples.

using System;

namespace Box1Class
{
    public class Program
    {
        private static void Main()
        {
                            // DECLARE VARIABLES
                            // for the BOX (i.e., the OBJECT)
            int lengthInteger;
            int widthInteger;
            int heightInteger;
                            // GET THE DIMENSION DATA
            Console.Write("Enter length: ");
            lengthInteger = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter width: ");
            widthInteger = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter height: ");
            heightInteger = Convert.ToInt32(Console.ReadLine());

                            // DECLARE VARIABLES
                            // for the CALCULATIONS
            int volume;
            int footprint;
                            // DO CALCULATIONS & SHOW RESULTS
            volume = lengthInteger * widthInteger * heightInteger;
            Console.WriteLine("\nVOLUME is {0}", volume);

            footprint = lengthInteger * widthInteger;
            Console.WriteLine("\nFOOTPRINT is {0}\n", footprint);
        }
    }
}
//Enter length: 35
//Enter width: 20
//Enter height: 15

//VOLUME is 10500

//FOOTPRINT is 700

//Press any key to continue . . .