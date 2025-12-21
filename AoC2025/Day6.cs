using System.Numerics;

namespace AoC2025;

public class Day6
{
    public static BigInteger SumOfAllOperations(int[,] numbers, char[] operations)
    {
        BigInteger sum = 0;
        foreach (var (index, operation) in operations.Index())
        {
            BigInteger operationSum = 0;
            if (operation == '*')
            {
                operationSum = 1;
                for (var i = 0; i < numbers.GetLength(0); i++)
                {
                    if (numbers[i, index] == 0)
                        continue;
                    
                    operationSum *= numbers[i, index];
                }
            }
            else if (operation == '+')
            {
                for (var i = 0; i < numbers.GetLength(0); i++)
                    operationSum += numbers[i, index];
            }

            sum += operationSum;
        }

        return sum;
    }
}