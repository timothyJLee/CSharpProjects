// ADDITIONAL CODE ADDED TO A PROPERTY TO HELP PROTECT THE INTEGRITY OF
//      ITS INSTANCE VARIABLE.
// Properties are like methods & constructors in that they DO ACTIONS
//      rather than STORE DATA (which instance variables do).
// The set accessor (method) is executed when a caller refers to the
//      property's name in the context of assigning a value to it, e.g.,
//              Phone = ...  (as in the constructor and GetDataFromUser method).
//      So, here's where to put code to GUARD against bad data.
// -----------------------------------------------------------------------

using System;

namespace ContactPropertyCode
{
    class Contact
    {
        // -------------------- INSTANCE VARIABLES -------------------------
        private string nameString;
        private long phoneLong;
        private char friendORworkChar;
        private bool liveInKzooBool;
        // -------------------- PROPERTIES --------------------------------
        public string Name
        {
            get { return nameString; }
            set { nameString = value; }
        }
        public long Phone
        {
            get { return phoneLong; }

            set   // GUARDS phone FROM SOME CALLER PUTTING BAD DATA IN IT.
            {
                const long MAXPHONE = 9999999999;           // (999)999-9999
                const long MINPHONE = 0010010001;           // (001)001-0001
                const int RIGHT7DIGITS = 10000000;

                                    // TESTING FOR A VALID PHONE NUMBER OR RETURNS 0 (ZERO)
                if (value >= MINPHONE && value <= MAXPHONE)
                    phoneLong = value;
                else
                    phoneLong = 0;
                if (value % RIGHT7DIGITS == 0)
                    phoneLong = 0;
                if (value / RIGHT7DIGITS == 0)
                    phoneLong = 0;
            }
        }
        public char FriendORwork
        {
            get { return friendORworkChar; }
            set
            {
                if (value == 'F' || value == 'W')
                    friendORworkChar = value;
                else
                    friendORworkChar = 'F';
            }
        }
        public bool LiveInKzoo
        {
            get { return liveInKzooBool; }
            set
            {
                if (value == true || value == false)
                    liveInKzooBool = value;
                else
                    liveInKzooBool = false;
            }
        }
        // -------------------- CONSTRUCTORS ------------------------------
        public Contact() 
        {
        }                               // empty constructor!
        public Contact(string pName, long pPhone, char pFW, bool pLIK)
        {
            Name = pName;                           // name
            Phone = pPhone;                         // input name
            FriendORwork = pFW;                     // Friend or Work
            LiveInKzoo = pLIK;                      // Live in Kalamazoo
        }
        // -------------------- METHODS ------------------------------------
        public void ShowContactData()                               // HOW COULD THIS BE MADE PRIVATE???
        {
            Console.WriteLine("name:{0}, phone:{1}, f/w:{2}, kzoo?:{3}\n",
                Name, Phone, FriendORwork, LiveInKzoo);             // COULD BACKING FIELDS BE USED HERE???
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public void GetDataFromUser()
        {
            Console.Write("Enter name:  ");
            Name = Console.ReadLine();

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
