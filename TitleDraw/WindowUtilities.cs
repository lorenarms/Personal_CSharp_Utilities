using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TitleDraw
{
    class WindowUtilities
    {
        // change window size
        public static void SetConsoleWindowSize(int width, int height)
        {
            WindowWidth = width;
            WindowHeight = height;
        }

        public static int GetConsoleWindowWidth()
        {
            return WindowWidth;
        }

        // change title color and background
        public static void SetConsoleTextColor(ConsoleColor foreground, ConsoleColor background)
        {
            ForegroundColor = foreground;
            BackgroundColor = background;
        }

        // remove blinking cursor
        public static void ResetCursorVisible()
        {
            CursorVisible = CursorVisible != true;
        }

        public static void SetCursorPosition(int row, int column)
        {
            if (row >= 0 && row <= WindowHeight)
            {
                CursorTop = row;
            }

            if (column >= 0 && column <= WindowWidth)
            {
                CursorLeft = column;
            }
        }
    }
}
