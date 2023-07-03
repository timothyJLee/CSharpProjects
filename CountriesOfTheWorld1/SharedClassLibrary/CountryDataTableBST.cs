/* PROJECT: WorldDataAppCS (C#)         CLASS:CountryDataTableBST
 * AUTHOR: Timothy Lee / CS3310
 * OOP CLASSES USED (for Asgn 1):CountryDataTableBST, CountryDataTableBST, BSTNodeData
 * DESCRIPTION:  Binary Search Tree Class to store an array of BSTNodes which makes up the
 *   binary search tree.  Provides classes for inserts, deletes, searches, traversals, and
 *   various actions needed for a BST.
 *******************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SharedClassLibrary
{
    public class CountryDataTableBST
    {
        //**************************** PRIVATE DECLARATIONS ************************   
        private static short rootPtr = -1;
        private static short n = 0;  // number of good records (insert ++) (delete --)
        private static short nextEmpty = 0; // next empty location (insert ++) (delete does nothing)

        private static BSTNode[] countryDataTable;


        //**************************** PUBLIC GET/SET METHODS **********************
        public static BSTNode[] CountryDataTable { get; set; }
        public static List<BSTNode> InOrderTable { get; set; }
        public static short RootPointer { get; set; }
        public static short N { get; set; }
        public static short NextEmpty { get; set; }


        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public CountryDataTableBST(int size)
        {
            countryDataTable = new BSTNode[size];
            rootPtr = -1;
            n = 0;
            nextEmpty = 0;
        }


        //**************************** PUBLIC SERVICE METHODS **********************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Selects by name using BSTSearch
        /// </summary>
        public bool SelectByName(string name, out BSTNode nameNode, out int nodesVisited)
        {
            int index;
            nameNode = BSTSearch(name, out index, out nodesVisited);
            if (nameNode == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Inserts into proper place on binarysearchtree
        /// </summary>
        public static bool Insert(BSTNode newBSTNode, out int numberOfNodes)
        {
            countryDataTable[nextEmpty] = newBSTNode;
            numberOfNodes = 0;
            int i;
            int parentI = 0;
            char LorR = '\0';
            if (rootPtr == -1)   //[special case - no nodes in BST yet] 
            {
                rootPtr = nextEmpty;
            }
            else   //[normal case]     
            {
                i = rootPtr;
                while (i != -1)
                {
                    parentI = i;
                    if (newBSTNode.PrimaryKey.Trim().ToUpper().CompareTo(countryDataTable[i].PrimaryKey.Trim().ToUpper()) == -1)
                    {
                        i = int.Parse(countryDataTable[i].LeftChildPointer);
                        LorR = 'L';
                    }
                    else
                    {
                        i = int.Parse(countryDataTable[i].RightChildPointer);
                        LorR = 'R';
                    }
                    numberOfNodes++;
                }
                if (LorR == 'L')
                {
                    countryDataTable[parentI].LeftChildPointer = nextEmpty.ToString();
                }
                else
                {
                    countryDataTable[parentI].RightChildPointer = nextEmpty.ToString();
                }
            }

            n++;
            nextEmpty++;
            SetPublicTable();
            return true;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// delete using bstsearch
        /// </summary>
        public bool Delete(string name, out int numberOfNodes)
        {
            int index;
            numberOfNodes = 0;
            BSTSearch(name, out index, out numberOfNodes);
            if (index == -1)
            {
                // name does not exist
                return false;
            }
            else
            {
                countryDataTable[index].SetTombStoneState();
                n--;
                SetPublicTable();
                return true;
            }           
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Save Table to file
        /// </summary>
        public static void SaveTable(int size)
        {
            StreamWriter tableWriter = new StreamWriter(File.Open("BST.txt", FileMode.Create));
            int i = 0;
            while (i < size)
            {
                if (CountryDataTable[i] != null)
                {
                    tableWriter.WriteLine(CountryDataTable[i].PrimaryKey + ":" +
                                      CountryDataTable[i].Data.Code + ":" +
                                      CountryDataTable[i].Data.Name + ":" +
                                      CountryDataTable[i].Data.Continent + ":" +
                                      CountryDataTable[i].Data.SurfaceArea + ":" +
                                      CountryDataTable[i].Data.Population + ":" +
                                      CountryDataTable[i].Data.LifeExpectancy + ":" +
                                      CountryDataTable[i].LeftChildPointer + ":" +
                                      CountryDataTable[i].RightChildPointer + ":" +
                                      CountryDataTable[i].TombStone.ToString());
                }                
                i++;
            }
            tableWriter.Close();
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Restore table from file
        /// </summary>
        public static void RestoreTable(int size)
        {
            StreamReader tableReader = new StreamReader(File.Open("BST.txt", FileMode.Open));

            rootPtr = 0;
            int i = 0;
            while (tableReader.EndOfStream != true)
            {
                string theLine = tableReader.ReadLine();
                string[] lineSplit = theLine.Split(':');
                if (theLine != null)
                {
                    BSTNode newNode = new BSTNode(lineSplit[1], lineSplit[2], lineSplit[3], lineSplit[4], lineSplit[5], lineSplit[6],
                                                  short.Parse(lineSplit[7]), short.Parse(lineSplit[8]), bool.Parse(lineSplit[9]));
                    countryDataTable[i] = newNode;
                    n++;
                    nextEmpty++;
                    i++;
                }
            }
            tableReader.Close();
            SetPublicTable();
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Do an inOrderTraversal to put tree in order
        /// </summary>
        public BSTNode InOrderTraversal(BSTNode countryNode)
        {
            if (countryNode == null)
            {
                return null;
            }
            else
            {
                if (int.Parse(countryNode.LeftChildPointer) != -1)
                {
                    InOrderTraversal(countryDataTable[int.Parse(countryNode.LeftChildPointer)]);
                }
                
                InOrderTable.Add(countryNode);
                             
                if (int.Parse(countryNode.RightChildPointer) != -1)
                {
                    InOrderTraversal(countryDataTable[int.Parse(countryNode.RightChildPointer)]);
                }
            }
            return countryNode;
        }


        //*********************** PRIVATE METHODS ********************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Do search by following links
        /// </summary>
        private BSTNode BSTSearch(string target, out int i, out int numberOfNodes)
        {
            numberOfNodes = 0;
            BSTNode searchNode = null;
            i = rootPtr;
            while (i != -1 && target.Trim().ToLower() != countryDataTable[i].PrimaryKey.Trim().ToLower())
            {
                if (target.Trim().ToUpper().CompareTo(countryDataTable[i].PrimaryKey.Trim().ToUpper()) == -1)
                {
                    i = int.Parse(countryDataTable[i].LeftChildPointer);
                }
                else
                {
                    i = int.Parse(countryDataTable[i].RightChildPointer);
                }
                numberOfNodes++;
            }
            if (i == -1)
            {
                // handle UNSUCCESSFUL search situation
                return searchNode;
            }
            else
            {
                // handle SUCCESSFUL search situation
                searchNode = countryDataTable[i];
                return searchNode;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// public setter so can access data from other classes
        /// </summary>
        private static void SetPublicTable()
        {
            CountryDataTable = countryDataTable;
            RootPointer = rootPtr;
            N = n;
            NextEmpty = nextEmpty;
        }
    }
}
