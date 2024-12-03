using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using Microsoft.Win32.SafeHandles;

class Day2
{
    const bool decreasing = false;
    const bool increasing = true;

    static bool finished = false;
    static bool? direction = null;
    static int numberUnsafe = 0;

    public static void Main()
    {
        Puzzle2();
    }

    static void Puzzle1(){
        string path = @"C:\MyProjects\AdventOfCode2024\Day2\PuzzleInput.txt";

        List<int> list1 = new();
        int numberUnsafe = 0;
        int numberLines = 0;

        foreach (var line in File.ReadLines(path))
        {
            numberLines++;
            bool finished = false;
            bool? direction = null;
            string[] split = line.Split(" ");
            int[] isplit = Array.ConvertAll(split, Int32.Parse);

            for(int i = 0; i < isplit.Count() - 1; i++ )
            {
                int subAbs = Math.Abs(isplit[i] - isplit[i+1]);
                int sub = isplit[i] - isplit[i+1];

                if ( subAbs < 4 && subAbs > 0  && finished != true)
                {
                    if (sub < 0 && direction == false)
                    {
                        numberUnsafe++;
                        finished = true;
                        
                    }
                    else if (sub > 0 && direction == true)
                    {
                        numberUnsafe++;
                        finished = true;
                    }
                    else if (sub > 0)
                    {
                        direction = decreasing;
                    }
                    else {
                        direction = increasing;
                    }
                }
                else if ( (subAbs > 3 || subAbs == 0 )  && finished != true)
                {
                    numberUnsafe++;
                    finished = true;
                }
            }

        }

        Console.WriteLine("The Total unsafe reports is : " + (numberLines - numberUnsafe));

    }


    static void Puzzle2(){
        string path = @"C:\MyProjects\AdventOfCode2024\Day2\PuzzleInput.txt";

        List<int> list1 = new();
        
        int numberLines = 0;

        foreach (var line in File.ReadLines(path))
        {
            numberLines++;

            string[] split = line.Split(" ");
            List<int> isplit = Array.ConvertAll(split, Int32.Parse).ToList();

            finished = false;
            direction = null;

            
            tryRecord(isplit);
            
            if (finished == true)
            {
                if (!reTryRecord(isplit))
                    numberUnsafe++;
            } 
            

        }

        Console.WriteLine("The Total unsafe reports is : " + (numberLines - numberUnsafe));

    }

    static bool reTryRecord(List<int> isplit)
    {
        bool safe = false;
        int i = 0;


        while(safe == false && i < isplit.Count())
        {
            List<int> temp = new List<int>(isplit);;
            temp.RemoveAt(i);
            finished = false;
            direction = null;

            for(int y = 0; y < temp.Count() - 1; y++ )
            {
                int subAbs = Math.Abs(temp[y] - temp[y+1]);
                int sub = temp[y] - temp[y+1];

                if ( subAbs < 4 && subAbs > 0  && finished != true)
                {
                    if (sub < 0 && direction == false)
                    {
                        finished = true;
                        
                    }
                    else if (sub > 0 && direction == true)
                    {
                        finished = true;
                    }
                    else if (sub > 0)
                    {
                        direction = decreasing;
                    }
                    else {
                        direction = increasing;
                    }
                }
                else if ( (subAbs > 3 || subAbs == 0 )  && finished != true)
                {
                    finished = true;
                }

                if (y == (temp.Count() - 2) && finished == false)
                    safe = true; 
            }
            i++;
        } 
        return safe;    
    }

    static bool tryRecord(List<int> isplit)
    {
        for(int i = 0; i < isplit.Count() - 1; i++ )
        {
            int subAbs = Math.Abs(isplit[i] - isplit[i+1]);
            int sub = isplit[i] - isplit[i+1];

            if ( subAbs < 4 && subAbs > 0  && finished != true)
            {
                if (sub < 0 && direction == false)
                {
                    return finished = true;
                    
                }
                else if (sub > 0 && direction == true)
                {
                    return finished = true;
                }
                else if (sub > 0)
                {
                    direction = decreasing;
                }
                else {
                    direction = increasing;
                }
            }
            else if ( (subAbs > 3 || subAbs == 0 )  && finished != true)
            {
                return finished = true;
            }
        }
        return finished;
    }
}