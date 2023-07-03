using System;

namespace BoxParConstr3Obj
{
    class Box
    {
        // -----------------ATTRIBUTES (INSTANCE VARIABLES) -------
        private int lengthInteger;
        private int widthInteger;
        private int heightInteger;
        // -------------------- CONSTRUCTOR -----------------------
        public Box(int l, int w, int h)
        {
            lengthInteger = l;         // NO PROPERTIES SINCE ALL VALUES ARE USED IN BOX CLASS
            widthInteger = w;
            heightInteger = h;

        }
        // -------------------- METHODS ---------------------------
        //public int FindVolume()
        //{
        //    return lengthInteger * widthInteger * heightInteger;
        //}
        //// -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        //public void ShowVolume(int v)
        //{
        //    Console.WriteLine("\nVOLUME is {0}", v);
        //}
        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        public void ShowBoxAttributes()
        {
            Console.WriteLine("\nLENGTH: {0}, WIDTH: {1}, HEIGHT: {2}",
                lengthInteger, widthInteger, heightInteger);
        }
    }
}
