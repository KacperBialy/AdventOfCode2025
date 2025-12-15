namespace AoC2025;

public class Day1
{
    private const char LeftDirection = 'L';
    private const char RightDirection = 'R';

    public static (int endpoint, int zeroEntrance) CalculateDialPosition(string[] input, int startingDial)
    {
        var zeroEntrance = 0;
        foreach (var row in input)
        {
            var direction = row[0];
            var value = int.Parse(row[1..]);

            startingDial = direction switch
            {
                LeftDirection => ((startingDial - value) % 100 + 100) % 100,
                _ => (startingDial + value) % 100
            };

            if (startingDial == 0)
                zeroEntrance++;
        }

        return (startingDial, zeroEntrance);
    }
}