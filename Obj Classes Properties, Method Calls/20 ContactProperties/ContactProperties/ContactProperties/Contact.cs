// Properties are added for every instance variable to "protect them".
// 
// Any method (including constructors) wanting to access an instance variable
//      accesses its Property instead.  And the Property in turn accesses the
//      instance variable.
// Properties add a "method-like" layer, where ACTION code can be inserted
//      (shown in later examples).
// The get accessor gets the instance variable's value and returns it
//      to whomever called the Property.
//      EXAMPLE:  see the ShowContactData method
// The set accessor takes whatever value the caller gives the Property
//      and sets the instance variable to that value.
//      EXAMPLE:  see the GetData method
//
// C# Programmer RULES that some follow and are show here:
// RULE 1:  The Property name is the same as the instance variable name,
//              EXCEPT that the Property name starts with a Capital letter & doesn't contain datatype
// RULE 2:  Every instance variable should have a corresponding Property.
// RULE 3:  Instance variables are always private,
//              Properties are (generally) public.
// RULE 4:  Methods (including constructors) ALWAYS access the Property
//              (treating it just like it was a regular variable)
//              and don't access the instance variable.  (can't they are private)
//              [The Property will in turn access the instance variable].
// --------------------------------------------------------------------------

using System;

namespace ContactProperties
{
    class Contact
    {
        // -------------------- INSTANCE VARIABLES ---------------------------
        private string name;                    // starts with small letter
        private long phone;
        private char friendORwork;
        private bool liveInKzoo;
        // -------------------- PROPERTIES ----------------------------------
        public string Name                      // starts with Capital letter
        {
            get { return name; }                // refers to instance variable
            set { name = value; }               // refers to instance variable
        }
        public long Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public char FriendORwork
        {
            get { return friendORwork; }
            set { friendORwork = value; }
        }
        public bool LiveInKzoo
        {
            get { return liveInKzoo; }
            set { liveInKzoo = value; }
        }
        // -------------------- CONSTRUCTORS --------------------------------
        public Contact()                                    // empty constructor
        {
        }
        public Contact(string pName, long pPhone, char pFW, bool pLIK)
        {                                                   // parameterized constructor
            Name = pName;                   // These use Property names vs.
            Phone = pPhone;                 //   instance variable names.
            FriendORwork = pFW;             // These use the set accessors of 
            LiveInKzoo = pLIK;              //   the properties.
        }
        // -------------------- METHODS --------------------------------------
        public void ShowContactData()
        {
            Console.WriteLine("name:{0}, phone:{1}, f/w:{2}, kzoo?:{3}\n",
                Name, Phone, FriendORwork, LiveInKzoo);         // PROPERTY NAMES - but, here, could be PRIV. INST.VAR'S ALSO
        }                                       // These use the get accessors
                                                //     of the properties.
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void GetDataFromUser()           // These use the set accessors
        {                                       //     of the properties.
            Console.Write("Enter name:  ");
            Name = Console.ReadLine();                  // PROPERTY NAME USED

            Console.Write("Enter phone (with area code like: 2693871000):  ");
            Phone = Convert.ToInt64(Console.ReadLine());

            Console.Write("Is he/she a Friend or Workmate?  Enter F or W:  ");
            FriendORwork = Convert.ToChar(Console.ReadLine());

            Console.Write("Does he/she live in Kalamazoo?  Enter true or false:  ");
            LiveInKzoo = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("\n");
        }
    }
}


