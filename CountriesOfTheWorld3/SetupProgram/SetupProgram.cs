/* PROJECT:  WorldDataAppCS (C#)            PROGRAM: SetupProgram
 * AUTHOR: Timothy Lee / CS3310
 * OOP CLASSES USED (for Asgn 3):  RawData, TheLog, CountryDataTable, CountryDataIndex
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 *      INPUT:   RawData*.csv           (handled by RawData class)
 *      OUTPUT:  Log.txt                (handled by TheLog class)
 *      OUTPUT: CountryDataTable.bin and CountryDataIndex (& "INPUT" to check for "empty locations")
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
 *      finish up with CountryIndex
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

            CountryDataTable CountryDataTableObject = new CountryDataTable(RawData.Count);              //  Passing String creates new MainData File
            logFileInterface.DisplayALogRec("FILE STATUS > CountryData FILE opened ");

            CountryIndex CountryIndexObject = new CountryIndex("C");
            CountryIndexObject.RestoreTable(); // Restoring the Table
            logFileInterface.DisplayALogRec("CODE STATUS > CountryData INDEX created ");


            ProcessRecords(RawDataObject, CountryDataTableObject, logFileInterface);

            logFileInterface.DisplayALogRec("FILE STATUS > Closed File RawData" + fileNameSuffix + ".csv");
            logFileInterface.DisplayALogRec("CODE STATUS > Read in " + RawData.Count.ToString() + " records");

            CountryDataTableObject.FinishUp(logFileInterface, true);
            CountryIndexObject.FinishUp(logFileInterface, true);
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
                BSTData newRecord = new BSTData((short)int.Parse(RawDataRecord.ID), RawDataRecord.Code.PadRight(CountryDataTable.SizeOfCode).ToCharArray(), RawDataRecord.Name.PadRight(CountryDataTable.SizeOfName).ToCharArray(),
                          RawDataRecord.Continent.PadRight(CountryDataTable.SizeOfContinent).ToCharArray(), int.Parse(RawDataRecord.SurfaceArea), long.Parse(RawDataRecord.Population),
                          float.Parse(RawDataRecord.LifeExpectancy), -1);

                CountryDataRecord.Output1Record(newRecord, (short)int.Parse(RawDataRecord.ID)); //Insert Formatted Record into CountryDataTable File
                // countryIndex.insertCodeInIndex(rawData.getCode, rrn)
            }
        }
    }
}