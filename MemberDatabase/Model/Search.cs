using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDatabase.Model
{
    public static class Search
    {
        public static List<Member> byString(List<Member> members, string key)
        {
            List<Member> searchResult = new List<Member>();
            foreach (Member member in members)
            {
                if (member.firstName.Contains(key) || member.lastName.Contains(key))
                {
                    searchResult.Add(member);
                }
            }
            return searchResult;
        }
    }
}
