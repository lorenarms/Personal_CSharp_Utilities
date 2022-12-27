namespace GibberishGenerator;

class WriteAllLines
{
    public async Task WriteStringsToFile(List<string> input)
    {
           
        // writes a file to the current program directory, wherever that is
        await File.WriteAllLinesAsync(@".\RandomTextWritten.txt", input);
            
    }

    public async Task WriteStringsToFile(string input)
    {

        // writes a file to the current program directory, wherever that is
        await File.WriteAllTextAsync(@".\RandomTextWritten.txt", input);

    }
}