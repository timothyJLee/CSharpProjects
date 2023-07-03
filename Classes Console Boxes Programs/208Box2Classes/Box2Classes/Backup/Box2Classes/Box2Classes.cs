// Program gets 3 dimensions of a FedEx box,
//   then calculates the volume & footprint of the box.

// FORMAT:  Program has TWO CLASSES -in 1 FILE.

using System;

namespace Box2Classes
{
    //*************************** THE ACTUAL PROGRAM ************
    public class Program
    {
        public static void Main()
        {
                            // SET UP A SPECIFIC OBJECT
                            //      OF THE Box CLASS TYPE
            Box box1234 = new Box();
                            // CALL ONE OF Box's CLASS'S METHODS
                            //      TO DO THE ACTIONS
            box1234.DoActions();
        }
    }
    //*************************** THE Box CLASS ***************** 
    public class Box
    {
        // -------------------- ATTRIBUTES ----------------------
        // Declare the "instance variables" which any object of
        // the Box class would have.
        // -------------------------------------------------------
        private int length;
        private int width;
        private int height;
        // -------------------- METHOD ---------------------------
        // IN:  nothing sent in (i.e., no parameters specified)
        // OUT:  nothing sent out (i.e., it says void)
        // -------------------------------------------------------
        public void DoActions()
        {                            // GET THE DIMENSION DATA
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