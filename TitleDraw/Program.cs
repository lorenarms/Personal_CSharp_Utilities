using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TitleDraw
{
    class Program
    {
        public static void Main(string[] args)
        {
            var newTitle = new TitleDraw();

            newTitle.SetTitle("This is the Main Title");

            newTitle.DrawTitle();
            
            ReadKey();
            
        }
    }
}
