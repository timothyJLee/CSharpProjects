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
        private int lengthInteger;
        private int widthInteger;
        private int heightInteger;
        // -------------------- METHOD ---------------------------
        // IN:  nothing sent in (i.e., no parameters specified)
        // OUT:  nothing sent out (i.e., it says void)
        // -------------------------------------------------------
        public void DoActions()                             // NOTICE THIS IS PUBLIC..DO YOU KNOW WHY???
        {                            // GET THE DIMENSION DATA
            Console.Write("Enter length: ");
            lengthInteger = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter width: ");
            widthInteger = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter height: ");
            heightInteger = Convert.ToInt32(Console.ReadLine());

                                 // DECLARE VARIABLES
                                 // for the CALCULATIONS
            int volumeInteger;
            int footprintInteger;
                                 // DO CALCULATIONS & SHOW RESULTS
            volumeInteger = lengthInteger * widthInteger * heightInteger;
            Console.WriteLine("\nVOLUME is {0}", volumeInteger);

            footprintInteger = lengthInteger * widthInteger;
            Console.WriteLine("\nFOOTPRINT is {0}\n", footprintInteger);
        }
    }
}