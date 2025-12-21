using AoC2025;
using FluentAssertions;

namespace TestProject1;

public class Day5Tests
{
    [Fact]
    public void GetFreshCount_WhenSimpleInput_ReturnsCorrectCount()
    {
        var ranges = new (ulong from, ulong to)[] { (3, 5), (10, 14), (16, 20), (12, 18) };
        ulong[] ids = [1, 5, 8, 11, 17, 32];

        var result = Day5.GetFreshCount(ranges, ids);

        result.Should().Be(3);
    }

    [Fact]
    public void GetFreshCount_WhenPart1Input_ReturnsCorrectCount()
    {
        var ranges = new List<(ulong from, ulong to)>();
        var ids = new List<ulong>();
        foreach (var line in File.ReadAllLines("Inputs/Day5/Day5.txt"))
        {
            if (string.IsNullOrEmpty(line))
                continue;

            var parts = line.Split("-");
            if (parts.Length == 2)
                ranges.Add((ulong.Parse(parts[0]), ulong.Parse(parts[1])));
            else
                ids.Add(ulong.Parse(parts[0]));
        }

        var result = Day5.GetFreshCount(ranges.ToArray(), ids.ToArray());

        result.Should().Be(720);
    }
    
    [Fact]
    public void GetFreshCount_WhenPart2Input_ReturnsCorrectCount()
    {
        var ranges = new List<(ulong from, ulong to)>();
        foreach (var line in File.ReadAllLines("Inputs/Day5/Day5.txt"))
        {
            if (string.IsNullOrEmpty(line))
                continue;

            var parts = line.Split("-");
            if (parts.Length == 2)
                ranges.Add((ulong.Parse(parts[0]), ulong.Parse(parts[1])));
        }

        var result = Day5.GetFreshCount(ranges.ToArray());

        result.Should().Be(357608232770687);
    }
}