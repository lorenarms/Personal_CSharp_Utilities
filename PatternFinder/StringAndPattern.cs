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
        private string[] _str;
        private string[] _pat;
        private int _strHeight;
        private int _strWidth;
        private int _patHeight;
        private int _patWidth;

        private int[] Location;

        public StringAndPattern(string[] str, string[] pat)
        {
            this._str = str;
            this._pat = pat;

            _strHeight = str.Length;
            _strWidth = str[0].Length;
            _patHeight = pat.Length - 1;
            _patWidth = pat[0].Length - 1;

            Location = new[] {-1, -1};

        }

        public int[] FindPattern()
        {
            
            // flag for if patter is found
            bool foundPattern = false;

            // outer loop through 'rows' of main array
            for (int i = 0; i < _strHeight; i++)
            {
                // inner loop for chars of each row
                for (int j = 0; j < _strWidth; j++)
                {

                    // look for matching single char first
                    // only finds the first instance (foundPattern stops any others)
                    // doesn't check if the found char is too close to the end of the string
                    if (_str[i][j] == _pat[0][0] && !foundPattern && (j < _strWidth - _patWidth))
                    {
                        // marker vars
                        int l = 0;
                        int k = i;

                        // set a substring starting at row[k] and ending at length of pattern
                        string tempStr = _str[k].Substring(j, _patWidth + 1);
                        

                        // while the chars in the substring and the current pattern row match
                        while (tempStr == _pat[l])
                        {
                            // check if 'l' marker equals the number of 'rows' in the pattern
                            // l marker will equal this only if the while condition was true enough times
                            if (l == _patHeight)
                            {
                                
                                foundPattern = true;
                                Location[0] = i;
                                Location[1] = j;
                                break;
                            }

                            // increment the markers
                            l++;
                            k++;

                            // update the substring to compare pattern to
                            tempStr = _str[k].Substring(j, _patWidth + 1);
                        }
                    }
                }
            }
            
            return Location;
        }

        public void DrawPictureAndPattern()
        {
            WriteLine("PICTURE:");
            for (int i = 0; i < _str.Length; i++)
            {
                for (int j = 0; j < _str[0].Length; j++)
                {
                    Write(_str[i][j]);
                }
                Write("\n");
            }

            WriteLine("\nPATTERN TO FIND:");
            for (int i = 0; i < _pat.Length; i++)
            {
                for (int j = 0; j < _pat[0].Length; j++)
                {
                    Write(_pat[i][j]);
                }
                Write("\n");
            }
            WriteLine();
        }

        public void DrawPatternInPicture()
        {
            int patLength = _pat.Length;
            int patHeight = _pat[0].Length;
            int patRow = Location[0];

            WriteLine("LOCATION:");
            for (int i = 0; i < _str.Length; i++)
            {
                for (int j = 0; j < _str[0].Length; j++)
                {
                    if (i == Location[0] && j == Location[1])
                    {
                        ForegroundColor = ConsoleColor.Red;
                        //Write(str[i][j]);
                        int k = 0;
                        while (k < _pat[0].Length)
                        {
                            Write(_str[i][j]);
                            k++;
                            j++;
                        }

                        ResetColor();

                        if (Location[0] < patLength + patRow - 1)
                        {
                            Location[0]++;
                        }

                        // conditional to stop error of trying to write out of bounds of array
                        if (j < _str[0].Length)
                        {
                            Write(_str[i][j]);
                        }
                    }
                    else
                    {
                        Write(_str[i][j]);
                    }
                    //Write(str[i][j]);

                }
                Write("\n");
            }
        }
    }
}
