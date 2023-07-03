using System;

namespace ContactAutoImplProp            
{
    class Contact
    {
        // -------------------- INSTANCE VARIABLES ---------------------
        private char friendORwork;          //  3 vars in constructor so...
                                            //  why not 4 inst. vars?
                                            //     have 4 properties  this ONE w/ extra work so... expand.
        
        // -------------------- CONSTRUCTORS --------------------------
        public Contact(string pName, long pPhone, char pFW, bool pLIK)
        {
            Name = pName;
            Phone = pPhone;
            FriendORwork = pFW;
            LiveInKzoo = pLIK;
        }

        // -------------------- PROPERTIES ----------------------------
        public string Name         { get; set; }       // SETS UP PROP WITHOUT INSTANCE VARIABLES YOU CAN DO THAT???
        public long Phone          { get; set; }       //   STILL need CONSTRUCTOR!!!!!!!! just can
        public bool LiveInKzoo     { get; set; }       //     skip the longer get/set's
        
        public char   FriendORwork          // NEED INSTANCE VAR B/C DOING SOMETHING SPECIAL
        {
            get 
            {
                return friendORwork; 
            }

            set
            {
                if (value == 'f' || value == 'F')
                    friendORwork = 'F';
                else
                    friendORwork = 'W';
            }
        }
      // -------------------- METHODS --------------------------------
        public void ShowContactData()
        {
            Console.WriteLine("name: {0}, phone: {1}, f/w: {2}, kzoo?: {3}\n",
                Name, Phone, FriendORwork, LiveInKzoo);                 // OUTPUT PROPERTIES
        }
    }
}
