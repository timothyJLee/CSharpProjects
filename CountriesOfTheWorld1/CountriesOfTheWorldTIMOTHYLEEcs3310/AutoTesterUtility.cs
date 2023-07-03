/* PROJECT: WorldDataAppCS (C#)         PROGRAM: AutoTesterUtility
 * AUTHOR: Timothy Lee / CS3310
 * Programs Used CLASSES USED (for Asgn 1):  SetupProgram, UserApp, SnapShotUtility, TheLog
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 *      OUTPUT:  TheLog.txt                (handled by TheLog class)
 * DESCRIPTION:  The program itself is the Tester which calls all the programs in order in order to create and display a BST of
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
using SnapShotUtility;
using SharedClassLibrary;

namespace CountriesOfTheWorldTIMOTHYLEEcs3310
{
    class AutoTesterUtility
    {
        static void Main(string[] args)
        {//Delete the SINGLE output Log.txt file (if it exists) and create new file
            TheLog AutoTesterLog = new TheLog("create");

            AutoTesterLog.DisplayALogRec("FILE STATUS > TheLog FILE Closed");

            AutoTesterLog.DisplayALogRec("CODE STATUS > AutoTester Started");

            // The 3 parallel arrays (all strings, including the N's) with
            //      - hard-coded SUFFIX values to designate which files to use
            //      - N's to limit how many records to display during testing
            // The rawDataFileSuffix is used for RawData*.csv, transFileSuffix for TransData*.txt
            string[] rawDataFileSuffix = { "All", "All", "All", "All" };
            string[] transFileSuffix = { "1", "2", "3", "4"};
            string[] nRecToShow = { "all", "all", "all", "all" };

            AutoTesterLog.FinishUp();

            for (int i = 0; i < transFileSuffix.Length; i++) // For statement to cycle through runs of programs
            {
                // Delete 3 other output files (if they exist)
                DeleteFile("MainData.bin");
                DeleteFile("NameIndexBackup" + rawDataFileSuffix[i] + ".bin");
                DeleteFile("CodeIndexBackup" + rawDataFileSuffix[i] + ".bin");

                // Run All Coded Programs
                SetupProgram.SetupProgram.Main(new string[] { rawDataFileSuffix[i] });
                UserApp.UserApp.Main(new string[] { transFileSuffix[i] });
                SnapShotUtility.SnapShotUtility.Main(new string[] { nRecToShow[i] });
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
                DeleteLog.DisplayALogRec(fileName + " deleted");
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

