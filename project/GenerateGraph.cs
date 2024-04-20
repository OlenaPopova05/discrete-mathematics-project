namespace Project;
public class GraphGenerator
{
    private static Random random = new Random();

    public static List<(int, int)> GenerateGraph(int n, double density)
    {
        var edges = new List<(int, int)>();

        var maxEdges = n * (n - 1) / 2;
        var targetEdges = (int)(density * maxEdges);

        for (var i = 1; i <= n; i++)
        {
            for (var j = i + 1; j <= n; j++)
            {
                if (random.NextDouble() < density && edges.Count < targetEdges)
                {
                    edges.Add((i, j));
                }
            }
        }

        return edges;
    }

    public static int[,] GenerateAdjacencyMatrix(List<(int, int)> edges, int n)
    {
        var adjacencyMatrix = new int[n, n];

        foreach (var edge in edges)
        {
            adjacencyMatrix[edge.Item1 - 1, edge.Item2 - 1] = 1;
            adjacencyMatrix[edge.Item2 - 1, edge.Item1 - 1] = 1; 
        }

        return adjacencyMatrix;
    }

    public static List<List<int>> GenerateAdjacencyList(List<(int, int)> edges, int n)
    {
        var adjacencyList = new List<List<int>>();

        for (var i = 0; i < n; i++)
        {
            adjacencyList.Add(new List<int>());
        }

        foreach (var edge in edges)
        {
            adjacencyList[edge.Item1 - 1].Add(edge.Item2);
            adjacencyList[edge.Item2 - 1].Add(edge.Item1); 
        }

        return adjacencyList;
    }
}