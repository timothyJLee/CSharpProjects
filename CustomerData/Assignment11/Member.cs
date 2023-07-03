using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment11
{
    class Member : Customer
    {
        private string memberStatus;

        public Member(string memberStatusInput, string nameInput, int ageInput)
            : base(nameInput, ageInput)
        {
            memberStatus = memberStatusInput;
        }

        public string MemberStatus
        {
            get { return memberStatus; }
            set { memberStatus = value; }
        }

        public override string ToString()
        {
            return (base.Name + " : " + base.Age + " : " + MemberStatus);
        }
    }
}
