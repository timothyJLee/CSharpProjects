

///  Timothy lee
///  12/10/12
///  ClassRoomPointOfView:
///   - Loops, Console input/output, arrays, sorting, searching, input files, 
///  BusinessPointOfView:
///   - To Calculate the Depreciation on various equipment over a period of years using an input file for a reference for the equipment and Salvage Price
///     This program is suited for a salvage or scrap business wanted a quick reference on prices of different items.
///     
///  DECISIONS: case, if, If-else, try-catch, nested decisions, single line if, do until Loop, For loop
///  METHODS:UserMenuChoices(), GetCase3BeginningValue(), GetCase3YearsValue(), GetEquipmentNameAndValidate
///  (string[] equipmentNameUserInputStringArray, decimal[] salvageValueLengthDecimalArray), GetSalvagePriceAndValidate
///  (decimal[] salvagePriceUserInputDecimalArray), BusinessTierClass()(overloaded), DepreciationCalculation(decimal 
///  beginningValue, int yearsOfDepreciation, decimal salvageValue), EquipmentNameAscendingSort(string[] array, decimal[] 
///  array2). SalvagePriceAscendingSort(decimal[] array, string[] array2), Swap()(overloaded), 
///  SalvagePriceUserInputSearch(decimal target, decimal[] salvagePriceSearchArray), equipmentNameUserInputSearch
///  (string target, string[] equipmentNameSearchArray)
///  



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace LeeTProgram7EquipmentDepreciationConsole
{
    class Program
    {       

        static void Main(string[] args)
        {
            //Declaring Variables for use in presentation tier
            string customerInputEquipmentNameString;       // For input from the user from console of the equipment name  case 3
            decimal customerInputSalvagePriceDecimal;      // For input from the user from the console of the Salvage Price case 4
            int customerInputInteger = 0;        // for deciding which menu choice the user chose
            int ARRAY_SIZE_INTEGER = 25;     //  Common Array Size for Parallel Arrays
            decimal beginningValueUserInputdecimal = 0m; ;  // for overloaded business tier constructor
            int yearsDepreciationUserInputInteger = 0;   // for overloaded business tier constructor
            decimal[] salvageValueDecimalArray = new decimal[ARRAY_SIZE_INTEGER];            // array to hold integer 'salvageValue'
            string[] equipmentNameStringArray = new string[ARRAY_SIZE_INTEGER];          // array to hold string 'equipmentName'            



            //Filling Arrays with the salvagedata.txt file
            StreamReader fillArrayFromFile = new StreamReader("SalvageData.txt");    // creates instance of stream reader (opens file)

            int indexCounter = 0;  // to cycle through arrays
            string equipmentNameFillString;  // to fill the equipment name array
            string salvageValueFillString;   // to fill the salvage value array
            string lineString;               // for the split in the comma delimited file

            //Loading Comma Delimited Data from File into Parallel Arrays
            for (indexCounter = 0; indexCounter < equipmentNameStringArray.Length; indexCounter++)
            { // for loop stepping through the array
                if (fillArrayFromFile.Peek() != -1)
                {   // if peek is a valid character continue
                    lineString = fillArrayFromFile.ReadLine();  // filling the linestring

                    var field1 = lineString.Split(',');  // splitting the linestring for seperate strings
                    equipmentNameFillString = field1[0].Trim(); // filling seperate strings
                    salvageValueFillString = field1[1].Trim();  // filling seperate strings

                    equipmentNameStringArray[indexCounter] = equipmentNameFillString;  // Filling the indexCounter element of the array with seperate string
                    salvageValueDecimalArray[indexCounter] = Convert.ToDecimal(salvageValueFillString);// Filling the indexCounter element of the array with seperate string
                } // end of if
            }// end of for loop

            Console.WriteLine("     Equipment Name:          Salvage Value:"); // initial display of table of values
            for (int i = 0; i < equipmentNameStringArray.Length; i++)   //    for loop stepping through array to display elements
            {
                Console.Write("\t {0}\t", equipmentNameStringArray[i]);  // write displaying one array
                Console.WriteLine("\t{0:C}".PadLeft(20 - equipmentNameStringArray[i].Length), salvageValueDecimalArray[i]); // writeline displaying second array
            }

            Console.WriteLine();  // line of empty space

            // reading Customer menu input
            customerInputInteger = UserMenuChoices();  // calling menuchoice to return value to customerinputinteger
            
            //passing values to business tier
            switch (customerInputInteger) // Using customerinput from menu to decide which business tier constructor to instantiate
            {
                case 1: // First case for displaying Sorted Parallel Array Values based on Equipment Name
                    //Calling first constructor
                    BusinessTierClass CalculateDepreciationCase1BusinessTierClass = new BusinessTierClass(salvageValueDecimalArray, equipmentNameStringArray, customerInputInteger);
                    Console.WriteLine("     Equipment Name:          Salvage Value:"); // Outputting column headers
                    for (int i = 0; i < CalculateDepreciationCase1BusinessTierClass.EquipmentNameArray.Length; i++)   //   for loop for outputting sorted arrays
                    {
                        Console.Write("\t {0}\t", CalculateDepreciationCase1BusinessTierClass.EquipmentNameArray[i]);
                        Console.WriteLine("\t{0:C}".PadLeft(20 - CalculateDepreciationCase1BusinessTierClass.EquipmentNameArray[i].Length), CalculateDepreciationCase1BusinessTierClass.SalvageValueArray[i]);
                    }
                    break;
                case 2:  // Second case for displaying Sorted Parallel Array Values based on Salvage Price
                    //Calling first constructor
                    BusinessTierClass CalculateDepreciationCase2BusinessTierClass = new BusinessTierClass(salvageValueDecimalArray, equipmentNameStringArray, customerInputInteger);
                    Console.WriteLine("     Equipment Name:          Salvage Value:");// Outputting column headers
                    for (int i = 0; i < CalculateDepreciationCase2BusinessTierClass.EquipmentNameArray.Length; i++)  //   for loop for outputting sorted arrays
                    {
                        Console.Write("\t {0}\t", CalculateDepreciationCase2BusinessTierClass.EquipmentNameArray[i]);
                        Console.WriteLine("\t{0:C}".PadLeft(20 - CalculateDepreciationCase2BusinessTierClass.EquipmentNameArray[i].Length), CalculateDepreciationCase2BusinessTierClass.SalvageValueArray[i]);
                    }
                    break;
                case 3: // Third case takes user inputs(equipment name, beginningvalue, yearsofdeprec., both arrays, menuchoice) and calculates amount of depreciation
                    customerInputEquipmentNameString = GetEquipmentNameAndValidate(equipmentNameStringArray, salvageValueDecimalArray);
                    if (customerInputEquipmentNameString.Length < 1)
                    {//  Make sure customerInputEquipmentNameString has been assigned before moving on
                        do
                        {//  do loop that runs methods when necessary
                            UserMenuChoices();//reload menu choices for user
                            customerInputEquipmentNameString = GetEquipmentNameAndValidate(equipmentNameStringArray, salvageValueDecimalArray);//assign string
                        } while (customerInputEquipmentNameString.Length < 1);//conditions for do while loop
                    }

                    beginningValueUserInputdecimal = GetCase3BeginningValue();  //Setting values for case3
                    yearsDepreciationUserInputInteger = GetCase3YearsValue();  //setting calues for case 3
                    // Calling the Business Class's second constructor
                    BusinessTierClass CalculateDepreciationCase3BusinessTierClass = new BusinessTierClass(salvageValueDecimalArray, equipmentNameStringArray, customerInputInteger,
                                                                                                          beginningValueUserInputdecimal, yearsDepreciationUserInputInteger, customerInputEquipmentNameString);
                    //Writing Header and properly formatting output!!!!!!!!!!!!!
                    Console.WriteLine("Timothy Lee");
                    Console.WriteLine("Equipment Name: {0}", CalculateDepreciationCase3BusinessTierClass.EquipmentNameUserInput);
                    Console.WriteLine("Beginning Value: {0}", CalculateDepreciationCase3BusinessTierClass.BeginningValueUserInput);
                    Console.WriteLine("Salvage Value: {0}", CalculateDepreciationCase3BusinessTierClass.SalvagePriceUserInput);
                    Console.WriteLine("Years Depreciated: {0}", CalculateDepreciationCase3BusinessTierClass.YearsDepreciationUserInput);
                    Console.WriteLine("Total Depreciation: {0}\n", CalculateDepreciationCase3BusinessTierClass.AmountOfDepreciationTotal);
                    Console.WriteLine("\t Year: \t Current Value: ");
                    Console.WriteLine(CalculateDepreciationCase3BusinessTierClass.OutputDepreciatedValues);     //Outputting properly formatted string                
                    break;
                case 4:  //Calling third constructor based off of Salvage Value
                    customerInputSalvagePriceDecimal = GetSalvagePriceAndValidate(salvageValueDecimalArray);
                    BusinessTierClass CalculateDepreciationCase4BusinessTierClass = new BusinessTierClass(salvageValueDecimalArray, equipmentNameStringArray, customerInputInteger, customerInputSalvagePriceDecimal);
                    Console.WriteLine("     Equipment Name:          Salvage Value:");  // outputting column headers
                    Console.Write("\t {0}\t", CalculateDepreciationCase4BusinessTierClass.EquipmentNameArray[CalculateDepreciationCase4BusinessTierClass.parallelArrayIndex]);
                    Console.WriteLine("\t{0:C}".PadLeft(20 - CalculateDepreciationCase4BusinessTierClass.EquipmentNameArray[CalculateDepreciationCase4BusinessTierClass.parallelArrayIndex].Length), CalculateDepreciationCase4BusinessTierClass.SalvageValueArray[CalculateDepreciationCase4BusinessTierClass.parallelArrayIndex]);
                    break;
                case 5:
                    // allow program to end...
                    break;
                default:
                    Console.WriteLine("UNKNOWN ERROR!!!!!!!!!!!!");  // letting any unknown errors be known
                    break;
            }           
        }
        

        //Methods!!!!

        //Method to get input for user menu choice
        private static int UserMenuChoices()  // Providing the choices for the user to navigate program
        {
            Console.WriteLine("\t1.  Sort and Output Salvage Equipment and Values by Equipment Name");
            Console.WriteLine("\t2.  Sort and Output Salvage Equipment and Values by Salvage Value");
            Console.WriteLine("\t3.  Input Equipment Name, Beginning Value, and Years.");
            Console.WriteLine("\t4.  Input Salvage Value for Equipment with matching Value.");
            Console.WriteLine("\t5.  Quit Program.");
            Console.WriteLine("\t\tPlease enter a number 1-5 for menu choice.\n\n");
            int userMenuChoiceInteger;  // variable to hold user choice

            try // Validation of user input
            {
                userMenuChoiceInteger = Convert.ToInt32(Console.ReadLine());  //converting and assigning to variable
                Console.WriteLine();

                if (userMenuChoiceInteger < 6 && userMenuChoiceInteger > 0)  // Validation
                {
                    return userMenuChoiceInteger;  //returning user choice
                }
                else
                {
                    Console.WriteLine("PLEASE ENTER A NUMBER BETWEEN 1 AND 5 FOR A MENU CHOICE!!!\n\n");  // telling about wrong input
                    return UserMenuChoices();
                }

            }
            catch
            {
                Console.WriteLine("PLEASE ENTER A NUMBER BETWEEN 1 AND 5 FOR A MENU CHOICE!!!\n\n"); // telling about wrong input
                return UserMenuChoices();
            }
        }

        //Method for getting the Beginning Value for the 3rd Case choice
         private static decimal GetCase3BeginningValue()
        {
            decimal beginningValueUserInputUserInputdecimal; //return value
            

            Console.Write("\tPlease enter the Beginning Value of the Equipment: "); // prompting for user input

            try // Validating user input
            {
                beginningValueUserInputUserInputdecimal = Convert.ToDecimal(Console.ReadLine());  // assigning user input
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("PLEASE ENTER A PROPER MONEY VALUE FOR THE BEGINNING VALUE!!! (####.##)\n\n"); // Telling user wrong input
                return GetCase3BeginningValue();  // caling for input again
            }
            return beginningValueUserInputUserInputdecimal;  // returning user input
         }            

        //Method for getting the Years Value for the 3rd case choice
         private static int GetCase3YearsValue()
         {
             int yearsDepreciationUserInputUserInputInteger; // creating userinput variable

             Console.Write("\tPlease enter the Years of Depreciation of the Equipment: ");  // prompting for user input

             try  // validating user input
            {
                yearsDepreciationUserInputUserInputInteger = Convert.ToInt32(Console.ReadLine());  // assigning user input
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("PLEASE ENTER A PROPER INTEGER VALUE FOR YEARS!!! (####)\n\n");// telling user wrong input
                return GetCase3YearsValue();
            }
            return yearsDepreciationUserInputUserInputInteger;  // returing value
         }

        //Method for getting the equipment name and Testing if it matches the namearray
         private static string GetEquipmentNameAndValidate(string[] equipmentNameUserInputStringArray, decimal[] salvageValueLengthDecimalArray)
         {
             string returnString = ""; // string for return value

             string equipmentNameString;  // storage fo equipmentname
             
             for (int i = 0; i < equipmentNameUserInputStringArray.Length; i++)   //   loop displaying equipment name
             {
                 Console.Write("\t {0}\n", equipmentNameUserInputStringArray[i]);
             }
             Console.Write("Please Enter the Equipment Name: ");  // user prompt
             equipmentNameString = Console.ReadLine();  // assignment of user input

             if (equipmentNameUserInputStringArray.Contains(equipmentNameString)) // validation of user input
             {
                 returnString = equipmentNameString;  // assignment of user input
             }
             else
             {
                 Console.WriteLine("PLEASE ENTER PROPER EQUIPMENT NAME!!!!!");  // Telling user wrong input
                 return "";  // returning for another call
             }

             return returnString;  // successful return
         }

        //Method for getting the salvage price and Testing if it matches the salvagearray
         private static decimal GetSalvagePriceAndValidate(decimal[] salvagePriceUserInputDecimalArray)
         {
             decimal returnDecimal = 0m;  // creating return variable

             decimal salvageInputDecimal;  // creating storage variable
                  
             for (int i = 0; i < salvagePriceUserInputDecimalArray.Length; i++)   //    displaying salvagearray
                 {
                     Console.Write("\t {0}\n", salvagePriceUserInputDecimalArray[i]);
                 }
             Console.Write("Please Enter the Salvage Price: ");   // prompt user input

             try  //validating user input
             {
                 salvageInputDecimal = Convert.ToDecimal(Console.ReadLine());  // assigning user input
                 Console.WriteLine();
             }
             catch
             {
                 Console.WriteLine("PLEASE ENTER A PROPER MONEY VALUE FOR THE SALVAGE PRICE!!! (####.##)\n\n"); //telling user wrong input
                 return GetSalvagePriceAndValidate(salvagePriceUserInputDecimalArray);  //recall
             }

             if (salvagePriceUserInputDecimalArray.Contains(salvageInputDecimal))  //more validating user input
             {
                 returnDecimal = salvageInputDecimal; // successful return
             }
             else
             {                 
                 Console.WriteLine("     Equipment Name:");
                 for (int i = 0; i < salvagePriceUserInputDecimalArray.Length; i++)   //    displaynig options
                 {
                     Console.Write("\t {0}\n", salvagePriceUserInputDecimalArray[i]);
                 }
                 Console.WriteLine("Enter a Proper Equipment Name from the List!"); // prompting proper input
                 GetSalvagePriceAndValidate(salvagePriceUserInputDecimalArray);
             }

             return returnDecimal;  // returning value
         }


         public static string[] equipmentNameStringArray { get; set; }  //public property
    }
}
