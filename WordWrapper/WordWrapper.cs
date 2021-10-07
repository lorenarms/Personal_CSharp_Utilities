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

            // append a space to the text
            // find total lines of text
            // find what text doesn't go to the end of the windwow
            paragraphToWrap += " ";                                         
            int totalLines = paragraphToWrap.Length / windowWidth;          
            int remainderLines = paragraphToWrap.Length % windowWidth;

            // text doesn't need to be wrapped
            if (totalLines <= 0)                                            
            {
                Console.WriteLine(paragraphToWrap);                         
            }
            else
            {
                //loop while lines of text still remain
                while (totalLines > 0)                                      
                {

                    //initialize 'j' to be used outside of loop
                    int j;

                    //loop to find best place to split line
                    for (j = windowWidth; !paragraphToWrap[j].Equals(' '); j--)     
                                                                            
                    { }
                    var line = paragraphToWrap.Substring(0, j);   
                                                                            
                    // remove the top line of text
                    // print the line
                    // decrement the number of lines
                    paragraphToWrap = paragraphToWrap.Substring(j + 1);     
                    Console.WriteLine(line);                                
                    totalLines--;                                           
                }

                // this prints the very last line that doesn't go to window edge
                if (remainderLines > 0)
                {
                    Console.WriteLine(paragraphToWrap);
                }

            }
        }
    }
}
