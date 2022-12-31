using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TitleDraw.WindowUtilities;

namespace TitleDraw
{
    class TitleDraw
    {
        private string _titleToDraw;
        private int _titleWidth;
        private int _titleStartColumn;
        private int _titleStartRow = 1;
        
        public void DrawTitle()
        {
            SetCursorPosition(_titleStartRow, _titleStartColumn);
            Console.WriteLine(_titleToDraw);
        }

        
        // find the width of the window and determine the center, then set the cursor
        // to start at the column that would put the title in the exact center of the 
        // window
        public void SetTitle(string title)
        {
            _titleToDraw = title;
            _titleWidth = _titleToDraw.Length;
            var temp = GetConsoleWindowWidth() - _titleWidth;
            temp /= 2;
            _titleStartColumn = temp;
        }
    }
}
