﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDatabase.Model
{
    class Anniversary
    {
        private List<Member> sortedList;
        private DateTime today;
        public Anniversary(List<Member> member)
        {
            sortedList = member.OrderBy(d => d.accession).ToList<Member>();
            today = DateTime.Today;
        }
        public string nextAnniversary()
        {
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
                string days = "";
                if (daysToAnniversary[min] == 0)
	            {
                    days = "Heute";
	            }
                else if (daysToAnniversary[min] == 1)
                {
                    days = "Morgen";
                }
                else
                {
                    days = daysToAnniversary[min] + " Tage";
                }
                output = output + "  " + resultMember.firstName + " " + resultMember.lastName + ", " + ((DateTime)resultMember.accession).ToString("dd'.'MM'.'yyyy") + " (" + days + ")\n";
                daysToAnniversary.Remove(min);
            }
            return output;
        }

        public string nextBirthday()
        {
            Dictionary<int, int> daysToBirthday = new Dictionary<int, int>();
            string output = "";
            foreach (Member member in sortedList)
            {
                if (member.birthday != null)
                {
                    member.birthday = member.birthday.Value.AddYears(today.Year - member.birthday.Value.Year);
                    if (member.birthday < today)
                        member.birthday = member.birthday.Value.AddYears(1);

                    daysToBirthday.Add(member.getID(), (member.birthday.Value - today).Days);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (daysToBirthday.Count == 0) { break; }

                var min = daysToBirthday.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
                Member resultMember = sortedList.Find(item => item.getID() == min);
                string days = "";
                if (daysToBirthday[min] == 0)
                {
                    days = "Heute";
                }
                else if (daysToBirthday[min] == 1)
                {
                    days = "Morgen";
                }
                else
                {
                    days = daysToBirthday[min] + " Tage";
                }
                output = output + "  " + resultMember.firstName + " " + resultMember.lastName + ", " + ((DateTime)resultMember.birthday).ToString("dd'.'MM'.'yyyy") + " (" + days + ")\n";
                daysToBirthday.Remove(min);
            }
            return output;
        }
    }
}
