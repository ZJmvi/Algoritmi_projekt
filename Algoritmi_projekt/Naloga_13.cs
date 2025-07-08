using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmi_projekt
{
    public enum Naloga13
    {
        Naloga131 = 1,
        Naloga132 = 2
    }
    public class Naloga_13
    {
        public static void Naloga131()
        {
            // Pot do podatkov
            string dataPath = Program.GetPath("Input_naloga_13");

            // Branje podatkov iz txt datoteke 
            string[] lines = File.ReadAllLines(dataPath);

            // Kreiranje objekta
            Signal signal = new Signal(lines);

            // Kreiranje seznama, ki shranjuje dvojice seznamov objektov
            List<(List<object> left, List<object> right)> pairs = new List<(List<object> left, List<object> right)>();
            
            // Klicanje metode, ki razčleni vrstico v dvojico (tuple) seznamov objektov
            pairs = signal.ParsePairs(lines);

            int sum = 0;

            // Zanka, ki preverja ali sta levi in desni par v seznamu v pravilnem vrstnem redu
            for (int i = 0; i < pairs.Count; i++)
            {
                if (signal.IsInRightOrder(pairs[i].left, pairs[i].right))
                {
                    sum += (i + 1);
                }
            }

            // Izpis vsote parov v pravilnem vrstnem redu
            Console.WriteLine($"Vsota parov v pravilnem vrstnem redu: {sum}");
        }

        public static void Naloga132()
        {
            // Pot do podatkov
            string dataPath = Program.GetPath("Input_naloga_13");

            // Branje podatkov iz txt datoteke 
            string[] lines = File.ReadAllLines(dataPath);

            // Kreiranje objekta
            Signal signal = new Signal(lines);

            // Razčlenitev vrstic v seznam objektov
            List<List<object>> packets = signal.ParsePackets(lines);

            // Dodajanje divider paketov
            packets.Add(signal.ParsePacket("[[2]]"));
            packets.Add(signal.ParsePacket("[[6]]"));

            // Urejanje paketov
            packets.Sort(signal.ComparePackets);

            // Iskanje indeksov divider paketov
            int index2 = packets.FindIndex(p => signal.IsEqual(p, signal.ParsePacket("[[2]]"))) + 1;
            int index6 = packets.FindIndex(p => signal.IsEqual(p, signal.ParsePacket("[[6]]"))) + 1;

            // Izračun dekodirnega ključa
            int decoderKey = index2 * index6;

            Console.WriteLine($"Dekodirni ključ: {decoderKey}");
        }
    }
}
