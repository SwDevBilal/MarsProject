using MarsRoverDiscoveryApp.Houston;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsMissionTest
{
    public class MissionControlTests
    {
        private MissionControl missionControl;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase(null)]
        public void StartMarsMission_Should_Throw_NullReferenceException_When_Inputs_Null_Or_Empty(string[] inputs)
        {
            missionControl = new MissionControl(inputs);
            Assert.Throws<NullReferenceException>(() => missionControl.StartMarsMission());
        }

        [Test]
        [TestCase(new object[] { new string[] { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"}, new string[] {"1 3 N","5 1 E" } })]
        public void StartMarsMission_Should_Success_When_Inputs_Valid(string[] inputs,string[] expected)
        {
            missionControl = new MissionControl(inputs);
            missionControl.StartMarsMission();
            string[] actual = missionControl.getPositionsAllVehiclePositions();
            Assert.AreEqual(expected, actual);
        }


    }
}
