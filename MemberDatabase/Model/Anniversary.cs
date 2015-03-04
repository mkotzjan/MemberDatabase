using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDatabase.Model
{
    class Anniversary
    {
        private List<Member> memberList;
        public Anniversary(List<Member> member)
        {
            memberList = member;
        }
        public string nextAnniversary()
        {
            return "  1\n  2\n  3\n  4\n  5\n";
        }

        public string nextBirthday()
        {
            return "  1\n  2\n  3\n  4\n  5\n";
        }
    }
}
