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
        
        public void DrawTitle()
        {
            SetCursorPosition(1, _titleStartColumn);
            Console.WriteLine(_titleToDraw);
        }

        

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
