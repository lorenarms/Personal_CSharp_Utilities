using System;

namespace passwordcalc.engines

{
	public class Paragraph
	{
		//public string Phrase;

		public static void Wrap(string Phrase)
		{
            //Console.WriteLine("\nUSING CLASS OUTSIDE PROGRAM\n");

            Console.WriteLine();
            //variables
            int window_width = Console.WindowWidth - 1;
            /*  get width of the window
                must subtract '1' bc a line that goes to the very edge of the window
                makes a blank line below */
            //string origtext = Console.ReadLine();                   //get input from user
            string text = Phrase + " ";                             //append 1 space to end of text
            string line = " ";                                      //create string called 'line' for storage of substrings
            int string_length = text.Length;                        //get length of full text input
            int total_lines = string_length / window_width;         //find total lines that text takes up
            int remainder_lines = string_length % window_width;     //find remainder of text that doesn't go to end of window
            int j;                                                  //initialize 'j' to be used outside of loop
            if (total_lines <= 0)           //don't do anything special, just reprint the text later
            { }
            else
            {
                while (total_lines > 0)     //loop while lines of text still remain
                {
                    for (j = window_width; !text[j].Equals(' '); j--)      //loop to find best place to split line
                    { }
                    line = text.Substring(0, j);        //line equals the substring from 0 to j
                    text = text.Substring(j + 1);       //text is reset to remove previous line, start at j+1 to remove space in front 
                    Console.WriteLine(line);            //print the extracted line
                    total_lines--;                      //let the loop know we've removed one line
                }
                if (remainder_lines > 0)
                {
                    Console.WriteLine(text);
                }
                else
                { }
            }
        }

	}
}
