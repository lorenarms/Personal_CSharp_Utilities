using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using System;

namespace ImportDataCSV
{
    public class Customer
    {
        [Name("id")] public int IdNumber { get; set; }
        [Name("fName")] public string FirstName { get; set; }
        [Name("lName")] public string LastName { get; set; }


        public void PrintAll(List<Customer> records)
        {
            Console.WriteLine("Items in list: " + records.Count);
            foreach (var s in records)
            {
                Console.WriteLine("Name: " + s.FirstName + " " + s.LastName + " ID: " + s.IdNumber);
            }
        }

    }
}

  