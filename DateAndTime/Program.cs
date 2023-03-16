using DateTime = System.DateTime;

namespace DateAndTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;

            // day of the week's name
            Console.WriteLine(now.DayOfWeek.ToString()); 

            // 15/March/2023
            Console.WriteLine($@"{now.Day:00}/{now:MMMM}/{now.Year:0000}");
            
            // 17:59:02
            Console.WriteLine($@"{now.Hour:00}:{now.Minute:00}:{now.Second:00}");

            // Wednesday, March 15, 2023
            Console.WriteLine($@"{now.DayOfWeek}, {now:MMMM} {now.Day:00}, {now.Year:0000}");

            // 3/15/2023 12:00:00 AM
            Console.WriteLine(now.Date);
 
            // 17:59:02.7218195
            Console.WriteLine(now.TimeOfDay);

            // 3/15/2023 5:59:02 PM
            Console.WriteLine(now.ToString());

            // 2023-03-15
            string date = now.ToString("yyyy-MM-dd");
            Console.WriteLine(date);

            // 17:59:02
            string time = now.ToString("HH:mm:ss");
            Console.WriteLine(time);

            // Most user-friendly / readable
            Console.WriteLine(now.ToString("D"));
            Console.WriteLine(now.ToString("h:mm tt"));


            Console.ReadKey();



        }
    }
}