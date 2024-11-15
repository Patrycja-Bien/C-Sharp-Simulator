using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;
    public class RectangleTests
    {
        [Fact]
        public void Rectangle_Constructor_SetsCoordinatesCorrectly()
        {
            // Arrange
            int x1 = 1, y1 = 1, x2 = 4, y2 = 5;

            // Act
            var rectangle = new Rectangle(x1, y1, x2, y2);

            // Assert
            Assert.Equal(1, rectangle.X1);
            Assert.Equal(1, rectangle.Y1);
            Assert.Equal(4, rectangle.X2);
            Assert.Equal(5, rectangle.Y2);
        }

        [Fact]
        public void Rectangle_Constructor_ThrowsForCollinearPoints()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 1, 5));
            Assert.Throws<ArgumentException>(() => new Rectangle(2, 2, 4, 2));
        }

        [Fact]
        public void Rectangle_Constructor_WithPoints_SetsCoordinatesCorrectly()
        {
            // Arrange
            var p1 = new Point(3, 3);
            var p2 = new Point(6, 8);

            // Act
            var rectangle = new Rectangle(p1, p2);

            // Assert
            Assert.Equal(3, rectangle.X1);
            Assert.Equal(3, rectangle.Y1);
            Assert.Equal(6, rectangle.X2);
            Assert.Equal(8, rectangle.Y2);
        }

        [Theory]
        [InlineData(2, 2, true)] 
        [InlineData(5, 6, true)]  
        [InlineData(7, 10, false)] 
        [InlineData(3, 5, true)] 
        [InlineData(1, 5, false)] 
        [InlineData(5, 10, false)] 
        public void Rectangle_Contains_ReturnsCorrectResult(int x, int y, bool expected)
        {
            // Arrange
            var rectangle = new Rectangle(1, 1, 7, 10);
            var point = new Point(x, y);

            // Act
            var result = rectangle.Contains(point);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Rectangle_ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var rectangle = new Rectangle(2, 3, 7, 10);

            // Act
            var result = rectangle.ToString();

            // Assert
            Assert.Equal("(2, 3):(7, 10)", result);
        }
    }

