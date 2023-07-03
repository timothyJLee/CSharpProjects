using System;

namespace ContactExtraProp
{
    class Contact
    {
        // -------------------- CONSTANTS ----------------------------------
        private const int THIS_YEAR = 2011;

        // -------------------- INSTANCE VARIABLES -------------------------
        private string fName;
        private string lName;
        private long phone;
        private char friendORwork;
        private bool liveInKzoo;
        // -------------------- PROPERTIES ---------------------------------
        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }
        public string LName
        {
            get { return lName; }
            set { lName = value; }
        }
        public long Phone                 
        {
            get { return phone; }
            set { phone = value; }
        }
        public string FriendORwork      // DATA TYPE DIFFERENT FROM INSTANCE VARIABLE
        {                               //          friendORwork
            get
            {
                return Convert.ToString(friendORwork); }        // why string? > # built in methods
                                                                //   
            set                                             // so here - char; return string
            {
                if (value == "F" || value == "f")       // test the String then
                    friendORwork = Convert.ToChar(value);   // convert to character
                else
                    friendORwork = 'W';
            }
        }
        public string LiveInKzoo        // DATA TYPE DIFFERENT FROM INSTANCE VARIABLE
        {                               //                          liveInKzoo
            get { return Convert.ToString(liveInKzoo); }
            set
            {
                liveInKzoo = false;
                
                if (value == "yes" || value == "Yes" || value == "YES" || value == "Y"
                        || value == "y" || value == "True" || value == "true"
                        || value == "T" || value == "t")
                {
                    liveInKzoo = true;
                }
            }
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public string Name              // PROPERTY WITH NO INSTANCE VARIABLE (combines 2 Props into 1)
        {                               // so that it comes as 1 field into method call (in Main)
            get
            {
                return FName + " " + LName;
            }
        }
        //------------------------------------------------------------------------


        public int AreaCode              // PROPERTY WITH NO INSTANCE VARIABLE
                                    // change phone into just the area code (/7 0's - the returned int
                                    //      is only the first 3 digits in Phone. But FIRST ( to divide)
                                    //   (division will create a LONG but need an INT) so 'cast'
                                   // it to an int  (forces the data conversion)
        {                           // cast's answer of (Phone / 10000000) into an int the returned
            get { return (int) (Phone / 10000000); }
        }
        // -------------------- CONSTRUCTORS -------------------------------
        //          6 strings input but not to use 6 strings so...how deal w/ it?
        //  a) convert inside the CONSTRUCTOR       (See ph # - but need to combine 2 sent strings into 1 prop)
        //  b) although Properties should be the one who deals w/ it (see above for FriendOrwork & LiveInKzo


        public Contact(string pFName,       string pLName,
                        string pAreaCode,   string pLocalPhone,
                        string pFOrW,       string pLIK)
        {
            FName = pFName;
            LName = pLName;
            Phone = Convert.ToInt64(pAreaCode + pLocalPhone);       // combines 2 into 1 so 1 ph #
                                                                    //  ToInt64 b/c LONG
            FriendORwork = pFOrW;
            LiveInKzoo = pLIK;
        }
        // -------------------- METHODS ------------------------------------
        public void ShowContactData()
        {
            Console.WriteLine("This year is {0}", THIS_YEAR);
            Console.WriteLine("\nname: {0}, (first name: {1}, last name {2})",
                Name, FName, LName);
            Console.WriteLine("phone: {0}, (area code: {1})",
                Phone, AreaCode);
            Console.WriteLine("Friend or Workmate: {0}", FriendORwork);
            Console.WriteLine("Live in Kalamazoo: {0}\n", LiveInKzoo);
        }
    }
}

