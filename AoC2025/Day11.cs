namespace AoC2025;

public class Day11
{
    public static ulong CalculateNumberOfPaths(string start, string end, Dictionary<string, string[]> connections)
    {
        var visited = new HashSet<string>();
        return CountPathsRecursive(start, end, connections, visited);
    }

    private static ulong CountPathsRecursive(string current, string end, Dictionary<string, string[]> connections, HashSet<string> visited)
    {
        if (current == end)
            return 1;

        visited.Add(current);

        ulong count = 0;
        if (connections.TryGetValue(current, out var connection))
        {
            foreach (var neighbor in connection)
            {
                if (!visited.Contains(neighbor))
                {
                    count += CountPathsRecursive(neighbor, end, connections, visited);
                }
            }
        }

        visited.Remove(current);

        return count;
    }
}