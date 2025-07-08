using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmi_projekt
{
    public class Path
    {
        // Metoda za iskanje poti v mreži
        public int FindThePath(string[] lines)
        {
            // Število vrstic in stolpcev v zapisu
            int rows = lines.Length;
            int cols = lines[0].Length;

            char[,] grid = new char[rows, cols];

            // Inicializacija začetne in končne točke
            (int, int) start = (-1, -1);
            (int, int) end = (-1, -1);

            // Iskanje začetne in končne točke v mreži
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = lines[i][j];
                    if (grid[i, j] == 'S')
                    {
                        start = (i, j);

                        // Postavitev začetne točke na nivo 'a'
                        grid[i, j] = 'a';
                        Console.WriteLine($"Začetna točka: [{i},{j}]");
                    }
                    else if (grid[i, j] == 'E')
                    {
                        end = (i, j);

                        // Postavitev končne točke na nivo 'z'
                        grid[i, j] = 'z';
                    }
                }
            }

            // Določitev enodimenzionalnih tabel za premik po mreži
            int[] dRow = { -1, 1, 0, 0 };
            int[] dCol = { 0, 0, -1, 1 };

            // Inicializacija vrste za shranjevanje lokacij
            Queue<((int, int), int)> queue = new Queue<((int, int), int)>();
            bool[,] visited = new bool[rows, cols];
            queue.Enqueue((start, 0));
            visited[start.Item1, start.Item2] = true;

            // Premikanje po mreži
            while (queue.Count > 0)
            {
                var ((currentRow, currentCol), steps) = queue.Dequeue();

                // Preverjanje, ali je trenutna lokacija tudi končna lokacija
                if ((currentRow, currentCol) == end)
                {
                    Console.WriteLine($"Končna točka: [{currentRow},{currentCol}]");
                    return steps;
                }

                // Premik iz trenutne lokacije v vseh štirih smereh
                for (int i = 0; i < 4; i++)
                {

                    int newRow = currentRow + dRow[i];
                    int newCol = currentCol + dCol[i];

                    // Preverjanje veljavnosti premika v mreži in zapis v vrsto
                    if (IsValidMove(grid, visited, currentRow, currentCol, newRow, newCol, rows, cols))
                    {
                        queue.Enqueue(((newRow, newCol), steps + 1));
                        visited[newRow, newCol] = true;
                        Console.WriteLine($"Točka: [{newRow},{newCol}], korak: {steps + 1}");
                    }
                }
            }

            return -1;
        }

        // Metoda za preverjanje veljavnosti premika
        public bool IsValidMove(char[,] grid, bool[,] visited, int currentRow, int currentCol, int newRow, int newCol, int rows, int cols)
        {
            // Preverjanje, ali je nova lokacija izven mreže
            if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols)
            {
                return false;
            }

            // Preverjanje, ali je bila lokacija že obiskana
            if (visited[newRow, newCol])
            {
                return false;
            }

            // Izračun trenutne in nove višine
            int currentElevation = grid[currentRow, currentCol] - 'a';
            int newElevation = grid[newRow, newCol] - 'a';

            return newElevation <= currentElevation + 1;
        }

        // Metoda za iskanje najkrajše poti v mreži
        public int FindShortestPath(string[] lines)
        {
            // Število vrstic in stolpcev v zapisu
            int rows = lines.Length;
            int cols = lines[0].Length;

            char[,] grid = new char[rows, cols];

            // Inicializacija seznama začetnih lokacij
            List<(int, int)> startPositions = new List<(int, int)>();

            (int, int) end = (-1, -1);

            // Iskanje začetne in končne točke v mreži
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = lines[i][j];
                    if (grid[i, j] == 'S' || grid[i, j] == 'a')
                    {
                        startPositions.Add((i, j));
                        grid[i, j] = 'a'; // Lokacija 'S' je nastavljena na višino 'a'
                    }
                    else if (grid[i, j] == 'E')
                    {
                        end = (i, j); grid[i, j] = 'z'; // Lokacija 'E' je nastavljena na višino 'z'
                    }
                }
            }

            int fewestSteps = int.MaxValue;

            // Iskanje najkrajše poti iz poljubne lokacije
            foreach (var start in startPositions)
            {
                int steps = SearchingGrid(grid, start, end, rows, cols);
                if (steps != -1 && steps < fewestSteps)
                {
                    fewestSteps = steps;
                }
            }
            return fewestSteps;
        }

        // Metoda za pregled mreže
        public int SearchingGrid(char[,] grid, (int, int) start, (int, int) end, int rows, int cols)
        {
            // Določitev enodimenzionalnih tabel za premik po mreži
            int[] dRow = { -1, 1, 0, 0 };
            int[] dCol = { 0, 0, -1, 1 };

            // Inicializacija vrste za shranjevanje lokacij
            Queue<((int, int), int)> queue = new Queue<((int, int), int)>();
            bool[,] visited = new bool[rows, cols]; queue.Enqueue((start, 0));
            visited[start.Item1, start.Item2] = true;

            // Premikanje po mreži
            while (queue.Count > 0)
            {
                var ((currentRow, currentCol), steps) = queue.Dequeue();

                // Preverjanje, ali je trenutna lokacija tudi končna lokacija
                if ((currentRow, currentCol) == end)
                {
                    return steps;
                }

                // Premik iz trenutne lokacije v vseh štirih smereh
                for (int i = 0; i < 4; i++)
                {
                    int newRow = currentRow + dRow[i];
                    int newCol = currentCol + dCol[i];

                    // Preverjanje veljavnosti premika v mreži in zapis v vrsto
                    if (IsValidMove(grid, visited, currentRow, currentCol, newRow, newCol, rows, cols))
                    {
                        queue.Enqueue(((newRow, newCol), steps + 1));
                        visited[newRow, newCol] = true;
                    }
                }
            }
            return -1;
        }
    }
}
