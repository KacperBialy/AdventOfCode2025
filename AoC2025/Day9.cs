using System.Drawing;

namespace AoC2025;

public class Day9
{
    public static long CalculateMaxSquareArea(Point[] points)
    {
        long distance = 0;
        for (var i = 0; i < points.Length; i++)
        {
            for (var j = i + 1; j < points.Length; j++)
            {
                if (i == j)
                    continue;

                var newDistance = (1L + Math.Abs(points[i].X - points[j].X))
                                  * (1 + Math.Abs(points[i].Y - points[j].Y));

                if (newDistance > distance)
                    distance = newDistance;
            }
        }

        return distance;
    }
}