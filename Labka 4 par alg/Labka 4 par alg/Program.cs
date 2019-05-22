using System;

class Program
{
    //алгоритм Дейкстри
    static void Dijkstra(int[][] GR, int st)
    {
        int V = GR.GetLength(0);
        int count, index = 0, i, u, m = st + 1;
        int[] distance = new int[V];
        bool[] visited = new bool[V];

        for (i = 0; i < V; i++)
        {
            distance[i] = int.MaxValue; visited[i] = false;
        }

        distance[st] = 0;

        for (count = 0; count < V - 1; count++)
        {
            int min = int.MaxValue;
            for (i = 0; i < V; i++)
                if (!visited[i] && distance[i] <= min)
                {
                    min = distance[i]; index = i;
                }
            u = index;
            visited[u] = true;
            for (i = 0; i < V; i++)
                if (!visited[i] && GR[u][i] != 0 && distance[u] != int.MaxValue &&
                    distance[u] + GR[u][i] < distance[i])
                    distance[i] = distance[u] + GR[u][i];
        }

        Console.WriteLine("Вiдстань (найменший шлях) вiд початкового мiста до остальних:\t\n");
        
        for (i = 0; i < V; i++) if (distance[i] != int.MaxValue)
                Console.WriteLine("{0} -> {1} = {2}", m, i + 1, distance[i]);
            else
                Console.WriteLine(@"{0} -> {1} = ""Маршрут не доступний", m, i + 1);
    }
    
    static void Main(string[] args)
    {


        int[][] GR = new int[6][] {
        new int[] { 0, 1, 4, 0, 2, 0 },
        new int[] { 0, 0, 0, 9, 0, 0 },
        new int[] { 4, 0, 0, 7, 0, 0 },
        new int[] { 0, 9, 7, 0, 0, 2 },
        new int[] { 0, 0, 0, 0, 0, 8 },
        new int[] { 0, 0, 0, 0, 0, 0 } };

        Console.WriteLine("Початкове мiсто (1 - 6): ");
        int start = int.Parse(Console.ReadLine());

        Dijkstra(GR, start - 1);
        Console.ReadKey();
    }
}