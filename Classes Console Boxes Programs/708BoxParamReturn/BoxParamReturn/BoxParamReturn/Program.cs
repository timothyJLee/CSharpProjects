// CREATE 2 BOXES THEN PROCESS EACH BOX INDIVIDUALLY USING THE Box.cs CLASS WHICH
//   ACCEPTS THE PASSED VOLUME AFTER THE VOLUME METHOD IS COMPLETED AND SAVED INTO
//   VARIABLE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxParamReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            Box someBox = new Box();                // CREATE 2 BOXES
            Box anotherBox = new Box();

            // -----------------------------------------
            Console.WriteLine("\nFIRST Box");
            someBox.GetData();                      // DATA IS INPUT VIA GETDATA METHOD/VALUES REMAIN IN THAT CLASS

            int volumeInteger;
            volumeInteger = someBox.FindVolume();          // returns volume to int volume (VIA FindVolume METHOD)
            someBox.ShowVolume(volumeInteger);             // passes the volume to ShowVolume method (FOR OUTPUT FROM METHOD)
              
            someBox.FindNShowFootprint();           // CALLS METHOD - NOTHING PASSED IN OR RETURNED

            // -----------------------------------------
            Console.WriteLine("\nSECOND Box");
            anotherBox.GetData();

            volumeInteger = anotherBox.FindVolume();
            anotherBox.ShowVolume(volumeInteger);

            anotherBox.FindNShowFootprint();
        }
    }
}

  