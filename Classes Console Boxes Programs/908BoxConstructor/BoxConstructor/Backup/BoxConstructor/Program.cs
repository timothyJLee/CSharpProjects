// Program demonstrates the use of a class CONSTRUCTOR.
// A CONSTRUCTOR is a special method in the class which is called when
//      the object is first declared.  It is used to initialize the
//      instance variables for that object being declared, (though the
//      constructor may do other things as well, just like a regular method).
// The constructor's name should be the same as the class's name.
// The "call" to the constructor method is just after the = new in
//      the object declaration.
// -------------------------------------------------------------------------

using System;

namespace BoxConstructor
{
    public class Program
    {
        public static void Main()
        {
            Box someBox = new Box();    // CALLS CONSTRUCTOR WHERE USER INPUT IS ACCEPTED

            // someBox.GetData();		// NOT USED SINCE CONSTRUCTOR DOES IT

                                        // CALL 3 OF Box's METHODS
                                        //	1) NO IN PARAMETERS
                                        //	   int VALUE RETURNED
            int volume = someBox.FindVolume();

                                        //	2) 1 IN PARAMETER
                                        //		NO RETURN VALUE
            someBox.ShowVolume(volume);

                                        //	3) NO IN PARAMETERS
                                        //		NO RETURN VALUE
            someBox.ShowBoxAttributes();
        }
    }
}
