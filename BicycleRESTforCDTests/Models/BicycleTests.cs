using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BicycleRESTforCD.Models.Tests
{
    [TestClass()]
    public class BicycleTests
    {
        [TestMethod()]
        public void ValidateColorTest()
        {
            Bicycle nullColor = new Bicycle { Color = null };
            Assert.ThrowsException<ArgumentNullException>(() => nullColor.ValidateColor());
            Bicycle shortColor = new Bicycle { Color = "ab" };
            Assert.ThrowsException<ArgumentException>(() => shortColor.ValidateColor());
            Bicycle okColor = new Bicycle { Color = "abc" };
            okColor.ValidateColor();
        }

        [TestMethod]
        public void ValidateNumberOfWheelsTest()
        {
            Bicycle zeroWheels = new Bicycle { NumberOfWheels = 0 };
            zeroWheels.ValidateNumberOfWheels();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => zeroWheels.ValidateNumberOfWheels());
            Bicycle okWheels = new Bicycle { NumberOfWheels = 2 };
            okWheels.ValidateNumberOfWheels();
        }
    }
}