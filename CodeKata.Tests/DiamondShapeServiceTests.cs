using CodeKata.Lib;
using Moq;
using NUnit.Framework;

namespace CodeKata.Tests
{
    
    public class DiamondShapeServiceTests
    {
        private Mock<IDiamondShape> diamondShapeMock;
        
        [SetUp]
        public void Setup()
        {
            diamondShapeMock = new Mock<IDiamondShape>();
        }

        [Test]
        public void PrintDiamond_ValidInput_ShouldInvokeCreateDiamondShape()
        {
            string[] args = { "Z" };

            diamondShapeMock.Setup<bool>(o => o.IsValid(args)).Returns(true);

            DiamondShapeService service = new DiamondShapeService(diamondShapeMock.Object); ;
            
            service.PrintDiamondShape(args);

            diamondShapeMock.Verify(o => o.CreateDiamondShape(It.IsAny<char>()), Times.Once());
        }

        [Test]
        public void PrintDiamond_InvalidInput_ShouldNotInvokeCreateDiamondShape()
        {
            string[] args = { "Zzzz" };

            diamondShapeMock.Setup<bool>(o => o.IsValid(args)).Returns(false);

            DiamondShapeService service = new DiamondShapeService(diamondShapeMock.Object); ;

            service.PrintDiamondShape(args);

            diamondShapeMock.Verify(o => o.CreateDiamondShape(It.IsAny<char>()), Times.Never());
        }

    }
}
