/* PROJECT: WorldDataAppCS (C#)         PROGRAM: UserApp
 * AUTHOR: Timothy Lee / CS3310
 * OOP CLASSES USED (for Asgn 1):  TheLog, CountryDataTable
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 *      INPUT:   TransData*.txt         (handled by TheLog class)
 *      OUTPUT:  Log.txt                (handled by TheLog class)
 *      OUTPUT:  CountrDataTable.txt   (handled by CountrDataTable class)
 * DESCRIPTION:  The program itself is just the CONTROLLER which UTILIZES
 *      the SERVICES (public methods) of various OOP classes.
 *      It processes the transaction requests in TransData file.  It sends the request
 *      and the result to the Log file.
 *          The ACTUAL CountrDataTable will be provided to user (in Log file).  Also, transaction requests
 *          based on RRN(id) are handled using CountrDataTable and the random
 *          access CountrDataTable file.
 * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      loop til done with TransData
 *      {   input 1 transaction request from TransData
 *          switch to use that data to call appropriate service in CountrDataTable
 *                  class to handle request
 *      }
 *      finish up with TransData
 *      finish up with CountryDataTable
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

            BSTData aRecord;
            while (transInterface.InputATransRec(out transInputArray, logFileInterface))
            {
                transInput = transInterface.TransactionInput;
                transCodeInput = transInterface.TransactionCode;

                switch (transInput)
                {
                    case "SI":
                        SelectById(int.Parse(transInterface.Id), out aRecord, CountryDataTableUserApp, logFileInterface);
                        break;
                    case "SA":
                        ListAllById(CountryDataTableUserApp, logFileInterface);
                        break;
                    case "IN":
                        Insert1Record(transInputArray, CountryDataTableUserApp, logFileInterface);
                        break;
                    case "DI":
                        DeleteById(int.Parse(transInterface.Id), out aRecord, CountryDataTableUserApp, logFileInterface);
                        break;
                }
                transInterface.Id = null;
            }
            CountryDataTableUserApp.FinishUp(logFileInterface, true);
            logFileInterface.DisplayALogRec("FILE STATUS > CountryData FILE closed ");
            logFileInterface.DisplayALogRec("CODE STATUS > Read in " + CountryDataTable.NRec.ToString() + " records");
            logFileInterface.FinishUp();
        }

        //*********************** PRIVATE METHODS ********************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Takes a RRN and attempts to find it within the CountryDataFile
        /// </summary>
        /// <returns>A bool indicating success and a BSTData object of the returned record</returns>
        private static bool SelectById(int RRN, out BSTData aRecord, CountryDataTable CountryDataObject, TheLog selectLog)
        {
            aRecord = null;
            string aRec;
            if (RRN != 0)
            {
                if (CountryDataObject.Read1Record(out aRec, RRN) && aRec != "")    // if a viable record
                {
                    if (aRec.Substring(6, CountryDataTable.SizeOfRRN) == "\0\0\0" | aRec.Substring(0, CountryDataTable.SizeOfRRN) == "   ")
                    {
                        selectLog.DisplayALogRec("**ERROR: no country with id " + RRN); // can't find country that is being queried
                        return false;
                    }
                    else
                    {
                        aRecord = new BSTData(RRN, CountryDataObject.Code.PadRight(CountryDataTable.SizeOfCode), CountryDataObject.Name.PadRight(CountryDataTable.SizeOfName),
                          CountryDataObject.Continent.PadRight(CountryDataTable.SizeOfContinent), CountryDataObject.SurfaceArea.PadRight(CountryDataTable.SizeOfSurfaceArea),
                          CountryDataObject.Population.PadRight(CountryDataTable.SizeOfPopulation),
                          CountryDataObject.LifeExpectancy.PadRight(CountryDataTable.SizeOfLifeExpectancy));

                        selectLog.DisplayALogRec("[" + Convert.ToString(aRecord.RRN).PadLeft(3, '0') + "]".PadRight(2) + (aRecord.Code).Trim().PadRight(6) + (aRecord.Name).Trim().PadRight(15) +
                                    (aRecord.Continent).Trim().PadRight(15) + (aRecord.SurfaceArea).PadRight(12) +
                                    (aRecord.Population).PadRight(14) + (aRecord.LifeExpectancy));
                        return true;
                    }                    
                }
                else
                {
                    selectLog.DisplayALogRec("**ERROR: no country with id " + RRN); // can't find country that is being queried
                    return false;
                }
            }
            else
            {
                selectLog.DisplayALogRec("**ERROR: no country with id " + RRN + ".  RRNs start with 1");  // RRN is 0 and that can't happen
                aRec = "";
                return false;
            }

        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Lists all records by ID skipping the empty locations
        /// </summary>
        private static void ListAllById(CountryDataTable CountryDataTablePrint, TheLog listAllToLogFileInterface)
        {
            int i = 1;
            string aRec;
            int nRecToPrint = CountryDataTable.NRec;

            listAllToLogFileInterface.DisplayALogRec("");
            listAllToLogFileInterface.DisplayALogRec("\n***************LIST ALL BY ID STARTED***************\n");
            listAllToLogFileInterface.DisplayALogRec("COUNTRY DATA FILE".PadRight(header.Length + 1, '*'));
            listAllToLogFileInterface.DisplayALogRec("Number of Records: " + CountryDataTable.NRec.ToString()); // write appropriate header
            listAllToLogFileInterface.DisplayALogRec(header);

            while (i <= nRecToPrint && CountryDataTablePrint.Read1Record(out aRec, i))  // while not max records
            {
                if(aRec != "")
                {
                    if (aRec.Substring(6, CountryDataTable.SizeOfRRN) == "\0\0\0" | aRec.Substring(0, CountryDataTable.SizeOfRRN) == "   ")
                    {
                        i++; // empty record so print nothing
                    }
                    else
                    {   // good record so print
                        listAllToLogFileInterface.DisplayALogRec("[" + Convert.ToString(i).PadLeft(3, '0') + "]".PadRight(6) + (CountryDataTablePrint.Code).PadRight(6) + (CountryDataTablePrint.Name).PadRight(15) +
                        (CountryDataTablePrint.Continent).PadRight(15) + (CountryDataTablePrint.SurfaceArea).PadRight(12) +
                        (CountryDataTablePrint.Population).PadRight(14) + (CountryDataTablePrint.LifeExpectancy));
                        i++;
                    }
                }
                else
                {
                    i++; // not a record
                }                
            }
            listAllToLogFileInterface.DisplayALogRec("End".PadRight(header.Length + 1, '*'));
            listAllToLogFileInterface.DisplayALogRec("");

            listAllToLogFileInterface.DisplayALogRec("#Rec in COUNTRY TABLE FILE: " + CountryDataTable.NRec);
            listAllToLogFileInterface.DisplayALogRec("\n**********End Of LIST ALL BY ID**********\n");
            listAllToLogFileInterface.DisplayALogRec("");
            listAllToLogFileInterface.DisplayALogRec("");
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Inserts a record into the CountryDataTable file
        /// </summary>
        private static void Insert1Record(string[] transArray, CountryDataTable CountryDataTableObject, TheLog InsertToLogFileInterface)
        {
            InsertToLogFileInterface.DisplayALogRec("IN " + transArray[2].Substring(1, transArray[2].Length - 2));
            BSTData newRecord = new BSTData(int.Parse(transArray[0].Substring(transArray[0].Length - 2, 2).TrimStart('(')), transArray[1].Substring(1, transArray[1].Length - 1),
                                            transArray[2].Substring(1, transArray[2].Length - 2), transArray[3].Substring(1, transArray[3].Length - 2),
                                            transArray[5], transArray[7], transArray[8]);
            CountryDataTableObject.Input1Record(newRecord, int.Parse(transArray[0].Substring(transArray[0].Length - 2, 2).TrimStart('(')));
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Deletes a record from the country data file
        /// </summary>
        /// <returns>bool indicating success, BSTData object with record</returns>
        private static bool DeleteById(int RRN, out BSTData aRec, CountryDataTable CountryDataTableObject, TheLog DeleteIdToLogFileInterface)
        {
            if (RRN > 0)
            {

                string printRecName;
                CountryDataTableObject.Read1Record(out printRecName, RRN);
                if (printRecName != "")
                {
                    if (printRecName.Substring(6, CountryDataTable.SizeOfRRN) == "\0\0\0" | printRecName.Substring(0, CountryDataTable.SizeOfRRN) == "   ")
                    {
                        aRec = null;
                        DeleteIdToLogFileInterface.DisplayALogRec("> **ERROR: no country with id " + RRN.ToString()); // no record exists in spot specified
                        return false;
                    }
                    else
                    {
                        if (CountryDataTableObject.Delete1Record(out aRec, RRN)) // if delete a rec works
                        {
                            DeleteIdToLogFileInterface.DisplayALogRec("> " + printRecName.Substring(9, 17).Trim() + " deleted"); //  print its deleted
                            return true;
                        }
                        else
                        {
                            DeleteIdToLogFileInterface.DisplayALogRec("> **ERROR: no country with id " + RRN.ToString()); // no record exists in spot specified
                            return false;
                        }
                    }                    
                }
                else
                {
                    aRec = null;
                    DeleteIdToLogFileInterface.DisplayALogRec("> **ERROR: no country with id " + RRN.ToString()); // no record exists in spot specified
                    return false;
                }
                
            }
            else
            {
                DeleteIdToLogFileInterface.DisplayALogRec("**ERROR: no country with id " + RRN.ToString()); // countries don't have an id of 0
                aRec = null;
                return false;
            }
        }
    }
}
