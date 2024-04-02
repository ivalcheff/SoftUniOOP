using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class PersonTests
    {
        private const string ValidUserName = "pesho123";
        private const long ValidId = 100001;


        [Test]
        public void Ctor_WithValidParameters_CreateNewInstance()
        {
            Person person = new Person(ValidId, ValidUserName);
            Assert.IsNotNull(person);
            Assert.AreEqual(person.Id, ValidId);
            Assert.AreEqual(person.UserName, ValidUserName);
        }
    }
}
