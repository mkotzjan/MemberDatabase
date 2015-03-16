namespace MemberDatabase.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Anniversary
    {
        private List<Member> sortedList;
        private DateTime today;
        public Anniversary(List<Member> member)
        {
            this.sortedList = member.OrderBy(d => d.accession).ToList<Member>();
            this.today = DateTime.Today;
        }
        public Tuple<List<string>, List<string>> nextAnniversary()
        {
            Dictionary<int, int> daysToAnniversary = new Dictionary<int, int>();
            List<string> anniversarys = new List<string>();
            List<string> anniversarysTooltip = new List<string>();
            foreach (Member member in this.sortedList)
            {
                if (member.accession != null)
                {
                    member.accession = member.accession.Value.AddYears(this.today.Year - member.accession.Value.Year);
                    if (member.accession < this.today)
                        member.accession = member.accession.Value.AddYears(1);

                    daysToAnniversary.Add(member.getID(), (member.accession.Value - this.today).Days);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (daysToAnniversary.Count == 0) { break; }

                var min = daysToAnniversary.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
                Member resultMember = this.sortedList.Find(item => item.getID() == min);
                string days = string.Empty;
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
                anniversarys.Add(resultMember.firstName + " " + resultMember.lastName + " (" + days + ")");
                anniversarysTooltip.Add(((DateTime)resultMember.accession).ToString("dd'.'MM'.'yyyy") + " (" + calcYears((DateTime)resultMember.accession) + " Jahre)");
                daysToAnniversary.Remove(min);
            }
            return new Tuple<List<string>, List<string>>(anniversarys, anniversarysTooltip);
        }

        public Tuple<List<string>, List<string>> nextBirthday()
        {
            Dictionary<int, int> daysToBirthday = new Dictionary<int, int>();
            List<string> birthdays = new List<string>();
            List<string> birthdaysTooltip = new List<string>();

            foreach (Member member in this.sortedList)
            {
                if (member.birthday != null)
                {
                    DateTime calcBirthday = new DateTime();
                    calcBirthday = member.birthday.Value.AddYears(this.today.Year - member.birthday.Value.Year);
                    if (calcBirthday < this.today)
                        calcBirthday = calcBirthday.AddYears(1);

                    daysToBirthday.Add(member.getID(), (calcBirthday - this.today).Days);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (daysToBirthday.Count == 0) { break; }

                var min = daysToBirthday.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
                Member resultMember = this.sortedList.Find(item => item.getID() == min);
                string days = string.Empty;
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
                birthdays.Add(resultMember.firstName + " " + resultMember.lastName + " (" + days + ")");
                birthdaysTooltip.Add(((DateTime)resultMember.birthday).ToString("dd'.'MM'.'yyyy") + " (" + calcYears((DateTime)resultMember.birthday) + " Jahre)");
                daysToBirthday.Remove(min);
            }
            return new Tuple<List<string>,List<string>>(birthdays, birthdaysTooltip);
        }

        private string calcYears(DateTime date)
        {
            int years = today.Year - date.Year;
            if (today < date.AddYears(years)) years--;
            years++;

            return years.ToString();
        }
    }
}
