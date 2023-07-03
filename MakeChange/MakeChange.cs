///  Timothy lee
///  10/17/12
///  ClassRoomPointOfView:
///   - Learn how to manipulate inputs of console lines and display the contents of variables as outputs...
///  BusinessPointOfView:
///   - Determine the amount of coins that are in any given amount of pennies.  This could help a bank tremendously
///     
/*   Copy the C# file called MakeChangeClassExercise which has the following code in it.
     Add the lines to the code to produce the change (# of dimes and pennies) 
     given an input # of pennies 


3  Make Change (using integers) Given price (0-100) in pennies.

// Program Steps:
//  1 - set up the necessary variables  
//  2 - get the overall price from the user (with prompt)
//  3 - calcuate the number of dimes & pennies
//  4 - write out the final answers
// ************************************************************/

using System;

namespace MakeChange
{
    class Program
    {
        public static void Main()
        {
                    // DECLARE VARIABLES - 3 integer values (Input Pennies, Calc'd dimes/pennies)

            int userInputNumberOfPenniesInteger = 0;
            int calculatedNumberOfPenniesInteger = 0;
            int calculatedNumberOfNickelsInteger = 0;
            int calculatedNumberOfDimesInteger = 0;
            int calculatedNumberOfQuartersInteger = 0;

             
                    // PROMPT & GET PRICE FROM  0  to 100:
            Console.WriteLine("Please enter the number of pennies...");
            userInputNumberOfPenniesInteger = Convert.ToInt32(Console.ReadLine());

           

                    // DO CALCULATIONS
            if (userInputNumberOfPenniesInteger > 25)  // if there are enough pennies to make a quarter
            {
                calculatedNumberOfQuartersInteger = userInputNumberOfPenniesInteger / 25;  // determine how many quarters there are
                userInputNumberOfPenniesInteger = userInputNumberOfPenniesInteger - (calculatedNumberOfQuartersInteger * 25); // minus that from total number of pennies
            }
            if (userInputNumberOfPenniesInteger > 10)  // same for dimes as for quarters
            {
                calculatedNumberOfDimesInteger = userInputNumberOfPenniesInteger / 10;
                userInputNumberOfPenniesInteger = userInputNumberOfPenniesInteger - (calculatedNumberOfDimesInteger * 10);
            }
            if (userInputNumberOfPenniesInteger > 5)  // same for nickels as for the rest
            {
                calculatedNumberOfNickelsInteger = userInputNumberOfPenniesInteger / 5;
                userInputNumberOfPenniesInteger = userInputNumberOfPenniesInteger - (calculatedNumberOfNickelsInteger * 5);
            }
            if (userInputNumberOfPenniesInteger > 0) // if theres any left over, its pennies
            {
                calculatedNumberOfPenniesInteger = userInputNumberOfPenniesInteger;
            }
            

                   // WRITE ANSWER
            // should look like  this:      Original Amount:  87
            //
            //                             Change:          8 dimes  7 pennies
            Console.WriteLine("Original Amount: {0}", userInputNumberOfPenniesInteger);
            Console.WriteLine("Change: {0} Quarters, {1} Dimes, {2} Nickels, {3} Pennies", calculatedNumberOfQuartersInteger, calculatedNumberOfDimesInteger,
                              calculatedNumberOfNickelsInteger, calculatedNumberOfPenniesInteger);


           

             





        }
    }
}