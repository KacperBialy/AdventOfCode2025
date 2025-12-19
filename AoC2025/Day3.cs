namespace AoC2025;

public class Day3
{
    public static ulong SumTotalJoltage(string[] banks, int numberOfJoltage)
    {
        ulong sum = 0;

        foreach (var bank in banks)
        {
            var result = new List<char>();
            var start = 0;

            for (var remaining = numberOfJoltage; remaining > 0; remaining--)
            {
                var maxValue = '0';
                var end = bank.Length - remaining;

                for (var i = start; i <= end; i++)
                {
                    if (maxValue < bank[i])
                    {
                        maxValue = bank[i];
                        start = i + 1;
                    }
                }

                result.Add(maxValue);
            }

            sum += ulong.Parse(new string(result.ToArray()));
        }

        return sum;
    }
}