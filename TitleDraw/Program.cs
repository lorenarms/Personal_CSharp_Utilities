//============================================================================
// Name        : TITLE DRAW
// Author      : Lawrence Artl III
// Version     : 1.0.0
// Copyright   : Copyright © 2021
// Description : Write a line centered in the console
// Website     : http://artllj.com
// Github      : https://github.com/lorenarms
//============================================================================


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

            Write("Type a title to center in the console: ");
            string mainTitle = Console.ReadLine();

            Clear();

            newTitle.SetTitle(mainTitle);

            newTitle.DrawTitle();
            
            ReadKey();
            
        }
    }
}
