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

            Anniversary an = new Anniversary(memberList);
        }
    }
}
