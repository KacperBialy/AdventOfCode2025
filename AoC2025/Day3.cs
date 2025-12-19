namespace AoC2025;

public class Day3
{
    public static ulong SumTotalJoltage(string[] banks)
    {
        ulong sum = 0;
        foreach (var bank in banks)
        {
            var leftMax = ulong.MinValue;
            var rightMax = ulong.MinValue;

            for (var i = 0; i < bank.Length - 1; i++)
            {
                var left = ulong.Parse(bank[i].ToString());
                var right = ulong.Parse(bank[i + 1].ToString());

                if (left > leftMax)
                {
                    leftMax = left;
                    rightMax = right;
                }

                if (right > rightMax)
                    rightMax = right;
            }

            sum += ulong.Parse(leftMax.ToString() + rightMax);
        }

        return sum;
    }
}