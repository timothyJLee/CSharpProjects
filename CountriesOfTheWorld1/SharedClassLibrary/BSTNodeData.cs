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
    public class BSTNodeData
    {
        //**************************** PRIVATE DECLARATIONS ************************   
        private char[] code = new char[3];                           //Country code
        private char[] name = new char[17];                           //Name of country
        private char[] continent = new char[12];                      //What continent the country is located
        private int surfaceArea;                      //Size of the country
        private long population;                       //Total population of the country
        private float lifeExpectancy;                  //The average time someone is alive in the country


        //**************************** PUBLIC GET/SET METHODS **********************
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string SurfaceArea { get; set; }
        public string Population { get; set; }
        public string LifeExpectancy { get; set; }


        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public BSTNodeData(string passedCode, string passedName, string passedContinent, string passedSurfaceArea, string passedPopulation, string passedLifeExpectancy)
        {
            AssignPrivateValues(passedCode, passedName, passedContinent, passedSurfaceArea, passedPopulation, passedLifeExpectancy);
            AssignPublicValues();
        }


        //*********************** PRIVATE METHODS ********************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Public setter for BSTNode class
        /// </summary>
        private void AssignPublicValues()
        {
            Code = "";
            foreach (char c in code)
            {
                Code += c;
            }
            Name = "";
            foreach (char c in name)
            {
                Name += c;
            }
            Continent = "";
            foreach (char c in continent)
            {
                Continent += c;
            }
            SurfaceArea = surfaceArea.ToString();
            Population = population.ToString();
            LifeExpectancy = lifeExpectancy.ToString();
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Assigning private values
        /// </summary>
        private void AssignPrivateValues(string pCode, string pName, string pContinent, string pSurfaceArea, string pPopulation, string pLifeExpectancy)
        {
            code = pCode.ToCharArray();
            name = pName.ToCharArray();
            continent = pContinent.ToCharArray();
            surfaceArea = (int)Math.Ceiling(float.Parse(pSurfaceArea));
            population = long.Parse(pPopulation);
            lifeExpectancy = float.Parse(pLifeExpectancy);
        }
    }
}
