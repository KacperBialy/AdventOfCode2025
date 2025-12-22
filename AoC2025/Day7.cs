namespace AoC2025;

public class Day7
{
    public static int CalculateNumberOfSplits(char[,] map, (int x, int y) start)
    {
        var rows = map.GetLength(0);
        var cols= map.GetLength(1);
        
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
                if(point.x + 1 > rows - 1 || (point.y + 1 > cols - 1 && point.y - 1 > 0))
                    continue;
                
                switch (map[point.x + 1, point.y])
                {
                    case '.':
                        newPoints.Add((point.x + 1, point.y));
                        break;
                    case '^':
                        sum++;
                        newPoints.Add((point.x + 1 , point.y - 1));
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
}