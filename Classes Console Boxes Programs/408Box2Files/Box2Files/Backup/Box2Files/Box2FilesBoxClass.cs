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