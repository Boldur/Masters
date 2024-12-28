using System.Collections;
using System.ComponentModel;


namespace SerchAlgorthmsPrototypes
{
    internal class TreeSearch
    {
        private static Queue<Node> OpenSetBFS;
        private static Queue<Node> ClosedSetBFS;
        private static Stack<Node> OpenSetDFS;
        private static Stack<Node> ClosedSetDFS;
        private static PriorityQueue<Node, int> OpenSetUFS;
        private static PriorityQueue<Node, int> ClosedSetUFS;
        private HashSet<(int, int)> Visited;
        private Node StartNode;
        private (int, int) GoalCoordinates;
        public int[,] updatedMap;
        public List<Node> path;

        public TreeSearch((int, int) startCoordinates, (int, int) goalCoordinates, int[,] Map)
        {   
            OpenSetBFS = new Queue<Node> ();
            ClosedSetBFS = new Queue<Node> ();
            OpenSetDFS = new Stack<Node> ();
            ClosedSetDFS = new Stack<Node> ();
            OpenSetUFS = new PriorityQueue<Node, int>();
            ClosedSetUFS = new PriorityQueue<Node, int>();
            StartNode = new Node(startCoordinates, 0);
            Visited = new HashSet<(int, int)>() { (StartNode.State.Item1, StartNode.State.Item2) };
            GoalCoordinates = goalCoordinates;
            OpenSetBFS.Enqueue(StartNode);
            OpenSetDFS.Push(StartNode);
            OpenSetUFS.Enqueue(StartNode, StartNode.Cost);

            updatedMap = Map;
            path = new List<Node>();
        }

