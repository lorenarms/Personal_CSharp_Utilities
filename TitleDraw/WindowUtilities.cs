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
        public static void SetConsoleWindowSize(int width, int height)
        {
            WindowWidth = width;
            WindowHeight = height;
        }

        public static int GetConsoleWindowWidth()
        {
            return WindowWidth;
        }

        public static void SetConsoleTextColor(ConsoleColor foreground, ConsoleColor background)
        {
            ForegroundColor = foreground;
            BackgroundColor = background;
        }

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
