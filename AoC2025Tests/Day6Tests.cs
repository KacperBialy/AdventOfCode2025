using System.Text;
using AoC2025;
using FluentAssertions;

namespace TestProject1;

public class Day6Tests
{
    [Fact]
    public void SumOfAllOperations_WhenSimpleInput_ReturnsCorrectSum()
    {
        var input = """
                    123 328  51 64 
                     45 64  387 23 
                      6 98  215 314
                    *   +   *   +  
                    """;
        var (numbers, operations) = PrepareDataPart1(input);

        var result = Day6.SumOfAllOperations(numbers, operations);

        result.Should().Be(4277556);
    }

    [Fact]
    public void SumOfAllOperations_WhenPart1Input_ReturnsCorrectSum()
    {
        var input = File.ReadAllText("Inputs/Day6/Day6.txt");
        var (numbers, operations) = PrepareDataPart1(input);

        var result = Day6.SumOfAllOperations(numbers, operations);

        result.Should().Be(4951502530386);
    }

    [Fact]
    public void SumOfAllOperations_WhenPart2Input_ReturnsCorrectSum()
    {
        var input = File.ReadAllText("Inputs/Day6/Day6.txt");
        var (numbers, operations) = PrepareDataPart2(input);

        var result = Day6.SumOfAllOperations(numbers, operations);

        result.Should().Be(8486156119946);
    }

    private static (int[,] numbers, char[]) PrepareDataPart2(string input)
    {
        var lines = input
            .Split(Environment.NewLine);

        var operationLine = lines[^1];
        var operations = operationLine
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s[0])
            .ToArray();

        var numberLines = lines[..^1];
        var rows = numberLines.Length;
        var cols = numberLines[0]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Length;

        var index = 0;
        var numbers = new int[rows, cols];
        for (var i = 0; i < numberLines[0].Length; i++)
        {
            var numberBuilder = new StringBuilder();
            foreach (var line in numberLines)
            {
                if (line[i] != ' ')
                    numberBuilder.Append(line[i]);
            }

            if (numberBuilder.Length == 0)
                index++;
            else
                numbers[i % rows, index] = int.Parse(numberBuilder.ToString());
        }

        return (numbers, operations);
    }

    private static (int[,] numbers, char[] operations) PrepareDataPart1(string input)
    {
        var lines = input
            .Split(Environment.NewLine);

        // Last line contains operations
        var operationLine = lines[^1];
        var operations = operationLine
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s[0])
            .ToArray();

        // Remaining lines contain numbers
        var numberLines = lines[..^1];
        var rows = numberLines.Length;
        var cols = numberLines[0]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Length;

        var numbers = new int[rows, cols];

        for (var i = 0; i < rows; i++)
        {
            var values = numberLines[i]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (var j = 0; j < cols; j++)
            {
                numbers[i, j] = values[j];
            }
        }

        return (numbers, operations);
    }
}