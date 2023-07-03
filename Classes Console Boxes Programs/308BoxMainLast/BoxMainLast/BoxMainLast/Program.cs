// Program gets 3 dimensions of a FedEx box,
//   then calculates the volume & footprint of the box.

// FORMAT:  Program has TWO classes with Box class first and Main 2nd.

using System;

namespace BoxMainLast
{
    //*************************** THE Box CLASS *****************
    public class Box
    {
        // -------------------- ATTRIBUTES ----------------------
        private int lengthInteger;
        private int widthInteger;
        private int heightInteger;
        // -------------------- METHOD ---------------------------
        public void DoActions()                                 // CAN THIS METHOD BE PRIVATE???
        {
            Console.Write("Enter length: ");
            lengthInteger = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter width: ");
            widthInteger = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter height: ");
            heightInteger = Convert.ToInt32(Console.ReadLine());

            int volumeInteger;
            int footprintInteger;

            volumeInteger = lengthInteger * widthInteger * heightInteger;
            Console.WriteLine("\nVOLUME is {0}", volumeInteger);

            footprintInteger = lengthInteger * widthInteger;
            Console.WriteLine("\nFOOTPRINT is {0}\n", footprintInteger);
        }
    }
    //*************************** THE ACTUAL PROGRAM ************
    class Program
    {
        static void Main(string[] args)
        {
            Box box1234 = new Box();
            box1234.DoActions();
        }
    }
}
