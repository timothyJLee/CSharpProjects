using System;

namespace ContactMainAccProp
{
    class Contact
    {
        // -------------------- INSTANCE VARIABLES ---------------------
        private string nameString;                    // always private but properties allow
        private long phoneLong;                     //  them to be 'public'  
        private char friendORworkChar;
        private bool liveInKzooBool;
        // -------------------- PROPERTIES -----------------------------
        public string Name                      // methods always public
        {
            get { return nameString; }                // 
            set { nameString = value; }
        }
        public long Phone
        {
            get { return phoneLong; }
            set { phoneLong = value; }
        }
        public char FriendORwork
        {
            get { return friendORworkChar; }
            set { friendORworkChar = value; }
        }
        public bool LiveInKzoo
        {
            get { return liveInKzooBool; }
            set { liveInKzooBool = value; }
        }
        // -------------------- CONSTRUCTORS ---------------------------
        public Contact(string pName, long pPhone, char pFW, bool pLIK)
        {
            Name = pName;
            Phone = pPhone;
            FriendORwork = pFW;
            LiveInKzoo = pLIK;
        }
        // -------------------- METHODS --------------------------------
        public void ShowContactData()
        {
            Console.WriteLine("name:{0}, phone:{1}, f/w:{2}, kzoo?:{3}\n",
                Name, Phone, FriendORwork, LiveInKzoo);
        }
    }
}
