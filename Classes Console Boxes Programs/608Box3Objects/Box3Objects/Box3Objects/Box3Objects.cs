// This program demonstrates Main declaring 3 different objects
//      (that is, 3 different INSTANCES of the Box class).
// That means there will be THREE copies of length, THREE copies
//      of width and THREE copies of height.

// To call a method, the caller must specify WHICH OBJECT is
//      being referred to.  Hence the method will know which of
//      the 3 lengths, widths and heights to use.

// this continues to use 3 called methods (void)
// **************************************************************
using System;

public class Box3Objects
{
	public static void Main()
	{
								// SET UP 3 OBJECTS OF Box CLASS
		Box fedExBox = new Box();
		Box upsBox = new Box();
		Box postOfficeBox = new Box();
                                // CALL 3 OF Box's METHODS for EACH BOX CREATED(box instance)
                                // SPECIFYING THE fedEx INSTANCE
        Console.WriteLine("\n***** FedEx box *****");
        fedExBox.GetData();
		fedExBox.FindNShowVolume();
		fedExBox.FindNShowFootprint();
                                // CALL 3 OF Box's METHODS
                                // SPECIFYING THE ups INSTANCE
        Console.WriteLine("\n***** UPS box *****");
        upsBox.GetData();
		upsBox.FindNShowVolume();
		upsBox.FindNShowFootprint();
                                // CALL 3 OF Box's METHODS
                                // SPECIFYING THE postOffice INSTANCE
        Console.WriteLine("\n***** PostOffice box *****");
        postOfficeBox.GetData();
		postOfficeBox.FindNShowVolume();
		postOfficeBox.FindNShowFootprint();
	}
}
//************************************************************
public class Box
{	
	// -----------------ATTRIBUTES (INSTANCE VARIABLES) -------
	private int lengthInteger;
	private int widthInteger;
	private int heightInteger;
	// -------------------- METHODS ---------------------------
	public void GetData()
	{
		Console.Write("Enter length: ");
		lengthInteger = Convert.ToInt32(Console.ReadLine());
		Console.Write("Enter width: ");
		widthInteger = Convert.ToInt32(Console.ReadLine());
		Console.Write("Enter height: ");
		heightInteger = Convert.ToInt32(Console.ReadLine());
	}
	// -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
	public void FindNShowVolume()
	{
		int vInteger;
		vInteger = lengthInteger * widthInteger * heightInteger;
		Console.WriteLine("\nVOLUME is {0}", vInteger);
	}
	// -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -
	public void FindNShowFootprint()
	{
		Console.WriteLine("\nFOOTPRINT is {0}\n", lengthInteger * widthInteger);
	}
}