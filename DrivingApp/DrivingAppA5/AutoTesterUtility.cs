/* PROJECT: DrivingAppA5 ASSN #5 (C#)         PROGRAM: AutoTesterUtility
 * AUTHOR: Timothy Lee / CS3310
 * Programs Used CLASSES USED (for Asgn 5):  SetupUtility, DrivingApp, TheLog
 * FILES ACCESSED: (only INDIRECTLY through the OOP classes)
 * DESCRIPTION:  The program itself is the Tester which calls all the programs in order in order to create and display a Country Data File of
 *      processed rawdata.  It also deletes any left over files from last run.
 * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      For Loop for multiple runs
 *      {  
 *      Calls programs with proper suffixes passed *      
 *      }
 *  *******************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetupUtility;
using DrivingAppMain;
using SharedClassLibrary;

namespace DrivingAppA5
{
    class AutoTesterUtility
    {
        static void Main(string[] args)
        {
            string[] fileNamePreFix = { "Europe", "Other" };

            UI deleteLog = new UI("C", fileNamePreFix[0]);
            deleteLog.FinishUp();

            for (int i = 0; i < 2; i++)
            {
                SetupUtility.SetupUtility.Main(new string[]{fileNamePreFix[i], i.ToString()});
                DrivingAppMain.DrivingAppMain.Main(new string[]{fileNamePreFix[i], i.ToString()});
            }            
        }
    }
}
