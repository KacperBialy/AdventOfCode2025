using System.Numerics;

namespace AoC2025;

public class Day5
{
    public static int GetFreshCount((ulong from, ulong to)[] ranges, ulong[] ids)
    {
        return ids.Count(id =>
            ranges.Any(r => id >= r.from && id <= r.to));
    }

    public static BigInteger GetFreshCount((ulong from, ulong to)[] ranges)
    {
        var ordered = ranges.OrderBy(range => range.from)
            .ToArray();

        BigInteger total = 0;

        var (currentFrom, currentTo) = ordered[0];

        for (var i = 1; i < ordered.Length; i++)
        {
            var nextFrom = ordered[i].from;
            var nextTo = ordered[i].to;

            if (nextFrom <= currentTo)
                currentTo = Math.Max(currentTo, nextTo);
            else
            {
                total += currentTo - currentFrom + 1;
                currentFrom = nextFrom;
                currentTo = nextTo;
            }
        }
        
        total += currentTo - currentFrom + 1;
        return total;
    }
}