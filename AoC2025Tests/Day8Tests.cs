using AoC2025;
using FluentAssertions;

namespace TestProject1;

public class Day8Tests
{
    [Fact]
    public void CalculateDistance_WhenSimpleInput_ReturnsCorrectDistance()
    {
        int[] vectorA = [162, 817, 812];
        int[] vectorB = [425, 690, 689];

        var distance = Day8.CalculateDistance(vectorA, vectorB);

        distance.Should().Be(100427);
    }

    [Fact]
    public void Calculate_WhenSimpleInput_ReturnsCorrectDistance()
    {
        int[][] vectors =
        [
            [162, 817, 812],
            [57, 618, 57],
            [906, 360, 560],
            [592, 479, 940],
            [352, 342, 300],
            [466, 668, 158],
            [542, 29, 236],
            [431, 825, 988],
            [739, 650, 466],
            [52, 470, 668],
            [216, 146, 977],
            [819, 987, 18],
            [117, 168, 530],
            [805, 96, 715],
            [346, 949, 466],
            [970, 615, 88],
            [941, 993, 340],
            [862, 61, 35],
            [984, 92, 344],
            [425, 690, 689]
        ];

        var result = Day8.Calculate(vectors);

        result.Should().Be(25272);
    }

    [Fact]
    public void Calculate_WhenPart1Input_ReturnsCorrectDistance()
    {
        var vectors = File.ReadAllLines("Inputs/Day8/Day8.txt")
            .Select(line => line.Split(','));

        var list = new List<int[]>();
        foreach (var vector in vectors)
        {
            var x = int.Parse(vector[0]);
            var y = int.Parse(vector[1]);
            var z = int.Parse(vector[2]);

            list.Add([x, y, z]);
        }

        var result = Day8.Calculate(list.ToArray());
        
        result.Should().Be(8135565324);
    }
}