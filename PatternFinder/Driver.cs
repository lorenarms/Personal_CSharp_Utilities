//*******************************************************************
//* This program takes a text document as input
//* The text in the document is assumed to be random
//* lowercase letters in lines of equal length; each line
//* is stored in a string array as an individual string
//* to simulate rows of data in a picture file
//*
//* The user enters a pattern to search for in the 'picture'
//*
//* The pattern input can only be one line, but multiple lines can
//* make up the pattern if necessary (see code below for example)
//*
//* This program is a solution to a question on an interview tech
//* assessment I took when applying for a job as a software developer
//*******************************************************************




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PatternFinder
{
    class Driver
    {
        public static void Main(string[] args)
        {
            string[] str = 
                System.IO.File
                    .ReadAllLines(@"C:\Users\Lawrence\Git Repos\Personal_CSharp_Utilities\PatternFinder\pic.txt");

            // takes the pattern from a separate file with lines of text
            string[] pat =
                System.IO.File
                    .ReadAllLines(@"C:\Users\Lawrence\Git Repos\Personal_CSharp_Utilities\PatternFinder\pattern.txt");

            // sample patterns to search for; comment out each line one at a time to test
            //string[] pat = {"wql", "pzc", "bii"};
            //string[] pat = { "qe", "pk", "rk" };
            //string[] pat = { "cugwnr", "ykizxn"};
            //string[] pat = { "maizuqkgsflzwhejav"};

            // accept user input for a pattern to find; only one line can be searched for
            //WriteLine("Input a lowercase string to find: ");
            //string input = ReadLine();
            //string[] pat = { input };

            
            var newSet = new StringAndPattern(str, pat);
            newSet.DrawPictureAndPattern();
            
            int[] location = newSet.FindPattern();
            if (location[0] == -1)
            {
                WriteLine("Pattern not found.");
            }
            else
            {
                WriteLine("Pattern Found at row " + (location[0] + 1) + ", column " + (location[1] + 1));
                newSet.DrawPatternInPicture();
            }

            ReadKey();
        }
    }
}

