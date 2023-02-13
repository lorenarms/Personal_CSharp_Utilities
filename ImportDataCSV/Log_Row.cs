using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace ImportDataCSV
{
    public class Log_Row
    {
        [Name("Day")] public string Day { get; set; }
        [Name("Room Time")] public string RoomTime { get; set; }
        [Name("Puzzle")] public String Puzzle { get; set; }
        [Name("Hint Used")] public string Hint { get; set; }
        [Name("Text (If Custom)")] public string Text {get; set; }
        [Name("Glitch/Bypass Nedded")] public string Glitch { get; set; }


    }
    
}
