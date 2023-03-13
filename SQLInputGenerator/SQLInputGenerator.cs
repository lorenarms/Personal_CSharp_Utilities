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

        public void GeneratInput(int start, int i)
        {
            for(int j = 0; j < i; j++)
            {
                
                StringBuilder sb = new StringBuilder();
                sb.Append($@"INSERT INTO `log` VALUES ({start},");
                sb.Append($@"'{_rooms[Random.Shared.Next(_rooms.Length)]}',");
                sb.Append($@"'{_day[Random.Shared.Next(_day.Length)]}',");
                sb.Append($@"'{Random.Shared.Next(1, 30)}',");
                sb.Append($@"'{_month[Random.Shared.Next(_month.Length)]}',");
                sb.Append($@"'{_year[Random.Shared.Next(_year.Length)]}',");
                sb.Append($@"'{_ct.GetTime()}',");
                sb.Append($@"'{_puzzle[Random.Shared.Next(_puzzle.Length)]}',");
                sb.Append($@"'{Random.Shared.Next(1, 15)}',");
                sb.Append($@"'{_text_used[Random.Shared.Next(_text_used.Length)]}',");
                sb.Append($@"'{_glitch[Random.Shared.Next(_glitch.Length)]}',");
                sb.Append($@"'{_bypass[Random.Shared.Next(_bypass.Length)]}');{Environment.NewLine}");

                var input = sb.ToString();

                _input.Add(input);

                start++;
            }

        }


    }

    public class CurrentTime
    {
        public CurrentTime(DateTime now)
        {
            Day = now.Day.ToString();
            Month = now.ToString("MMMM");
            Year = now.Year.ToString("0000");
            DayOfWeek = now.DayOfWeek.ToString();
            Time = $@"{now.Hour:00}:{now.Minute:00}:{now.Second:00}";
            _now= now;
        }

        public DateTime _now;
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string DayOfWeek { get; set; }
        public string Time { get; set; }

        public string GetTime()
        {
            return $@"{_now.AddHours(Random.Shared.Next(0, 24)).Hour:00}:{_now.AddMinutes(Random.Shared.Next(0, 59)).Minute:00}:{_now.AddSeconds(Random.Shared.Next(0, 59)).Second:00}";
        }

    }
}
