using System;

namespace BoxConstructor
{
    public class Box
    {
        // -----------------ATTRIBUTES (INSTANCE VARIABLES) ------------
        private int length;
        private int width;
        private int height;
        // -------------------- CONSTRUCTOR ----------------------------
        public Box()                                 // GETS INPUT
        {
            Console.Write("Enter length: ");
            length = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter width: ");
            width = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter height: ");
            height = Convert.ToInt32(Console.ReadLine());
        }
        // -------------------- METHODS --------------------------------
        public int FindVolume()
        {
            return length * width * height;
        }
        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        public void ShowVolume(int v)
        {
            Console.WriteLine("\nVOLUME is {0}", v);
        }
        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        public void ShowBoxAttributes()
        {
            Console.WriteLine("\nLENGTH: {0}, WIDTH: {1}, HEIGHT: {2}",
                length, width, height);
        }
    }
}


