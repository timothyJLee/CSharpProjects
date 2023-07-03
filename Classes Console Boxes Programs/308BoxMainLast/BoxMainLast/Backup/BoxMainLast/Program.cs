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
        private int length;
        private int width;
        private int height;
        // -------------------- METHOD ---------------------------
        public void DoActions()
        {
            Console.Write("Enter length: ");
            length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter width: ");
            width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter height: ");
            height = Convert.ToInt32(Console.ReadLine());

            int volume;
            int footprint;

            volume = length * width * height;
            Console.WriteLine("\nVOLUME is {0}", volume);

            footprint = length * width;
            Console.WriteLine("\nFOOTPRINT is {0}\n", footprint);
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
