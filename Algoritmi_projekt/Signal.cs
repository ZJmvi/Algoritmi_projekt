using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmi_projekt
{
    public class Signal
    {
        string[] Lines { get; }
        public Signal(string[] lines)
        {
            this.Lines = lines;
        }

        // Metoda, ki razčleni vrstico v dvojico seznamov objektov
        public List<(List<object> left, List<object> right)> ParsePairs(string[] lines)
        {
            List<(List<object>, List<object>)> pairs = new List<(List<object> left, List<object> right)>();
            
            // Zanka, ki iterira skozi vrstice v koraku po 3 (vrstica 1 je levi seznam, vrstica 2 desni seznam, vrstica 3 je prazna
            for (int i = 0; i < lines.Length; i += 3)
            {
                var left = ParsePacket(lines[i]);
                var right = ParsePacket(lines[i + 1]);

                // Zapis parov (tuplov) v seznam
                pairs.Add((left, right));
            }
            return pairs;
        }

        // Metoda, ki iz vrstice odstrani začetne in končne znake in vrne seznam objektov
        public List<object> ParsePacket(string line)
        {
            return ParseList(line.Trim());
        }

        //Metoda, ki razčleni niz
        public List<object> ParseList(string s)
        {
            // Inicializacija seznama objektov
            List<object> list = new List<object>();
            
            int i = 1;

            // Zanka, ki iterira skozi niz in izpusti prvi in zadnji znak v nizu, ki sta [ in ]
            while (i < s.Length - 1)
            {
                if (s[i] == '[')
                {
                    // Iskanje pripadajočega zaklepaja
                    int end = FindMatchingBracket(s, i);

                    // Zapis niza med [ in ] v seznam list
                    list.Add(ParseList(s.Substring(i, end - i + 1)));
                    i = end + 1;
                }
                else if (char.IsDigit(s[i]) || s[i] == '-')
                {
                    // Preverjanje, ali je trenutni znak številka
                    int start = i;

                    // Iteracija skozi niz do konca števila
                    while (i < s.Length && (char.IsDigit(s[i]) || s[i] == '-'))
                    {
                        i++;
                    }

                    // Pretvorba niza v število in zapis v seznam
                    list.Add(int.Parse(s.Substring(start, i - start)));
                }
                else
                {
                    i++;
                }
            }
            return list;
        }

        // Metoda za iskanje ustreznega zaklepaja
        public int FindMatchingBracket(string s, int start)
        {
            // Spremenljivka, ki beleži globino gnezdenja
            int depth = 0;

            // Zanka, ki vrne indeks, ko najde ustrezni zaklepaj
            for (int i = start; i < s.Length; i++)
            {
                if (s[i] == '[')
                    depth++;
                if (s[i] == ']')
                    depth--;
                if (depth == 0)
                    return i;
            }
            throw new ArgumentException("Ni ustreznega zaklepaja.");
        }

        // Metoda, ki vrne informacijo, ali sta seznama v pravilnem vrstnem redu
        public bool IsInRightOrder(List<object> left, List<object> right)
        {
            // Zanka, ki iterira skozi seznama do dolžine manjšega seznama
            for (int i = 0; i < Math.Min(left.Count, right.Count); i++)
            {
                // Preverjanje, ali sta elementa celi števili in ju primerja po velikosti
                if (left[i] is int leftInt && right[i] is int rightInt)
                {
                    if (leftInt < rightInt)
                        return true;
                    if (leftInt > rightInt)
                        return false;
                }
                else if (left[i] is List<object> leftList && right[i] is List<object> rightList)
                {
                    // Preverja, ali sta elementa na indeksu seznama in ju primerja
                    bool? result = CompareLists(leftList, rightList);

                    if (result.HasValue)
                        return result.Value;
                }
                else if (left[i] is int)
                {
                    // Preverja, ali je levi element število, desni pa seznam in ju primerja
                    bool? result = CompareLists(new List<object> { left[i] }, (List<object>)right[i]);
                    if (result.HasValue)
                        return result.Value;
                }
                else
                {
                    // Preveri, ali je levi element seznam, desni pa število in ju primerja
                    bool? result = CompareLists((List<object>)left[i], new List<object> { right[i] });
                    if (result.HasValue)
                        return result.Value;
                }
            }
            return left.Count < right.Count;
        }

        // Metoda za primerjavo seznamov
        static bool? CompareLists(List<object> left, List<object> right)
        {
            // Zanka, ki primerja seznama do dolžine najmanjšega seznama
            for (int i = 0; i < Math.Min(left.Count, right.Count); i++)
            {
                // Preverjanje, ali sta elementa celi števili in ju primerja po velikosti
                if (left[i] is int leftInt && right[i] is int rightInt)
                {
                    if (leftInt < rightInt)
                        return true;
                    if (leftInt > rightInt)
                        return false;
                }
                else if (left[i] is List<object> leftList && right[i] is List<object> rightList)
                {
                    // Preverjanje, ali sta oba elementa seznama in ju primerja
                    bool? result = CompareLists(leftList, rightList);
                    if (result.HasValue) return result.Value;
                }
                else if (left[i] is int)
                {
                    // Preverjanje, ali je levi element število, desni pa seznam in ju primerja
                    bool? result = CompareLists(new List<object> { left[i] }, (List<object>)right[i]);
                    if (result.HasValue)
                        return result.Value;
                }
                else
                {
                    // Preveri, ali je levi element seznam, desni pa število in ju primerja
                    bool? result = CompareLists((List<object>)left[i], new List<object> { right[i] });
                    if (result.HasValue)
                        return result.Value;
                }
            }
            if (left.Count != right.Count)
            {
                return left.Count < right.Count;
            }
            return null;
        }

        // Metoda, ki razčleni pakete
        public List<List<object>> ParsePackets(string[] lines)
        {
            // Inicializacija seznama seznamov objektov
            List<List<object>> packets = new List<List<object>>();

            // Iteracija čez vse vrstice
            foreach (string line in lines)
            {
                // Preverjanje, da vrstica ni prazna in dodajanje razčlenjene vrstice v seznam
                if (!string.IsNullOrWhiteSpace(line))
                {
                    packets.Add(ParsePacket(line));
                }
            }
            return packets;
        }

        // Metoda za primerjavo paketov
        public int ComparePackets(List<object> left, List<object> right)
        {
            // Zanka, ki primerja seznama do dolžine najmanjšega seznama
            for (int i = 0; i < Math.Min(left.Count, right.Count); i++)
            {
                // Preverjanje, ali sta elementa celi števili in ju primerja po velikosti
                if (left[i] is int leftInt && right[i] is int rightInt)
                {
                    if (leftInt < rightInt)
                        return -1;
                    if (leftInt > rightInt)
                        return 1;
                }
                else if (left[i] is List<object> leftList && right[i] is List<object> rightList)
                {
                    // Preverjanje, ali sta oba elementa seznama in ju primerja
                    int result = ComparePackets(leftList, rightList);
                    if (result != 0)
                        return result;
                }
                else if (left[i] is int)
                {
                    // Preverjanje, ali je levi element število, desni pa seznam in ju primerja
                    int result = ComparePackets(new List<object> { left[i] }, (List<object>)right[i]);
                    if (result != 0)
                        return result;
                }
                else
                {
                    // Preverjanje, ali je levi element seznam, desni pa število in ju primerja
                    int result = ComparePackets((List<object>)left[i], new List<object> { right[i] });
                    if (result != 0)
                        return result;
                }
            }

            // Primerjava dolžin seznamov
            return left.Count.CompareTo(right.Count);
        }

        // Metoda za primerjavo dveh seznamov objektov
        public bool IsEqual(List<object> left, List<object> right)
        {
            // Preverjanje dolžin seznamov
            if (left.Count != right.Count)
                return false;

            // Iteriranje skozi elemente obeh seznamov
            for (int i = 0; i < left.Count; i++)
            {
                // Preverjanje, ali sta oba elementa števili
                if (left[i] is int leftInt && right[i] is int rightInt)
                {
                    if (leftInt != rightInt)
                        return false;
                }
                else if (left[i] is List<object> leftList && right[i] is List<object> rightList)
                {
                    // Preverjanje, ali sta seznama enaka
                    if (!IsEqual(leftList, rightList))
                        return false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
