// No Constructor is defined in the Box class, so the
//      "invisible" 'DEFAULT' CONSTRUCTOR is automatically called & run
//      when the object is created.
// It initializes all instance variables:
//      int and double (and other numeric data type) variables get 0's.

//  BUT THIS HAS NO INPUT OR CONSTRUCTOR SO OUTPUTS ZERO'S FOR ALL VALUES

using System;

namespace BoxDefConstr
{
    class Program
    {
        static void Main()
        {
            Box someBox = new Box();

            int volume = someBox.FindVolume();  // 
            someBox.ShowVolume(volume);         // PASSES IN volume PARAMETER FOR OUTPUT IN Box
            someBox.ShowBoxAttributes();        // 
        }
    }
}

