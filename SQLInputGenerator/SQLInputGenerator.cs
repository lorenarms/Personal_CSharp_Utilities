using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter
{
    public class SQLInputGenerator
    {
        private CurrentTime _ct = new CurrentTime(DateTime.Now);

        private static readonly string[] _rooms = new[]
        {
            "Wizard", "Casino", "Haunted", "Zombie", "Atlantis", "Time Machine"
        };
        private static readonly string[] _day = new[]
        {
            "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
        };
        private static readonly string[] _month = new[]
        {
            "January", "February", "March", "April", "May", "June"
        };
        private static readonly string[] _year = new[]
        {
            "2021", "2022", "2023"        
        };
        private static readonly string[] _puzzle = new[]
        {
            "Door", "Bench", "Kiosk", "Floor", "Wall", "Table", "Puzzle"
        };
        private static readonly string[] _text_used = new[]
        {
            "None", "Open the door", "Finish the puzzle", "Turn on the light", "Rotate the knob"
        };
        private static readonly string[] _glitch = new[]
        {
            "None", "Did not open", "Did not close", "Did not finish", "Did not activate"
        };
        private static readonly string[] _bypass = new[]
        {
            "None", "Finished manually", "Special message", "Sent custom hint", "Closed room"
        };
        private List<string> _input = new List<string>();

        public List<string> GetInput()
        {
            return _input;
        }

        public void GenerateInput(int i)
        {
            for(int j = 0; j < i; j++)
            {
                
                StringBuilder sb = new StringBuilder();
                sb.Append($@"INSERT INTO `log` VALUES (DEFAULT,");
                sb.Append($@"'{_rooms[Random.Shared.Next(_rooms.Length)]}',");
                sb.Append($@"'{_ct.GetDate()}',");
                sb.Append($@"'{_ct.GetTime()}',");
                sb.Append($@"'{_puzzle[Random.Shared.Next(_puzzle.Length)]}',");
                sb.Append($@"'{Random.Shared.Next(1, 15)}',");
                sb.Append($@"'{_text_used[Random.Shared.Next(_text_used.Length)]}',");
                sb.Append($@"'{_glitch[Random.Shared.Next(_glitch.Length)]}',");
                sb.Append($@"'{_bypass[Random.Shared.Next(_bypass.Length)]}');{Environment.NewLine}");

                var input = sb.ToString();

                _input.Add(input);
                
            }

        }

        public void GenerateInsertsForHintsDB()
        {
            
	        for (int j = 1; j <= 94; j++)
	        {

		        StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO [dbo].[Hint] ([Order], [PuzzleId], [Text]) VALUES (0, " + j + " , N'\"\"NO HINT / CUSTOM TEXT\"\"')");
                sb.Append($@"{Environment.NewLine}");
		        
                var input = sb.ToString();

                _input.Add(input);
	        }
        }


    }

    public class CurrentTime
    {
        public CurrentTime(DateTime now)
        {
	        Date = now.ToString("yyyy-MM-dd");
	        Time = now.ToString("HH:mm:ss");
        }

        public DateTime Now;
        public string Date{ get; set; }
        public string Time { get; set; }

        public string GetTime()
        {
            return 
	            $@"{Now.AddHours(Random.Shared.Next(0, 24)).Hour:00}:{Now.AddMinutes(Random.Shared.Next(0, 59)).Minute:00}:{Now.AddSeconds(Random.Shared.Next(0, 59)).Second:00}";
        }

        public string GetDate()
        {
	        return
		        $@"{Now.AddYears(Random.Shared.Next(2020, 2023)).Year:0000}-{Now.AddMonths(Random.Shared.Next(0, 11)).Month:00}-{Now.AddDays(Random.Shared.Next(0, 30)).Day:00}";
        }

    }
}
