//*******************************************************************
//
// CSV IMPORTER and SORTER
//
// Author: Lawrence Artl III
//
// Purpose: import a csv file and sort, save as a new file
// 
//*******************************************************************
//
// Use 'Install-Package CsvHelper -Version 27.2.1' in Package Manager Console
// make sure to target the correct project!
//
//*******************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.IO;
using System.Globalization;


namespace ImportDataCSV
{
    class Driver
    {
        static void Main(string[] args)
        {
            var c = new Log_Row();
            var title = string.Empty;
            List<Log_Row> records;

            // 'using' keyword allows disposal of object after it goes out of scope, freeing resources
            using (var streamReader = new StreamReader(@".\log.csv"))   // './file.csv' only works on files in 'debug' folder with .exe of program
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    streamReader.ReadLine();
                    title = streamReader.ReadLine();
                    records = csvReader.GetRecords<Log_Row>().ToList();
                }
            }
            //c.PrintAll(records);

            var sh = new SortingHat();

            //records.Sort(sh);

            int count = 1;
            foreach (var record in records)
            {
                Console.WriteLine($@"{count}: {record.Day} {record.RoomTime} : {record.Puzzle} Text: {record.Text}");
                count++;
            }
            

            Console.WriteLine();
            //c.PrintAll(records);

            using (var streamWriter = new StreamWriter(@"C:\Users\Lawrence\Git Repos\Personal_CSharp_Utilities\ImportDataCSV\sorted_sheet1.csv"))
            {
                foreach (var r in records)
                {
                    //var first = r.FirstName;
                    //var second = r.LastName;
                    //var third = r.IdNumber;
                    //var line = string.Format("{0},{1},{2}", first, second, third);
                    //streamWriter.WriteLine(line);
                    streamWriter.Flush();
                }

            }       


            Console.ReadKey();
        }

        
    }
}
