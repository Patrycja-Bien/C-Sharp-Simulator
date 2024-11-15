using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;
    public class PointTests
    {
        [Fact]
        public void Point_Constructor_SetsCoordinatesCorrectly()
        {
            // Arrange
            int x = 5, y = 10;

            // Act
            var point = new Point(x, y);

            // Assert
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }

        [Theory]
        [InlineData(Direction.Left, -1, 0)]
        [InlineData(Direction.Right, 1, 0)]
        [InlineData(Direction.Up, 0, 1)]
        [InlineData(Direction.Down, 0, -1)]
        public void Point_Next_MovesCorrectly(Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(0, 0);

            // Act
            var result = point.Next(direction);

            // Assert
            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
        }

        [Theory]
        [InlineData(Direction.Left, -1, 1)]
        [InlineData(Direction.Right, 1, -1)]
        [InlineData(Direction.Up, 1, 1)]
        [InlineData(Direction.Down, -1, -1)]
        public void Point_NextDiagonal_MovesCorrectly(Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(0, 0);

            // Act
            var result = point.NextDiagonal(direction);

            // Assert
            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
        }

        [Fact]
        public void Point_ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var point = new Point(5, 6);

            // Act
            var result = point.ToString();

            // Assert
            Assert.Equal("(5, 6)", result);
        }
    }
