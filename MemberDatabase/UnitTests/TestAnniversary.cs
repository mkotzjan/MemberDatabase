using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MemberDatabase.Model;

namespace MemberDatabase.UnitTests
{
    [TestFixture]
    public class TestAnniversary
    {
        [Test]
        public void TestInitializeNull()
        {
            List<Member> memberList = null;
            Anniversary an = new Anniversary(memberList);
        }

        [Test]
        public void TestInitializeEmpty()
        {
            List<Member> memberList = new List<Member>();
            Anniversary an = new Anniversary(memberList);
        }

        [Test]
        public void TestInitialize()
        {
            List<Member> memberList = new List<Member>();
            memberList.Add(new Member { firstName = "M", lastName = "K", active = true});
            memberList.Add(new Member { firstName = "C", lastName = "W", birthday = new DateTime(2000, 11, 1) });
            memberList.Add(new Member { firstName = "Max", lastName = "Mustermann", active = true, birthday = new DateTime(1999, 4, 3), accession = new DateTime(2001, 12, 1) });

            int i = 0;
            foreach (Member member in memberList)
            {
                member.setID(i);
                ++i;
            }

            Anniversary an = new Anniversary(memberList);
        }

        [Test]
        public void TestNextAnniversary()
        {
            List<Member> memberList = new List<Member>();
            memberList.Add(new Member { firstName = "M", lastName = "K", active = true });
            memberList.Add(new Member { firstName = "C", lastName = "W", birthday = DateTime.Now.AddYears(-20).AddDays(1), accession = DateTime.Now.AddYears(-15).AddDays(2) });
            memberList.Add(new Member { firstName = "Max", lastName = "Mustermann", active = true, birthday = DateTime.Now.AddYears(-22).AddDays(3), accession = DateTime.Now.AddYears(-17).AddDays(42) });

            int i = 0;
            foreach (Member member in memberList)
            {
                member.setID(i);
                ++i;
            }

            Anniversary an = new Anniversary(memberList);
            List<string> item1 = an.nextAnniversary().Item1;
            List<string> item2 = an.nextAnniversary().Item2;

            Assert.AreEqual(2, item1.Count());
            Assert.AreEqual(2, item2.Count());
            Assert.AreEqual("C W (2 Tage)", item1[0]);
            Assert.AreEqual("Max Mustermann (42 Tage)", item1[1]);
            Assert.AreEqual(DateTime.Now.AddYears(-15).AddDays(2).ToString("dd'.'MM'.'yyyy") + " (15 Jahre)", item2[0]);
            Assert.AreEqual(DateTime.Now.AddYears(-17).AddDays(42).ToString("dd'.'MM'.'yyyy") + " (17 Jahre)", item2[1]);
        }
    }
}
