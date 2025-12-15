using AoC2025;
using FluentAssertions;

namespace TestProject1;

public class Day1Tests
{
    [Fact]
    public void CalculateDialPosition_LeftMove_WithoutFullRotation_ReturnsCorrectDialPosition()
    {
        string[] input = ["L45"];

        var result = Day1.CalculateDialPosition(input, 50);

        result.endpoint.Should().Be(5);
    }

    [Fact]
    public void CalculateDialPosition_LeftMove_WithFullRotation_ReturnsCorrectDialPosition()
    {
        string[] input = ["L420"];

        var result = Day1.CalculateDialPosition(input, 43);

        result.endpoint.Should().Be(23);
    }

    [Fact]
    public void CalculateDialPosition_LeftRight_WithoutFullRotation_ReturnsCorrectDialPosition()
    {
        string[] input = ["R118"];

        var result = Day1.CalculateDialPosition(input, 50);

        result.endpoint.Should().Be(68);
    }

    [Fact]
    public void CalculateDialPosition_LeftRight_WithFullRotation_ReturnsCorrectDialPosition()
    {
        string[] input = ["R68"];

        var result = Day1.CalculateDialPosition(input, 50);

        result.endpoint.Should().Be(18);
    }

    [Fact]
    public void CalculateDialPosition_WhenComplex_ReturnsCorrectDialPositionAndZeroEntrance()
    {
        string[] input = ["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"];

        var result = Day1.CalculateDialPosition(input, 50);

        result.endpoint.Should().Be(32);
        result.zeroEntrance.Should().Be(6);
    }
    
    [Fact]
    public void CalculateDialPosition_WhenDay1Input_ReturnsEntrance()
    {
        var input = File.ReadAllLines("Day1/Day1.txt");

        var result = Day1.CalculateDialPosition(input, 50);
    }
}