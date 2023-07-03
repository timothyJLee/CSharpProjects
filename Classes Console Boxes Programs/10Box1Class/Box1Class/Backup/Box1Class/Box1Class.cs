//   8   Program gets 3 dimensions of a FedEx box,
//   then calculates the volume & footprint of the box.

// FORMAT:  Program has only ONE class, like earlier examples.

using System;

namespace Box1Class
{
    public class Program
    {
        public static void Main()
        {
                            // DECLARE VARIABLES
                            // for the BOX (i.e., the OBJECT)
            int length;
            int width;
            int height;
                            // GET THE DIMENSION DATA
            Console.Write("Enter length: ");
            length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter width: ");
            width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter height: ");
            height = Convert.ToInt32(Console.ReadLine());

                            // DECLARE VARIABLES
                            // for the CALCULATIONS
            int volume;
            int footprint;
                            // DO CALCULATIONS & SHOW RESULTS
            volume = length * width * height;
            Console.WriteLine("\nVOLUME is {0}", volume);

            footprint = length * width;
            Console.WriteLine("\nFOOTPRINT is {0}\n", footprint);
        }
    }
}