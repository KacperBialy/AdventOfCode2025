using AoC2025;
using FluentAssertions;

namespace TestProject1;

public class Day4Tests
{
    [Fact]
    public void CalculateAccessedRows_WhenSimplePart1Input_ReturnsCorrectValue()
    {
        char[,] grid =
        {
            {'.', '.', '@', '@', '.', '@', '@', '@', '@', '.'},
            {'@', '@', '@', '.', '@', '.', '@', '.', '@', '@'},
            {'@', '@', '@', '@', '@', '.', '@', '.', '@', '@'},
            {'@', '.', '@', '@', '@', '@', '.', '.', '@', '.'},
            {'@', '@', '.', '@', '@', '@', '@', '.', '@', '@'},
            {'.', '@', '@', '@', '@', '@', '@', '@', '.', '@'},
            {'.', '@', '.', '@', '.', '@', '.', '@', '@', '@'},
            {'@', '.', '@', '@', '@', '.', '@', '@', '@', '@'},
            {'.', '@', '@', '@', '@', '@', '@', '@', '@', '.'},
            {'@', '.', '@', '.', '.', '@', '@', '@', '.', '@'}
        };

        var result = Day4.CalculateAccessedRowsPart1(grid);

        result.Should().Be(13);
    }
    
    [Fact]
    public void CalculateAccessedRows_WhenPart1Input_ReturnsCorrectValue()
    {
        var lines = File.ReadAllLines("Inputs/Day4/Day4.txt");

        var rows = lines.Length;
        var cols = lines[0].Length;

        var grid = new char[rows, cols];

        for (var r = 0; r < rows; r++)
        for (var c = 0; c < cols; c++)
            grid[r, c] = lines[r][c];

        var result = Day4.CalculateAccessedRowsPart1(grid);

        result.Should().Be(1604);
    }
    
    [Fact]
    public void CalculateAccessedRows_WhenSimplePart2Input_ReturnsCorrectValue()
    {
        char[,] grid =
        {
            {'.','.', '@','@','.', '@','@','@','@','.'},
            {'@','@','@','.', '@','.', '@','.', '@','@'},
            {'@','@','@','@','@','.', '@','.', '@','@'},
            {'@','.', '@','@','@','@','.', '.','@','.'},
            {'@','@','.', '@','@','@','@','.', '@','@'},
            {'.','@','@','@','@','@','@','@','.', '@'},
            {'.','@','.', '@','.', '@','.', '@','@','@'},
            {'@','.', '@','@','@','.', '@','@','@','@'},
            {'.','@','@','@','@','@','@','@','@','.'},
            {'@','.', '@','.', '@','@','@','.', '@','.'}
        };

        var result = Day4.CalculateAccessedRowsPart2(grid);

        result.Should().Be(43);
    }
    
    [Fact]
    public void CalculateAccessedRows_WhenPart2Input_ReturnsCorrectValue()
    {
        var lines = File.ReadAllLines("Inputs/Day4/Day4.txt");

        var rows = lines.Length;
        var cols = lines[0].Length;

        var grid = new char[rows, cols];

        for (var r = 0; r < rows; r++)
        for (var c = 0; c < cols; c++)
            grid[r, c] = lines[r][c];

        var result = Day4.CalculateAccessedRowsPart2(grid);

        result.Should().Be(9397);
    }
}