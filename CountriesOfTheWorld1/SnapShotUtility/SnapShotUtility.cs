/* PROJECT:  Asign 1 (C#)            PROGRAM: SnapShotUtility(AKA PrettyPrint (AKA ShowFilesUtility))
 * AUTHOR: Timothy Lee
 * FILE ACCESSED:
 *          (INPUT) BST.txt
 *          (OUTPUT) log.txt
 *          
 * USEAGE: To access and showcase the data stored within BST.txt file. 
 *         Quick run of the mill looping structure that will loops till 
 *         the end of the file, collecting information and displaying it 
 *         in a formatted matter.
 *******************************************************************************/

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using SharedClassLibrary;


namespace SnapShotUtility
{
        public class SnapShotUtility
        {
            public static void Main(string[] args)
            {
                TheLog snapShotLog = new TheLog();
                CountryDataTableBST countryPrintTable = new CountryDataTableBST(RawData.Count + 50);
                CountryDataTableBST.RestoreTable(RawData.Count + 50);
                PrintResults(CountryDataTableBST.CountryDataTable, snapShotLog);
                snapShotLog.FinishUp();
            }



            //------------------------------------------------------------------------------
            /// <summary>
            /// Formates the header to be displayed
            /// </summary>
            /// <returns>A ready to use string aligned in its columns</returns>
            private static string FormatHeader()
            {
                return "[SUB]".PadRight(6) +
                       "CDE".PadRight(6) +
                       "NAME".PadRight(18, '-') +
                       "CONTINENT".PadRight(12, '-') +
                       "AREA".PadLeft(7, '-').PadRight(10, '-') +
                       "POPULATION".PadLeft(12, '-').PadRight(13, '-') +
                       "LIFE".PadRight(5).PadLeft(6) +
                       "LCh".PadLeft(6) +
                       "RCh".PadLeft(6);
            }

            //------------------------------------------------------------------------------
            /// <summary>
            /// Print the results from the formatted text
            /// </summary>
            private static void PrintResults(BSTNode[] countryPrintList, TheLog printLog)
            {
                string header = FormatHeader();

                printLog.DisplayALogRec("");
                printLog.DisplayALogRec("\n***************Snap Shot Start***************\n");
                printLog.DisplayALogRec("COUNTRY DATA TABLE (BINARY SEARCH TREE)".PadRight(header.Length + 1, '*'));

                printLog.DisplayALogRec("N: " + CountryDataTableBST.N + ", NextEmpty: " + CountryDataTableBST.NextEmpty + ", RootPointer: " + Convert.ToString(CountryDataTableBST.RootPointer).PadLeft(3, '0'));
                printLog.DisplayALogRec(header);

                int i = 0;
                while (i < CountryDataTableBST.NextEmpty - 1)
                    {
                        if(countryPrintList[i].TombStone)
                        {
                            printLog.DisplayALogRec("[" + Convert.ToString(i).PadLeft(3, '0') + "]".PadRight(2) + "TOMBSTONE");
                            i++;
                        }
                        else
                        {
                            StringBuilder nameBuilder = new StringBuilder(countryPrintList[i].Data.Name, 18);
                            StringBuilder continentBuilder = new StringBuilder(countryPrintList[i].Data.Continent, 12);
                            nameBuilder.Length = 18;
                            continentBuilder.Length = 12;

                            printLog.DisplayALogRec("[" + Convert.ToString(i).PadLeft(3, '0') + "]".PadRight(2) +
                                              countryPrintList[i].Data.Code.PadRight(6) +
                                              nameBuilder +
                                              continentBuilder.ToString().PadRight(12) +
                                              string.Format("{0:#,###,###.##}", countryPrintList[i].Data.SurfaceArea).PadLeft(10) +
                                              string.Format("{0:#,###,###,###}", countryPrintList[i].Data.Population).PadLeft(13).PadRight(12) +
                                              string.Format("{0:0.#}", countryPrintList[i].Data.LifeExpectancy).PadRight(1).PadLeft(5) +
                                              int.Parse(countryPrintList[i].LeftChildPointer).ToString("D3").PadLeft(7) +
                                              int.Parse(countryPrintList[i].RightChildPointer).ToString("D3").PadLeft(6));
                        i++;
                        }
                    }
                printLog.DisplayALogRec("End".PadRight(header.Length + 1, '*'));
                printLog.DisplayALogRec("");
            }
        }
    }