namespace Project;
public class Print
{
    public static void PrintMatrix(int[,] matrix, List<string> vertexNames, string matrixName)
    {
        var n = matrix.GetLength(0);
        var maxVertexNameLength = vertexNames.Max(name => name.Length);
        var matrixWidth = 4 * n + 1;
        Console.WriteLine($"\n{matrixName}");

        Console.Write("".PadRight(maxVertexNameLength + 2));
        foreach (var name in vertexNames)
        {
            Console.Write($" {name} ");
        }
        Console.WriteLine();

        Console.WriteLine("".PadRight(maxVertexNameLength + 2 + matrixWidth, '-'));

        for (var i = 0; i < n; i++)
        {
            Console.Write($"{vertexNames[i]} |");
            for (var j = 0; j < n; j++)
            {
                Console.Write($" {matrix[i, j]} |".PadLeft(3));
            }
            Console.WriteLine();
        }
    }

    public static void PrintAdjacencyList(List<List<int>> adjacencyList, List<string> vertexNames)
    {
        for (var i = 0; i < adjacencyList.Count; i++)
        {
            Console.Write($"{vertexNames[i]} = {{ ");
            var neighbors = adjacencyList[i];
            for (var j = 0; j < neighbors.Count; j++)
            {
                Console.Write($"{neighbors[j]}");
                if (j < neighbors.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" }");
        }
    }
}