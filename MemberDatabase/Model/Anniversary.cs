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
            List<Member> sortedList = memberList.OrderBy(d => d.accession).ToList<Member>();
            DateTime today = DateTime.Today;
            Dictionary<int, int> daysToAnniversary = new Dictionary<int,int>();
            string output = "";
            foreach (Member member in sortedList)
            {
                if (member.accession != null)
                {
                    member.accession = member.accession.Value.AddYears(today.Year - member.accession.Value.Year);
                    if (member.accession < today)
                        member.accession = member.accession.Value.AddYears(1);

                    daysToAnniversary.Add(member.getID(), (member.accession.Value - today).Days);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (daysToAnniversary.Count == 0) { break; }

                var min = daysToAnniversary.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
                Member resultMember = sortedList.Find(item => item.getID() == min);
                output = output + "  " + resultMember.firstName + " " + resultMember.lastName + ", " + ((DateTime)resultMember.accession).ToString("dd'.'MM'.'yyyy") + " (" + daysToAnniversary[min] + ")\n";
                daysToAnniversary.Remove(min);
            }
            return output;
        }

        public string nextBirthday()
        {

            return "  1\n  2\n  3\n  4\n  5\n";
        }
    }
}
