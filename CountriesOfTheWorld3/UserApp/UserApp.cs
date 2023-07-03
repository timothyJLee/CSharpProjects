/* PROJECT: WorldDataAppCS (C#)         PROGRAM: UserApp
 * AUTHOR: Timothy Lee / CS3310
 * OOP CLASSES USED (for Asgn 1):  TheLog, CountryDataTable
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 *      INPUT:   TransData*.txt         (handled by TheLog class)
 *      OUTPUT:  Log.txt                (handled by TheLog class)
 *      OUTPUT:  CountryDataTable.bin, CountryIndex   (handled by CountrDataTable and CountryIndex class)
 * DESCRIPTION:  The program itself is just the CONTROLLER which UTILIZES
 *      the SERVICES (public methods) of various OOP classes.
 *      It processes the transaction requests in TransData file.  It sends the request
 *      and the result to the Log file.
 *          The ACTUAL CountryDataTable will be provided to user (in Log file).  Also, transaction requests
 *          based on (id) are handled using CountryDataTable and the Hashed CountryDataTable file.  CountryIndex is similar
 *          except for a binary file is stored in an array from a csv file.
 * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      loop til done with TransData
 *      {   input 1 transaction request from TransData
 *          switch to use that data to call appropriate service in CountrDataTable
 *                  class to handle request
 *      }
 *      finish up with TransData
 *      finish up with CountryDataTable
 *      finish up with CountryIndex
 *      finish up with LogFile
 * CAUTION:  The program code below DOES NOT DEAL DIRECTLY WITH
 *      TransData or NameIndex or Log.  Appropriate OOP classes handle those.  
 *******************************************************************************/

using System;
using System.IO;
using System.Collections.Generic;
using SharedClassLibrary; // for TheLog


namespace UserApp
{
    public class UserApp
    {

        private static string header = ("ID ").PadRight(6) + ("CODE").PadRight(6) + ("NAME").PadRight(17) + ("CONTINENT").PadRight(15) +
                        ("AREA").PadRight(12) + ("POPULATION").PadRight(14) + ("L.EXP").PadRight(7);  // header matching requirements for userapp

        public static void Main(string[] args)
        {
            string transFileSuffix = args[0];

            string[] transInputArray;

            string transInput;
            char[] transCodeInput;

            TheLog logFileInterface = new TheLog();    // overloaded TransData with int to call logfile
            TransData transInterface = new TransData(transFileSuffix);

            logFileInterface.DisplayALogRec("CODE STATUS > Starting UserApp");
            logFileInterface.DisplayALogRec("FILE STATUS > Opened File TransData" + transFileSuffix + ".txt");

            CountryDataTable CountryDataTableUserApp = new CountryDataTable();
            logFileInterface.DisplayALogRec("FILE STATUS > CountryData FILE opened ");

            CountryIndex CountryIndexObject = new CountryIndex("C");
            CountryIndexObject.RestoreTable();
            logFileInterface.DisplayALogRec("CODE STATUS > CountryData INDEX created ");

            BSTData aRecord;
            while (transInterface.InputATransRec(out transInputArray, logFileInterface))
            {
                transInput = transInterface.TransactionInput;
                transCodeInput = transInterface.TransactionCode;

                switch (transInput)
                {
                    case "SI":
                        SelectById(transInputArray, (short)int.Parse(transInterface.Id), out aRecord, CountryDataTableUserApp, logFileInterface);
                        break;
                    case "SC":
                        SelectByCode(transInputArray, CountryIndexObject, logFileInterface);
                        break;
                    case "DI":
                        DeleteById(transInputArray, CountryDataTableUserApp, logFileInterface);
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
            CountryDataTableUserApp.FinishUp(logFileInterface, true);
            CountryIndexObject.FinishUp(logFileInterface, true);
            logFileInterface.DisplayALogRec("FILE STATUS > CountryData FILE closed ");
            logFileInterface.DisplayALogRec("CODE STATUS > Read in " + CountryDataTable.NRec.ToString() + " records");
            logFileInterface.FinishUp();
        }

        //*********************** PRIVATE METHODS ********************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Takes a id and attempts to find it within the CountryDataFile
        /// </summary>
        /// <returns>A bool indicating success and a BSTData object of the returned record</returns>
        private static bool SelectById(string[] transArray, short id, out BSTData aRecord, CountryDataTable CountryDataObject, TheLog selectLog)
        {
            aRecord = null;
            if (id != 0)
            {
                if (CountryDataObject.SelectByID(out aRecord, id) && aRecord != null)    // if a viable record
                {
                    if (aRecord.Code == "\0\0\0".ToCharArray() | aRecord.Code == "   ".ToCharArray())
                    {
                        selectLog.DisplayALogRec("**ERROR: no country with id " + id); // can't find country that is being queried
                        return false;
                    }
                    else
                    {
                        //aRecord = new BSTData(aRecord.ID, aRecord.Code, aRecord.Name, aRecord.Continent, aRecord.SurfaceArea, aRec.Population, aRec.LifeExpectancy, -1);

                        selectLog.DisplayALogRec("[" + Convert.ToString(aRecord.ID).PadLeft(3, '0') + "]".PadRight(2) + (new string(aRecord.Code)).Trim().PadRight(6) + (new string(aRecord.Name)).Trim().PadRight(15) +
                                    (new string(aRecord.Continent)).Trim().PadRight(15) + (aRecord.SurfaceArea.ToString()).PadRight(12) +
                                    (aRecord.Population.ToString()).PadRight(14) + (aRecord.LifeExpectancy));
                        return true;
                    }
                }
                else
                {
                    selectLog.DisplayALogRec("**ERROR: no country with id " + id); // can't find country that is being queried
                    return false;
                }
            }
            else
            {
                selectLog.DisplayALogRec("**ERROR: no country with id " + id);  // id is 0 and that can't happen
                //aRec = null;
                return false;
            }

        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Takes a Code and searches for it in Index and returns true if found and prints to log
        /// </summary>
        private static bool SelectByCode(string[] transArray, CountryIndex CountryDataIndex, TheLog SelectByCodeLogFileInterface)
        {
            BSTData selectRec;
            if (CountryDataIndex.SelectByCode(out selectRec, transArray[0].Substring(3, 3).ToCharArray()) && selectRec != null)
            {
                if (selectRec.Code == "\0\0\0".ToCharArray() | selectRec.Code == "   ".ToCharArray())
                {
                    SelectByCodeLogFileInterface.DisplayALogRec("**ERROR: no country with Code: " + transArray[0].Substring(3, 3)); // can't find country that is being queried
                    return false;
                }
                else
                {
                    //aRecord = new BSTData(aRecord.ID, aRecord.Code, aRecord.Name, aRecord.Continent, aRecord.SurfaceArea, aRec.Population, aRec.LifeExpectancy, -1);

                    SelectByCodeLogFileInterface.DisplayALogRec("[" + Convert.ToString(selectRec.IndexSubScript).PadLeft(3, '0') + "]".PadRight(2) + (new string(selectRec.Code)).Trim().PadRight(6) +
                                Convert.ToString(selectRec.IndexDRP).PadLeft(3, '0').PadRight(2) + Convert.ToString(selectRec.IndexLink).PadLeft(3, '0').PadRight(2));
                    return true;
                }
            }
            else
            {
                SelectByCodeLogFileInterface.DisplayALogRec("**ERROR: no country with Code: " + transArray[0].Substring(3, 3)); // can't find country that is being queried
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
        private static void DeleteById(string[] transInput, CountryDataTable CountryDataTableObject, TheLog DeleteIdToLogFileInterface)
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
