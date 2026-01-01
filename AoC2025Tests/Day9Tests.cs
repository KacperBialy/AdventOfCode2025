using System.Drawing;
using AoC2025;
using FluentAssertions;

namespace AoC2025Tests;

public class Day9Tests
{
    [Fact]
    public void CalculateMaxSquare_WhenSimpleInput_ReturnsCorrectMax()
    {
        var input = new Point[]
        {
            new() { X = 7, Y = 1 },
            new() { X = 11, Y = 1 },
            new() { X = 11, Y = 7 },
            new() { X = 9, Y = 7 },
            new() { X = 9, Y = 5 },
            new() { X = 2, Y = 5 },
            new() { X = 2, Y = 3 },
            new() { X = 7, Y = 3 }
        };

        var maxSquare = Day9.CalculateMaxSquareArea(input);

        maxSquare.Should().Be(50);
    }

    [Fact]
    public void CalculateMaxSquare_WhenPart1Input_ReturnsCorrectMax()
    {
        var input = File.ReadAllLines("Inputs/Day9/Day9.txt")
            .Select(row => row.Split(","))
            .Select(pair => new Point(int.Parse(pair[0]), int.Parse(pair[1])))
            .ToArray();

        var maxSquare = Day9.CalculateMaxSquareArea(input);

        maxSquare.Should().Be(4748826374);
    }
}