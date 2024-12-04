using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using Microsoft.Win32.SafeHandles;
using System.Text.RegularExpressions;

class Day4
{
    public static void Main()
    {
        Puzzle1();
    }

    static void Puzzle1(){

        string path = @"C:\MyProjects\AdventOfCode2024\Day4\PuzzleInput.txt";

        List<List<string>> table = new List<List<string>>();

        foreach(var line in File.ReadAllLines(path)){
            table.Add(line.Select(c => c.ToString()).ToList());
        }

        int XmasAppear = 0;
        int row = 0;
        foreach (List<string> rows in table)
        {
            int col = 0;
            foreach (string cell in rows)
            {
                if (cell == "X")
                {
                    string left = col > 0 ? table[row][col - 1] : "N/A";
                    string right = col < table[row].Count - 1 ? table[row][col + 1] : "N/A";
                    string up = row > 0 ? table[row - 1][col] : "N/A";
                    string down = row < table.Count - 1 ? table[row + 1][col] : "N/A";
                    string upLeft =  (row > 0 && col > 0) ? table[row - 1][col - 1] : "N/A";
                    string upRight =  (row > 0 && col < table[row].Count - 1) ? table[row - 1][col + 1] : "N/A";
                    string downLeft = (row < table.Count - 1 && col > 0) ? table[row + 1][col - 1] : "N/A";
                    string downRight = (row < table.Count - 1 && col < table[row].Count - 1) ? table[row + 1][col + 1] : "N/A";

                    if (left == "M")
                    {
                        left = col > 1 ? table[row][col - 2] : "N/A";
                        if (left == "A")
                        {
                            left = col > 2 ? table[row][col - 3] : "N/A";
                            if (left == "S")
                            {
                                XmasAppear++;
                            }
                        }
                    }
                    
                    if (right == "M") 
                    {
                        right = col < table[row].Count - 2 ? table[row][col + 2] : "N/A";
                        if (right == "A")
                        {
                            right = col < table[row].Count - 3 ? table[row][col + 3] : "N/A";
                            if (right == "S")
                            {
                                XmasAppear++;
                            }
                        }
                    }
                    
                    if (up == "M") 
                    {
                        up = row > 1 ? table[row - 2][col] : "N/A";
                        if (up == "A")
                        {
                            up = row > 2 ? table[row - 3][col] : "N/A";
                            if (up == "S")
                            {
                                XmasAppear++;
                            }
                        }
                    }
                    
                    if (down == "M")
                    {
                        down = row < table.Count - 2 ? table[row + 2][col] : "N/A";
                        if (down == "A")
                        {
                            down = row < table.Count - 3 ? table[row + 3][col] : "N/A";
                            if (down == "S")
                            {
                                XmasAppear++;
                            }
                        }    
                    }

                    if (upLeft == "M")
                    {
                        upLeft = (row > 1 && col > 1) ? table[row - 2][col - 2] : "N/A";
                        if (upLeft == "A")
                        {
                            upLeft = (row > 2 && col > 2) ? table[row - 3][col - 3] : "N/A";
                            if (upLeft == "S")
                            {
                                XmasAppear++;
                            }
                        }
                    }

                    if (upRight == "M")
                    {
                        upRight = (row > 1 && col < table[row].Count - 2) ? table[row - 2][col + 2] : "N/A";
                        if (upRight == "A")
                        {
                            upRight = (row > 2 && col < table[row].Count - 3) ? table[row - 3][col + 3] : "N/A";
                            if (upRight == "S")
                            {
                                XmasAppear++;
                            }
                        }
                    }
                    
                    if (downLeft == "M")
                    {
                        downLeft = (row < table.Count - 2 && col > 1) ? table[row + 2][col - 2] : "N/A";
                        if (downLeft == "A")
                        {
                            downLeft = (row < table.Count - 3 && col > 2) ? table[row + 3][col - 3] : "N/A";
                            if (downLeft == "S")
                            {
                                XmasAppear++;
                            }
                        }
                    }

                    if (downRight == "M")
                    {
                        downRight = (row < table.Count - 2 && col < table[row].Count - 2) ? table[row + 2][col + 2] : "N/A";
                        if (downRight == "A")
                        {
                            downRight = (row < table.Count - 3 && col < table[row].Count - 3) ? table[row + 3][col + 3] : "N/A";
                            if (downRight == "S")
                            {
                                XmasAppear++;
                            }
                        }
                    }
                }
                col++;
            }
            row++;
        }

        Console.WriteLine("How many times does XMAS appear? : " + XmasAppear );
    }


    static void Puzzle2(){

        string path = @"C:\MyProjects\AdventOfCode2024\Day4\PuzzleInput.txt";

        List<List<string>> table = new List<List<string>>();

        foreach(var line in File.ReadAllLines(path)){
            table.Add(line.Select(c => c.ToString()).ToList());
        }

        int XmasAppear = 0;

        int row = 0;
        foreach (List<string> rows in table)
        {
            int col = 0;
            foreach (string cell in rows)
            {
                if (cell == "A")
                {
                    string upLeft =  (row > 0 && col > 0) ? table[row - 1][col - 1] : "N/A";
                    string upRight =  (row > 0 && col < table[row].Count - 1) ? table[row - 1][col + 1] : "N/A";
                    string downLeft = (row < table.Count - 1 && col > 0) ? table[row + 1][col - 1] : "N/A";
                    string downRight = (row < table.Count - 1 && col < table[row].Count - 1) ? table[row + 1][col + 1] : "N/A";

                    if (upLeft == "M" && upRight == "S") 
                    {
                        if (downLeft == "M" && downRight == "S")
                        {
                            XmasAppear++;
                        }
                    }
                    else if (upLeft == "S" && upRight == "M") 
                    {
                        if (downLeft == "S" && downRight == "M")
                        {
                            XmasAppear++;
                        }
                    }
                    else if (upLeft == "S" && upRight == "S") 
                    {
                        if (downLeft == "M" && downRight == "M")
                        {
                            XmasAppear++;
                        }
                    }
                    else if (upLeft == "M" && upRight == "M") 
                    {
                        if (downLeft == "S" && downRight == "S")
                        {
                            XmasAppear++;
                        }
                    }
                }
                col++;
            }
            row++;
        }

        Console.WriteLine("How many times does X-MAS appear? : " + XmasAppear );

    }
}