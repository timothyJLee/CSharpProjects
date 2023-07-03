/* PROJECT: DrivingAppA5 (C#)         CLASS: ShortestPath
 * AUTHOR: Timothy Lee / CS3310
 * Class  for implementing dijkstras algorithm.  Has all the necessary methods for 
 *    finding shortest path and reporting ansswers
 *******************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary
{
    public class ShortestPath
    {
        //handles pathfinding(dijkstras algorithm)
        //Uses UI.WriteThis() to report Trace and Answers to TheLog file
        // stores: 3 working-storage arrays,
        //  & trace array/list (STORES TARGETS IN THE ORDER THAT THEY ARE SELECTED)
        private Map shortestMap;
        private UI shortestInterface;
        private string filePrefix;

        private short[] distance;
        private bool[] included;
        private short[] path;  // or preecessor

        private List<short> trace = new List<short>();
        int totalDistance;
        short numOfTargets;
        string log = "";
        
        public ShortestPath(string passedPrefix, UI logInterface, Map passedMap)
        {
            filePrefix = passedPrefix;
            shortestInterface = logInterface;
            shortestMap = passedMap;
        }

        private void InitializeArrays(short startNodeNum, short destNodeNum)
        {
            //the 3 working-storage arrays
            distance = new short[Map.N];
            included = new bool[Map.N];
            path = new short[Map.N];

            for (short i = 0; i < Map.N; i++)
            {
                
                if (distance[i] != short.MaxValue && distance[i] != 0)
                {
                    path[i] = startNodeNum;
                }
                else
                {
                   path[i] = -1; 
                }
                distance[i] = shortestMap.GetRoadDistance(startNodeNum, i);
                included[i] = false;  
                }
            included[startNodeNum] = true;                     
        }

        private void ReportAnswer(short startNum, short destNum)
        {
            //which includes both the path distance & the actual path
            //as a list of city NAMES (not numbers)
            shortestInterface.WriteThis("");
            shortestInterface.WriteThis(shortestMap.WhatsCityName(startNum) + "(" + startNum + ") TO " + shortestMap.WhatsCityName(destNum) + "(" + destNum + ")");
            shortestInterface.WriteThis("DISTANCE: " + totalDistance);
            shortestInterface.WriteThis("PATH: " + log.Remove((log.Length - 1 - shortestMap.WhatsCityName(destNum).Length), shortestMap.WhatsCityName(destNum).Length)); // Remove the duplicate from broken while
            shortestInterface.WriteThis("");
            shortestInterface.WriteThis("TRACE OF TARGETS: " + shortestMap.WhatsCityName(startNum) + " " + ReportTraceOfTargets() + " " + shortestMap.WhatsCityName(destNum));
            shortestInterface.WriteThis("# TARGETS: " + numOfTargets);
            shortestInterface.WriteThis("#  #   #   #   #   #   #   #   #   #   #   #   #   #   #   #   ");
        }
        private void ReportAnswer(short startNum, short destNum, string overLoad) // report answerOverLoad for unreachable paths
        {
            //which includes both the path distance & the actual path
            //as a list of city NAMES (not numbers)
            shortestInterface.WriteThis("");
            shortestInterface.WriteThis(shortestMap.WhatsCityName(startNum) + "(" + startNum + ") TO " + shortestMap.WhatsCityName(destNum) + "(" + destNum + ")");
            shortestInterface.WriteThis("DISTANCE: ?");
            shortestInterface.WriteThis("PATH: SORRY - can't reach destination city from start city.");
            shortestInterface.WriteThis("");
            shortestInterface.WriteThis("TRACE OF TARGETS: ...");
            shortestInterface.WriteThis("# TARGETS: ...");
            shortestInterface.WriteThis("#  #   #   #   #   #   #   #   #   #   #   #   #   #   #   #   ");
        }

        private string ReportTraceOfTargets()
        {
            string pathString = "";

            for (short i = 0; i < Map.N; i++)
            {
                if (path[i] != -1 && included[i])
                    pathString += shortestMap.WhatsCityName(path[i]) + " ";
            }
            return pathString;
        }

        public void Search(short startNum, short destNum)  // ACTUALLY implementing Dijkstras algorithm
        {
            short targetDistance = short.MaxValue;
            short target = startNum;
            log = shortestMap.WhatsCityName(target) + " "; // start of the log to print paths
            string prevCity = "";
            totalDistance = 0;
            numOfTargets = 0;
            bool breakOverLoadBool = false; // to tell whether to break the while loop

            while (!included[destNum]) 
            {
                if (prevCity == shortestMap.WhatsCityName(target)) // Breaking infinite loops
                {
                    breakOverLoadBool = true;
                    break;
                }
                prevCity = shortestMap.WhatsCityName(target);

                targetDistance = short.MaxValue;
                for (short i = 0; i < Map.N; i++)  // Breaking Eden
                {
                    if (!included[i] && targetDistance > distance[i])
                    {
                        target = i;
                        targetDistance = distance[i];
                        if (target == destNum)
                        {
                            log += shortestMap.WhatsCityName(target) + " ";
                            break;
                        }
                    }                    
                }

                //Random R = new Random();
                //int chances;
                //int life = R.Next(777);
                //int Methylamine = R.Next(7777);
                //float blue = 0;
                //int money = 0;
                //while (Methylamine > 0)             // Breaking Bad
                //{
                //    blue = (Methylamine * 2) / 4;
                //    chances = R.Next(2);
                //    if (chances == 0)
                //    {
                //        life = life - 10;
                //    }
                //    else
                //    {
                //        money += (int)(100 * blue); 
                //    }

                //    if (life < 1)
                //    {
                //        //shortestInterface.WriteThis(" You died.  $" + money);
                //        //break;  Just in case
                //    }
                //}
                ////shortestInterface.WriteThis(" Out of Stuff.  $" + money);


                log += shortestMap.WhatsCityName(target) + " ";
                totalDistance += distance[target];

                included[target] = true;
                for (short j = 0; j < Map.N; j++)
                {
                    if (!included[j])
                    {
                        if (shortestMap.GetRoadDistance(target, j) != 0 && shortestMap.GetRoadDistance(target, j) != short.MaxValue)
                        {
                            if ((distance[target] + shortestMap.GetRoadDistance(target, j)) < distance[j]) // checking if two edges are shorter than just one
                            {
                                distance[j] = (short)(distance[target] + shortestMap.GetRoadDistance(target, j));
                                numOfTargets++;
                                path[j] = target;
                            }
                        }
                    }
                } 
            }

            if (breakOverLoadBool)  // Telling program if while broke and to use other report answer if so
            {
                ReportAnswer(startNum, destNum, "breakOverLoad");
            }
            else
            {
                ReportAnswer(startNum, destNum);
            }
        }

        public void DijkstrasShortestPath(short startNodeNum, short destNodeNum) //  Putting everything together
        {
                //initialize // initialize here not outside or wrong answer will pop out
            InitializeArrays(startNodeNum, destNodeNum);  //
            Search(startNodeNum, destNodeNum);
        }

        public void FinishUp()
        {
            // doesn't need any finishing but may if ever worked on later
        }
    }
}
