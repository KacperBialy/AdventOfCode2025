namespace AoC2025;

public class Day1
{
    private const char LeftDirection = 'L';
    private const char RightDirection = 'R';

    public static (int endpoint, int zeroEntrance) CalculateDialPosition(
        string[] input,
        int startingDial)
    {
        var zeroEntrance = 0;

        foreach (var row in input)
        {
            var direction = row[0];
            var value = int.Parse(row[1..]);

            if (direction == RightDirection)
            {
                zeroEntrance += (startingDial + value) / 100;
                startingDial = (startingDial + value) % 100;
            }
            else
            {
                var raw = startingDial - value;
                if (raw == 0)
                    zeroEntrance++;
                else if (raw < 0)
                {
                    if (startingDial != 0)
                        zeroEntrance++;

                    zeroEntrance += Math.Abs(raw) / 100;
                }

                startingDial = (raw % 100 + 100) % 100;
            }
        }

        return (startingDial, zeroEntrance);
    }
}