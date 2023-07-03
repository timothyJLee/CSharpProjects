// This program demonstrates a class with 3 different methods
// and how Main calls them.

// All three are 'void' methods
//      - meaning, they don't return any value to the caller.

// All three have no input parameters
//      - meaning, the caller didn't send any values IN.
// **************************************************************

using System;

public class Box3VoidMethods
{
	public static void Main()
	{
								// SET UP OBJECT OF Box CLASS
		Box someBox = new Box();
                                // CALL 3 OF Box's METHODS
                                // - no parameters sent IN
                                // - no return values from methods
		someBox.GetData();
		someBox.FindNShowVolume();
		someBox.FindNShowFootprint();
	}
}
//***************************************************************
//***************************************************************
public class Box
{	
	// ----------------- ATTRIBUTES (INSTANCE VARIABLES) --------
	private int lengthInteger;
	private int widthInteger;
	private int heightInteger;
	// ----------------- THREE METHODS --------------------------
 
    // - - - - - - - #1 - - GetData method - - - - - - - - - - - - -
    // IN:  no input parameters (from the caller, i.e., Main)
    // IN:  from user (keyboard)
    // OTHER AVAILABLE DATA:  the attributes in this class
    // OUT: to user (console window)
    // OUT: no return value (to the caller, i.e., Main)
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
	public void GetData()                                       // CAN THESE BE PRIVATE??
	{                                                           // why?
		Console.Write("Enter length: ");
		lengthInteger = Convert.ToInt32(Console.ReadLine());
		Console.Write("Enter width: ");
		widthInteger = Convert.ToInt32(Console.ReadLine());
		Console.Write("Enter height: ");
		heightInteger = Convert.ToInt32(Console.ReadLine());
	}



    // - - - - - - - #2 - - FindNShowVolume method  - - - - - - - -
    // IN:  no input parameters (from the caller, i.e., Main)
    // IN:  none from user (keyboard)
    // OTHER AVAILABLE DATA:  the attributes in this class
    // OTHER AVAILABLE DATA:  local variable
    // OUT: to user (console window)
    // OUT: no return value (to the caller, i.e., Main)
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
	public void FindNShowVolume()
	{
		int vInteger;
		vInteger = lengthInteger * widthInteger * heightInteger;
		Console.WriteLine("\nVOLUME is {0}", vInteger);
	}



    // - - - - - - -#3  - - FindNShowFootprint method  - - - - - -
    // IN:  no input parameters (from the caller, i.e., Main)
    // IN:  none from user (keyboard)
    // OTHER AVAILABLE DATA:  the attributes in this class
    // OUT: to user (console window)
    // OUT: no return value (to the caller, i.e., Main)
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
	public void FindNShowFootprint()
	{
		Console.WriteLine("\nFOOTPRINT is {0}\n", lengthInteger * widthInteger);
	}
}