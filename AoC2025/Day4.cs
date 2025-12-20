namespace AoC2025;

public class Day4
{
    public static int CalculateAccessedRows(char[,] grid)
    {
        var moves = new List<(int x, int y)>()
        {
            (-1, -1),
            (-1, 0),
            (-1, 1),
            (0, 1),
            (1, 1),
            (1, 0),
            (1, -1),
            (0, -1)
        };

        var sum = 0;
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] != '@')
                    continue;

                var rollsOfPaper = 0;
                foreach (var move in moves)
                {
                    var x = i + move.x;
                    var y = j + move.y;

                    if (x < 0 || y < 0)
                        continue;

                    if (x > grid.GetLength(0) - 1 || y > grid.GetLength(1) - 1)
                        continue;

                    if (grid[x, y] == '@')
                        rollsOfPaper++;
                }

                if (rollsOfPaper < 4)
                    sum++;
            }
        }

        return sum;
    }
}