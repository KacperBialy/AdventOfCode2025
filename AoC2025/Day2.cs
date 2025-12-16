namespace AoC2025;

public class Day2
{
    #region Part1

    public static ulong SumValuesWithRepeatedHalf(List<(ulong from, ulong to)> ranges)
    {
        ulong sum = 0;

        foreach (var range in ranges)
        {
            for (var position = range.from; position <= range.to; position++)
            {
                if (HasRepeatedHalf(position))
                    sum += position;
            }
        }

        return sum;
    }

    private static bool HasRepeatedHalf(ulong value)
    {
        var valueAsString = value.ToString();
        var half = valueAsString.Length / 2;

        return valueAsString.Length % 2 == 0 && valueAsString[..half] == valueAsString[half..];
    }

    #endregion

    #region Part2

    public static ulong SumValuesWithRepeatedPrefixPattern(List<(ulong from, ulong to)> ranges)
    {
        ulong sum = 0;

        foreach (var range in ranges)
        {
            for (var position = range.from; position <= range.to; position++)
            {
                if (HasRepeatedPrefixPattern(position))
                    sum += position;
            }
        }

        return sum;
    }

    private static bool HasRepeatedPrefixPattern(ulong value)
    {
        ReadOnlySpan<char> s = value.ToString();
        var half = s.Length / 2;

        for (var patternLength = 1; patternLength <= half; patternLength++)
        {
            var pattern = s[..patternLength];

            if (s.Length % patternLength != 0)
                continue;

            var isMatch = true;

            for (var j = patternLength; j < s.Length; j += patternLength)
            {
                if (s.Slice(j, patternLength).SequenceEqual(pattern))
                    continue;
                
                isMatch = false;
                break;
            }

            if (isMatch)
                return true;
        }

        return false;
    }

    #endregion
}