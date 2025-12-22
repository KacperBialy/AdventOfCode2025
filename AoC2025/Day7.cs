namespace AoC2025;

public class Day7
{
    public static int CalculateNumberOfSplits(char[,] map, (int x, int y) start)
    {
        var rows = map.GetLength(0);

        var points = new HashSet<(int x, int y)>()
        {
            start
        };

        var sum = 0;
        var newPoints = new HashSet<(int x, int y)>();

        while (true)
        {
            foreach (var point in points)
            {
                if (point.x >= rows - 1)
                    continue;

                switch (map[point.x + 1, point.y])
                {
                    case '.':
                        newPoints.Add((point.x + 1, point.y));
                        break;
                    case '^':
                        sum++;
                        newPoints.Add((point.x + 1, point.y - 1));
                        newPoints.Add((point.x + 1, point.y + 1));
                        break;
                }
            }

            if (newPoints.Count == 0)
                break;

            points = newPoints;
            newPoints = [];
        }

        return sum;
    }
    
 public static ulong CalculateTotalTachyonTimelines(char[,] map, (int x, int y) start)
    {
        var rows = map.GetLength(0);
        var memo = new Dictionary<(int x, int y), ulong>();
        
        return Solve(start);

        ulong Solve((int x, int y) point)
        {
            if (point.x >= rows)
                return 1;

            if (memo.TryGetValue(point, out var cached))
                return cached;

            ulong result = map[point.x, point.y] switch
            {
                '.' or 'S' => Solve((point.x + 1, point.y)),
                '^' => Solve((point.x, point.y - 1)) + Solve((point.x, point.y + 1)),
                _ => 1
            };

            memo[point] = result;
            return result;
        }
    }
   

}