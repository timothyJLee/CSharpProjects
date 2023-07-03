/* PROJECT: WorldDataAppCS (C#)         PROGRAM: UserApp
 * AUTHOR: Timothy Lee / CS3310
 * OOP CLASSES USED (for Asgn 1):  TransData, CountryDataTableBST, BSTNode, TheLog
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 *      INPUT:   TransData*.txt         (handled by TransData class)
 *      OUTPUT:  TheLog.txt                (handled by TheLog class)
 *      OUTPUT:  BST.txt   (handled by CountryDataTableBST class)
 * DESCRIPTION:  The program itself is just the CONTROLLER which UTILIZES
 *      the SERVICES (public methods) of various OOP classes.
 *      It processes the transaction requests in TransData file.  It sends the request
 *      and the result to the Log file.
 *          The ACTUAL BSTData will be provided to user (in Log file).  Also, transaction requests
 *          based on PrimaryKey(name) are handled using CountryDataTableBST and the BinarySearchTree
 * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      loop til done with TransData
 *      {   input 1 transaction request from TransData
 *          switch to use that data to call appropriate service in CountryDataTableBST
 *                  class to handle request
 *      }
 *      finish up with TransData
 *      finish up with LogFile
 * CAUTION:  The program code below DOES NOT DEAL DIRECTLY WITH
 *      TransData, CountryDataTable, or Log.  Appropriate OOP classes handle those.  
 *******************************************************************************/

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using SharedClassLibrary; // for log / country data table


namespace UserApp
{
    public class UserApp
    {
        public static void Main(string[] args)
        {
            string transFileSuffix = args[0];
            string[] transInputArray;
            string transInput;

            TheLog userAppLog = new TheLog();
            TransData transInterface = new TransData(transFileSuffix);
            CountryDataTableBST countryDataTableUserAppBST = new CountryDataTableBST(RawData.Count + 50);
            CountryDataTableBST.RestoreTable(RawData.Count + 50);

            userAppLog.DisplayALogRec("CODE STATUS > UserApp Started");
            userAppLog.DisplayALogRec("FILE STATUS > TheLog FILE Opened");
            userAppLog.DisplayALogRec("FILE STATUS > TransData FILE Opened");

            int transCount = 0;
            while (transInterface.InputATransRec(out transInputArray, userAppLog))
            {
                transInput = transInterface.TransactionInput;

                switch (transInput)
                {
                    case "SN":
                        SelectByName(countryDataTableUserAppBST, transInputArray, userAppLog);
                        break;
                    case "SA":
                        SelectAll(transInputArray, countryDataTableUserAppBST, userAppLog);
                        break;
                    case "IN":
                        Insert(countryDataTableUserAppBST, transInputArray, userAppLog);
                        break;
                    case "DN":
                        Delete(countryDataTableUserAppBST, transInputArray, userAppLog);
                        break;
                }
                transCount++;
            }

            CountryDataTableBST.SaveTable(RawData.Count + 50);
            userAppLog.DisplayALogRec("FILE STATUS > TransData FILE Closed - " + transCount + " transactions processed");
            userAppLog.FinishUp();
        }


        //*********************** PRIVATE METHODS ********************************

