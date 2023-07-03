using System;

namespace Contact2Constr
{
    public class Contact
    {
        // -------------------- INSTANCE VARIABLES ---------------------
        private string name;
        private long phone;
        private char friendORwork;
        private bool liveInKzoo;
        // -------------------- CONSTRUCTORS ---------------------------
        public Contact()                // empty constructor
        {
            // ACTS LIKE A DEFAULT CONSTRUCTOR WHICH INITIALIZES
            // THE INSTANCE VARIABLES BASED ON THEIR DATA TYPES:
            //  0 in an int, long, short, double, float, decimal, ...
            //  "" (or null for nothing-in-string) in a string
            //  false in a bool
            //  ' ' in a char
        }

        public Contact(string pName, long pPhone, char pFW, bool pLIK)
        {                               // parameterized constructor
            name = pName;
            phone = pPhone;
            friendORwork = pFW;
            liveInKzoo = pLIK;

            ShowContactData();
        }
        // -------------------- METHODS --------------------------------
      
      //  public void ShowContactData()
         private void ShowContactData()
        {
            Console.WriteLine("name:{0}, phone:{1}, f/w:{2}, kzoo?:{3}\n",
                name, phone, friendORwork, liveInKzoo);
        }
    }
}
