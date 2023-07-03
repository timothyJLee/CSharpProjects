// FILE:  Box2FilesBoxClass.cs
// IN PROJECT:  Box2Files

// FORMAT:  Program has TWO classes:
//      - the Main Program class is in one file,
//      - the Box class is in a separate file.

// NOTE:  both classes are in the SAME namespace.

using System;

namespace Box2Files
{
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
        public void DoActions()                                 // DIFFERENT FILE..CAN THIS BE PRIVATE??
        {                            // GET THE DIMENSION DATA  //    WHAT HAPPENS WHEN IT'S CHANGED TO PRIVATE??
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