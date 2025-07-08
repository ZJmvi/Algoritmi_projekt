using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmi_projekt
{
    public enum Naloga18
    {
        Naloga181 = 1,
        Naloga182 = 2
    }
    public class Naloga_18
    {
        public static void Naloga181()
        {
            // Pot do podatkov
            string dataPath = Program.GetPath("Input_naloga_18");

            // Branje podatkov iz txt datoteke 
            string[] lines = File.ReadAllLines(dataPath);

            // Kreiranje objekta
            Boulders boulders = new Boulders(lines);

            // Izračun površine kapljice lave
            int surfaceArea = boulders.CalculateSurfaceArea(boulders.CreateListOfCubes(lines));
            Console.WriteLine($"Skupna površina: {surfaceArea}");
        }

        public static void Naloga182()
        {
            // Pot do podatkov
            string dataPath = Program.GetPath("Input_naloga_18");

            // Branje podatkov iz txt datoteke 
            string[] lines = File.ReadAllLines(dataPath);

            // Kreiranje objekta
            Boulders boulders = new Boulders(lines);

            // Izračun zunanje površine kapljice lave
            int exteriorSurfaceArea = boulders.CalculateExteriorSurfaceArea(boulders.CreateListOfCubes(lines));
            Console.WriteLine($"Skupna zunanja površina: {exteriorSurfaceArea}");
        }
    }
}
