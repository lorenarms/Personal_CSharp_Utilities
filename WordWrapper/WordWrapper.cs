using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWrapper
{
    class WordWrapper
    {
        public static void Wrap(string paragraphToWrap)
        {
            //variables
            int windowWidth = Console.WindowWidth - 1;
            /*  get width of the window
                must subtract '1' bc a line that goes to the very edge of the window
                makes a blank line below */

            paragraphToWrap += " ";                                         //append 1 space to end of text
            int totalLines = paragraphToWrap.Length / windowWidth;          //find total lines that text takes up
            int remainderLines = paragraphToWrap.Length % windowWidth;      //find remainder of text that doesn't go to end of window
            if (totalLines <= 0)                                            
            {
                Console.WriteLine(paragraphToWrap);                         //text doesn't need to be wrapped
            }
            else
            {
                while (totalLines > 0)                                      //loop while lines of text still remain
                {
                    int j;                                                  //initialize 'j' to be used outside of loop
                    for (j = windowWidth; !paragraphToWrap[j].Equals(' '); j--)     
                                                                            //loop to find best place to split line
                    { }
                    var line = paragraphToWrap.Substring(0, j);   
                                                                            
                    
                    paragraphToWrap = paragraphToWrap.Substring(j + 1);     //text is reset to remove previous line, start at j+1 to remove space in front 
                    Console.WriteLine(line);                                //print the extracted line
                    totalLines--;                                           //let the loop know we've removed one line
                }
                if (remainderLines > 0)
                {
                    Console.WriteLine(paragraphToWrap);
                }

            }
        }
    }
}
