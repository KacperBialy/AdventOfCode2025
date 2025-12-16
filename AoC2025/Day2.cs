namespace AoC2025;

public class Day2
{
    public static ulong GetInvalidSum(List<(ulong from, ulong to)> ranges)
    {
        ulong sum = 0;

        foreach (var range in ranges)
        {
            for (var position = range.from; position <= range.to; position++)
            {
                if(IsInvalid(position))
                    sum += position;
            }
        }

        return sum;
    }

    private static bool IsInvalid(ulong value)
    {
        var s = value.ToString();
        var half = s.Length / 2;

        return s.Length % 2 == 0 && s[..half] == s[half..];
    }
}