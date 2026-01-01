using AoC2025;
using FluentAssertions;

namespace AoC2025Tests;

public class Day2Tests
{
    [Fact]
    public void GetInvalidSumPart1_WhenOneRange_ReturnsCorrectSum()
    {
        var ranges = new List<(ulong from, ulong to)> { (11, 22) };

        var sum = Day2.SumValuesWithRepeatedHalf(ranges);

        sum.Should().Be(33);
    }
    
    [Fact]
    public void GetInvalidSumPart1_WhenMultipleRanges_ReturnsCorrectSum()
    {
        var ranges = new List<(ulong from, ulong to)> 
        { 
            (11, 22),
            (95, 115),
            (998, 1012),
            (1188511880, 1188511890),
            (222220, 222224),
            (1698522, 1698528),
            (446443, 446449),
            (38593856, 38593862),
            (565653, 565659),
            (824824821, 824824827),
            (2121212118, 2121212124)
        };

        var sum = Day2.SumValuesWithRepeatedHalf(ranges);

        sum.Should().Be(1227775554);
    }
    
    [Fact]
    public void GetInvalidSumPart1_WhenDay2Part1Input_ReturnsCorrectSum()
    {
        List<(ulong from, ulong to)> ranges = File.ReadAllText("Inputs/Day2/Day2.txt")
            .Split(",")
            .Select(row => row.Split("-"))
            .Select(pair => (ulong.Parse(pair[0]), ulong.Parse(pair[1])))
            .ToList();
        
        var sum = Day2.SumValuesWithRepeatedHalf(ranges);

        sum.Should().Be(16793817782);
    }

    
    [Fact]
    public void GetInvalidSumPart2_WhenOneRange_ReturnsCorrectSum()
    {
        var ranges = new List<(ulong from, ulong to)> { (11, 22) };

        var sum = Day2.SumValuesWithRepeatedPrefixPattern(ranges);

        sum.Should().Be(33);
    }
    
    [Fact]
    public void GetInvalidSumPart2_WhenMultipleRanges_ReturnsCorrectSum()
    {
        var ranges = new List<(ulong from, ulong to)> 
        { 
            (11, 22),
            (95, 115),
            (998, 1012),
            (1188511880, 1188511890),
            (222220, 222224),
            (1698522, 1698528),
            (446443, 446449),
            (38593856, 38593862),
            (565653, 565659),
            (824824821, 824824827),
            (2121212118, 2121212124)
        };

        var sum = Day2.SumValuesWithRepeatedPrefixPattern(ranges);

        sum.Should().Be(4174379265);
    }
    
    [Fact]
    public void GetInvalidSumPart2_WhenDay2Part1Input_ReturnsCorrectSum()
    {
        List<(ulong from, ulong to)> ranges = File.ReadAllText("Inputs/Day2/Day2.txt")
            .Split(",")
            .Select(row => row.Split("-"))
            .Select(pair => (ulong.Parse(pair[0]), ulong.Parse(pair[1])))
            .ToList();
        
        var sum = Day2.SumValuesWithRepeatedPrefixPattern(ranges);

        sum.Should().Be(27469417404);
    }
}