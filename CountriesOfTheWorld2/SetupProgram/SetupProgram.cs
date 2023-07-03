/* PROJECT:  WorldDataAppCS (C#)            PROGRAM: SetupProgram
 * AUTHOR: Timothy Lee / CS3310
 * OOP CLASSES USED (for Asgn 2):  RawData, TheLog, CountryDataTable
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 *      INPUT:   RawData*.csv           (handled by RawData class)
 *      OUTPUT:  Log.txt                (handled by TheLog class)
 *      OUTPUT: CountryDataTable.bin (& "INPUT" to check for "empty locations")
 *                                      (handled by DataStorage class)
 * DESCRIPTION:  The program itself is just the CONTROLLER which UTILIZES
 *      the SERVICES (public methods) of various OOP classes.
 *      Creates a random access CountryDataTable file from data in the RawData file
 *      Status messages are sent to the Log file.
 *          
 * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      loop til done with RawData
 *      {   input 1 data set from RawData
 *          use that data to construct an entry for MainData (calling
 *                  appropriate service method in that class)
 *      }
 *      finish up with RawData
 *      finish up with CountryDataTable
 * CAUTION:  The program code below DOES NOT DEAL DIRECTLY WITH
 *      RawData or CountryDataTable or Log.  Appropriate OOP classes handle those.   
 *******************************************************************************/

using System;

using SharedClassLibrary; // Needed in order to call instances of objects and classes

namespace SetupProgram
{
    public class SetupProgram
    {
        public static void Main(string[] args)
        {
            TheLog logFileInterface = new TheLog();

            logFileInterface.DisplayALogRec("CODE STATUS > Starting SetupProgram");

            string fileNameSuffix = args[0]; // for holding args[] passed from Program Calling Setup

            RawData RawDataObject = new RawData(fileNameSuffix);
            logFileInterface.DisplayALogRec("FILE STATUS > Opened File RawData" + fileNameSuffix + ".csv");

            CountryDataTable CountryDataTableObject = new CountryDataTable("Y");              //  Passing String creates new MainData File
            logFileInterface.DisplayALogRec("FILE STATUS > CountryData FILE opened ");

            ProcessRecords(RawDataObject, CountryDataTableObject, logFileInterface);

            logFileInterface.DisplayALogRec("FILE STATUS > Closed File RawData" + fileNameSuffix + ".csv");
            logFileInterface.DisplayALogRec("CODE STATUS > Read in " + RawData.Count.ToString() + " records");

            CountryDataTableObject.FinishUp(logFileInterface, true);
            logFileInterface.DisplayALogRec("FILE STATUS > CountryData FILE closed");
            logFileInterface.FinishUp();
        }


        //*********************** PRIVATE METHODS ********************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Loops through RawData and creates BSTData objects to put into CountryDataTableFile
        /// </summary>
        private static void ProcessRecords(RawData RawDataRecord, CountryDataTable CountryDataRecord, TheLog ProcessLog)   // Take one Raw Data Record and Convert it to a Main Data Record
        {
            while (RawDataRecord.Input1Record())
            {   // Format a single Fixed Length MainData Record
                BSTData newRecord = new BSTData(int.Parse(RawDataRecord.RRN), RawDataRecord.Code.PadRight(CountryDataTable.SizeOfCode), RawDataRecord.Name.PadRight(CountryDataTable.SizeOfName),
                          RawDataRecord.Continent.PadRight(CountryDataTable.SizeOfContinent), RawDataRecord.SurfaceArea.PadRight(CountryDataTable.SizeOfSurfaceArea),
                          RawDataRecord.Population.PadRight(CountryDataTable.SizeOfPopulation),
                          RawDataRecord.LifeExpectancy.PadRight(CountryDataTable.SizeOfLifeExpectancy));

                CountryDataRecord.Input1Record(newRecord, int.Parse(RawDataRecord.RRN)); //Insert Formatted Record into CountryDataTable File
            }
        }
    }
}