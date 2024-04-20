namespace Project;

public class BFSsolver
{
    public static void BFS(List<List<int>> adjacencyList, int startNode, HashSet<int> reachableNodes)
    {
        var n = adjacencyList.Count;
        var visited = new bool[n];

        var queue = new Queue<int>();
        queue.Enqueue(startNode);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            if (!visited[currentNode - 1])
            {
                reachableNodes.Add(currentNode);
                visited[currentNode - 1] = true;

                foreach (var neighbor in adjacencyList[currentNode - 1])
                {
                    if (!visited[neighbor - 1])
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }

    public static int[,] GenerateReachabilityMatrix(List<List<int>> adjacencyList, int vertices)
    {
        var reachabilityMatrix = new int[vertices, vertices];

        for (var i = 1; i <= vertices; i++)
        {
            var reachableNodes = new HashSet<int>();
            BFS(adjacencyList, i, reachableNodes);

            foreach (var node in reachableNodes)
            {
                reachabilityMatrix[i - 1, node - 1] = 1;
            }
        }

        return reachabilityMatrix;
    }
}