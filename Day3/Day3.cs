using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using Microsoft.Win32.SafeHandles;
using System.Text.RegularExpressions;

class Day2
{
    public static void Main()
    {
        Puzzle2();
    }

    static void Puzzle1(){

        string path = @"C:\MyProjects\AdventOfCode2024\Day3\PuzzleInput.txt";

        string input = File.ReadAllText(path);
        
        string pattern = @"mul\((\d+(,\d+)*)\)";
        MatchCollection matches = Regex.Matches(input, pattern);

        int uncorruptedMemory = 0;
        foreach (Match match in matches)
        {
            int[] isplit = Array.ConvertAll(match.Groups[1].Value.Split(','), Int32.Parse);
            uncorruptedMemory += isplit[0] * isplit[1];
        }
        
        Console.WriteLine("The add up of all uncorrupted mul instructions : " + uncorruptedMemory );

    }


    static void Puzzle2(){
                string path = @"C:\MyProjects\AdventOfCode2024\Day3\PuzzleInput.txt";

        string input = File.ReadAllText(path);
        
        string pattern = @"mul\((\d+(,\d+)*)\)|do\(\)|don't\(\)";
        MatchCollection matches = Regex.Matches(input, pattern);

        bool instruction = true;
        int uncorruptedMemory = 0;
        foreach (Match match in matches)
        {
            if (match.Groups[0].Value == "do()")
                instruction = true;
            
            else if (match.Groups[0].Value == "don't()")
                instruction = false;

            else if (instruction == true)
            {
                int[] isplit = Array.ConvertAll(match.Groups[1].Value.Split(','), Int32.Parse);
                uncorruptedMemory += isplit[0] * isplit[1];
            }
        }
        
        Console.WriteLine("The add up of all uncorrupted mul instructions : " + uncorruptedMemory );

    }
}