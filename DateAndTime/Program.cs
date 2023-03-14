using DateTime = System.DateTime;

namespace DateAndTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;

            Console.WriteLine(now.Date.ToString());
            Console.WriteLine(now.TimeOfDay.ToString());
            Console.WriteLine(now.ToString());
            string date = now.ToString("MM/dd/yyyy");
            Console.WriteLine(date);



            Console.WriteLine(now.DayOfWeek);
            Console.WriteLine($@"{now.Day:00}/{now:MMMM}/{now.Year:0000}");
            Console.WriteLine($@"{now.Hour:00}:{now.Minute:00}:{now.Second:00}");

            Console.ReadKey();



        }
    }
}