/* PROJECT: WorldDataAppCS (C#)         PROGRAM: SetupProgram
 * AUTHOR: Timothy Lee / CS3310
 * OOP CLASSES USED (for Asgn 1):  RawData, CountryDataTableBST, BSTNode, TheLog
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 *      INPUT:   RawData*.csv         (handled by RawData class)
 *      OUTPUT:  TheLog.txt                (handled by TheLog class)
 *      OUTPUT:  BST.txt   (handled by CountryDataTableBST class)
 * DESCRIPTION:  The program itself is just the CONTROLLER which UTILIZES
 *      the SERVICES (public methods) of various OOP classes.
 *      It processes the Raw Data in the RawData file.  It formats the data and inserts into CountryDataTable.
 * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      loop til done with RawData
 *      {   input 1 RawData request from RawData
 *          ProcessRecords to add BSTNode to CountryDataTable
 *      }
 *      finish up with RawData
 *      finish up with LogFile
 * CAUTION:  The program code below DOES NOT DEAL DIRECTLY WITH
 *      RawData, CountryDataTable, or Log.  Appropriate OOP classes handle those.  
 *******************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using SharedClassLibrary;


namespace SetupProgram
{
    public class SetupProgram
    {
        public static void Main(string[] args)
        {
            TheLog setupProgramLog = new TheLog();

            setupProgramLog.DisplayALogRec("FILE STATUS > TheLog FILE Opened");
            setupProgramLog.DisplayALogRec("CODE STATUS > Setup Started");

            string fileNameSuffix = args[0]; // for holding args[] passed from Program Calling Setup

            RawData RawDataObject = new RawData(fileNameSuffix);
            setupProgramLog.DisplayALogRec("FILE STATUS > RawData File Opened");
            CountryDataTableBST countryDataBinarySearchTree = new CountryDataTableBST(RawData.Count);

            int i = 0;
            while (RawDataObject.Input1Record())
            {
                CountryDataTableBST.Insert(ProcessRecord(RawDataObject, setupProgramLog), out i);
            }

            CountryDataTableBST.SaveTable(RawData.Count);

            setupProgramLog.DisplayALogRec("FILE STATUS > RawData File Closed");
            setupProgramLog.DisplayALogRec("FILE STATUS > Read in " + RawData.Count.ToString() + " records");

            setupProgramLog.DisplayALogRec("CODE STATUS > Setup Finished - " + RawData.Count + " records processed");

            setupProgramLog.FinishUp();
        }


        //*********************** PRIVATE METHODS ********************************

        //------------------------------------------------------------------------------
        /// <summary>
        /// Process a RawData Record and return a BSTNode
        /// </summary>
        private static BSTNode ProcessRecord(RawData RawDataRecord, TheLog processRecLog) 
        {
            BSTNode returnNode = new BSTNode(RawDataRecord.Code, RawDataRecord.Name, RawDataRecord.Continent, RawDataRecord.SurfaceArea,
                                         RawDataRecord.Population, RawDataRecord.LifeExpectancy, -1, -1, false);
            return returnNode;
        }
    }
}
