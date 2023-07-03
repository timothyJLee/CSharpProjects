///   HERE ARE 2 INSTANCES OF THE Box CLASS EACH WITH 3 VALUES (l, w, h)
///   THAT ARE USING THE Box CONSTRUCTOR TO CREATE & CALCULATE EACH THE WRITES EACH
///      USING THE BOX CLASS METHOD ShowBoxAttributes
///   Box IS USED AS THE 'BUSINESS' TIER

using System;

namespace BoxParConstr3Obj
{
    class Program
    {
        static void Main()
        {
            Box box1 = new Box(30, 20, 10);         // 3 SEPARATE BOX INSTANCES
            Box box2 = new Box(5, 8, 4);
            Box box3 = new Box(10, 10, 10);

            Console.Write("\nBOX #1 -->  ");
            box1.ShowBoxAttributes();

            Console.Write("\nBOX #2 -->  ");
            box2.ShowBoxAttributes();

            Console.Write("\nBOX #3 -->  ");
            box3.ShowBoxAttributes();
        }
    }
}
