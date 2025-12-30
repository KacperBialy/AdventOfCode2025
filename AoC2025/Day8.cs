namespace AoC2025;

public class Day8
{
    public static long Calculate(int[][] vectors, int n)
    {
        var priorityQueue = new PriorityQueue<(int[] vectorA, int[] vectorB), long>();

        for (var i = 0; i < vectors.Length; i++)
        {
            var vectorA = vectors[i];
            for (var j = i + 1; j < vectors.Length; j++)
            {
                var vectorB = vectors[j];
                if (vectorA == vectorB)
                    continue;

                var distance = CalculateDistance(vectorA, vectorB);
                priorityQueue.Enqueue((vectorA, vectorB), distance);
            }
        }

        var neighbours = new Dictionary<int[], List<int[]>>();
        for (var i = 0; i < n; i++)
        {
            var (vectorA, vectorB) = priorityQueue.Dequeue();

            if (!neighbours.ContainsKey(vectorA))
                neighbours.Add(vectorA, []);

            if (!neighbours.ContainsKey(vectorB))
                neighbours.Add(vectorB, []);

            neighbours[vectorA].Add(vectorB);
            neighbours[vectorB].Add(vectorA);
        }

        var sums = new List<int>();
        var visited = new HashSet<int[]>();

        foreach (var startNode in vectors)
        {
            if (visited.Contains(startNode))
                continue;

            var stack = new Stack<int[]>();
            stack.Push(startNode);
            visited.Add(startNode);

            var sum = 0;
            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                if (!neighbours.TryGetValue(currentNode, out var neighbour))
                    break;

                sum++;
                
                foreach (var neighbor in neighbour)
                {
                    if (visited.Add(neighbor))
                        stack.Push(neighbor);
                }
            }

            sums.Add(sum);
        }

        return sums.OrderByDescending(s => s)
            .Take(3)
            .Select(s => (long)s)
            .Aggregate((x, y) => x * y);
    }

    public static long CalculateDistance(int[] vectorA, int[] vectorB)
    {
        long dx = vectorA[0] - vectorB[0];
        long dy = vectorA[1] - vectorB[1];
        long dz = vectorA[2] - vectorB[2];
    
        return dx * dx + dy * dy + dz * dz;
    }
}