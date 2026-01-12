using AoC2025;
using FluentAssertions;

namespace AoC2025Tests;

public partial class Day10Tests
{
    [Fact]
    public void Calculate_WhenPart1_ReturnsCorrectResult()
    {
        var result = Day10.Calculate(File.ReadAllText("inputs/Day10/Day10.txt"));

        result.Should().Be(481);
    }
}