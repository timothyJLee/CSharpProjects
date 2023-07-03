/* PROJECT: DrivingAppA5 (C#)         PROGRAM: DrivingAppMain
 * AUTHOR: Timothy Lee / CS3310
 * OOP CLASSES USED (for Asgn 5):   Map, ShortestPath, UI
 * DESCRIPTION:  The program itself is just the CONTROLLER which UTILIZES
 *      the SERVICES (public methods) of various OOP classes.
 *      It processes the transaction requests in CityPairs file.  It sends the request
 *      and the result to the Log file.
 *          The ACTUAL edgeweightAdjacency matrix will be provided to user (through Roads.bin file). 
 * CONTROLLER ALGORITHM:  Traditional sequential-stream processing - i.e., 
 *      loop til done with TransData
 *      {   input 1 transaction request from TransData
 *          switch to use that data to call appropriate service in CountrDataTable
 *                  class to handle request
 *      }
 *      finish up with TransData
 *      finish up with LogFile
 * CAUTION:  The program code below DOES NOT DEAL DIRECTLY WITH
 *      TransData or NameIndex or Log.  Appropriate OOP classes handle those.  
 *******************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedClassLibrary;

namespace DrivingAppMain
{
    public class DrivingAppMain
    {
        public static void Main(string[] args)
        {
            string filePreFix = args[0];

            short cityNum1;
            short cityNum2;

            Map drivingMap = new Map(filePreFix);
            UI drivingUI = new UI(filePreFix);
            ShortestPath drivingShortestPath = new ShortestPath(filePreFix, drivingUI, drivingMap);
            
            string[] record;
            while(drivingUI.MoreTrans(out record))
            {
                if (record[0] != "%")
                {
                    //ask ui for 2 Cities
                    cityNum1 = drivingMap.WhatsCityNumber(record[0]);
                    cityNum2 = drivingMap.WhatsCityNumber(record[1]);
                    if (cityNum1 != -1 && cityNum2 != -1)
                    {
                        drivingShortestPath.DijkstrasShortestPath(cityNum1, cityNum2);
                    }
                    //ask shortestPath to findPath given the two numbers
                    // - needs to access ui and map objects
                }               
            }

            //Call finish up for the 3 objects
            drivingMap.FinishUp();
            drivingUI.FinishUp();
            drivingShortestPath.FinishUp();
        }
    }
}
