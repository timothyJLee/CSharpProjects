// FILE:  Box2FilesMain.cs
// IN PROJECT:  Box2Files
// FORMAT:  Program has TWO classes:
//      - the Main Program class is in one file,
//      - the Box class is in a separate file.
// NOTE:  both classes are in the SAME namespace.
using System;
namespace Box2Files
{
    //*************************** THE ACTUAL PROGRAM ************
    public class Program
    {
        public static void Main()
        {
            Box box1234 = new Box();

            box1234.DoActions();
        }
    }
}