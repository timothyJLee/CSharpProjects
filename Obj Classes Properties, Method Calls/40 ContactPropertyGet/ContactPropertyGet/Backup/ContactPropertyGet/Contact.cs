// The GET accessor code is executed whenever the property name is used in
//      the context of "using the variable", as in a WriteLine statement,
//      or in the righthand side of an assignment statement, or. . .
// -------------------------------------------------------------------------

using System;

namespace ContactPropertyGet
{
    public class Contact
    {
        // -------------------- INSTANCE VARIABLES -------------------------
        private string name;
        private long phone;
        private char friendORwork;
        private bool liveInKzoo;
        // -------------------- PROPERTIES -----------WITH MANIPULATION AND VALIDATION--------
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public long Phone
        {  //********************* LOOK AT THE GET!! ***********    THIS IS THE NEW PART!   
            get     // "TRANSLATES" 10-digit phone INTO WHAT "CALLER" WANTS
                    //      - ONLY THE 7-digit local phone number
            {
                if (liveInKzoo == true)
                    return phone % 10000000;      // modulus returns the remainder (of the ph #)
                else
                    return phone;
            }

            set   // GUARDS phone FROM SOMEONE PUTTING BAD DATA IN IT.
            {
                const long MAXPHONE = 9999999999;          // (999)999-9999
                const long MINPHONE = 0010010001;          // (001)001-0001
                const int RIGHT7DIGITS = 10000000;

                if (value >= MINPHONE && value <= MAXPHONE)
                    phone = value;
                else
                    phone = 0;
                if (value % RIGHT7DIGITS == 0)
                    phone = 0;
                if (value / RIGHT7DIGITS == 0)
                    phone = 0;
            }
        }
        public char FriendORwork
        {
            get { return friendORwork; }
            set
            {
                if (value == 'F' || value == 'W')
                    friendORwork = value;
                else
                    friendORwork = 'F';
            }
        }
        public bool LiveInKzoo
        {
            get { return liveInKzoo; }
            set
            {
                if (value == true || value == false)
                    liveInKzoo = value;
                else
                    liveInKzoo = false;
            }
        }
        // -------------------- CONSTRUCTORS ------------------------------
        public Contact() { }
        public Contact(string pName, long pPhone, char pFW, bool pLIK)
        {
            Name = pName;
            Phone = pPhone;
            FriendORwork = pFW;
            LiveInKzoo = pLIK;
        }
        // -------------------- METHODS ------------------------------------
        public void ShowContactData()                     // CAN BACKING FIELDS BE USED FOR THIS OUTPUT????
        {
            Console.WriteLine("name:{0}, phone:{1}, f/w:{2}, kzoo?:{3}\n",
                Name, Phone, FriendORwork, LiveInKzoo);
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
