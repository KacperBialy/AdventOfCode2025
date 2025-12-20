namespace AoC2025;

public class Day4
{
    private static readonly (int dx, int dy)[] Moves =
    {
        (-1, -1), (-1, 0), (-1, 1),
        ( 0,  1),
        ( 1,  1), ( 1, 0), ( 1, -1),
        ( 0, -1)
    };

    private static bool InBounds(char[,] grid, int x, int y) =>
        x >= 0 && y >= 0 &&
        x < grid.GetLength(0) &&
        y < grid.GetLength(1);

    private static int CountAdjacent(char[,] grid, int i, int j)
    {
        var count = 0;

        foreach (var (dx, dy) in Moves)
        {
            var x = i + dx;
            var y = j + dy;

            if (InBounds(grid, x, y) && grid[x, y] == '@')
                count++;
        }

        return count;
    }

    public static int CalculateAccessedRows(char[,] grid)
    {
        var sum = 0;

        for (var i = 0; i < grid.GetLength(0); i++)
        for (var j = 0; j < grid.GetLength(1); j++)
        {
            if (grid[i, j] != '@')
                continue;

            if (CountAdjacent(grid, i, j) < 4)
                sum++;
        }

        return sum;
    }

    public static int CalculateAccessedRowsPart2(char[,] grid)
    {
        var sum = 0;

        while (true)
        {
            var changes = 0;
            var gridCopy = (char[,])grid.Clone();

            for (var i = 0; i < grid.GetLength(0); i++)
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] != '@')
                    continue;

                if (CountAdjacent(grid, i, j) < 4)
                {
                    gridCopy[i, j] = 'x';
                    changes++;
                }
            }

            if (changes == 0)
                break;

            sum += changes;
            grid = gridCopy;
        }

        return sum;
    }
}