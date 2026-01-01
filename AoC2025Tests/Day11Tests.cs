using AoC2025;
using FluentAssertions;

namespace AoC2025Tests;

public class Day11Tests
{
    [Fact]
    public void Day11_WhenPart1Input_ReturnsCorrectResult()
    {
        Dictionary<string, string[]> connections = new();
        
        var lines = File.ReadAllLines("Inputs/Day11/Day11.txt");
        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            var key = parts[0];
            var values = parts[1].Split(' ');
            connections[key] = values;
        }

        var result = Day11.CalculateNumberOfPaths("you", "out", connections);

        result.Should().Be(599);
    }
}