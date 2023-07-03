
/* PROJECT: WorldDataAppCS (C#)         CLASS: BSTData
 * AUTHOR: Timothy Lee / CS3310
 * FILE STRUCTURE: Object/Class
 * DESCRIPTION: Class properly initializing and holding CountryDataTable File Records for processing
 *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary
{
    public class BSTData
    {
        //**************************** PRIVATE DECLARATIONS ************************ 
        private int privRRN;
        private char[] code = new char[3];                           //Country code
        private char[] name = new char[16];                           //Name of country
        private char[] continent = new char[13];                      //What continent the country is located
        private int surfaceArea;                      //Size of the country
        private long population;                       //Total population of the country
        private float lifeExpectancy;                  //The average time someone is alive in the country


        //**************************** PUBLIC GET/SET METHODS **********************
        public int RRN { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string SurfaceArea { get; set; }
        public string Population { get; set; }
        public string LifeExpectancy { get; set; }


        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public BSTData(int RRNum, string passedCode, string passedName, string passedContinent, string passedSurfaceArea, string passedPopulation, string passedLifeExpectancy)
        {
            AssignPrivateValues(RRNum, passedCode, passedName, passedContinent, passedSurfaceArea, passedPopulation, passedLifeExpectancy);
            AssignPublicValues();
        }


        //*********************** PRIVATE METHODS ********************************
        //------------------------------------------------------------------------------
        /// <summary>
        /// Public setter for BSTNode class
        /// </summary>
        private void AssignPublicValues()
        {
            RRN = privRRN;
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
        private void AssignPrivateValues(int pRRN, string pCode, string pName, string pContinent, string pSurfaceArea, string pPopulation, string pLifeExpectancy)
        {
            privRRN = pRRN;
            code = pCode.ToCharArray();
            name = pName.ToCharArray();
            continent = pContinent.ToCharArray();
            if (pSurfaceArea != "         ") { surfaceArea = (int)Math.Ceiling(float.Parse(pSurfaceArea)); }
            if (pPopulation != "          ") { population = (long)float.Parse(pPopulation); }
            if (pLifeExpectancy != "    ") { lifeExpectancy = float.Parse(pLifeExpectancy); }
        }
    }
}