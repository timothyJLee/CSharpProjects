
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
        private short id;
        private char[] code = new char[3];                           //Country code
        private char[] name = new char[16];                           //Name of country
        private char[] continent = new char[13];                      //What continent the country is located
        private int surfaceArea;                      //Size of the country
        private long population;                       //Total population of the country
        private float lifeExpectancy;                  //The average time someone is alive in the country

        private short homeRRN;
        private short finalRRN;
        private short link;
        private char[] location;

        private short indexSubScript; // fields for CountryIndex
        private short indexHomeScript;
        private short indexDRP;
        private short indexLink;


        //**************************** PUBLIC GET/SET METHODS **********************
        public short ID { get { return id; } set { id = value; } }
        public char[] Code { get { return code; } set { code = value; } }
        public char[] Name { get { return name; } set { name = value; } }
        public char[] Continent { get { return continent; } set { continent = value; } }
        public int SurfaceArea { get { return surfaceArea; } set { surfaceArea = (short)value; } }
        public long Population { get { return population; } set { population = value; } }
        public float LifeExpectancy { get { return lifeExpectancy; } set { lifeExpectancy = value; } }

        public short HomeRRN { get { return homeRRN; } set { homeRRN = value; } }
        public short FinalRRN { get { return finalRRN; } set { finalRRN = value; } }
        public short Link { get { return link; } set { link = value; } }
        public char[] Location { get { return location; } set { location = value; } }

        public short IndexDRP { get { return indexDRP; } set { indexDRP = value; } }   //public properties for Index
        public short IndexLink { get { return indexLink; } set { indexLink = value; } }
        public short IndexSubScript { get { return indexSubScript; } set { indexSubScript = value; } }
        public short IndexHomeSubScript { get { return indexHomeScript; } set { indexHomeScript = value; } }

        //**************************** PUBLIC CONSTRUCTOR(S) ***********************
        public BSTData(short passedID, char[] passedCode, char[] passedName, char[] passedContinent, int passedSurfaceArea,
                       long passedPopulation, float passedLifeExpectancy, short passedLink)
        {
            AssignPrivateValues(passedID, passedCode, passedName, passedContinent, passedSurfaceArea, passedPopulation, passedLifeExpectancy, passedLink);
        }
        public BSTData(short passedID, char[] passedCode, char[] passedName, char[] passedContinent, int passedSurfaceArea,
                       long passedPopulation, float passedLifeExpectancy, short passedLink, short passedHomeRRN)
        {
            AssignPrivateValues(passedID, passedCode, passedName, passedContinent, passedSurfaceArea, passedPopulation, passedLifeExpectancy, passedLink, passedHomeRRN);
        }
        public BSTData(char[] passedCode, short passedLink, short passedDRP) // Constructor for CountryIndex
        {
            AssignPrivateValues(passedCode, passedLink, passedDRP);
        }


        //*********************** PRIVATE METHODS ********************************


        //------------------------------------------------------------------------------
        /// <summary>
        /// Assigning private values
        /// </summary>
        private void AssignPrivateValues(short pID, char[] pCode, char[] pName, char[] pContinent, int pSurfaceArea, long pPopulation, float pLifeExpectancy, short pLink)
        {
            id = pID;
            code = pCode;
            name = pName;
            continent = pContinent;
            if (pSurfaceArea != null) { surfaceArea = pSurfaceArea; }
            if (pPopulation != null) { population = pPopulation; }
            if (pLifeExpectancy != null) { lifeExpectancy = pLifeExpectancy; }
            link = pLink;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Assigning private values
        /// </summary>
        private void AssignPrivateValues(short pID, char[] pCode, char[] pName, char[] pContinent, int pSurfaceArea, long pPopulation, float pLifeExpectancy, short pLink, short pHomeRRN)
        {
            id = pID;
            code = pCode;
            name = pName;
            continent = pContinent;
            if (pSurfaceArea != null) { surfaceArea = pSurfaceArea; }
            if (pPopulation != null) { population = pPopulation; }
            if (pLifeExpectancy != null) { lifeExpectancy = pLifeExpectancy; }
            link = pLink;
            homeRRN = pHomeRRN;
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Assigning private values for CountryIndex
        /// </summary>
        private void AssignPrivateValues(char[] pCode, short pLink, short pDRP)
        {
            code = pCode;
            indexLink = pLink;
            indexDRP = pDRP;
        }
    }
}