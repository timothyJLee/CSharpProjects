// GetDataFromUser is a private method (rather than a public method)
//      since it is only called from other members (methods, constructors,
//      properties) in THIS Contact class.  Public methods can be called
//      by any member of THIS class OR a member of another class, like by
//      Main in Program class.
// --------------------------------------------------------------------------

using System;

namespace ContactPrivateMethod
{
    class Contact
    {// -------------------- INSTANCE VARIABLES -------------------------
        private string name;
        private long phone;
        private char friendORwork;
        private bool liveInKzoo;
        // -------------------- PROPERTIES --------------------------------
        public string Name
        {
            get { return name; }
            set { name = value; }
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
        // -------------------- CONSTRUCTORS ------------------------------
        public Contact()
        {
            GetDataFromUser();                         // **** CALLED HERE SINCE CALLED METHOD IS PRIVATE ****
        }
        public Contact(string pName, long pPhone, char pFW, bool pLIK)
        {
            Name = pName;
            Phone = pPhone;
            FriendORwork = pFW;
            LiveInKzoo = pLIK;
        }
        // -------------------- METHODS ------------------------------------
        public void ShowContactData()
        {
            Console.WriteLine("name:{0}, phone:{1}, f/w:{2}, kzoo?:{3}\n",
                Name, Phone, FriendORwork, LiveInKzoo);
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private void GetDataFromUser()                                   // **** PRIVATE ****
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
