namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const int CornerCaseInvalidNumberOfPeople = 17;
        private const int MaxNumberOfPeople = 16;
        private const string AddRangeExpectedException = "Provided data length should be in range [0..16]!";
        private const string AddMaxNumberReachedExpectedException = "Array's capacity must be exactly 16 integers!";
        private const string AddExistingUsernameExpectedException = "There is already user with this username!";
        private const string AddExistingIdExpectedException = "There is already user with this Id!";
        private const string ValidUserNamePesho = "pesho123";
        private const long ValidIdPesho = 100001;
        private const string ValidUserNameIvan = "ivan123";
        private const long ValidIdIvan = 100002;
        private Database sut;

        [SetUp]
        public void SetUp()
        {
            Person pesho = new Person(ValidIdPesho, ValidUserNamePesho);
            Person ivan = new Person(ValidIdIvan, ValidUserNameIvan);
            Person[] people = new Person[] { pesho, ivan };
            sut = new Database(people);  //sut == system under test
        }   

        [Test]
        public void Ctor_EmptyWithValidParams_CreatesNewInstance()
        {
            Database database = new Database();
            Assert.IsNotNull(database);
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_WithValidParams_CreatesNewInstance()
        {
            Assert.That(sut, Is.Not.Null);
            Assert.That(sut.Count, Is.EqualTo(2));
        }

        [Test]
        public void Ctor_WithTooManyPeople_ThrowsException()
        {
            Person[] tooManyPeople = new Person[CornerCaseInvalidNumberOfPeople];

            for (int i = 0; i < CornerCaseInvalidNumberOfPeople; i++)
            {
                tooManyPeople[i] = new Person(ValidIdPesho + i, $"{ValidUserNamePesho}-{i}");
            }

            ArgumentException ae = Assert.Throws<ArgumentException>(
                            () => new Database(tooManyPeople));
            Assert.That(ae.Message, Is.EqualTo(AddRangeExpectedException));
        }

        [Test]
        public void Add_HappyPath_AddsNewPerson()
        {
            Person maria = new Person(ValidIdIvan + 1, "Maria");
            sut.Add(maria);
            Assert.That(sut.Count, Is.EqualTo(3));
        }

        [Test]
        public void Add_DatabaseIsFull_ThrowsException()
        {
            for (int i = sut.Count; i < MaxNumberOfPeople; i++)
            {
                sut.Add(new Person(200000 + i, $"Gosho-{i}"));
            }

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
                sut.Add(new Person(3333333, "Petkan")));
            Assert.That(ex.Message, Is.EqualTo(AddMaxNumberReachedExpectedException));
        }

        [Test]
        public void Add_UserNameExists_ThrowsException()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
                sut.Add(new Person(3333333, ValidUserNamePesho)));
            Assert.That(ex.Message, Is.EqualTo(AddExistingUsernameExpectedException));
        }

        [Test]
        public void Add_IdExists_ThrowsException()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
                sut.Add(new Person(ValidIdIvan, "Navuhodonosor")));
            Assert.That(ex.Message, Is.EqualTo(AddExistingIdExpectedException));
        }

        [Test]
        public void FindByUserName_HappyPath_ReturnsUser()
        {
            Person peshoFound = sut.FindByUsername(ValidUserNamePesho);
            Assert.That(peshoFound, Is.Not.Null);
            Assert.That(peshoFound.UserName, Is.EqualTo(ValidUserNamePesho));
            Assert.That(peshoFound.Id, Is.EqualTo(ValidIdPesho));
        }

        [Test]
        public void FindByUserName_UserNameNull_ThrowsException()
        {
            ArgumentException ae = Assert.Throws<ArgumentNullException>(()
                => sut.FindByUsername(null));
        }

        [Test]
        public void FindByUserName_UserIsWhiteSpace_ThrowsException()
        {
            InvalidOperationException ae = Assert.Throws<InvalidOperationException>(()
                => sut.FindByUsername(" "));
        }

        [Test]
        public void FindById_HappyPath_ReturnsUser()
        {
            Person peshoFound = sut.FindById(ValidIdPesho);
            Assert.That(peshoFound, Is.Not.Null);
            Assert.That(peshoFound.UserName, Is.EqualTo(ValidUserNamePesho));
            Assert.That(peshoFound.Id, Is.EqualTo(ValidIdPesho));
        }

        [Test]
        public void FindById_LessThanZero_ThrowsException()
        {
            ArgumentOutOfRangeException ae = Assert.Throws<ArgumentOutOfRangeException>(()
                => sut.FindById(-1));
        }

        [Test]
        public void FindById_UserDoesNotExist_ThrowsException()
        {
            InvalidOperationException ae = Assert.Throws<InvalidOperationException>(()
                => sut.FindById(999));
        }

        [Test]
        public void Remove_HappyPath_RemovesUser()
        {
            sut.Remove();
            Assert.That(sut.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_EmptyDatabase_ThrowsException()
        {
            sut.Remove();
            sut.Remove();
            Assert.Throws<InvalidOperationException>(() => sut.Remove());
        }
    }
}