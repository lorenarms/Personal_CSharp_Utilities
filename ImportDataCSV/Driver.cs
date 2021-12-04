//
// Use 'Install-Package CsvHelper -Version 27.2.1' in Package Manager Console
// make sure to target the correct project!
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImportDataCSV;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Runtime.Versioning;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;



namespace ImportDataCSV
{
    class Driver
    {
        static void Main(string[] args)

        {
            List<Customer> records;
            using (var streamReader = new StreamReader(@"C:\Users\dayar\Downloads\sheet1.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    records = csvReader.GetRecords<Customer>().ToList();

                    
                }
            }

            Console.WriteLine("Items in list: " + records.Count);
            foreach (var s in records)
            {
                Console.WriteLine("Name: " + s.FirstName + " " + s.LastName + " ID: " + s.IDNumber);
            }

            Console.ReadKey();

        }
    }

    public class Customer
    {
        [Name("id")]
        public int IDNumber { get; set; }
        [Name("fName")]
        public string FirstName { get; set; }
        [Name("lName")]
        public string LastName { get; set; }
        
    }
}
