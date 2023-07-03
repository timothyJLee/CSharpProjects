using System;

namespace BoxDefConstr
{
    class Box
    {
        // -----------------ATTRIBUTES (INSTANCE VARIABLES) -------
        private int length;
        private int width;
        private int height;
        // -------------------- METHODS ---------------------------
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


