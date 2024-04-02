namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        private const string Name = "Iva";
        private const int Damage = 10;
        private const int HP = 200;
        private Warrior warrior;

        private const string DaraName = "Dara the bullet dodger";
        private const int DaraDamage = 15;
        private const int DaraHP = 100;
        private Warrior dara;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior(Name, Damage, HP);
            dara = new Warrior(DaraName, DaraDamage, DaraHP);
        }

        [Test]
        public void Ctor_WithValidInput_CreatesNewWarrior()
        {
            Warrior warrior = new Warrior(Name, Damage, HP);
            Assert.IsNotNull(warrior);
            Assert.AreEqual(Name, warrior.Name);
            Assert.AreEqual(HP, warrior.HP);
            Assert.AreEqual(Damage, warrior.Damage);
        }

        [Test]
        public void Ctor_NameIsNull_ExpectedException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => 
                new Warrior(null, Damage, HP));
            Assert.AreEqual("Name should not be empty or whitespace!", ex.Message);
        }


        [Test]
        public void Ctor_NameIsEmpty_ExpectedException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Warrior(string.Empty, Damage, HP));
            Assert.AreEqual("Name should not be empty or whitespace!", ex.Message);
        }

        [Test]
        public void Ctor_DamageIsZeroOrNegative_ExpectedException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Warrior(Name, 0, HP));
            Assert.AreEqual("Damage value should be positive!", ex.Message);
        }


        [Test]
        public void Ctor_HPIsNegative_ExpectedException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Warrior(Name, Damage, -1));
            Assert.AreEqual("HP should not be negative!", ex.Message);
        }

        [Test]
        public void Attack_IsLessThanZero_ThrowsException()
        {
            Warrior dragan = new Warrior("Dragan", 100, 29);
            Assert.Throws<InvalidOperationException>(() => dragan.Attack(warrior));
        }

    }
}