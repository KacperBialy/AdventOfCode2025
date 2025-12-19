using AoC2025;
using FluentAssertions;

namespace TestProject1;

public class Day3Tests
{

    [Theory]
    [InlineData("987654321111111", 98)]
    [InlineData("811111111111119", 89)]
    [InlineData("234234234234278", 78)]
    [InlineData("818181911112111", 92)]
    public void SumTotalJoltage_WhenOneBank_ReturnsCorrectSum(string bank, ulong expectedSum)
    {
        var sum = Day3.SumTotalJoltage([bank]);

        sum.Should().Be(expectedSum);
    }
    
    [Fact]
    public void SumTotalJoltage_WhenPart1Input_ReturnsCorrectSum()
    {
        var banks = File.ReadAllLines("Inputs/Day3/Day3.txt");
        
        var sum = Day3.SumTotalJoltage(banks);
        
        sum.Should().Be(0);
    }
}