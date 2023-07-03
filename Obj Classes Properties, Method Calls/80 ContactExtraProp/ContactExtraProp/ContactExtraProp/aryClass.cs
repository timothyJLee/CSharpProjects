using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactExtraProp
{
    class aryClass
    {
        int[] _ary;


        public aryClass(int[] aryHere)
        {
             aryProp = aryHere;

             for (int s = 0; s < _ary.Length; s++)
                 Console.WriteLine(_ary[s]);   // = aryHere[s];


        }

        public int[] aryProp 
        {
        set 
        {
            
            _ary  = value;


        }

        }
//        ah Okay I understand it now. In another subject, I am having issues using a write only property to initialize the array in a class. Do properties for arrays act differently than any others? I use the for loop in the property to copy the parameter array, but it is not working. I was working if I am doing something wrong. I got it to work by doing the for loop in the constructor, but if I try to put it in the set statement of the property, it won't copy it. 

//The constructor accepts 2 arrays (int[] integerArray, string[] stringArray)

//Here is how I got it to work...

//            _nameStringArray = new string[nameArrayString.Length];
//            _gradeIntegerArray = new int[gradeArrayInteger.Length];
//            
//              for (int subscript = 0; subscript < nameArrayString.Length; subscript++)
//            {  
  // Transfers the information from the arrays and makes copies of the arrays for this class use only
// by making a copy, it is assured the changes are limited to the class's private instance variables
//                _nameStringArray[subscript] = nameArrayString[subscript];
//                _gradeIntegerArray[subscript] = gradeArrayInteger[subscript];
//            }



    }
}
