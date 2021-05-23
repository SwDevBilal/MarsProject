using MarsRoverDiscoveryApp.DrivedClasses;
using MarsRoverDiscoveryApp.Houston;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsMissionTest
{
    public class RoverTests
    {
        [SetUp]
        public void Setup() {

        }

        [Test]
        [TestCase("",0)]
        public void Rover_Should_Throw_InvalidCastException_When_Inputs_Is_Noll_Or_Empty(string position,int index)
        {
            Assert.Throws<InvalidCastException>(() => new Rover(position,index));
        }

        [Test]
        [TestCase("-1 5", 0)]
        [TestCase("A 5", 0)]
        [TestCase("A -1", 0)]
        [TestCase("A B", 0)]
        public void Rover_Should_Throw_InvalidCastException_When_Inputs_Invalid(string position, int index)
        {
            Assert.Throws<InvalidCastException>(() => new Rover(position, index));
        }

        [Test]
        [TestCase(new object[] { new string[] { "5 5", "1 2 N", "TLMLMLMLMM" } })]
        public void Rover_Should_Throw_InvalidOperationException_When_Directions_Invalid(string[] inputs)
        {
            MissionControl missionControl = new MissionControl(inputs);
            Assert.Throws<InvalidOperationException>(() => missionControl.StartMarsMission());
        }

        [Test]
        [TestCase(new object[] { new string[] { "5 5", "1 2 N", "TLMLMLMLMMMMMMMMMMMMM" } })]
        public void Rover_Should_Throw_InvalidOperationException_When_Rover_Outside_Boundries(string[] inputs)
        {
            MissionControl missionControl = new MissionControl(inputs);
            Assert.Throws<InvalidOperationException>(() => missionControl.StartMarsMission());
        }
    }
}
