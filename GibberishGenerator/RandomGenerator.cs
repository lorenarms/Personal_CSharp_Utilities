using System.Text;

namespace GibberishGenerator;

public class RandomGenerator
{
    // Instantiate random number generator.  
    // It is better to keep a single Random instance 
    // and keep using Next on the same instance.  
    private readonly Random _random = new Random();
    


    public string RandomNumber(int size)
    {
        
        var builder = new StringBuilder(size);   
        for (var i = 0; i < size; i++)
        {
            builder.Append(_random.Next(0, 9));
        }

        return builder.ToString();
    }

    public string RandomNumber(int size, int lines)
    {

        var builder = new StringBuilder(size);
        for (var j = 0; j < lines; j++)
        {
            for (var i = 0; i < size; i++)
            {
                builder.Append(_random.Next(0, 9));
            }

            if (lines == 1)
            {
                continue;
            }

            builder.Append("\n");
        }
        

        return builder.ToString();
    }

    // Generates a random string with a given size.    
    public string RandomString(int size, int lines, bool lowerCase = true)
    {
        var builder = new StringBuilder(size);

        // Unicode/ASCII Letters are divided into two blocks
        // (Letters 65–90 / 97–122):   
        // The first group containing the uppercase letters and
        // the second group containing the lowercase.  

        // char is a single Unicode character  
        char offset = lowerCase ? 'a' : 'A';
        const int lettersOffset = 26; // A...Z or a..z: length = 26  

        for (var j = 0; j < lines; j++)
        {
            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            if (lines == 1)
            {
                continue;
            }

            builder.Append("\n");
        }

        

        return lowerCase ? builder.ToString().ToLower() : builder.ToString();
    }
}