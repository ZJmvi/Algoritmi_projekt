using RST2_Programiranje_Vaje;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using IOPath = System.IO.Path;

namespace Algoritmi_projekt
{
    public class Program
    {
        enum Sections
        {
            Naloga8 = 1,
            Naloga12 = 2,
            Naloga13 = 3,
            Naloga18 = 4
            
        }

        public static string GetPath(string naloga)
        {
            string exeFolder = AppContext.BaseDirectory;
            string dataFolder = IOPath.Combine(exeFolder, "DATA");
            string inputFolder = IOPath.Combine(dataFolder, naloga);
            //string fileName = "test.txt";
            string fileName = "input.txt";
            return IOPath.Combine(inputFolder, fileName);
        }

        public static void NextTry()
        {
            Console.Write("\n\n###########################################\n\nNaslednja naloga (d/n)? ");
            string next = Console.ReadLine();

            if (next == "d" || next == "D")
            {
                Menu();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public static void Menu()
        {
            Console.Clear();
            switch (InterfaceFunctions.ChooseSection<Sections>())
            {
                case Sections.Naloga8:
                    {
                        switch (InterfaceFunctions.ChooseSection<Naloga8>())
                        {
                            case Naloga8.Naloga81:
                                {
                                    string str = Naloga8.Naloga81.ToString();
                                    Choice(str);
                                    Naloga_8.Naloga81();
                                    NextTry();
                                }
                                break;
                            case Naloga8.Naloga82:
                                {
                                    string str = Naloga8.Naloga82.ToString();
                                    Choice(str);
                                    Naloga_8.Naloga82();
                                    NextTry();
                                }
                                break;
                        }
                        break;
                    }
                case Sections.Naloga12:
                    {
                        switch (InterfaceFunctions.ChooseSection<Naloga12>())
                        {
                            case Naloga12.Naloga121:
                                {
                                    string str = Naloga12.Naloga121.ToString();
                                    Choice(str);
                                    Naloga_12.Naloga121();
                                    NextTry();
                                }
                                break;
                            case Naloga12.Naloga122:
                                {
                                    string str = Naloga12.Naloga122.ToString();
                                    Choice(str);
                                    Naloga_12.Naloga122();
                                    NextTry();
                                }
                                break;
                        }
                        break;
                    }
                case Sections.Naloga13:
                    {
                        switch (InterfaceFunctions.ChooseSection<Naloga13>())
                        {
                            case Naloga13.Naloga131:
                                {
                                    string str = Naloga13.Naloga131.ToString();
                                    Choice(str);
                                    Naloga_13.Naloga131();
                                    NextTry();
                                }
                                break;
                            case Naloga13.Naloga132:
                                {
                                    string str = Naloga13.Naloga132.ToString();
                                    Choice(str);
                                    Naloga_13.Naloga132();
                                    NextTry();
                                }
                                break;
                        }
                        break;
                    }
                case Sections.Naloga18:
                    {
                        switch (InterfaceFunctions.ChooseSection<Naloga18>())
                        {
                            case Naloga18.Naloga181:
                                {
                                    string str = Naloga18.Naloga181.ToString();
                                    Choice(str);
                                    Naloga_18.Naloga181();
                                    NextTry();
                                }
                                break;
                            case Naloga18.Naloga182:
                                {
                                    string str = Naloga18.Naloga182.ToString();
                                    Choice(str);
                                    Naloga_18.Naloga182();
                                    NextTry();
                                }
                                break;
                        }
                        break;
                    }
                default:
                    {
                        Menu();
                        break;
                    }
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Choice(string input)
        {
            // Prikaz navodil za nalogo
            Console.Write("Navodila (d/n)? ");
            string choice = Console.ReadLine();

            if (choice != null)
            {
                if (choice == "d" || choice == "D")
                {
                    if (input == "Naloga81") Navodila8_1();
                    if (input == "Naloga82") Navodila8_2();
                    if (input == "Naloga121") Navodila12_1();
                    if (input == "Naloga122") Navodila12_2();
                    if (input == "Naloga131") Navodila13_1();
                    if (input == "Naloga132") Navodila13_2();
                    if (input == "Naloga181") Navodila18_1();
                    if (input == "Naloga182") Navodila18_2();
                }
            }
        }
        public static void Navodila8_1()
        {
            string str = @"The expedition comes across a peculiar patch of tall trees all planted carefully in a grid. The Elves explain that a previous expedition planted these trees as a reforestation effort. Now, they're curious if this would be a good location for a tree house.

First, determine whether there is enough tree cover here to keep a tree house hidden. To do this, you need to count the number of trees that are visible from outside the grid when looking directly along a row or column.

The Elves have already launched a quadcopter to generate a map with the height of each tree (your puzzle input). For example:

30373
25512
65332
33549
35390

Each tree is represented as a single digit whose value is its height, where 0 is the shortest and 9 is the tallest.

A tree is visible if all of the other trees between it and an edge of the grid are shorter than it. Only consider trees in the same row or column; that is, only look up, down, left, or right from any given tree.

All of the trees around the edge of the grid are visible - since they are already on the edge, there are no trees to block the view. In this example, that only leaves the interior nine trees to consider:

The top-left 5 is visible from the left and top. (It isn't visible from the right or bottom since other trees of height 5 are in the way.)
The top-middle 5 is visible from the top and right.
The top-right 1 is not visible from any direction; for it to be visible, there would need to only be trees of height 0 between it and an edge.
The left-middle 5 is visible, but only from the right.
The center 3 is not visible from any direction; for it to be visible, there would need to be only trees of at most height 2 between it and an edge.
The right-middle 3 is visible from the right.
In the bottom row, the middle 5 is visible, but the 3 and 4 are not.
With 16 trees visible on the edge and another 5 visible in the interior, a total of 21 trees are visible in this arrangement.

Consider your map; how many trees are visible from outside the grid?
";
            Console.WriteLine("\nDay 8: Treetop Tree House\nNAVODILA ZA NALOGO 8 - 1. del:\n");
            Console.WriteLine(str);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void Navodila8_2()
        {
            string str = @"Content with the amount of tree cover available, the Elves just need to know the best spot to build their tree house: they would like to be able to see a lot of trees.

To measure the viewing distance from a given tree, look up, down, left, and right from that tree; stop if you reach an edge or at the first tree that is the same height or taller than the tree under consideration. (If a tree is right on the edge, at least one of its viewing distances will be zero.)

The Elves don't care about distant trees taller than those found by the rules above; the proposed tree house has large eaves to keep it dry, so they wouldn't be able to see higher than the tree house anyway.

In the example above, consider the middle 5 in the second row:

30373
25512
65332
33549
35390

Looking up, its view is not blocked; it can see 1 tree (of height 3).
Looking left, its view is blocked immediately; it can see only 1 tree (of height 5, right next to it).
Looking right, its view is not blocked; it can see 2 trees.
Looking down, its view is blocked eventually; it can see 2 trees (one of height 3, then the tree of height 5 that blocks its view).
A tree's scenic score is found by multiplying together its viewing distance in each of the four directions. For this tree, this is 4 (found by multiplying 1 * 1 * 2 * 2).

However, you can do even better: consider the tree of height 5 in the middle of the fourth row:

30373
25512
65332
33549
35390

Looking up, its view is blocked at 2 trees (by another tree with a height of 5).
Looking left, its view is not blocked; it can see 2 trees.
Looking down, its view is also not blocked; it can see 1 tree.
Looking right, its view is blocked at 2 trees (by a massive tree of height 9).
This tree's scenic score is 8 (2 * 2 * 1 * 2); this is the ideal spot for the tree house.

Consider each tree on your map. What is the highest scenic score possible for any tree?
";
            Console.WriteLine("\nDay 8: Treetop Tree House\nNAVODILA ZA NALOGO 8 - 2. del:\n");
            Console.WriteLine(str);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void Navodila12_1()
        {
            string str = @"You try contacting the Elves using your handheld device, but the river you're following must be too low to get a decent signal.

You ask the device for a heightmap of the surrounding area (your puzzle input). The heightmap shows the local area from above broken into a grid; the elevation of each square of the grid is given by a single lowercase letter, where a is the lowest elevation, b is the next-lowest, and so on up to the highest elevation, z.

Also included on the heightmap are marks for your current position (S) and the location that should get the best signal (E). Your current position (S) has elevation a, and the location that should get the best signal (E) has elevation z.

You'd like to reach E, but to save energy, you should do it in as few steps as possible. During each step, you can move exactly one square up, down, left, or right. To avoid needing to get out your climbing gear, the elevation of the destination square can be at most one higher than the elevation of your current square; that is, if your current elevation is m, you could step to elevation n, but not to elevation o. (This also means that the elevation of the destination square can be much lower than the elevation of your current square.)

For example:

Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi

Here, you start in the top-left corner; your goal is near the middle. You could start by moving down or right, but eventually you'll need to head toward the e at the bottom. From there, you can spiral around to the goal:

v..v<<<<
>v.vv<<^
.>vv>E^^
..v>>>^^
..>>>>>^

In the above diagram, the symbols indicate whether the path exits each square moving up (^), down (v), left (<), or right (>). The location that should get the best signal is still E, and . marks unvisited squares.

This path reaches the goal in 31 steps, the fewest possible.

What is the fewest steps required to move from your current position to the location that should get the best signal?
";
            Console.WriteLine("\nDay 12: Hill Climbing Algorithm\nNAVODILA ZA NALOGO 12 - 1. del:\n");
            Console.WriteLine(str);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void Navodila12_2()
        {
            string str = @"As you walk up the hill, you suspect that the Elves will want to turn this into a hiking trail. The beginning isn't very scenic, though; perhaps you can find a better starting point.

To maximize exercise while hiking, the trail should start as low as possible: elevation a. The goal is still the square marked E. However, the trail should still be direct, taking the fewest steps to reach its goal. So, you'll need to find the shortest path from any square at elevation a to the square marked E.

Again consider the example from above:

Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi

Now, there are six choices for starting position (five marked a, plus the square marked S that counts as being at elevation a). If you start at the bottom-left square, you can reach the goal most quickly:

...v<<<<
...vv<<^
...v>E^^
.>v>>>^^
>^>>>>>^

This path reaches the goal in only 29 steps, the fewest possible.

What is the fewest steps required to move starting from any square with elevation a to the location that should get the best signal?
";
            Console.WriteLine("\nDay 12: Hill Climbing Algorithm\nNAVODILA ZA NALOGO 12 - 2. del:\n");
            Console.WriteLine(str);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void Navodila13_1()
        {
            string str = @"You climb the hill and again try contacting the Elves. However, you instead receive a signal you weren't expecting: a distress signal.

Your handheld device must still not be working properly; the packets from the distress signal got decoded out of order. You'll need to re-order the list of received packets (your puzzle input) to decode the message.

Your list consists of pairs of packets; pairs are separated by a blank line. You need to identify how many pairs of packets are in the right order.

For example:

[1,1,3,1,1]
[1,1,5,1,1]

[[1],[2,3,4]]
[[1],4]

[9]
[[8,7,6]]

[[4,4],4,4]
[[4,4],4,4,4]

[7,7,7,7]
[7,7,7]

[]
[3]

[[[]]]
[[]]

[1,[2,[3,[4,[5,6,7]]]],8,9]
[1,[2,[3,[4,[5,6,0]]]],8,9]
Packet data consists of lists and integers. Each list starts with [, ends with ], and contains zero or more comma-separated values (either integers or other lists). Each packet is always a list and appears on its own line.

When comparing two values, the first value is called left and the second value is called right. Then:

If both values are integers, the lower integer should come first. If the left integer is lower than the right integer, the inputs are in the right order. If the left integer is higher than the right integer, the inputs are not in the right order. Otherwise, the inputs are the same integer; continue checking the next part of the input.
If both values are lists, compare the first value of each list, then the second value, and so on. If the left list runs out of items first, the inputs are in the right order. If the right list runs out of items first, the inputs are not in the right order. If the lists are the same length and no comparison makes a decision about the order, continue checking the next part of the input.
If exactly one value is an integer, convert the integer to a list which contains that integer as its only value, then retry the comparison. For example, if comparing [0,0,0] and 2, convert the right value to [2] (a list containing 2); the result is then found by instead comparing [0,0,0] and [2].
Using these rules, you can determine which of the pairs in the example are in the right order:

== Pair 1 ==
- Compare [1,1,3,1,1] vs [1,1,5,1,1]
  - Compare 1 vs 1
  - Compare 1 vs 1
  - Compare 3 vs 5
    - Left side is smaller, so inputs are in the right order

== Pair 2 ==
- Compare [[1],[2,3,4]] vs [[1],4]
  - Compare [1] vs [1]
    - Compare 1 vs 1
  - Compare [2,3,4] vs 4
    - Mixed types; convert right to [4] and retry comparison
    - Compare [2,3,4] vs [4]
      - Compare 2 vs 4
        - Left side is smaller, so inputs are in the right order

== Pair 3 ==
- Compare [9] vs [[8,7,6]]
  - Compare 9 vs [8,7,6]
    - Mixed types; convert left to [9] and retry comparison
    - Compare [9] vs [8,7,6]
      - Compare 9 vs 8
        - Right side is smaller, so inputs are not in the right order

== Pair 4 ==
- Compare [[4,4],4,4] vs [[4,4],4,4,4]
  - Compare [4,4] vs [4,4]
    - Compare 4 vs 4
    - Compare 4 vs 4
  - Compare 4 vs 4
  - Compare 4 vs 4
  - Left side ran out of items, so inputs are in the right order

== Pair 5 ==
- Compare [7,7,7,7] vs [7,7,7]
  - Compare 7 vs 7
  - Compare 7 vs 7
  - Compare 7 vs 7
  - Right side ran out of items, so inputs are not in the right order

== Pair 6 ==
- Compare [] vs [3]
  - Left side ran out of items, so inputs are in the right order

== Pair 7 ==
- Compare [[[]]] vs [[]]
  - Compare [[]] vs []
    - Right side ran out of items, so inputs are not in the right order

== Pair 8 ==
- Compare [1,[2,[3,[4,[5,6,7]]]],8,9] vs [1,[2,[3,[4,[5,6,0]]]],8,9]
  - Compare 1 vs 1
  - Compare [2,[3,[4,[5,6,7]]]] vs [2,[3,[4,[5,6,0]]]]
    - Compare 2 vs 2
    - Compare [3,[4,[5,6,7]]] vs [3,[4,[5,6,0]]]
      - Compare 3 vs 3
      - Compare [4,[5,6,7]] vs [4,[5,6,0]]
        - Compare 4 vs 4
        - Compare [5,6,7] vs [5,6,0]
          - Compare 5 vs 5
          - Compare 6 vs 6
          - Compare 7 vs 0
            - Right side is smaller, so inputs are not in the right order
What are the indices of the pairs that are already in the right order? (The first pair has index 1, the second pair has index 2, and so on.) In the above example, the pairs in the right order are 1, 2, 4, and 6; the sum of these indices is 13.

Determine which pairs of packets are already in the right order. What is the sum of the indices of those pairs?
";
            Console.WriteLine("\nDay 13: Distress Signal\nNAVODILA ZA NALOGO 13 - 1. del:\n");
            Console.WriteLine(str);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void Navodila13_2()
        {
            string str = @"Now, you just need to put all of the packets in the right order. Disregard the blank lines in your list of received packets.

The distress signal protocol also requires that you include two additional divider packets:

[[2]]
[[6]]

Using the same rules as before, organize all packets - the ones in your list of received packets as well as the two divider packets - into the correct order.

For the example above, the result of putting the packets in the correct order is:

[]
[[]]
[[[]]]
[1,1,3,1,1]
[1,1,5,1,1]
[[1],[2,3,4]]
[1,[2,[3,[4,[5,6,0]]]],8,9]
[1,[2,[3,[4,[5,6,7]]]],8,9]
[[1],4]
[[2]]
[3]
[[4,4],4,4]
[[4,4],4,4,4]
[[6]]
[7,7,7]
[7,7,7,7]
[[8,7,6]]
[9]

Afterward, locate the divider packets. To find the decoder key for this distress signal, you need to determine the indices of the two divider packets and multiply them together. (The first packet is at index 1, the second packet is at index 2, and so on.) In this example, the divider packets are 10th and 14th, and so the decoder key is 140.

Organize all of the packets into the correct order. What is the decoder key for the distress signal?
";
            Console.WriteLine("\nDay 13: Distress Signal\nNAVODILA ZA NALOGO 13 - 2. del:\n");
            Console.WriteLine(str);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void Navodila18_1()
        {
            string str = @"You and the elephants finally reach fresh air. You've emerged near the base of a large volcano that seems to be actively erupting! Fortunately, the lava seems to be flowing away from you and toward the ocean.

Bits of lava are still being ejected toward you, so you're sheltering in the cavern exit a little longer. Outside the cave, you can see the lava landing in a pond and hear it loudly hissing as it solidifies.

Depending on the specific compounds in the lava and speed at which it cools, it might be forming obsidian! The cooling rate should be based on the surface area of the lava droplets, so you take a quick scan of a droplet as it flies past you (your puzzle input).

Because of how quickly the lava is moving, the scan isn't very good; its resolution is quite low and, as a result, it approximates the shape of the lava droplet with 1x1x1 cubes on a 3D grid, each given as its x,y,z position.

To approximate the surface area, count the number of sides of each cube that are not immediately connected to another cube. So, if your scan were only two adjacent cubes like 1,1,1 and 2,1,1, each cube would have a single side covered and five sides exposed, a total surface area of 10 sides.

Here's a larger example:

2,2,2
1,2,2
3,2,2
2,1,2
2,3,2
2,2,1
2,2,3
2,2,4
2,2,6
1,2,5
3,2,5
2,1,5
2,3,5

In the above example, after counting up all the sides that aren't connected to another cube, the total surface area is 64.

What is the surface area of your scanned lava droplet?
";
            Console.WriteLine("\nDay 18: Boiling Boulders\nNAVODILA ZA NALOGO 18 - 1. del:\n");
            Console.WriteLine(str);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void Navodila18_2()
        {
            string str = @"
";
            Console.WriteLine("\nDay 18: Boiling Boulders\nNAVODILA ZA NALOGO 18 - 2. del:\n");
            Console.WriteLine(str);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
