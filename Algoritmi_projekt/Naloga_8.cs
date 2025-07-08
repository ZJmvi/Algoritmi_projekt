using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using static System.Collections.Specialized.BitVector32;


namespace Algoritmi_projekt
{
    public enum Naloga8
    {
        Naloga81 = 1,
        Naloga82 = 2
    }
    public class Naloga_8
    {
        public static void Naloga81()
        {
            // Pot do podatkov
            string dataPath = Program.GetPath("Input_naloga_8");

            // Branje podatkov iz txt datoteke 
            string[] lines = File.ReadAllLines(dataPath);

            // Kreiranje objekta
            Forrest forrest = new Forrest(lines);

            // Zapis podatkov v dvodimenzionalni array
            int[,] grid = forrest.GetGrid();

            // Določitev števila vrstic in stolpcev v mreži
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            // Preštevanje dreves na robovih
            int edgeTrees = (rows * 2) + (cols * 2) - 4;
            Console.WriteLine($"Edgetrees: {edgeTrees}\n");

            int visibleTrees = forrest.CountVisibleTrees(grid);
            visibleTrees = visibleTrees + edgeTrees;
            Console.WriteLine($"Število vidnih dreves: {visibleTrees}");
            
        }

        public static void Naloga82()
        {
            // Pot do podatkov
            string dataPath = Program.GetPath("Input_naloga_8");

            // Branje podatkov iz txt datoteke 
            string[] lines = File.ReadAllLines(dataPath);


            // Kreiranje objekta
            Forrest forrest = new Forrest(lines);

            // Zapis podatkov v dvodimenzionalni array
            int[,] grid = forrest.GetGrid();

            int scenicScore = forrest.CountScenicScore(grid);
            Console.WriteLine($"Scenic score = {scenicScore}");
        }
    }
}
