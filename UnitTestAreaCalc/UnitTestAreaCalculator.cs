using AreaCalc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAreaCalc
{
    [TestClass]
    public class UnitTestAreaCalculator
    {
        [TestMethod]
        public void AreaOfCicrle_WithValidRadius_ReturnAreaCircle()
        {
            // Arrange          
            double radius = 236;
            double exepted = 174974.14443433713;

            // Act
            double actual = AreaCalculator.GetArea(radius);

            // Assert
            Assert.AreEqual(exepted, actual, 0.00000000001, "Area circle is not correct");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),AreaCalculator.RadiusLessThanZeroMessage)]
        public void AreaOfCicrle_WithRadiusLessThanZero_ThrowError()
        {
            // Arrange          
            double radius = -4;
            Exception exepted = new Exception();

            // Act and assert
            AreaCalculator.GetArea(radius);
        }
        [TestMethod]
        public void AreaOfCircle_WithOneOfEdgeLessZero_ShouldThrowEdgeLessThanZero()
        {
            // Arrange
            double[] triangleEdges = new double[3] { -3, 3, 3 }; 
            

            // Act
            var exception1 = CatchExeptionWithOneOfEfgeLessZero(triangleEdges[0], triangleEdges[1], triangleEdges[2]);
            var exception2 = CatchExeptionWithOneOfEfgeLessZero(triangleEdges[1], triangleEdges[0], triangleEdges[2]);
            var exception3 = CatchExeptionWithOneOfEfgeLessZero(triangleEdges[2], triangleEdges[1], triangleEdges[0]);

            // Assert
            StringAssert.Contains(exception1.Message, AreaCalculator.EdgeLessThanZeroMessage);
            StringAssert.Contains(exception2.Message, AreaCalculator.EdgeLessThanZeroMessage);
            StringAssert.Contains(exception3.Message, AreaCalculator.EdgeLessThanZeroMessage);

        }
        private static Exception CatchExeptionWithOneOfEfgeLessZero(double triangleEdge1, double triangleEdge2, double triangleEdge3)
        {           
            try
            {
                AreaCalculator.GetArea(triangleEdge1, triangleEdge2, triangleEdge3);
            }
            catch (Exception ex)
            {
                return ex;
            }
            return new Exception("Sould be error");
            
        }
        [TestMethod]
        public void AreaOfCircle_WithOneOfEdgeMoreThanSumOtherEdges_ShouldThrowExeptionImpossibleTriangle()
        {
            // Arrange
            double[] triangleEdges;
            triangleEdges = new double[3] { 8, 4, 3 };

            // Act
            Exception exeption1 = CatchExeptionWithOneOfEdgeMoreThanSumOtherEdges(triangleEdges[0], triangleEdges[1], triangleEdges[2]);
            Exception exeption2 = CatchExeptionWithOneOfEdgeMoreThanSumOtherEdges(triangleEdges[1], triangleEdges[0], triangleEdges[2]);
            Exception exeption3 = CatchExeptionWithOneOfEdgeMoreThanSumOtherEdges(triangleEdges[1], triangleEdges[2], triangleEdges[0]);

            // Assert
            StringAssert.Contains(exeption1.Message, AreaCalculator.ImpossibleTriangleMessege);
            StringAssert.Contains(exeption2.Message, AreaCalculator.ImpossibleTriangleMessege);
            StringAssert.Contains(exeption3.Message, AreaCalculator.ImpossibleTriangleMessege);
        }
        public Exception CatchExeptionWithOneOfEdgeMoreThanSumOtherEdges(double triangleEdge1, double triangleEdge2, double triangleEdge3)
        {
            try
            {
                AreaCalculator.GetArea(triangleEdge1, triangleEdge2, triangleEdge3);
            }
            catch (Exception ex)
            {
                return ex;
            }
            return new Exception("Sould be error");
        }
        [TestMethod]
        public void AllDataMoreThanZero_WithAllValueMoreThanZero_ReturnFalse()
        {
            // Arrange
            var value1 = 1;
            var value2 = 2;
            var value3 = 0;
            var value4 = 4;
            bool isAllValueMoreThanZero;

            // Act
            isAllValueMoreThanZero = AreaCalculator.AllDataMoreThanZero(value1, value2, value3, value4);

            // Assert
            Assert.IsTrue(isAllValueMoreThanZero);
        }
        [TestMethod]
        public void AllDataMoreThanZero_WithAValueLessThanZero_ReturnFalse()
        {
            // Arrange
            var value1 = 1;
            var value2 = 2;
            var value3 = 0;
            var value4 = -4;
            bool isAllValueMoreThanZero;

            // Act
            isAllValueMoreThanZero = AreaCalculator.AllDataMoreThanZero(value1, value2, value3, value4);

            // Assert
            Assert.IsFalse(isAllValueMoreThanZero);
        }
        [TestMethod]
        public void AllDataMoreThanZero_WithRightTriangleEdges_ReturnTrue()
        {
            // Arrange
            var edge1 = 3.0;
            var edge2 = 4.0;
            var edge3 = 5.0;
            bool isRightTriangle;

            // Act
            isRightTriangle = AreaCalculator.IsTriangleRight(edge1, edge2, edge3);

            // Assert
            Assert.IsTrue(isRightTriangle);
        }
        [TestMethod]
        public void AllDataMoreThanZero_WithNotRightTriangleEdges_ReturnFalse()
        {
            // Arrange
            var edge1 = 3.0;
            var edge2 = 6.0;
            var edge3 = 5.0;
            bool isRightTriangle;

            // Act
            isRightTriangle = AreaCalculator.IsTriangleRight(edge1, edge2, edge3);

            // Assert
            Assert.IsFalse(isRightTriangle);
        }
    }
}