        //------------------------------------------------------------------------------
        /// <summary>
        /// Formats transaction into a SelectByName request and calls the appropriate method from CountrySelectTableBST
        /// </summary>
        private static void SelectByName(CountryDataTableBST countrySelectTableBST, string[] transSelectArray, TheLog transSelectLog)
        {
            transSelectLog.DisplayALogRec(transSelectArray[0]);
            int numOfNodes = 0;
            BSTNode selectNode;
            if (countrySelectTableBST.SelectByName(transSelectArray[0].Substring(3, transSelectArray[0].Length - 3).ToLower().Trim(), out selectNode, out numOfNodes))
            {
                //if SelectByName returns true
                if(!selectNode.TombStone)
                {
                    // if not deleted
                    transSelectLog.DisplayALogRec("   " + PrintARec(selectNode, transSelectLog));
                    transSelectLog.DisplayALogRec("    >> " + numOfNodes + " nodes visited"); 
                }
                else
                {
                    //has been deleted and thus not found
                    transSelectLog.DisplayALogRec("   Sorry, " + transSelectArray[0].Substring(3, transSelectArray[0].Length - 3) + " not Found...");
                }                
            }
            else
            {
                //request not found
                transSelectLog.DisplayALogRec("   Sorry, " + transSelectArray[0].Substring(3, transSelectArray[0].Length - 3) + " not Found...");
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Uses InOrderTraversal to make a sorted table to print all records in alphabetical order
        /// </summary>
        private static void SelectAll(string[] transSelectArray, CountryDataTableBST countrySelectTableBST, TheLog transSelectLog)
        {
            transSelectLog.DisplayALogRec(transSelectArray[0]);
            CountryDataTableBST.InOrderTable = new List<BSTNode>();
            countrySelectTableBST.InOrderTraversal(CountryDataTableBST.CountryDataTable[0]);
            PrintTable(countrySelectTableBST, transSelectLog);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Takes transaction data and formats it into a node to be inserted into CountryDataTable
        /// </summary>
        private static void Insert(CountryDataTableBST countryInsertTableBST, string[] transSelectArray, TheLog transSelectLog)
        {
            int numOfNodes = 0;
            transSelectLog.DisplayALogRec(transSelectArray[0].Substring(34, 3) + "," + transSelectArray[1].Substring(1, transSelectArray[1].Length - 2) + "," +
                                                 transSelectArray[2].Substring(1, transSelectArray[2].Length - 2) + "," + transSelectArray[4] + "," + transSelectArray[6] + "," + transSelectArray[7]);
            if (transSelectArray.Length > 1)
            {
                BSTNode insertNode = new BSTNode(transSelectArray[0].Substring(34, 3), transSelectArray[1].Substring(1,transSelectArray[1].Length - 2),
                                                 transSelectArray[2].Substring(1, transSelectArray[2].Length - 2), transSelectArray[4], transSelectArray[6], transSelectArray[7], -1, -1, false);
                CountryDataTableBST.Insert(insertNode, out numOfNodes);
                transSelectLog.DisplayALogRec("   Ok, country Inserted");
                transSelectLog.DisplayALogRec("      >> " + numOfNodes + " visited");
            }
            else
            {
                transSelectLog.DisplayALogRec("ERROR:UserApp:Insert:transselectarrayNotLargeEnoughERROR");
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Uses CountryDataTableBST method to delete a node if found
        /// </summary>
        private static void Delete(CountryDataTableBST countryDeleteTableBST, string[] transSelectArray, TheLog transSelectLog)
        {
            int numOfNodes = 0;
            transSelectLog.DisplayALogRec(transSelectArray[0]);
            if (transSelectArray[0].Length > 3)
            {
                //If an actual request
                if (countryDeleteTableBST.Delete(transSelectArray[0].Substring(3, transSelectArray[0].Length - 3), out numOfNodes))
                {
                    transSelectLog.DisplayALogRec("   Ok, delete of " + transSelectArray[0].Substring(3, transSelectArray[0].Length - 3) + " successful...");
                }
                else
                {
                    //request not found
                    transSelectLog.DisplayALogRec("   Sorry, delete of " + transSelectArray[0].Substring(3, transSelectArray[0].Length - 3) + " FAILED...");
                }
            }
            else
            {
                //not an actual request
                transSelectLog.DisplayALogRec("   Sorry, delete of " + transSelectArray[0] + " FAILED...");
            }            
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Prints a single formatted record
        /// </summary>
        private static string PrintARec(BSTNode printNode, TheLog printLog)
        {           
            if (printNode != null)
            {
                StringBuilder nameBuilder = new StringBuilder(printNode.Data.Name, 18);
                StringBuilder continentBuilder = new StringBuilder(printNode.Data.Continent, 12);
                nameBuilder.Length = 18;
                continentBuilder.Length = 12;

                return (printNode.Data.Code.PadRight(6) +
                                  nameBuilder +
                                  continentBuilder +
                                  string.Format("{0:#,###,###.##}", printNode.Data.SurfaceArea).PadLeft(10) +
                                  string.Format("{0:#,###,###,###}", printNode.Data.Population).PadLeft(13).PadRight(12) +
                                  string.Format("{0:0.#}", printNode.Data.LifeExpectancy).PadRight(1).PadLeft(5));
            }
            return "";
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Prints a header and uses the PrintARec Method to print the entire table
        /// </summary>
        private static void PrintTable(CountryDataTableBST printTable, TheLog printLog)
        {
            string header = "CDE".PadRight(6) +
                       "NAME".PadRight(18, '-') +
                       "CONTINENT".PadRight(12, '-') +
                       "AREA".PadLeft(7, '-').PadRight(10, '-') +
                       "POPULATION".PadLeft(12, '-').PadRight(13, '-') +
                       "LIFE".PadRight(5).PadLeft(6);

            printLog.DisplayALogRec(header);

            for (int i = 0; i < CountryDataTableBST.InOrderTable.Count; i++)
            {
                printLog.DisplayALogRec(PrintARec(CountryDataTableBST.InOrderTable[i], printLog));
            }
        }
    }
}
