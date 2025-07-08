using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmi_projekt
{
    public class Forrest
    {
        public string[] Lines { get; }
        public int[,] Grid { get; }


        public Forrest(string[] lines)
        {
            this.Lines = lines;

            int rows = Lines.Length;
            int cols = Lines[0].Length;

            Grid = new int[rows, cols];
        }

        public int[,] GetGrid()
        {

            for (int i = 0; i < Lines.Length; i++)
            {
                for (int j = 0; j < Lines[0].Length; j++)
                {
                    Grid[i, j] = Lines[i][j] - '0';
                }
            }
            return Grid;
        }

        public int CountVisibleTrees(int[,] grid)
        {
            // Določitev števila vrstic in stolpcev v mreži
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            // Inicializacija števca vidnih dreves
            int countVisibleTrees = 0;


            for (int row = 1; row < rows - 1; row++)
            {
                for (int col = 1; col < cols - 1; col++)
                {
                    // Nastavitev trenutno najvišjega drevesa
                    int currentHeight = grid[row, col];

                    bool visible = true;

                    // Preverjanje iz leve
                    visible = VisibleFromLeft(grid, row, col, currentHeight);
                    if (visible == true)
                    {
                        Console.WriteLine($"Št.: {grid[row, col]}\tgrid[{row},{col}], vidna iz leve");
                        countVisibleTrees++;
                        continue;
                    }

                    // Preverjanje iz desne
                    visible = VisibleFromRight(grid, row, col, currentHeight);
                    if (visible == true)
                    {
                        Console.WriteLine($"Št.: {grid[row, col]}\tgrid[{row},{col}], vidna iz desne");
                        countVisibleTrees++;
                        continue;
                    }

                    // Preverjanje od zgoraj
                    visible = VisibleFromTop(grid, row, col, currentHeight);
                    if (visible == true)
                    {
                        Console.WriteLine($"Št.: {grid[row, col]}\tgrid[{row},{col}], vidna od zgoraj");
                        countVisibleTrees++;
                        continue;
                    }

                    // Preverjanje od spodaj
                    visible = VisibleFromBottom(grid, row, col, currentHeight);
                    if (visible == true)
                    {
                        Console.WriteLine($"Št.: {grid[row, col]}\tgrid[{row},{col}], vidna od spodaj");
                        countVisibleTrees++;
                    }
                }
            }

            // Vračanje števila vidnih dreves
            return countVisibleTrees;
        }

        // Metoda za pregled v levo
        public bool VisibleFromLeft(int[,] grid, int row, int col, int currentHeight)
        {
            bool visible = true;
            for (int i = col - 1; i >= 0; i--)
            {
                if (grid[row, i] >= currentHeight)
                {
                    visible = false;
                }

            }
            return visible;
        }

        // Metoda za pregled v desno
        public bool VisibleFromRight(int[,] grid, int row, int col, int currentHeight)
        {
            bool visible = true;
            for (int i = col + 1; i < grid.GetLength(0); i++)
            {
                if (grid[row, i] >= currentHeight)
                {
                    visible = false;
                }
            }
            return visible;
        }

        // Metoda za pregled navzgor
        public static bool VisibleFromTop(int[,] grid, int row, int col, int currentHeight)
        {
            bool visible = true;
            for (int i = row - 1; i >= 0; i--)
            {
                if (grid[i, col] >= currentHeight)
                {
                    visible = false;
                }
            }
            return visible;
        }

        // Metoda za pregled navzdol
        public bool VisibleFromBottom(int[,] grid, int row, int col, int currentHeight)
        {
            bool visible = true;
            for (int i = row + 1; i < grid.GetLength(0); i++)
            {
                if (grid[i, col] >= currentHeight)
                {
                    visible = false;
                }
            }
            return visible;
        }

        public int CountScenicScore(int[,] grid)
        {
            // Določitev števila vrstic in stolpcev v mreži
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            // Inicializacija števca vidnih dreves
            int scenicScore = 0;


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // Nastavitev trenutno najvišjega drevesa
                    int currentHeight = grid[row, col];

                    int left = 0;
                    int right = 0;
                    int up = 0;
                    int down = 0;

                    // Pregled v levo
                    for (int i = col - 1; i >= 0; i--)
                    {
                        left++;
                        if (grid[row, i] >= currentHeight)
                        {
                            break;
                        }
                    }

                    // Pregled v desno
                    for (int i = col + 1; i < grid.GetLength(0); i++)
                    {
                        right++;
                        if (grid[row, i] >= currentHeight)
                        {
                            break;
                        }
                    }

                    // Pregled navzgor
                    for (int i = row - 1; i >= 0; i--)
                    {
                        up++;
                        if (grid[i, col] >= currentHeight)
                        {
                            break;
                        }
                    }

                    // Pregled navzdol
                    for (int i = row + 1; i < grid.GetLength(0); i++)
                    {
                        down++;
                        if (grid[i, col] >= currentHeight)
                        {
                            break;
                        }
                    }

                    int score = left * right * up * down;

                    if (score > scenicScore)
                    {
                        scenicScore = score;
                    }
                }
            }

            // Vračanje števila vidnih dreves
            return scenicScore;
        }
    }
}
