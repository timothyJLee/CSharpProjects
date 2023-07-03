/* PROJECT: WorldDataAppCS (C#)         PROGRAM: UserApp
 * AUTHOR: Timothy Lee / CS3310
 * OOP CLASSES USED (for Asgn 4):  TheLog, CountryData, CountryIndex
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 *      INPUT:   TransData*.txt         (handled by TheLog class)
 *      OUTPUT:  Log.txt                (handled by TheLog class)
 *      OUTPUT:  CountryData.txt, CountryIndex.bin   (handled by CountrDataTable and CountryIndex class)
 * DESCRIPTION:  The program itself is just the CONTROLLER which UTILIZES
 *      the SERVICES (public methods) of various OOP classes.
 *      It processes the transaction requests in TransData file.  It sends the request
 *      and the result to the Log file.
 *          The ACTUAL CountryData will be provided to user (in Log file).  Also, transaction requests
 *          based on (code) are handled using CountryIndex to find the proper record in CountryData
 *          * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      loop til done with TransData
 *      {   input 1 transaction request from TransData
 *          switch to use that data to call appropriate service in CountrDataTable
 *                  class to handle request
 *      }
 *      finish up with TransData
 *      finish up with CountryData
 *      finish up with CountryIndex
 *      finish up with LogFile
 * CAUTION:  The program code below DOES NOT DEAL DIRECTLY WITH
 *      TransData or CountryIndex or Log or CountryData.  Appropriate OOP classes handle those.  
 *******************************************************************************/

using System;
using System.IO;
using System.Collections.Generic;
using SharedClassLibrary; // for TheLog


namespace UserApp
{
    public class UserApp
    {

        private static string header = (">>> ID ").PadRight(7) + ("CODE").PadRight(5) + ("STRINGFIELD").PadRight(12) + ("NUMFIELD").PadRight(9);  // header matching requirements for userapp

        public static void Main(string[] args)
        {
            //**************************** PRIVATE DECLARATIONS ************************

            string transFileSuffix = args[0];

            string[] transInputArray;
            string transInput;
            char[] transCodeInput;

            TheLog logFileInterface = new TheLog();    // overloaded TransData with int to call logfile
            logFileInterface.DisplayALogRec(" ");
            logFileInterface.DisplayALogRec("========================================");
            logFileInterface.DisplayALogRec("PROCESSING A4TransData" + transFileSuffix);


            TransData transInterface = new TransData(transFileSuffix);

            CountryData CountryDataUserApp = new CountryData((short)int.Parse(transFileSuffix));

            CountryIndex CountryIndexObject = new CountryIndex("setup", (short)int.Parse(transFileSuffix));

            logFileInterface.DisplayALogRec(" ");
            logFileInterface.DisplayALogRec(header);
            logFileInterface.DisplayALogRec(" ");

            while (transInterface.InputATransRec(out transInputArray, logFileInterface))
            {
                transInput = transInterface.TransactionInput;
                transCodeInput = transInterface.TransactionCode;

                switch (transInputArray[0])
                {
                    case "SI":
                        SelectById(logFileInterface);
                        break;
                    case "SC":
                        SelectByCode(transInputArray, CountryIndexObject, CountryDataUserApp, logFileInterface);
                        break;
                    case "DI":
                        DeleteById(transInputArray, CountryDataUserApp, logFileInterface);
                        break;
                    case "DC":
                        DeleteByCode(transInputArray, CountryIndexObject, logFileInterface);
                        break;
                    case "IN":
                        InsertCountry(transInputArray, CountryIndexObject, logFileInterface);
                        break;
                }
                transInterface.Id = null;
            }
            CountryDataUserApp.FinishUp(logFileInterface);
            CountryIndexObject.FinishUp(logFileInterface);
            logFileInterface.FinishUp();
        }

        //*********************** PRIVATE METHODS ********************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Takes a id and attempts to find it within the CountryDataFile
        /// </summary>
        /// <returns>A bool indicating success and a BSTData object of the returned record</returns>
        private static bool SelectById(TheLog selectLog)
        {
            selectLog.DisplayALogRec("> **DeleteByID not yet operational");
            return false;

        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Takes a Code and searches for it in Index and returns true if found and prints to log
        /// </summary>
        private static bool SelectByCode(string[] transArray, CountryIndex CountryDataIndex, CountryData CountryDataObject, TheLog SelectByCodeLogFileInterface)
        {
            SelectByCodeLogFileInterface.DisplayALogRec(transArray[0] + " " + transArray[1]);
            short selectDRP;
            if (CountryDataIndex.SelectByCode(transArray[1].ToCharArray(), out selectDRP)) //&& selectRec != null)
            {
                if(CountryDataObject.Find1Record(selectDRP))
                {
                    SelectByCodeLogFileInterface.DisplayALogRec(">>> " + CountryDataObject.ID + " " + CountryDataObject.Code + " " +
                                                                        CountryDataObject.StringField + " " + CountryDataObject.NumField);
                    SelectByCodeLogFileInterface.DisplayALogRec("     [# nodes read:  " + CountryDataIndex.NodesRead + "]");
                    SelectByCodeLogFileInterface.DisplayALogRec(" ");
                }
                return true;
            }
            else
            {
                SelectByCodeLogFileInterface.DisplayALogRec("**ERROR: no country with Code: " + transArray[1]);// can't find country that is being queried
                SelectByCodeLogFileInterface.DisplayALogRec(" ");
                return false;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Inserts a record into the Index
        /// </summary>
        private static void InsertCountry(string[] transArray, CountryIndex CountryDataIndex, TheLog InsertToLogFileInterface)
        {
            InsertToLogFileInterface.DisplayALogRec("> **Insert not yet operational");
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Deletes a record from the country data file
        /// </summary>
        /// <returns>bool indicating success, BSTData object with record</returns>
        private static void DeleteById(string[] transInput, CountryData CountryDataObject, TheLog DeleteIdToLogFileInterface)
        {
            DeleteIdToLogFileInterface.DisplayALogRec("> **DeleteByID not yet operational");
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Deletes a record from the Index
        /// </summary>
        /// <returns>bool indicating success, BSTData object with record</returns>
        private static void DeleteByCode(string[] transInput, CountryIndex CountryDataIndex, TheLog DeleteIdToLogFileInterface)
        {
            DeleteIdToLogFileInterface.DisplayALogRec("> **DeleteByCode not yet operational");
        }
    }
}
