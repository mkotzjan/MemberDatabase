using MemberDatabase.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDatabase.UnitTests
{
    [TestFixture]
    class TestDateItem
    {
        [Test]
        public void TestInitialize()
        {
            DateItem dateItem = new DateItem();
            Assert.IsNull(dateItem.date);
            Assert.AreEqual(string.Empty, dateItem.information);
            Assert.AreEqual(0, dateItem.id);
            Assert.AreEqual(0, dateItem.memberID);
        }
    }
}
