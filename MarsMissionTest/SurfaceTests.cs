using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MarsRoverDiscoveryApp;
using MarsRoverDiscoveryApp.SurfaceClasses;

namespace MarsMissionTest
{
    public class SurfaceTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("")]
        public void Surface_Should_Throw_InvalidCastException_When_Inputs_Null_Or_Empty(string surfaceArea)
        {
            Assert.Throws<InvalidCastException>(() => new Surface(surfaceArea));
        }

        [Test]
        [TestCase("9 B")]
        public void Surface_Should_Throw_InvalidCastException_When_Inputs_Invalid(string surfaceArea)
        {
            Assert.Throws<InvalidCastException>(() => new Surface(surfaceArea));
        }

        [Test]
        [TestCase("9 9")]
        public void Surface_Should_Succes_When_Inputs_Valid(string surfaceArea)
        {
            Assert.DoesNotThrow(() => new Surface(surfaceArea));
        }
    }
}
