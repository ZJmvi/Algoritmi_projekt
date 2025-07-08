using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmi_projekt
{
    public class Boulders
    {
        string[] Lines { get; }

        public Boulders(string[] lines)
        {
            this.Lines = lines;
        }

        // Metoda za pripravo seznama kock
        public List<(int x, int y, int z)> CreateListOfCubes(string[] lines)
        {
            List<(int, int, int)> cubes = new List<(int x, int y, int z)>();
            
            // Pretvorba vrstic v koordinate kock
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                int x = int.Parse(parts[0]);
                int y = int.Parse(parts[1]);
                int z = int.Parse(parts[2]);

                // Dodajanje kock v seznam
                cubes.Add((x, y, z));
            }
            return cubes;
        }

        // Metoda za izračun površine vseh kock v seznamu
        public int CalculateSurfaceArea(List<(int x, int y, int z)> cubes)
        {
            // Definicija niza tuplov smeri v 3D prostoru
            (int, int, int)[] directions = new (int dx, int dy, int dz)[]
            {
                (1, 0, 0), (-1, 0, 0),
                (0, 1, 0), (0, -1, 0),
                (0, 0, 1), (0, 0, -1)
            };

            // Kreiranje množice kock
            HashSet<(int, int, int)> cubeSet = new HashSet<(int x, int y, int z)>(cubes);

            int surfaceArea = 0;

            // Iteracija skozi kocke v seznamu
            foreach (var cube in cubes)
            {
                int exposedSides = 6;

                // Štetje izpostavljenih strani
                foreach (var (dx, dy, dz) in directions)
                {
                    if (cubeSet.Contains((cube.x + dx, cube.y + dy, cube.z + dz)))
                    {
                        exposedSides--;
                    }
                }

                surfaceArea += exposedSides;
            }
            return surfaceArea;
        }

        // Metoda za izračun zunanje površine vseh kock v seznamu
        public int CalculateExteriorSurfaceArea(List<(int x, int y, int z)> cubes)
        {
            // Definicija niza tuplov smeri v 3D prostoru
            (int, int, int)[] directions = new (int dx, int dy, int dz)[]
            {
                (1, 0, 0), (-1, 0, 0),
                (0, 1, 0), (0, -1, 0),
                (0, 0, 1), (0, 0, -1)
            };

            // Kreiranje množice kock
            HashSet<(int, int, int)> cubeSet = new HashSet<(int x, int y, int z)>(cubes);

            HashSet<(int, int, int)> visited = new HashSet<(int x, int y, int z)>();
            Queue<(int, int, int)> queue = new Queue<(int x, int y, int z)>();

            // Inicializacija minimalnih in maksimalnih vrednosti
            int minX = int.MaxValue, minY = int.MaxValue, minZ = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue, maxZ = int.MinValue;

            // Iteracija skozi kocke v seznamu in posodobitev minimalnih in maksimalnih vrednosti
            foreach (var (x, y, z) in cubes)
            {
                minX = Math.Min(minX, x);
                minY = Math.Min(minY, y);
                minZ = Math.Min(minZ, z);
                maxX = Math.Max(maxX, x);
                maxY = Math.Max(maxY, y);
                maxZ = Math.Max(maxZ, z);
            }

            // Začetek iskanja po širini iz zunanje strani kapljic
            queue.Enqueue((minX - 1, minY - 1, minZ - 1));
            visited.Add((minX - 1, minY - 1, minZ - 1));

            int surfaceArea = 0;

            while (queue.Count > 0)
            {
                var (x, y, z) = queue.Dequeue();

                foreach (var (dx, dy, dz) in directions)
                {
                    int nx = x + dx;
                    int ny = y + dy;
                    int nz = z + dz;

                    if (cubeSet.Contains((nx, ny, nz)))
                    {
                        surfaceArea++;
                    }
                    else if (!visited.Contains((nx, ny, nz)) && nx >= minX - 1 && nx <= maxX + 1 && ny >= minY - 1 && ny <= maxY + 1 && nz >= minZ - 1 && nz <= maxZ + 1)
                    {
                        queue.Enqueue((nx, ny, nz));
                        visited.Add((nx, ny, nz));
                    }
                }
            }

            return surfaceArea;
        }
    }
}
