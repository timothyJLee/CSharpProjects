

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




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeTProgram7EquipmentDepreciationConsole
{
    class BusinessTierClass
    {
        //backing fields
        private int _customerInputBusinessTierInteger;  // first constructor passed values
        private static int _parallelIndexInteger;  // index for connecting parallel arrays
        private static decimal[] _salvageValueBusinessTierDecimalArray; // first constructor passed values
        private static string[] _equipmentNameBusinessTierStringArray; // first constructor passed values
        private static string _outputDepreciatedValuesString;  // formatting output for displaying on presentation form

        private decimal _beginningValueBusinessTierUserInputDecimal;  // second constructor passed values
        private int _yearsDepreciationBusinessTierUserInputInteger;   // second constructor passed values
        private string _customerInputEquipmentNameBusinessTierString; // second constructor passed values

        private static decimal _amountCanBeDepreciatedTotalDecimal;  // beginning value - salvage value
        private static decimal _annualDepreciationAmountDecimal;  // _amountCanBeDepreciatedTotal / _yearsDepreciationBusinessTierUserInputInteger

        private decimal _customerInputSalvagePriceBusinessTierUserInputDecimal; //third constructor passed value

        //parameterized overloaded constructors
        public BusinessTierClass(decimal[] salvageValueDecimalArrayBusinessTier, string[] equipmentNameStringArrayBusinessTier, int customerInputIntegerBusinessTier)
        {// first constructor for sorting arrays
            SalvageValueArray = salvageValueDecimalArrayBusinessTier;  // assigning public properties
            EquipmentNameArray = equipmentNameStringArrayBusinessTier; // assigning public properties
            CustomerInputMenuChoice = customerInputIntegerBusinessTier;// assigning public properties

            switch (_customerInputBusinessTierInteger) // Case deciding if menu item 1 or 2 was chosen
            {
                case 1:
                    _equipmentNameBusinessTierStringArray = EquipmentNameAscendingSort(_equipmentNameBusinessTierStringArray, _salvageValueBusinessTierDecimalArray);
                    break; // if 1 Sort arrays by equipment name
                case 2: // if 2 Sort arrays by salvage price
                    SalvagePriceAscendingSort(_salvageValueBusinessTierDecimalArray,_equipmentNameBusinessTierStringArray);
                    break;
                default: // if other some unknown error with _customerInputBusinessTierInteger
                    Console.WriteLine("Something went wrong with _customerInputBusinessTierInteger variable");
                    break;
            }
        }

        public BusinessTierClass(decimal[] salvageValueDecimalArrayBusinessTier, string[] equipmentNameStringArrayBusinessTier, int customerInputIntegerBusinessTier,
                                 decimal beginningValueUserInputDecimalBusinessTier, int yearsDepreciationUserInputIntegerBusinessTier, string customerInputEquipmentNameStringBusinessTier)
        {// second overloaded constructor for calculating depreciation over a period of years
            int indexParallelInteger;
            decimal depreciatedAmountDecimal;

            SalvageValueArray = salvageValueDecimalArrayBusinessTier;// assigning public properties
            EquipmentNameArray = equipmentNameStringArrayBusinessTier;// assigning public properties
            CustomerInputMenuChoice = customerInputIntegerBusinessTier;// assigning public properties

            BeginningValueUserInput = beginningValueUserInputDecimalBusinessTier;  // assigning public properties second constructor
            YearsDepreciationUserInput = yearsDepreciationUserInputIntegerBusinessTier;  // assigning public properties second constructor
            EquipmentNameUserInput = customerInputEquipmentNameStringBusinessTier;  // assigning public properties second constructor

            indexParallelInteger = equipmentNameUserInputSearch(_customerInputEquipmentNameBusinessTierString, _equipmentNameBusinessTierStringArray);
            //deciding parellel index

            DepreciationCalculation(_beginningValueBusinessTierUserInputDecimal, _yearsDepreciationBusinessTierUserInputInteger, salvageValueDecimalArrayBusinessTier[indexParallelInteger]);
            // Passing values to calculate depreciation

            depreciatedAmountDecimal = _beginningValueBusinessTierUserInputDecimal;
            // Calculating depreciation amount
            
            for (int i = 1; i <= _yearsDepreciationBusinessTierUserInputInteger; i++)   //    outputing to formatted string
            {
                depreciatedAmountDecimal = depreciatedAmountDecimal - _annualDepreciationAmountDecimal;  // Calculating Depreciated amount               
                _outputDepreciatedValuesString += "\t" + i.ToString();
                _outputDepreciatedValuesString += "\t" + depreciatedAmountDecimal.ToString("c").PadLeft(20 - i.ToString().Length);
                _outputDepreciatedValuesString += "\n";
            }
        }

        public BusinessTierClass(decimal[] salvageValueDecimalArrayBusinessTier, string[] equipmentNameStringArrayBusinessTier, int customerInputIntegerBusinessTier, decimal customerInputSalvagePriceDecimalBusinessTier)
        {//third overloaded constructor for searching based on salvage value
            int indexParallelInteger; // index for parallel array

            SalvageValueArray = salvageValueDecimalArrayBusinessTier; // assigning public properties
            EquipmentNameArray = equipmentNameStringArrayBusinessTier; // assigning public properties
            CustomerInputMenuChoice = customerInputIntegerBusinessTier; // assigning public properties

            SalvagePriceUserInput = customerInputSalvagePriceDecimalBusinessTier; // assigning public properties third constructor

            indexParallelInteger = SalvagePriceUserInputSearch(_customerInputSalvagePriceBusinessTierUserInputDecimal, _salvageValueBusinessTierDecimalArray);
            // assigning to index

            //Case assigning index to parallelarrayindex
            switch (indexParallelInteger)
            {
                case -1:
                    Console.WriteLine("Something went wrong with indexParallelInteger variable - value = -1..."); // some unknown error
                    break;
                default:
                    parallelArrayIndex = indexParallelInteger;
                    break;
            }
        }

        //public properties
        public int CustomerInputMenuChoice                      //public property for menu choice
        {
            get { return _customerInputBusinessTierInteger; }                // refers to instance variable
            set { _customerInputBusinessTierInteger = value; }
        }

        public int parallelArrayIndex                      //public property for parallelarray
        {
            get { return _parallelIndexInteger; }                // refers to instance variable
            set { _parallelIndexInteger = value; }
        }

        public decimal[] SalvageValueArray                      //public property for SalvageArray
        {
            get { return _salvageValueBusinessTierDecimalArray; }                // refers to instance variable
            set { _salvageValueBusinessTierDecimalArray = value; }
        }

        public decimal AmountOfDepreciationTotal                      //public property for totalDepreciation
        {
            get { return _amountCanBeDepreciatedTotalDecimal; }                // refers to instance variable
            set { _amountCanBeDepreciatedTotalDecimal = value; }
        }

        public decimal AnnualDepreciationAmount                      //public property for depreciation/year
        {
            get { return _annualDepreciationAmountDecimal; }                // refers to instance variable
            set { _annualDepreciationAmountDecimal = value; }
        }

        public string[] EquipmentNameArray                      //public property for equipmentname
        {
            get { return _equipmentNameBusinessTierStringArray; }                // refers to instance variable
            set { _equipmentNameBusinessTierStringArray = value; }
        }

        public string OutputDepreciatedValues                      //public property for output string
        {
            get { return _outputDepreciatedValuesString; }                // refers to instance variable
            set { _outputDepreciatedValuesString = value; }
        }

        public decimal BeginningValueUserInput                      // starts with beginning value
        {
            get { return _beginningValueBusinessTierUserInputDecimal;}                // refers to instance variable
            set { _beginningValueBusinessTierUserInputDecimal = value; }
        }

        public int YearsDepreciationUserInput                      // starts with years of depreciation
        {
            get { return _yearsDepreciationBusinessTierUserInputInteger;}                // refers to instance variable
            set { _yearsDepreciationBusinessTierUserInputInteger = value; }
        }

        public string EquipmentNameUserInput                      //public property for userinputequipment name
        {
            get { return _customerInputEquipmentNameBusinessTierString; }                // refers to instance variable
            set { _customerInputEquipmentNameBusinessTierString = value; }
        }

        public decimal SalvagePriceUserInput                      //public property for Salvage price iser input
        {
            get { return _customerInputSalvagePriceBusinessTierUserInputDecimal; }                // refers to instance variable
            set { _customerInputSalvagePriceBusinessTierUserInputDecimal = value; }
        }

        //methods
        private static void DepreciationCalculation(decimal beginningValue, int yearsOfDepreciation, decimal salvageValue)
        {// calculates depreciation with three input values
            _amountCanBeDepreciatedTotalDecimal = beginningValue - salvageValue; // calculating amount total depreciation
            _annualDepreciationAmountDecimal = _amountCanBeDepreciatedTotalDecimal / yearsOfDepreciation; // calculating amount annually             
        }

        private static string[] EquipmentNameAscendingSort(string[] array, decimal[] array2)
        {// returns sorted string array of equipment names with two array inputs and sorts salvage array accordingly
            Array.Sort(array, array2);
            _salvageValueBusinessTierDecimalArray = array2;
            return array; //returing array value
        }

        private static void SalvagePriceAscendingSort(decimal[] array, string[] array2)  // Sorting through salvage price
        {
            int SmallestIndex;              //   (holds top/leftmost element) position in compare
            int NextIndex;                  //   holds the next / rightmost element position in compare
            String SwapString = "Y";        //   indicates if a swap was made in the pass..if so..must
            //     go through another 'Pass'
            int MaxCompares = array.Length;     // set initial # elements. # compares is one less than # elements

            // PASS Loop:
            while (SwapString == "Y")           // loop while more to sort
            {
                MaxCompares -= 1;               // actual # compares is 1 less than # elements
                SwapString = "N";               // before start compares..set to N - Y when swap is made (indicating another pass)

                // COMPARE Loop:
                for (SmallestIndex = 0; SmallestIndex < MaxCompares; SmallestIndex++)
                {
                    NextIndex = SmallestIndex + 1;               // set 'next' index to compare left one (smallest index) w/right one (next index)
                    if (array[SmallestIndex] > array[NextIndex])     // test
                    {
                        Swap(array, SmallestIndex, NextIndex);       // execute Swap when left is > right
                        Swap(array2, SmallestIndex, NextIndex);
                        SwapString = "Y";                            // indicate swap made and another Pass will be required
                    }
                }
            }
            _salvageValueBusinessTierDecimalArray = array;  // being sure to assign to both arrays
            _equipmentNameBusinessTierStringArray = array2;  // being sure to assign to both arrays
        }
        
        private static void Swap(decimal[] a, int left, int right) // overloaded swap method, one for decimal[], one for string[]
        {
            decimal temp = a[left];                              // place left element in temporary hold variable
            a[left] = a[right];                             // move right element into left position
            a[right] = temp;                                // move 'held' value into left position
        }
        private static void Swap(string[] a, int left, int right) // overloaded swap method, one for decimal[], one for string[]
        {
            string temp = a[left];                              // place left element in temporary hold variable
            a[left] = a[right];                             // move right element into left position
            a[right] = temp;                                // move 'held' value into left position
        }

        private static int SalvagePriceUserInputSearch(decimal target, decimal[] salvagePriceSearchArray)// ON EXAM!!!!!!
        {// Searching the Salvage Price for Case 4
            for (int i = 0; i < salvagePriceSearchArray.Length; i++)  //setting up for loop to stop at array length      
            {
                if (salvagePriceSearchArray[i] == target)    //testing for target
                    return i;						// SUCCESSFUL & EXITS METHOD
            }                                       // PASS BACK THE INDEX!
            return -1;								// UNSUCCESSFUL SEARCH RETURNS A -1
        }
        private static int equipmentNameUserInputSearch(string target, string[] equipmentNameSearchArray)// ON EXAM!!!!!!
        {// equipment name search based on userinput
            for (int i = 0; i < equipmentNameSearchArray.Length; i++)   // QUICK AND DIRTY BUT BREAKS RULES!       
            {
                if (equipmentNameSearchArray[i] == target)     // checking for target
                    return i;						// SUCCESSFUL & EXITS METHOD
            }                                       // PASS BACK THE INDEX!
            return -1;								// UNSUCCESSFUL SEARCH RETURNS A -1
        }              
    }
}
