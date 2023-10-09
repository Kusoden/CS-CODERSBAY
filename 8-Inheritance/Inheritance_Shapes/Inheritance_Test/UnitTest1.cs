using Inheritance_Shapes;

namespace Inheritance_Test;

public class ShapesTests
{
    public class CircleTests
    {
        [Fact]
        public void CircleAreaCalculation()
        {
            Shape circle = new Circle("Green", true, 5.0);
            Assert.Equal(Math.PI * 25.0, circle.GetArea()); /*There were too many numbers in result because of that just wrote the solution before thee circle.GetArea*/
        }

        [Fact]
        public void CirclePerimeterCalculation()
        {
            Shape circle = new Circle("Green", true, 5.0);
            Assert.Equal(2 * Math.PI * 5.0, circle.GetPerimeter());
        }

        [Fact]
        public void CircleNegativeRadiusException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Circle("Green", true, -5.0));
            Assert.Equal("\nERROR: Radius must be greater than 0.\n", ex.Message);
        }

        [Fact]
        public void CircleZeroRadiusException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Circle("Green", true, 0));
            Assert.Equal("\nERROR: Radius must be greater than 0.\n", ex.Message);
        }
    }

    public class RectangleTests
    {
        [Fact]
        public void RectangleAreaCalculation()
        {
            Shape rectangle = new Rectangle("White", false, 4.0, 6.0);
            Assert.Equal(24.0, rectangle.GetArea());/*6*4*/
        }

        [Fact]
        public void RectanglePerimeterCalculation()
        {
            Shape rectangle = new Rectangle("White", false, 4.0, 6.0);
            Assert.Equal(20.0, rectangle.GetPerimeter());/*4+4 + 6+6*/
        }

        [Fact]
        public void RectangleNegativeWidthException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Rectangle("White", false, -4.0, 6.0));
            Assert.Equal("\nERROR: Width must be greater than 0.\n", ex.Message);
        }

        [Fact]
        public void RectangleZeroHeightException()
        {
            Assert.Throws<ArgumentException>(() => new Rectangle("White", false, 4.0, 0));
        }
    }

    public class SquareTests
    {
        [Fact]
        public void SquareAreaCalculation()
        {
            Shape square = new Square("Red", true, 5.0);
            Assert.Equal(25.0, square.GetArea());
        }

        [Fact]
        public void SquarePerimeterCalculation()
        {
            Shape square = new Square("Red", true, 5.0);
            Assert.Equal(20.0, square.GetPerimeter());
        }

        [Fact]
        public void SquareNegativeSideException()
        {
            Assert.Throws<ArgumentException>(() => new Square("Red", true, -5.0));
        }

        [Fact]
        public void SquareZeroSideException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Square("Red", true, 0));
            Assert.Equal("\nERROR: Side must be greater than 0.\n", ex.Message);
        }
    }

}