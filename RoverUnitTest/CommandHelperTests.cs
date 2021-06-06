using NUnit.Framework;
using Rover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverUnitTest
{
    public class CommandHelperTests
    {
        [Test]
        public void CheckInputStringForDirectionsTest()
        { 
            CommandHelper.CheckInputStringForDirections("LLRRMM");
            Assert.IsTrue(true);
            Assert.Throws(typeof(FormatException),delegate { CommandHelper.CheckInputStringForDirections("abc"); });
        }


        [Test]
        public void ValidateSurfaceCommand()
        {
            CommandHelper.ValidateSurfaceCommand(new string[] { "5", "5" });
            Assert.IsTrue(true);
            Assert.Throws(typeof(FormatException), delegate { CommandHelper.ValidateSurfaceCommand(new string[] { "a", "5" }); });
            Assert.Throws(typeof(FormatException), delegate { CommandHelper.ValidateSurfaceCommand(new string[] { "5", "a" }); });
        }

        [Test]
        public void ValidateStartingPointCommand()
        {
            CommandHelper.ValidateStartingPointCommand(new string[] { "1", "2", "N" });
            Assert.IsTrue(true);
            Assert.Throws(typeof(FormatException), delegate { CommandHelper.ValidateStartingPointCommand(new string[] { "a", "2", "N" }); });
            Assert.Throws(typeof(FormatException), delegate { CommandHelper.ValidateStartingPointCommand(new string[] { "1", "a", "N" }); });
            Assert.Throws(typeof(FormatException), delegate { CommandHelper.ValidateStartingPointCommand(new string[] { "1", "2", "b" }); });
        }

        [Test]
        public void GetNumber()
        {
            var number = CommandHelper.GetNumber("12");
            Assert.AreEqual(number, 12);
            Assert.Throws(typeof(FormatException), delegate { CommandHelper.GetNumber("abc"); });
        }

    }
}
