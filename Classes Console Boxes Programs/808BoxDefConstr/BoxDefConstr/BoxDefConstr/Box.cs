using System;

namespace BoxDefConstr
{
    class Box
    {
        // -----------------ATTRIBUTES (INSTANCE VARIABLES) -------
        private int lengthinteger;
        private int widthInteger;
        private int heightInteger;
        // -------------------- METHODS ---------------------------
        public int FindVolume()
        {
            return lengthinteger * widthInteger * heightInteger;
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
                lengthinteger, widthInteger, heightInteger);
        }
    }
}



