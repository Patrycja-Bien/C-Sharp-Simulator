using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(15, 1, 10, 10)]
    [InlineData(1, 1, 10, 1)]
    [InlineData(10, 1, 10, 10)]
    public void Limiter_ReturnsCorrectValue(int value, int min, int max, int expected)
    {
        // Act
        var result = Validator.Limiter(value, min, max);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("Hello", 3, 10, ' ', "Hello")]
    [InlineData("Hello, World!", 3, 10, ' ', "Hello, Wor")]
    [InlineData("Hi", 5, 10, '_', "Hi___")]
    [InlineData("a", 3, 10, '_', "A__")]
    [InlineData("a very long string", 5, 10, '.', "A very lon")]
    [InlineData("A                                    B", 3, 25, '#', "A##")]
    public void Shortener_ReturnsCorrectResult(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }
}
