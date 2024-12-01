using System;
using System.Collections.Generic;

class Day1
{
    public static void Main()
    {
        Puzzle2();

    }

    static void Puzzle1(){
        string path = @"C:\MyProjects\AdventOfCode2024\Day1\PuzzleInput.txt";

        List<int> list1 = new();
        List<int> list2 = new();

        foreach (var line in File.ReadLines(path))
        {
            var split = line.Split("   ");

            list1.Add(Int32.Parse(split[0]));
            list2.Add(Int32.Parse(split[1]));
        }

        list1.Sort();
        list2.Sort();

        int sizeList1 = list1.Count();
        int sizeList2 = list1.Count();

        int TotalDistance = 0;

        if (sizeList1 == sizeList2){
            for (int i = 0; i < sizeList1; i++){
                int num1 = list1[i];
                int num2= list2[i];

                TotalDistance += Math.Abs(num1 - num2);
            }
            Console.WriteLine("The Total Distance between the two list is : " + TotalDistance);
        }
        else {
            Console.WriteLine("ERROR");
        }
    }


    static void Puzzle2(){
        string path = @"C:\MyProjects\AdventOfCode2024\Day1\PuzzleInput.txt";

        List<int> list1 = new();
        List<int> list2 = new();

        foreach (var line in File.ReadLines(path))
        {
            var split = line.Split("   ");

            list1.Add(Int32.Parse(split[0]));
            list2.Add(Int32.Parse(split[1]));
        }

        list1.Sort();
        list2.Sort();

        int sizeList1 = list1.Count();
        int sizeList2 = list1.Count();

        int totalSimilarityScore = 0;

        if (sizeList1 == sizeList2){

            for (int i = 0; i < sizeList1; i++){
                int num1 = list1[i];

                int similarityScore = num1 * list2.Count(n => n == num1);

                totalSimilarityScore += similarityScore;
            }
            Console.WriteLine("The Total Similarity between the two list is : " + totalSimilarityScore);
        }
        else {
            Console.WriteLine("ERROR");
        }
    }
}