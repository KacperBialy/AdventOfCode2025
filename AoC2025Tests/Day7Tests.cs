using AoC2025;
using FluentAssertions;

namespace AoC2025Tests;

public class Day7Tests
{
    [Fact]
    public void CalculateNumberOfSplits_WhenSimpleInput_ReturnsCorrectCount()
    {
        const string input = """
                             .......S.......
                             ...............
                             .......^.......
                             ...............
                             ......^.^......
                             ...............
                             .....^.^.^.....
                             ...............
                             ....^.^...^....
                             ...............
                             ...^.^...^.^...
                             ...............
                             ..^...^.....^..
                             ...............
                             .^.^.^.^.^...^.
                             ...............
                             """;

        var start = PrepareData(input, out var map);

        var result = Day7.CalculateNumberOfSplits(map, start);

        result.Should().Be(21);
    }

    [Fact]
    public void CalculateNumberOfSplits_WhenPart1_ReturnsCorrectCount()
    {
        var input = File.ReadAllText("Inputs/Day7/Day7.txt");
        var start = PrepareData(input, out var map);
        
        var result = Day7.CalculateNumberOfSplits(map, start);

        result.Should().Be(1628); //1876174090
    }

    [Fact]
    public void CalculateNumberOfSplits_WhenPart2SimpleInput_ReturnsCorrectCount()
    {
        const string input = """
                             .......S.......
                             ...............
                             .......^.......
                             ...............
                             ......^.^......
                             ...............
                             .....^.^.^.....
                             ...............
                             ....^.^...^....
                             ...............
                             ...^.^...^.^...
                             ...............
                             ..^...^.....^..
                             ...............
                             .^.^.^.^.^...^.
                             ...............
                             """;

        var start = PrepareData(input, out var map);
        
        var result = Day7.CalculateTotalTachyonTimelines(map, start);

        result.Should().Be(40);
    }
    
    [Fact]
    public void CalculateNumberOfSplits_WhenPart2Input_ReturnsCorrectCount()
    {
        var input = File.ReadAllText("Inputs/Day7/Day7.txt");
        var start = PrepareData(input, out var map);
        
        var result = Day7.CalculateTotalTachyonTimelines(map, start);

        result.Should().Be(27055852018812);
    }

    private static (int, int) PrepareData(string input, out char[,] map)
    {
        var lines = input.Split(Environment.NewLine);
        var rows = lines.Length;
        var cols = lines[0].Length;

        var start = (0, 0);
        map = new char[rows, cols];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (lines[i][j] == 'S')
                    start = (i, j);

                map[i, j] = lines[i][j];
            }
        }

        return start;
    }
}