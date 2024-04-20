namespace Project;
public class DFSSolver
{
    public static void DFS(List<List<int>> adjacencyList, int startNode, HashSet<int> reachableNodes)
    {
        var n = adjacencyList.Count;
        var visited = new bool[n];

        var stack = new Stack<int>();
        stack.Push(startNode);

        while (stack.Count > 0)
        {
            var currentNode = stack.Pop();

            if (!visited[currentNode - 1])
            {
                reachableNodes.Add(currentNode); 
                visited[currentNode - 1] = true;

                foreach (var neighbor in adjacencyList[currentNode - 1])
                {
                    if (!visited[neighbor - 1])
                    {
                        stack.Push(neighbor);
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
            DFS(adjacencyList, i, reachableNodes);
            
            foreach (var node in reachableNodes)
            {
                reachabilityMatrix[i - 1, node - 1] = 1;
            }
        }

        return reachabilityMatrix;
    }
}