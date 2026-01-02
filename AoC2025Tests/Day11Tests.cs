using AoC2025;
using FluentAssertions;

namespace AoC2025Tests;

public class Day11Tests
{
    [Fact]
    public void Day11_WhenPart2Input_ReturnsCorrectResult()
    {
        var result = Day11.Calculate("svr", "out", PrepareData());

        result.Should().Be(393474305030400);
    }

    private static Dictionary<string, string[]> PrepareData()
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

        return connections;
    }
}