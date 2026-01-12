using System.Text.RegularExpressions;

namespace AoC2025;

public partial class Day10
{
    public static int Calculate(string input)
    {
        var total = 0;

        foreach (var line in input.Split("\n"))
        {
            var match = Pattern().Match(line.Trim());
            
            if (!match.Success) 
                continue;

            // 1. Parse the Target Set
            var targetStr = match.Groups[1].Value;
            var target = new HashSet<int>();
            for (var i = 0; i < targetStr.Length; i++)
            {
                if (targetStr[i] == '#')
                    target.Add(i);
            }

            // 2. Parse the Buttons
            var buttonsStr = match.Groups[2].Value;
            var buttons = buttonsStr.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(b => b.Trim('(', ')').Split(',')
                    .Select(int.Parse)
                    .ToHashSet())
                .ToList();

            // 3. Find the first combination that matches the target
            var foundForLine = false;
            for (var count = 1; count <= buttons.Count; count++)
            {
                foreach (var attempt in GetCombinations(buttons, count))
                {
                    var lights = new HashSet<int>();
                    foreach (var button in attempt)
                        lights.SymmetricExceptWith(button);

                    if (lights.SetEquals(target))
                    {
                        total += count;
                        foundForLine = true;
                        break;
                    }
                }

                if (foundForLine) break;
            }
        }

        return total;
    }

    private static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> list, int length)
    {
        if (length == 1) return list.Select(t => new[] { t });

        return list.SelectMany((t, i) =>
            GetCombinations(list.Skip(i + 1), length - 1)
                .Select(c => new[] { t }.Concat(c)));
    }

    [GeneratedRegex(@"^\[([.#]+)\] ([()\d, ]+) \{([\d,]+)\}$")]
    private static partial Regex Pattern();
}