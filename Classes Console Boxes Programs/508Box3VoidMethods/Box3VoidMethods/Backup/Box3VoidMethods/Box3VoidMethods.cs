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
public class Box
{	
	// ----------------- ATTRIBUTES (INSTANCE VARIABLES) --------
	private int length;
	private int width;
	private int height;
	// ----------------- THREE METHODS --------------------------
 
    // - - - - - - - #1 - - GetData method - - - - - - - - - - - - -
    // IN:  no input parameters (from the caller, i.e., Main)
    // IN:  from user (keyboard)
    // OTHER AVAILABLE DATA:  the attributes in this class
    // OUT: to user (console window)
    // OUT: no return value (to the caller, i.e., Main)
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
	public void GetData()                               
	{
		Console.Write("Enter length: ");
		length = Convert.ToInt32(Console.ReadLine());
		Console.Write("Enter width: ");
		width = Convert.ToInt32(Console.ReadLine());
		Console.Write("Enter height: ");
		height = Convert.ToInt32(Console.ReadLine());
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
		int v;
		v = length * width * height;
		Console.WriteLine("\nVOLUME is {0}", v);
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
		Console.WriteLine("\nFOOTPRINT is {0}\n", length * width);
	}
}