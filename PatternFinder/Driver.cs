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
        //public static void DrawPicture(string[] str, string[] pat)
        //{
        //    WriteLine("PICTURE:");
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        for (int j = 0; j < str[0].Length; j++)
        //        {
        //            Write(str[i][j]);
        //        }
        //        Write("\n");
        //    }

        //    WriteLine("\nPATTERN TO FIND:");
        //    for (int i = 0; i < pat.Length; i++)
        //    {
        //        for (int j = 0; j < pat[0].Length; j++)
        //        {
        //            Write(pat[i][j]);
        //        }
        //        Write("\n");
        //    }
        //    WriteLine();
        //}

        //public static void PrintFinalPicture(string[] str, string[] pat, int[] location)
        //{
        //    int patLength = pat.Length;
        //    int patHeight = pat[0].Length;
        //    int patRow = location[0];

        //    WriteLine("LOCATION:");
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        for (int j = 0; j < str[0].Length; j++)
        //        {
        //            if (i == location[0] && j == location[1])
        //            {
        //                ForegroundColor = ConsoleColor.Red;
        //                //Write(str[i][j]);
        //                int k = 0;
        //                while (k < pat[0].Length)
        //                {
        //                    Write(str[i][j]);
        //                    k++;
        //                    j++;
        //                }

        //                ResetColor();

        //                if (location[0] < patLength + patRow - 1)
        //                {
        //                    location[0]++;
        //                }

        //                // conditional to stop error of trying to write out of bounds of array
        //                if (j < str[0].Length)
        //                {
        //                    Write(str[i][j]);
        //                }
        //            }
        //            else
        //            {
        //                Write(str[i][j]);
        //            }
        //            //Write(str[i][j]);

        //        }
        //        Write("\n");
        //    }
        //}

        //public static int[] FindPattern(string[] str, string[] pat, int strWidth, int strHeight, int patWidth,
        //    int patHeight)
        //{
        //    int[] location = { -1, -1 };

        //    // flag for if patter is found
        //    bool foundPattern = false;

        //    // outer loop through 'rows' of main array
        //    for (int i = 0; i < strHeight; i++)
        //    {
        //        // inner loop for chars of each row
        //        for (int j = 0; j < strWidth; j++)
        //        {

        //            // look for matching single char first
        //            // only finds the first instance (foundPattern stops any others)
        //            // doesn't check if the found char is too close to the end of the string
        //            if (str[i][j] == pat[0][0] && !foundPattern && (j < strWidth - patWidth))
        //            {
        //                // marker vars
        //                int l = 0;
        //                int k = i;

        //                // set a substring starting at row[k] and ending at length of pattern
        //                string tempStr = str[k].Substring(j, patWidth + 1);


        //                // while the chars in the substring and the current pattern row match
        //                while (tempStr == pat[l])
        //                {
        //                    // check if 'l' marker equals the number of 'rows' in the pattern
        //                    // l marker will equal this only if the while condition was true enough times
        //                    if (l == patHeight)
        //                    {
        //                        foundPattern = true;
        //                        location[0] = i;
        //                        location[1] = j;
        //                        break;
        //                    }

        //                    // increment the markers
        //                    l++;
        //                    k++;

        //                    // update the substring to compare pattern to
        //                    tempStr = str[k].Substring(j, patWidth + 1);
        //                }


        //            }
        //        }
        //    }


        //    return location;
        //}

        public static void Main(string[] args)
        {
            string[] str = System.IO.File.ReadAllLines(@"C:\Users\dayar\Desktop\pic.txt");
            

            WriteLine("Input a lowercase string to find: ");
            string input = ReadLine();
            string[] pat = { input };
            
            var newSet = new StringAndPattern(str, pat);
            newSet.DrawPictureAndPattern();
            int[] location = newSet.FindPattern();
            
            if (location[0] == -1 && location[1] == -1)
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

