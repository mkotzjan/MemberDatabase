using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDatabase.Model
{
    public static class ObjectConnector
    {
        private static Member memberS;
        public static Member selectedMember
        {
            get
            {
                return memberS;
            }

            set
            {
                if (value != memberS)
                {
                    memberS = value;
                }
            }
        }
    }
}
