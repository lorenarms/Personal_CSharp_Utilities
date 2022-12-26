//============================================================================
// Name        : PATTERN FINDER
// Author      : Lorenzo Dominguez
// Version     : 1.2.0
// Copyright   : Copyright © November 7, 2021
// Description : Find a multi-line pattern in a larger multi-line string array
//============================================================================



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PatternFinder
{
    class StringAndPattern
    {
        private readonly string[] _pictureAsString;
        private readonly string[] _patternAsString;
        private readonly int _heightOfPictureAsString;
        private readonly int _widthOfPictureAsString;
        private readonly int _heightOfPatternAsString;
        private readonly int _widthOfPatternAsString;

        private readonly int[] _locationOfPatternInPicture;

        public StringAndPattern(string[] pictureAsString, string[] patternAsString)
        {
            this._pictureAsString = pictureAsString;
            this._patternAsString = patternAsString;

            _heightOfPictureAsString = pictureAsString.Length;
            _widthOfPictureAsString = pictureAsString[0].Length;
            _heightOfPatternAsString = patternAsString.Length - 1;
            _widthOfPatternAsString = patternAsString[0].Length - 1;

            _locationOfPatternInPicture = new[] {-1, -1};

        }

        public int[] FindPattern()
        {
            
            // flag for if patter is found
            bool patternWasFound = false;

            // outer loop through 'rows' of main array
            for (int i = 0; i < _heightOfPictureAsString; i++)
            {
                // inner loop for chars of each row
                for (int j = 0; j < _widthOfPictureAsString; j++)
                {

                    // look for matching single char first
                    // only finds the first instance (foundPattern stops any others)
                    // doesn't check if the found char is too close to the end of the string
                    if (_pictureAsString[i][j] == _patternAsString[0][0] && !patternWasFound && (j < _widthOfPictureAsString - _widthOfPatternAsString))
                    {
                        // marker vars
                        int l = 0;
                        int k = i;

                        // set a substring starting at row[k] and ending at length of pattern
                        string tempStr = _pictureAsString[k].Substring(j, _widthOfPatternAsString + 1);
                        

                        // while the chars in the substring and the current pattern row match
                        while (tempStr == _patternAsString[l])
                        {
                            // check if 'l' marker equals the number of 'rows' in the pattern
                            // l marker will equal this only if the while condition was true enough times
                            if (l == _heightOfPatternAsString)
                            {
                                
                                patternWasFound = true;
                                _locationOfPatternInPicture[0] = i;
                                _locationOfPatternInPicture[1] = j;
                                break;
                            }

                            // increment the markers
                            l++;
                            k++;

                            // update the substring to compare pattern to
                            tempStr = _pictureAsString[k].Substring(j, _widthOfPatternAsString + 1);
                        }
                    }
                }
            }
            
            return _locationOfPatternInPicture;
        }

        public void DrawPictureAndPattern()
        {
            WriteLine("PICTURE:");
            for (int i = 0; i < _pictureAsString.Length; i++)
            {
                for (int j = 0; j < _pictureAsString[0].Length; j++)
                {
                    Write(_pictureAsString[i][j]);
                }
                Write("\n");
            }

            WriteLine("\nPATTERN TO FIND:");
            for (int i = 0; i < _patternAsString.Length; i++)
            {
                for (int j = 0; j < _patternAsString[0].Length; j++)
                {
                    Write(_patternAsString[i][j]);
                }
                Write("\n");
            }
            WriteLine();
        }

        public void DrawPatternInPicture()
        {
            int patLength = _patternAsString.Length;
            int patHeight = _patternAsString[0].Length;
            int patRow = _locationOfPatternInPicture[0];

            WriteLine("LOCATION:");
            for (int i = 0; i < _pictureAsString.Length; i++)
            {
                for (int j = 0; j < _pictureAsString[0].Length; j++)
                {
                    if (i == _locationOfPatternInPicture[0] && j == _locationOfPatternInPicture[1])
                    {
                        ForegroundColor = ConsoleColor.Red;
                        int k = 0;
                        while (k < _patternAsString[0].Length)
                        {
                            Write(_pictureAsString[i][j]);
                            k++;
                            j++;
                        }

                        ResetColor();

                        if (_locationOfPatternInPicture[0] < patLength + patRow - 1)
                        {
                            _locationOfPatternInPicture[0]++;
                        }

                        // conditional to stop error of trying to write out of bounds of array
                        if (j < _pictureAsString[0].Length)
                        {
                            Write(_pictureAsString[i][j]);
                        }
                    }
                    else
                    {
                        Write(_pictureAsString[i][j]);
                    }
                   

                }
                Write("\n");
            }
        }
    }
}
