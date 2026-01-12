namespace AoC2025;

public class Day11
{
    [Flags]
    private enum RequiredNodes
    {
        None = 0,
        Dac = 1 << 0,
        Fft = 1 << 1,
        Both = Dac | Fft
    }

    public static ulong Calculate(string start, string end, Dictionary<string, string[]> graph)
    {
        var memo = new Dictionary<(string node, RequiredNodes mask), ulong>();
        var visited = new HashSet<string>();

        return Solve(start, 0);

        ulong Solve(string curr, RequiredNodes mask)
        {
            if (curr == nameof(RequiredNodes.Dac).ToLower())
                mask |= RequiredNodes.Dac;

            if (curr == nameof(RequiredNodes.Fft).ToLower())
                mask |= RequiredNodes.Fft;

            if (curr == end)
            {
                return mask == RequiredNodes.Both
                    ? 1UL
                    : 0UL;
            }

            var key = (curr, mask);
            if (memo.TryGetValue(key, out var val))
                return val;

            visited.Add(curr);
            ulong count = 0;

            if (graph.TryGetValue(curr, out var neighbors))
            {
                foreach (var n in neighbors)
                {
                    if (!visited.Contains(n))
                        count += Solve(n, mask);
                }
            }

            visited.Remove(curr);

            return memo[key] = count;
        }
    }
}