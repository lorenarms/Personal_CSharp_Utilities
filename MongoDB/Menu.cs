//============================================================================
// Name        : INTERACTIVE MENU BUILDER
// Author      : Lawrence Artl
// Version     : 1.2.0
// Copyright   : Copyright © October 7, 2021
// Description : Build an interactive menu for your C# program
// Website     : http://artllj.com
// Github      : https://github.com/lorenarms
//============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MongoDB
{
    class Menu
    {
        //private string _prompt = "";
        private readonly List<string> _menuList;
        private int _currentSelection;
        private int _drawMenuColumnPos;
        private readonly int _drawMenuRowPos;
        private int _menuMaximumWidth;

        public Menu(List<string> menuList, int row, int col)
        {
            //_prompt = prompt;
            _menuList = menuList;
            _currentSelection = 0;
            _drawMenuRowPos = row;
            _drawMenuColumnPos = col;

        }

        public int GetMaximumWidth()
        {
            return _menuMaximumWidth;
        }

        public void CenterMenuToConsole()
        {
            _drawMenuColumnPos = GetConsoleWindowWidth() / 2 - (_menuMaximumWidth / 2);
        }

        // Modify the menu to be left justified
        public void ModifyMenuLeftJustified()
        {
            int maximumWidth = 0;
            string space = "";

            foreach (var t in _menuList)
            {
                if (t.Length > maximumWidth)
                {
                    maximumWidth = t.Length;
                }
            }

            maximumWidth += 6;

            for (int i = 0; i < _menuList.Count; i++)
            {
                int spacesToAdd = maximumWidth - _menuList[i].Length;
                for (int j = 0; j < spacesToAdd; j++)
                {
                    space += " ";
                }
                _menuList[i] = _menuList[i] + space;
                space = "";
            }

            _menuMaximumWidth = maximumWidth;
        }

        // Modify the menu to be centered in its column
        public void ModifyMenuCentered()
        {
            int maximumWidth = 0;
            string space = "";

            foreach (var t in _menuList)
            {
                if (t.Length > maximumWidth)
                {
                    maximumWidth = t.Length;
                }
            }

            maximumWidth += 6;     // make widest measurement wider by 10
                                    // modify this number to make menu wider / narrower

            for (int i = 0; i < _menuList.Count; i++)
            {
                if (_menuList[i].Length % 2 != 0)
                {
                    _menuList[i] += " ";     // make all menu items even num char wide
                }

                var minimumWidth = maximumWidth - _menuList[i].Length;
                minimumWidth /= 2;
                for (int j = 0; j < minimumWidth; j++)
                {
                    space += " ";
                }

                _menuList[i] = space + _menuList[i] + space;      // add spaces on either side of each    
                space = "";                             // menu item
            }

            for (int i = 0; i < _menuList.Count; i++)
            {
                if (_menuList[i].Length < maximumWidth)      // if any menu item isn't as wide as
                                                        // the max width, add 1 space
                {
                    _menuList[i] += " ";
                }
            }

            _menuMaximumWidth = maximumWidth;           // set the max width for use later

        }

        // UTILITIES FOR THE CLASS
        public void SetConsoleWindowSize(int width, int height)
        {
            WindowWidth = width;
            WindowHeight = height;
        }

        public static int GetConsoleWindowWidth()
        {
            return WindowWidth;
        }


        public void SetConsoleTextColor(ConsoleColor foreground, ConsoleColor background)
        {
            ForegroundColor = foreground;
            BackgroundColor = background;
        }

        public void ResetCursorVisible()
        {
            CursorVisible = CursorVisible != true;
        }

        public void SetCursorPosition(int row, int column)
        {
            if (row > 0 && row < WindowHeight)
            {
                CursorTop = row;
            }

            if (column > 0 && column < WindowWidth)
            {
                CursorLeft = column;
            }
        }

        

        // Engine to run the menu and relevant methods
        public int RunMenu()
        {
            bool run = true;
            DrawMenu();
            while (run)
            {
                var keyPressedCode = CheckKeyPress();
                if (keyPressedCode == 10)   // up arrow
                {
                    _currentSelection--;
                    if (_currentSelection < 0)
                    {
                        _currentSelection = _menuList.Count - 1;
                    }

                }
                else if (keyPressedCode == 11)  // down arrow
                {
                    _currentSelection++;
                    if (_currentSelection > _menuList.Count - 1)
                    {
                        _currentSelection = 0;
                    }

                }
                else if (keyPressedCode == 12)  // enter
                {
                    run = false;
                }  
                else if (keyPressedCode == 13)  // q for quit
                {
                    return -1;

                }
                // add more key options here with more else if statements
                // just make sure to add the case to your main switch statement

                DrawMenu();
            }

            return _currentSelection;
        }

        private void DrawMenu()
        {
            string leftPointer = "    ";
            string rightPointer = "    ";
            for (int i = 0; i < _menuList.Count; i++)
            {
                SetCursorPosition(_drawMenuRowPos + i, _drawMenuColumnPos);
                SetConsoleTextColor(ConsoleColor.White, ConsoleColor.Black);
                if (i == _currentSelection)
                {
                    SetConsoleTextColor(ConsoleColor.Black, ConsoleColor.White);
                    leftPointer = "  ► ";
                    //rightPointer = " ◄  ";

                }
                // comment out next line for standard menu, no pointers
                //Console.WriteLine(_menuList[i]);

                // comment out next line for menu with pointer
                Console.WriteLine(leftPointer + _menuList[i] + rightPointer);
                leftPointer = "    ";
                rightPointer = "    ";
                ResetColor();
            }
        }

        private int CheckKeyPress()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            do
            { 
                ConsoleKey keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    return 10;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    return 11;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    return 12;
                }
                else if (keyPressed == ConsoleKey.Q)
                {
                    return 13;
                }
                else
                {
                    return 0;
                }

            } while (true); 
        }
    }
}
