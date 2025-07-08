using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmi_projekt
{
    public enum Naloga12
    {
        Naloga121 = 1,
        Naloga122 = 2
    }
    public class Naloga_12
    {
        public static void Naloga121()
        {
            // Pot do podatkov
            string dataPath = Program.GetPath("Input_naloga_12");

            // Branje podatkov iz txt datoteke 
            string[] lines = File.ReadAllLines(dataPath);

            // Kreiranje objekta
            Path path = new Path();

            // Izpis najmanjšega števila korakov
            int steps = path.FindThePath(lines);
            Console.WriteLine($"Najmanjše število korakov: {steps}");
        }

        public static void Naloga122()
        {
            // Pot do podatkov
            string dataPath = Program.GetPath("Input_naloga_12");

            // Branje podatkov iz txt datoteke 

            string[] lines = File.ReadAllLines(dataPath);

            // Kreiranje objekta
            Path path = new Path();

            int steps = path.FindShortestPath(lines);
            Console.WriteLine($"Fewest steps required: {steps}");
        }
    }
}
