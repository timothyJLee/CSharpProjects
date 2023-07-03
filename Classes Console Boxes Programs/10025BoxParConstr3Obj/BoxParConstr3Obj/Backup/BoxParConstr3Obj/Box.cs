using System;

namespace BoxParConstr3Obj
{
    class Box
    {
        // -----------------ATTRIBUTES (INSTANCE VARIABLES) -------
        private int length;
        private int width;
        private int height;
        // -------------------- CONSTRUCTOR -----------------------
        public Box(int l, int w, int h)
        {
            length = l;         // NO PROPERTIES SINCE ALL VALUES ARE USED IN BOX CLASS
            width = w;
            height = h;
        }
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
