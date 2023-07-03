using System;

namespace BoxParConstr3Obj
{
    class Box
    {
        // -----------------ATTRIBUTES (INSTANCE VARIABLES) -------
        private int lengthInteger;
        private int widthInteger;
        private int heightInteger;

        private int VolInteger;
        // -------------------- CONSTRUCTOR -----------------------
        public Box(int l, int w, int h)
        {
            lengthInteger = l;                                      // WHY ARE THERE NO PROPERTIES???
            widthInteger = w;
            heightInteger = h;

           VolInteger = FindVolume();
            ShowVolume(VolInteger);
            ShowBoxAttributes();

        }
        // -------------------- METHODS ---------------------------// WHY ARE THE METHOD NOW "PRIVATE"???
        private int FindVolume()
        {
            return lengthInteger * widthInteger * heightInteger;
        }
        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        private void ShowVolume(int v)
        {
            Console.WriteLine("\nVOLUME is {0}", v);
        }
        // -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
        private void ShowBoxAttributes()                    
        {
            Console.WriteLine("\nLENGTH: {0}, WIDTH: {1}, HEIGHT: {2}",
                lengthInteger, widthInteger, heightInteger);
        }
    }
}
