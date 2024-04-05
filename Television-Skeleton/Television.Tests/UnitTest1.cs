using System.ComponentModel;

namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    public class Tests
    {

        private const string Brand = "Phillips";
        private const double Price = 1500.99;
        private const int ScreenWidth = 60;
        private const int ScreenHeigth = 40;
        private TelevisionDevice television;
        private int lastChannel = 0;
        private int lastVolume = 13;
        private bool lastMuted = false;

        [SetUp]
        public void Setup()
        {
            television = new TelevisionDevice(Brand, Price, ScreenWidth, ScreenHeigth);
        }

        [Test]
        public void Ctor_ValidParameters_CreatesInstanceCorrectly()
        {
            TelevisionDevice tv = new TelevisionDevice(Brand, Price, ScreenWidth, ScreenHeigth);
            Assert.IsNotNull(tv);
            Assert.AreEqual(Brand, tv.Brand);
            Assert.AreEqual(Price, tv.Price);
            Assert.AreEqual(ScreenWidth, tv.ScreenWidth);
            Assert.AreEqual(ScreenHeigth, tv.ScreenHeigth);
        }

        [Test]
        public void CurrentChannel_IsCorrect()
        {
            Assert.AreEqual(lastChannel, television.CurrentChannel);
        }

        [Test]
        public void CurrentVolume_IsCorrect()
        {
            Assert.AreEqual(lastVolume, television.Volume);
        }

        [Test]
        public void IsMuted_IsCorrect()
        {
            Assert.AreEqual(false, television.IsMuted);
        }

        [Test]
        public void SwitchOn_IsNotMuted_WorksCorrectly()
        {
            string switchOnOutput = television.SwitchOn();
            Assert.AreEqual($"Cahnnel 0 - Volume 13 - Sound On", switchOnOutput);
        }

        [Test]
        public void SwitchOn_IsMuted_WorksCorrectly()
        {
            television.MuteDevice();
            string switchOnOutput = television.SwitchOn();
            Assert.AreEqual($"Cahnnel 0 - Volume 13 - Sound Off", switchOnOutput);
        }

        [Test]
        public void ChangeChannel_ShouldChangeChannel()
        {
            television.ChangeChannel(5);
            Assert.AreEqual(5, television.CurrentChannel);
        }

        [Test]
        public void ChangeChannel_NegativeNumber_ThrowsException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => television.ChangeChannel(-5));
            Assert.AreEqual("Invalid key!", ex.Message);
        }

        [Test]
        public void VolumeChange_ChangesVolume()
        {
            television.VolumeChange("UP", 10);
            Assert.AreEqual(23, television.Volume);

            television.VolumeChange("UP", 113);
            Assert.AreEqual(100, television.Volume);

            television.VolumeChange("DOWN", 50);
            Assert.AreEqual(50, television.Volume);

            television.VolumeChange("DOWN", 70);
            Assert.AreEqual(0, television.Volume);

            television.VolumeChange("UP", -15);
            Assert.AreEqual(15, television.Volume);
            television.VolumeChange("DOWN", -3);
            Assert.AreEqual(12, television.Volume);

            string volumeOutput = $"Volume: {television.Volume}";
            Assert.AreEqual("Volume: 12", volumeOutput);
        }

        [Test]
        public void MuteDevice_ShouldMute()
        {
            television.MuteDevice();
            Assert.AreEqual(true, television.IsMuted);
            television.MuteDevice();
            Assert.AreEqual(false, television.IsMuted);
        }

        [Test]
        public void ToString_ReturnsCorrect()
        {
            string toStringOutput = television.ToString();
            Assert.AreEqual($"TV Device: {Brand}, Screen Resolution: {ScreenWidth}x{ScreenHeigth}, Price {Price}$", toStringOutput);
        }
    }
}