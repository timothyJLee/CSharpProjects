using System;

namespace BoxConstructor
{
    public class Box
    {
        // -----------------ATTRIBUTES (INSTANCE VARIABLES) ------------
        private int lengthInteger;
        private int widthInteger;
        private int heightInteger;
        // -------------------- CONSTRUCTOR -----------
        public Box()                                 // GETS INPUT
        {
            Console.Write("Enter length: ");
            lengthInteger = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter width: ");
            widthInteger = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter height: ");
            heightInteger = Convert.ToInt32(Console.ReadLine());
        }
        // -------------------- METHODS --------------------------------
        public int FindVolume()                                 // OK..THERE'S A CONSTRUCTOR WHY ARE METHODS STILL "PUBLIC"????
        {
            return lengthInteger * widthInteger * heightInteger;
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
                lengthInteger, widthInteger, heightInteger);
        }
    }
}


