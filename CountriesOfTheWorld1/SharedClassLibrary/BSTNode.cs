/* PROJECT: WorldDataAppCS (C#)         CLASS:BSTNode
 * AUTHOR: Timothy Lee / CS3310
 * OOP CLASSES USED (for Asgn 1):CountryDataTableBST, BSTNodeData
 * DESCRIPTION:  Binary Search Tree Node with a Class to hold all the data
 *******************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary
{
    public class BSTNode
    {
        //**************************** PRIVATE DECLARATIONS ************************         
        private string primaryKey;
        private BSTNodeData data;

        private short leftChildPointer;
        private short rightChildPointer;

        private bool tombStone = false;


        //**************************** PUBLIC GET/SET METHODS **********************
        public string PrimaryKey { get; set; }
        public BSTNodeData Data { get; set; }

        public string LeftChildPointer { get; set; }
        public string RightChildPointer { get; set; }

        public bool TombStone { get; set; }


        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public BSTNode(string code, string name, string continent, string surfaceArea, string population, string lifeExpectancy, short lChldPtr, short rChldPtr, bool tomb)
        {
            primaryKey = name;
            data = new BSTNodeData(code, name, continent, surfaceArea, population, lifeExpectancy);
            tombStone = tomb;
            leftChildPointer = lChldPtr;
            rightChildPointer = rChldPtr;
            SetPublicLinks();
        }


        //*********************** PRIVATE METHODS ********************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Set the pulbic accessors
        /// </summary>
        private void SetPublicLinks()
        {
            PrimaryKey = primaryKey;
            LeftChildPointer = leftChildPointer.ToString();
            RightChildPointer = rightChildPointer.ToString();
            Data = data;
            TombStone = tombStone;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Set the Tombstone state
        /// </summary>
        public void SetTombStoneState()
        {
            tombStone = !tombStone;
            TombStone = tombStone;
        }
    }
}
