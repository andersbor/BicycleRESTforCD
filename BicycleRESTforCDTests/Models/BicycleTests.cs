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
    }
}