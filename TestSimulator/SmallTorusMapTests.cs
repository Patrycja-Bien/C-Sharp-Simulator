using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallTorusMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int sizeX = 10;
        int sizeY = 15;
        // Act
        var map = new SmallTorusMap(sizeX, sizeY);
        // Assert
        Assert.Equal(sizeX, map.SizeX);
        Assert.Equal(sizeY, map.SizeY);
    }

    [Theory]
    [InlineData(4, 4)]
    [InlineData(21, 21)]
    public void
        Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException
        (int sizeX, int sizeY)
    {
        // Act & Assert
        // The way to check if method throws anticipated exception:
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallTorusMap(sizeX, sizeY));
    }

    [Theory]
    [InlineData(1, 1, 5, 5, true)]
    [InlineData(6, 1, 5, 5, false)]
    [InlineData(19, 19, 20, 20, true)]
    [InlineData(20, 20, 20, 20, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y,
        int sizeX, int sizeY, bool expected)
    {
        // Arrange
        var map = new SmallTorusMap(sizeX, sizeY);
        var point = new Point(x, y);
        // Act
        var result = map.Exist(point);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(0, 0, Direction.Down, 0, 19)]
    [InlineData(0, 8, Direction.Left, 19, 8)]
    [InlineData(19, 10, Direction.Right, 0, 10)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallTorusMap(20, 20);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.Next(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(0, 0, Direction.Down, 19, 19)]
    [InlineData(0, 8, Direction.Left, 19, 9)]
    [InlineData(19, 10, Direction.Right, 0, 9)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallTorusMap(20, 20);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.NextDiagonal(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}