using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository data;
        private Influencer influencer;
        private string name = "Madonna";
        private int followers = 5;


        [SetUp]
        public void Setup()
        {
            data = new InfluencerRepository();
            influencer = new Influencer(name, followers);
        }

        [Test]
        public void Ctor_InitializesCorrectly()
        {
            Assert.IsNotNull(data);
        }

        [Test]
        public void RegisterInfluencer_WorksCorrectly()
        {
            data.RegisterInfluencer(influencer);
            Assert.AreEqual(1, data.Influencers.Count);
            Assert.IsNotNull(data.Influencers);
        }

        [Test]
        public void RegisterInfluencer_InfluencerIsNull_ExceptionExpected()
        {
            Influencer infl = null;
            Exception ex = Assert.Throws<ArgumentNullException>(() => { data.RegisterInfluencer(null); });
        }

        [Test]

        public void RegisterInfluencer_UsernameExists_ThrowsEx()
        {
            data.RegisterInfluencer(influencer);
            Influencer infl = new Influencer(name, 10);

            Assert.Throws<InvalidOperationException>(() =>
                data.RegisterInfluencer(infl));
        }

        [Test]
        public void RemoveInfluencer_WorksCorrectly()
        {
            data.RegisterInfluencer(influencer);
            data.RemoveInfluencer(influencer.Username);
            Assert.AreEqual(0,data.Influencers.Count);
        }

        [Test]
        public void RemoveInfluencer_ArgsIsNull_ThrowsEx()
        {
            data.RegisterInfluencer(influencer);
            string name = null;
            Exception ex = Assert.Throws<ArgumentNullException>(() =>
                data.RemoveInfluencer(name));
        }

        [Test]
        public void GetInflWithMostFollowers_WorksCorrectly()
        {
            Influencer infl = new Influencer("Dara", 8276);
            data.RegisterInfluencer(influencer);
            data.RegisterInfluencer(infl);
            Assert.AreEqual(infl, data.GetInfluencerWithMostFollowers());

        }

        [Test]
        public void GetInfl_WorksCorrectly()
        {
            data.RegisterInfluencer(influencer);
            Assert.AreEqual(influencer, data.GetInfluencer(influencer.Username));

        }
    }
}