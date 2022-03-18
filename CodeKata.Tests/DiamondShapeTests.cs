using NUnit.Framework;
using CodeKata.Lib;

namespace CodeKata.Tests
{
    public class DiamondShapeTests
    {
        private DiamondShape diamondShape;

        [SetUp]
        public void Setup()
        {
            diamondShape = new DiamondShape();
        }

        [Test]
        public void PrintDiamond_A_ShouldReturnNoSpace()
        {
            Assert.AreEqual("A", diamondShape.CreateDiamondShape('A'));
        }

        [Test]
        public void PrintDiamond_C_ShouldContainsNewLines()
        {
            var expectedResult = "  A\r\n B B\r\nC   C\r\n B B\r\n  A";

            Assert.AreEqual(expectedResult, diamondShape.CreateDiamondShape('C'));
        }

        [Test]
        public void IsValid_Ampersand_ShouldReturnFalse()
        {
            string[] args = { "&" };
            Assert.False(diamondShape.IsValid(args));
        }

        [Test]
        public void IsValid_A_ShouldReturnTrue()
        {
            string[] args = { "A" };
            Assert.True(diamondShape.IsValid(args));
        }

        [Test]
        public void IsValid_Z_ShouldReturnTrue()
        {
            string[] args = { "Z" };
            Assert.True(diamondShape.IsValid(args));
        }
    }
}