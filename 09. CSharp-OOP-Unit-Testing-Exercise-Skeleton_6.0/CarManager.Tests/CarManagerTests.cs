namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {

        private const string Make = "BMW";
        private const string Model = "E87";
        private const double Consumption = 7.0;
        private const double FuelCapacity = 50;
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car(Make, Model, Consumption, FuelCapacity);
        }

        [Test]
        public void Ctor_WithValidParameters_CreateNewInstance()
        {
            Car newCar = new Car(Make, Model, Consumption, FuelCapacity);
            Assert.IsNotNull(newCar);
            Assert.AreEqual(Make, newCar.Make);
            Assert.That(newCar.Model, Is.EqualTo(Model));
            Assert.AreEqual(Consumption, newCar.FuelConsumption);
            Assert.AreEqual(FuelCapacity, newCar.FuelCapacity);
        }

        [Test]
        public void Make_Null_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(null, Model, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void Make_Empty_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(string.Empty, Model, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void Model_Null_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, null, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void Model_Empty_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, string.Empty, Consumption, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void FuelConsumption_Zero_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, Make, 0, FuelCapacity));
            Assert.That(ex.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }


        [Test]
        public void FuelCapacity_Zero_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                new Car(Make, Make, Consumption, 0));
            Assert.That(ex.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]

        public void Refuel_HappyPath_FuelAddedToTank()
        {
            double fuelAmount = FuelCapacity - 1;
            car.Refuel(fuelAmount);
            Assert.AreEqual(fuelAmount, car.FuelAmount);
        }

        [Test]
        public void Refuel_ZeroOrNegativeFuelAmountExpectedException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
                car.Refuel(0));
            Assert.That(ex.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
            Assert.Throws<ArgumentException>(() => car.Refuel(-1));
        }

        [Test]
        public void Refuel_TankCapacityExceeded()
        {
            double fuelToAdd = FuelCapacity + 1;

            car.Refuel(fuelToAdd);
            Assert.AreEqual(car.FuelAmount, FuelCapacity);
        }

        [Test]
        public void Drive_HappyPath_FuelDecreases()
        {
            //setup
            double distance = 20;
            car.Refuel(FuelCapacity);

            double fuelNeeded = (distance / 100) * Consumption;
            double expectedFuelAmount = car.FuelAmount - fuelNeeded;

            //Action
            car.Drive(distance);

            //Assert
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void Drive_NotEnoughFuel_ReducesFuelAmount()
        {

            double distance = 20;
            double fuelNeeded = (distance / 100) * Consumption;
            double expectedFuelAmount = car.FuelAmount - fuelNeeded;

            var exception = Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
            Assert.That(exception.Message, Is.EqualTo("You don't have enough fuel to drive!"));
        }
    }
}