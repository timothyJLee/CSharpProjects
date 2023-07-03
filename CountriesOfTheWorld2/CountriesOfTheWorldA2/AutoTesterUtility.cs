/* PROJECT: WorldDataAppCS (C#)         PROGRAM: AutoTesterUtility
 * AUTHOR: Timothy Lee / CS3310
 * Programs Used CLASSES USED (for Asgn 1):  SetupProgram, UserApp, SnapShotUtility, TheLog
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 *      OUTPUT:  TheLog.txt                (handled by TheLog class)
 * DESCRIPTION:  The program itself is the Tester which calls all the programs in order in order to create and display a Country Data File of
 *      processed rawdata.  It also deletes any left over files from last run.
 * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      For Loop for multiple runs
 *      {  
 *      Calls programs with proper suffixes passed *      
 *      }
 *      finish up with LogFile
 *  *******************************************************************************/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupProgram;  // having to add in order to call the programs
using UserApp;
//using SnapShotUtility;
using SharedClassLibrary;

namespace CountriesOfTheWorldA2
{
    public class AutoTesterUtility
    {
        public static void Main(string[] args)
        {//Delete the SINGLE output Log.txt file (if it exists) and create new file
            TheLog AutoTesterLog = new TheLog("create");

            AutoTesterLog.DisplayALogRec("CODE STATUS > AutoTester Started"); // NOT THE LOG FOR SETUP OR USERAPP

            // The 3 parallel arrays (all strings, including the N's) with
            //      - hard-coded SUFFIX values to designate which files to use
            //      - N's to limit how many records to display during testing
            // The rawDataFileSuffix is used for RawData*.csv, transFileSuffix for TransData*.txt
            //string[] rawDataFileSuffix = { "A2", "A2", "A2" };
            string[] transFileSuffix = { "5", "6", "7" };
            string[] nRecToShow = { "all", "all", "all" };

            AutoTesterLog.FinishUp();

            for (int i = 5; i < 8; i++) // For statement to cycle through runs of programs
            {
                DeleteFile("CountryDataTable.bin");

                // Run All Coded Programs
                SetupProgram.SetupProgram.Main(new string[] { "A2" });
                UserApp.UserApp.Main(new string[] { i.ToString() });
            }
        }


        //**************************************************************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Deletes files from last run
        /// </summary>
        private static bool DeleteFile(String fileName) // File Deleter
        {
            TheLog DeleteLog = new TheLog();
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                DeleteLog.DisplayALogRec("FILE STATUS > " + fileName + " deleted");
                DeleteLog.FinishUp();
                return true;
            }
            else
            {
                DeleteLog.FinishUp();
                return false;
            }
        }
    }
}

