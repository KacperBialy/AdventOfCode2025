using AoC2025;
using FluentAssertions;

namespace TestProject1;

public class Day7Tests
{
    [Fact]
    public void CalculateNumberOfSplits_WhenSimpleInput_ReturnsCorrectCount()
    {
        var input = """
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

        var lines = input.Split(Environment.NewLine);
        var rows = lines.Length;
        var cols = lines[0].Length;

        var start = (0, 0);
        var map = new char[rows, cols];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (lines[i][j] == 'S')
                    start = (i, j);

                map[i, j] = lines[i][j];
            }
        }
        
        var result = Day7.CalculateNumberOfSplits(map, start);

        result.Should().Be(21);
    }
    
    [Fact]
    public void CalculateNumberOfSplits_WhenPart1_ReturnsCorrectCount()
    {
        var input = File.ReadAllText("Inputs/Day7/Day7.txt");

        var lines = input.Split(Environment.NewLine);
        var rows = lines.Length;
        var cols = lines[0].Length;

        var start = (0, 0);
        var map = new char[rows, cols];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (lines[i][j] == 'S')
                    start = (i, j);

                map[i, j] = lines[i][j];
            }
        }
        
        var result = Day7.CalculateNumberOfSplits(map, start);

        result.Should().Be(21);
    }
}