        public List<Node> DFS(int[,] map, bool includeDiagonalMovement)
        {
            while (OpenSetDFS.Count > 0)
            {
                (int, int) Cordinates;
                Node currentNode = OpenSetDFS.Pop();
                ClosedSetDFS.Push(currentNode);
                if (map[currentNode.State.Item1, currentNode.State.Item2] != 1 && map[currentNode.State.Item1, currentNode.State.Item2] != 2)
                {
                    updatedMap[currentNode.State.Item1, currentNode.State.Item2] = 3;
                }

                if (currentNode.State == GoalCoordinates)
                {
                    Node nodePath = currentNode;
                    while (nodePath.Parent != null)
                    {
                        path.Insert(0, nodePath);
                        if (map[nodePath.State.Item1, nodePath.State.Item2] != 1 && map[nodePath.State.Item1, nodePath.State.Item2] != 2)
                        {
                            updatedMap[nodePath.State.Item1, nodePath.State.Item2] = 4;
                        }
                        nodePath = nodePath.Parent;
                    }
                    return path;
                }

                Cordinates = (currentNode.State.Item1 - 1, currentNode.State.Item2); // up
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    Node nextNode = new Node(Cordinates, currentNode);
                    OpenSetDFS.Push(nextNode);
                }
                if (includeDiagonalMovement)// up-Right
                {
                    Cordinates = (currentNode.State.Item1 - 1, currentNode.State.Item2 + 1);
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Node nextNode = new Node(Cordinates, currentNode);
                        OpenSetDFS.Push(nextNode);
                        Visited.Add(Cordinates);
                    }
                }
                Cordinates = (currentNode.State.Item1, currentNode.State.Item2 + 1); // right
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    Node nextNode = new Node(Cordinates, currentNode);
                    OpenSetDFS.Push(nextNode);
                }
                if (includeDiagonalMovement)// Right-Down
                {
                    Cordinates = (currentNode.State.Item1 + 1, currentNode.State.Item2 + 1);
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Node nextNode = new Node(Cordinates, currentNode);
                        OpenSetDFS.Push(nextNode);
                        Visited.Add(Cordinates);
                    }
                }
                Cordinates = (currentNode.State.Item1 + 1, currentNode.State.Item2); // down
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    Node nextNode = new Node(Cordinates, currentNode);
                    Visited.Add(Cordinates);
                }
                if (includeDiagonalMovement)// Down-Left
                {
                    Cordinates = (currentNode.State.Item1 + 1, currentNode.State.Item2 - 1);
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Node nextNode = new Node(Cordinates, currentNode);
                        OpenSetDFS.Push(nextNode);
                        Visited.Add(Cordinates);
                    }
                }
                Cordinates = (currentNode.State.Item1, currentNode.State.Item2 - 1); // left
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    Node nextNode = new Node(Cordinates, currentNode);
                    OpenSetDFS.Push(nextNode);
                }
                if (includeDiagonalMovement)// Left-Up
                {
                    Cordinates = (currentNode.State.Item1 - 1, currentNode.State.Item2 - 1);
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Node nextNode = new Node(Cordinates, currentNode);
                        OpenSetDFS.Push(nextNode);
                        Visited.Add(Cordinates);
                    }
                }
            }
                return null;
        }

        public List<Node> BFS(int[,] map, bool includeDiagonalMovement)
        {
            while (OpenSetBFS.Count > 0)
            {
                (int, int) Cordinates;
                Node currentNode = OpenSetBFS.Peek();
                OpenSetBFS.Dequeue();
                ClosedSetBFS.Enqueue(currentNode);
                if (map[currentNode.State.Item1, currentNode.State.Item2] != 1 && map[currentNode.State.Item1, currentNode.State.Item2] != 2)
                {
                    updatedMap[currentNode.State.Item1, currentNode.State.Item2] = 3;
                }

                if (currentNode.State == GoalCoordinates)
                {
                    Node nodePath = currentNode;
                    while (nodePath != null)
                    {
                        path.Insert(0, nodePath);
                        if (map[nodePath.State.Item1, nodePath.State.Item2] != 1 &&
                            map[nodePath.State.Item1, nodePath.State.Item2] != 2)
                        {
                            updatedMap[nodePath.State.Item1, nodePath.State.Item2] = 4;
                        }
                        nodePath = nodePath.Parent;
                    }
                    return path;
                }

                Cordinates = (currentNode.State.Item1 - 1, currentNode.State.Item2); // up
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    Node nextNode = new Node(Cordinates, currentNode);
                    OpenSetBFS.Enqueue(nextNode);
                    updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                }
                if (includeDiagonalMovement)// up-Right
                {
                    Cordinates = (currentNode.State.Item1 - 1, currentNode.State.Item2 +1); 
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Visited.Add(Cordinates);
                        Node nextNode = new Node(Cordinates, currentNode);
                        OpenSetBFS.Enqueue(nextNode);
                        updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                    }
                }
                Cordinates = (currentNode.State.Item1, currentNode.State.Item2 + 1); // right
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    Node nextNode = new Node(Cordinates, currentNode);
                    OpenSetBFS.Enqueue(nextNode);
                    updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                }
                if (includeDiagonalMovement)// Right-Down
                {
                    Cordinates = (currentNode.State.Item1 + 1, currentNode.State.Item2 + 1);
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Visited.Add(Cordinates);
                        Node nextNode = new Node(Cordinates, currentNode);
                        OpenSetBFS.Enqueue(nextNode);
                        updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                    }
                }
                Cordinates = (currentNode.State.Item1 + 1, currentNode.State.Item2); // down
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    Node nextNode = new Node(Cordinates, currentNode);
                    OpenSetBFS.Enqueue(nextNode);
                    updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                }
                if (includeDiagonalMovement)// Down-Left
                {
                    Cordinates = (currentNode.State.Item1 + 1, currentNode.State.Item2 - 1);
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Visited.Add(Cordinates);
                        Node nextNode = new Node(Cordinates, currentNode);
                        OpenSetBFS.Enqueue(nextNode);
                        updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                    }
                }
                Cordinates = (currentNode.State.Item1, currentNode.State.Item2 - 1); // left
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    Node nextNode = new Node(Cordinates, currentNode);
                    OpenSetBFS.Enqueue(nextNode);
                    updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                }
                if (includeDiagonalMovement)// Left-Up
                {
                    Cordinates = (currentNode.State.Item1 - 1, currentNode.State.Item2 - 1);
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Visited.Add(Cordinates);
                        Node nextNode = new Node(Cordinates, currentNode);
                        OpenSetBFS.Enqueue(nextNode);
                        updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                    }
                }

            }
            return null;
        }

        public List<Node> UFS(int[,] map, bool includeDiagonalMovement)
        {
            double diagonalCost = Math.Sqrt(2);

            while (OpenSetUFS.Count > 0)
            {
                (int, int) Cordinates;
                int newCost = 0;
                Node currentNode = OpenSetUFS.Dequeue();
                ClosedSetUFS.Enqueue(currentNode, currentNode.Cost);
                if (map[currentNode.State.Item1, currentNode.State.Item2] != 1 && map[currentNode.State.Item1, currentNode.State.Item2] != 2)
                {
                    updatedMap[currentNode.State.Item1, currentNode.State.Item2] = 3;
                }
                if (currentNode.State == GoalCoordinates)
                {
                    Node nodePath = currentNode;
                    while (nodePath != null)
                    {
                        path.Insert(0, nodePath);
                        if (map[nodePath.State.Item1, nodePath.State.Item2] != 1 &&
                            map[nodePath.State.Item1, nodePath.State.Item2] != 2)
                        {
                            updatedMap[nodePath.State.Item1, nodePath.State.Item2] = 4;
                        }
                        nodePath = nodePath.Parent;
                    }
                    return path;
                }
                Cordinates = (currentNode.State.Item1 - 1, currentNode.State.Item2); // up
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    newCost = currentNode.Cost + 1;
                    Node nextNode = new Node(Cordinates, newCost, currentNode);
                    OpenSetUFS.Enqueue(nextNode, nextNode.Cost);
                    updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                }
                if (includeDiagonalMovement)// up-Right
                {
                    Cordinates = (currentNode.State.Item1 - 1, currentNode.State.Item2 + 1);
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Visited.Add(Cordinates);
                        newCost = currentNode.Cost + (int)diagonalCost;
                        Node nextNode = new Node(Cordinates, newCost, currentNode);
                        OpenSetUFS.Enqueue(nextNode, nextNode.Cost);
                        updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                    }
                }
                Cordinates = (currentNode.State.Item1, currentNode.State.Item2 + 1); // right
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    newCost = currentNode.Cost + 1;
                    Node nextNode = new Node(Cordinates, newCost, currentNode);
                    OpenSetUFS.Enqueue(nextNode, nextNode.Cost);
                    updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                }
                if (includeDiagonalMovement)// Right-Down
                {
                    Cordinates = (currentNode.State.Item1 + 1, currentNode.State.Item2 + 1);
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Visited.Add(Cordinates);
                        newCost = currentNode.Cost + (int)diagonalCost;
                        Node nextNode = new Node(Cordinates, newCost, currentNode);
                        OpenSetUFS.Enqueue(nextNode, nextNode.Cost);
                        updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                    }
                }
                Cordinates = (currentNode.State.Item1 + 1, currentNode.State.Item2); // down
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    newCost = currentNode.Cost + 1;
                    Node nextNode = new Node(Cordinates, newCost, currentNode);
                    OpenSetUFS.Enqueue(nextNode, nextNode.Cost);
                    updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                }
                if (includeDiagonalMovement)// Down-Left
                {
                    Cordinates = (currentNode.State.Item1 + 1, currentNode.State.Item2 - 1);
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Visited.Add(Cordinates);
                        newCost = currentNode.Cost + (int)diagonalCost;
                        Node nextNode = new Node(Cordinates, newCost, currentNode);
                        OpenSetUFS.Enqueue(nextNode, nextNode.Cost);
                        updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                    }
                }
                Cordinates = (currentNode.State.Item1, currentNode.State.Item2 - 1); // left
                if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                {
                    Visited.Add(Cordinates);
                    newCost = currentNode.Cost + 1;
                    Node nextNode = new Node(Cordinates, newCost, currentNode);
                    OpenSetUFS.Enqueue(nextNode, nextNode.Cost);
                    updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                }
                if (includeDiagonalMovement)// Left-Up
                {
                    Cordinates = (currentNode.State.Item1 - 1, currentNode.State.Item2 - 1);
                    if ((map[Cordinates.Item1, Cordinates.Item2] == 0 || map[Cordinates.Item1, Cordinates.Item2] == 2) && !Visited.Contains(Cordinates))
                    {
                        Visited.Add(Cordinates);
                        newCost = currentNode.Cost + (int)diagonalCost;
                        Node nextNode = new Node(Cordinates, newCost, currentNode);
                        OpenSetUFS.Enqueue(nextNode, nextNode.Cost);
                        updatedMap[nextNode.State.Item1, nextNode.State.Item2] = 5;
                    }
                }
            }
                return null;
        }
    }
}
