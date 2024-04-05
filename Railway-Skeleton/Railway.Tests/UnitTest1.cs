namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {

        //first initialize the station
        private RailwayStation station;

        [SetUp]
        public void Setup()
        {
            station = new RailwayStation("Iskar");
        }

        [Test]
        public void Ctor_ValidParameters_CreatesInstance()
        {
            Assert.AreEqual("Iskar", station.Name);
            Assert.IsNotNull(station);
            Assert.AreEqual(0, station.ArrivalTrains.Count);
            Assert.AreEqual(0, station.DepartureTrains.Count);
        }

        [Test]
        public void Ctor_NameIsNull_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => { new RailwayStation(null); });
            Assert.AreEqual("Name cannot be null or empty!", ex.Message);
        }

        [Test]
        public void Ctor_NameIsWhitespace_ThrowsException()
        {
            Exception exception = Assert.Throws<ArgumentException>(() => { new RailwayStation(string.Empty); });
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [Test]
        public void NewArrival_ShouldAddToArrivalTrains()
        {
            station.NewArrivalOnBoard("Diana Express");
            Assert.AreEqual(1, station.ArrivalTrains.Count);
            Assert.AreEqual("Diana Express", station.ArrivalTrains.Dequeue());
        }

        [Test]
        public void TrainHasArrived_SameTrainInfo_RemovesFromArrivalAddsToDeparture()
        {
            station.NewArrivalOnBoard("Diana Express");
            Assert.AreEqual("Diana Express is on the platform and will leave in 5 minutes.", station.TrainHasArrived("Diana Express"));
            Assert.AreEqual(0, station.ArrivalTrains.Count);
            Assert.AreEqual(1, station.DepartureTrains.Count);
        }

        [Test]
        public void TrainHasArrived_TrainInfoIsDifferent_ReturnsOtherTrain()
        {
            station.NewArrivalOnBoard("Diana Express");
            Assert.AreEqual("There are other trains to arrive before Sofia-Varna.", station.TrainHasArrived("Sofia-Varna"));
            Assert.AreEqual(1, station.ArrivalTrains.Count);
            Assert.AreEqual(0, station.DepartureTrains.Count);
        }


        [Test]
        public void TrainHasLeft_SameTrainInfo_RemovesFromDeparture()
        {
            station.NewArrivalOnBoard("Diana Express");
            station.TrainHasArrived("Diana Express");
            Assert.AreEqual(true, station.TrainHasLeft("Diana Express"));
            Assert.AreEqual(0, station.DepartureTrains.Count);
        }

        [Test]
        public void TrainHasLeft_DifferentTrainInfo_ReturnsFalse()
        {
            station.NewArrivalOnBoard("Diana Express");
            station.TrainHasArrived("Diana Express");
            Assert.AreEqual(false, station.TrainHasLeft("Sofia-Varna"));
            Assert.AreEqual(1, station.DepartureTrains.Count);
        }
    }
}